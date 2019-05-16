using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractSweetShopWebView.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyService _service;
        private readonly IMaterialService _matService;

        public CandyController(ICandyService service, IMaterialService matService)
        {
            _service = service;
            _matService = matService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            if (Session["Candy"] == null)
            {
                var dress = new CandyBindingModel();
                dress.CandyMaterials = new List<CandyMaterialBindingModel>();
                Session["Candy"] = dress;
            }
            return View((CandyBindingModel)Session["Candy"]);
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var dress = (CandyBindingModel)Session["Candy"];

            dress.CandyName = Request["CandyName"];
            dress.Price = Convert.ToDecimal(Request["Price"]);

            _service.AddElement(dress);

            Session.Remove("Candy");

            return RedirectToAction("Index");
        }

        public ActionResult AddMaterial()
        {
            var materials = new SelectList(_matService.GetList(), "Id", "MaterialName");
            ViewBag.Materials = materials;
            return View();
        }

        [HttpPost]
        public ActionResult AddMaterialPost()
        {
            var dress = (CandyBindingModel)Session["Candy"];
            var material = new CandyMaterialBindingModel
            {
                CandyId = dress.Id,
                MaterialId = int.Parse(Request["MaterialId"]),
                MaterialName = _matService.GetElement(int.Parse(Request["MaterialId"])).MaterialName,
                Count = int.Parse(Request["Count"])
            };
            dress.CandyMaterials.Add(material);
            Session["Candy"] = dress;
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new CandyBindingModel
            {
                Id = id,
                CandyName = viewModel.CandyName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new CandyBindingModel
            {
                Id = int.Parse(Request["Id"]),
                CandyName = Request["CandyName"]
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