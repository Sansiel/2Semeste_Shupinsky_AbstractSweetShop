using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System;
using System.Web.Mvc;
using System.Windows.Forms;

namespace AbstractSweetShopWebView.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public FileResult SavePriceList()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\user\Documents\test.docx" };
            _service.SaveCandyPrice(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.docx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public FileResult SaveToExcel()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\user\Documents\test.xls" };
            _service.SaveStoreLoad(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.xls";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost]
        public FileResult SaveToPdf (ReportBindingModel model)
        {
            model.FileName = @"C:\Users\user\Documents\test.pdf";
            _service.SaveBuyerJobs(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult DesignerRequests()
        {
            return View();
        }
    }
}