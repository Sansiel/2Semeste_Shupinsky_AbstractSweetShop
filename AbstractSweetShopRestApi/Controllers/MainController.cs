using AbstractSweetShopRestApi.Services;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AbstractSweetShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        private readonly IExecutorService _serviceExecutorr;

        public MainController(IMainService service, IExecutorService serviceExecutor)
        {
            _service = service;
            _serviceExecutorr = serviceExecutor;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void CreateJob(JobBindingModel model)
        {
            _service.CreateJob(model);
        }
        [HttpPost]
        public void TakeJobInWork(JobBindingModel model)
        {
            _service.TakeJobInWork(model);
        }
        [HttpPost]
        public void FinishJob(JobBindingModel model)
        {
            _service.FinishJob(model);
        }
        [HttpPost]
        public void PayJob(JobBindingModel model)
        {
            _service.PayJob(model);
        }
        [HttpPost]
        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            _service.PutMaterialInStore(model);
        }
        [HttpPost]
        public void StartWork()
        {
            List<JobViewModel> jobs = _service.GetFreeJobs();
            foreach (var job in jobs)
            {
                ExecutorViewModel exec = _serviceExecutorr.GetFreeWorker();
                if (exec == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkExecutor(_service, _serviceExecutorr, exec.Id, job.Id);
            }
        }
        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}