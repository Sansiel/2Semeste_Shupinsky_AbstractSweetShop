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

        private readonly IExecutorService _serviceImplementer;

        public MainController(IMainService service, IExecutorService serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
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
                ExecutorViewModel exec = _serviceImplementer.GetFreeWorker();
                if (exec == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkExecutor(_service, _serviceImplementer, exec.Id, job.Id);
            }
        }
    }
}