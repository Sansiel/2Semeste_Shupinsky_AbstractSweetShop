using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using System;
using System.Web.Mvc;

namespace AbstractSweetShopWebView.Controllers
{
    public class MainController : Controller
    {
        private readonly IMainService _service;
        private readonly ICandyService _candyService;
        private readonly IBuyerService _buyerService;

        public MainController(IMainService service, ICandyService dressService, IBuyerService designerService)
        {
            _service = service;
            _candyService = dressService;
            _buyerService = designerService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            var dresses = new SelectList(_candyService.GetList(), "Id", "CandyName");
            var designers = new SelectList(_buyerService.GetList(), "Id", "BuyerFIO");
            ViewBag.Candyes = dresses;
            ViewBag.Buyers = designers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var buyerId = int.Parse(Request["BuyerId"]);
            var candyId = int.Parse(Request["CandyId"]);
            var count = int.Parse(Request["Count"]);
            var sum = CalcSum(candyId, count);

            _service.CreateOrder(new JobBindingModel
            {
                BuyerId = buyerId,
                CandyId = candyId,
                Count = count,
                Sum = sum

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int Id, int Count)
        {
            CandyViewModel candy = _candyService.GetElement(Id);
            return Count * candy.Price;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processing":
                        _service.TakeOrderInWork(new JobBindingModel { Id = id });
                        break;
                    case "Ready":
                        _service.FinishOrder(new JobBindingModel { Id = id });
                        break;
                    case "Paid":
                        _service.PayOrder(new JobBindingModel { Id = id });
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }


            return RedirectToAction("Index");
        }
    }
}