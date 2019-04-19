using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace AbstractSweetShopRestApi.Controllers
{
    public class BuyerController : ApiController
    {
        private readonly IBuyerService _service;
        public BuyerController(IBuyerService service)
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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(BuyerBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(BuyerBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(BuyerBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
