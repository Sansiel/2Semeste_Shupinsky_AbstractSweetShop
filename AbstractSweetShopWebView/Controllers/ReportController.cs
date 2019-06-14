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
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SavePriceList()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _service.SaveCandyPrice(new ReportBindingModel
                {
                    FileName = sfd.FileName
                });
            }
            return RedirectToAction("Index", "Order");
        }

        public ActionResult SaveToExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _service.SaveStoreLoad(new ReportBindingModel
                {
                    FileName = sfd.FileName
                });
            }
            return RedirectToAction("Index", "Order");
        }

        public ActionResult SaveToPdf()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _service.SaveBuyerJobs(new ReportBindingModel
                {
                    FileName = sfd.FileName,
                    DateFrom = new DateTime(2018, 1, 1),
                    DateTo = DateTime.Now
                });
            }
            return RedirectToAction("Index", "Order");
        }
    }
}