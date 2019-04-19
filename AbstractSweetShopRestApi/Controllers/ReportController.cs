using System;
using System.Web.Http;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;

namespace DressSewingRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStoreLoad()
        {
            var list = _service.GetStoreLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetBuyerJobs(ReportBindingModel model)
        {
            var list = _service.GetBuyerJobs(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveCandyPrice(ReportBindingModel model)
        {
            _service.SaveCandyPrice(model);
        }
        [HttpPost]
        public void SaveStoreLoad(ReportBindingModel model)
        {
            _service.SaveStoreLoad(model);
        }
        [HttpPost]
        public void SaveBuyerJobs(ReportBindingModel model)
        {
            _service.SaveBuyerJobs(model);
        }
    }
}