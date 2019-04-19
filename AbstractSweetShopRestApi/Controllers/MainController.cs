using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace AbstractSweetShopRestApi.Controllers
{
        public class MainController : ApiController
        {
            private readonly IMainService _service;
            public MainController(IMainService service)
            {
                _service = service;
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
    }
}