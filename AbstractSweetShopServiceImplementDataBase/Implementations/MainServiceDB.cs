using AbstractSweetShopModel;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AbstractSweetShopServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private AbstractDbContext context;

        public MainServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void CreateJob(JobBindingModel model)
        {
            var job = new Job
            {
                BuyerId = model.BuyerId,
                CandyId = model.CandyId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = JobStatus.Принят
            };
            context.Jobs.Add(job);
            context.SaveChanges();
            var buyer = context.Buyers.FirstOrDefault(x => x.Id == model.BuyerId);
            SendEmail(buyer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} создан успешно", job.Id, job.DateCreate.ToShortDateString()));
        }

        public void FinishJob(JobBindingModel model)
        {
            Job element = context.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != JobStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = JobStatus.Готов;
            context.SaveChanges();
            SendEmail(element.Buyer.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
    }

        public List<JobViewModel> GetList()
        {
            List<JobViewModel> result = context.Jobs.Select(rec => new JobViewModel
            {
                Id = rec.Id,
                BuyerId = rec.BuyerId,
                CandyId = rec.CandyId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                        SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                        SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
                        SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                        SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                        SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                BuyerFIO = rec.Buyer.BuyerFIO,
                CandyName = rec.Candy.CandyName,
                ExecutorId = rec.Executor.Id,
                ExecutorName = rec.Executor.ExecutorFIO
            })
            .ToList();
            return result;
        }

        public List<JobViewModel> GetFreeOrders()
        {
            List<JobViewModel> result = context.Jobs
            .Where(x => x.Status == JobStatus.Принят || x.Status ==
            JobStatus.НедостаточноРесурсов)
            .Select(rec => new JobViewModel
            {
                Id = rec.Id
            })
            .ToList();
            return result;
        }

        public void PayJob(JobBindingModel model)
        {
            Job element = context.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != JobStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = JobStatus.Оплачен;
            context.SaveChanges();
            SendEmail(element.Buyer.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            StoreMaterial element = context.StoreMaterials.FirstOrDefault(rec => rec.StoreId == model.StoreId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StoreMaterials.Add(new StoreMaterial
                {
                    StoreId = model.StoreId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        public List<JobViewModel> GetFreeJobs()
        {
            List<JobViewModel> result = context.Jobs
            .Where(x => x.Status == JobStatus.Принят || x.Status == JobStatus.НедостаточноРесурсов)
            .Select(rec => new JobViewModel
            {
                Id = rec.Id
            })
            .ToList();
            return result;
        }

        public void TakeJobInWork(JobBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                Job element = context.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
                try
                {
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != JobStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var CandyMaterials = context.CandyMaterials.Where(rec => rec.CandyId == element.CandyId);
                    // списываем
                    foreach (var CandyMaterial in CandyMaterials)
                    {
                        int countOnStores = CandyMaterial.Count * element.Count;
                        var StoreMaterials = context.StoreMaterials.Where(rec => rec.MaterialId == CandyMaterial.MaterialId);
                        foreach (var StoreMaterial in StoreMaterials)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (StoreMaterial.Count >= countOnStores)
                            {
                                StoreMaterial.Count -= countOnStores;
                                countOnStores = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStores -= StoreMaterial.Count;
                                StoreMaterial.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStores > 0)
                        {
                            throw new Exception("Не достаточно компонента " + CandyMaterial.Material.MaterialName + " требуется " + CandyMaterial.Count + ", не хватает " + countOnStores);
                        }
                    }
                    //element.Executor = context.Executors.First(rec => element.ExecutorId == element.ExecutorId);
                    element.ExecutorId = model.ExecutorId;
                    element.DateImplement = DateTime.Now;
                    element.Status = JobStatus.Выполняется;
                    context.SaveChanges();
                    SendEmail(element.Buyer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    element.Status = JobStatus.НедостаточноРесурсов;
                    context.SaveChanges();
                    transaction.Commit();
                    throw;
                }
            }
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
                MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
                NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}