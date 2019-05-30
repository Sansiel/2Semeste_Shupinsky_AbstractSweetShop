using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System.Web.Mvc;

namespace AbstractSweetShopWebView.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IBuyerService _service;

        public BuyerController(IBuyerService service)
        {
            _service = service;
        }
        
        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            _service.AddElement(new BuyerBindingModel
            {
                BuyerFIO = Request["BuyerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new BuyerBindingModel
            {
                Id = id,
                BuyerFIO = viewModel.BuyerFIO
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new BuyerBindingModel
            {
                Id = int.Parse(Request["Id"]),
                BuyerFIO = Request["BuyerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}