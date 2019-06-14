using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System.Web.Mvc;

namespace AbstractSweetShopWebView.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
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
            _service.AddElement(new MaterialBindingModel
            {
                MaterialName = Request["MaterialName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new MaterialBindingModel
            {
                Id = id,
                MaterialName = viewModel.MaterialName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new MaterialBindingModel
            {
                Id = int.Parse(Request["Id"]),
                MaterialName = Request["MaterialName"]
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