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
                var candy = new CandyBindingModel();
                candy.CandyMaterials = new List<CandyMaterialBindingModel>();
                Session["Candy"] = candy;
            }
            return View((CandyBindingModel)Session["Candy"]);
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var candy = (CandyBindingModel)Session["Candy"];

            candy.CandyName = Request["CandyName"];
            candy.Price = Convert.ToDecimal(Request["Price"]);

            _service.AddElement(candy);

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
            var candy = (CandyBindingModel)Session["Candy"];
            var material = new CandyMaterialBindingModel
            {
                CandyId = candy.Id,
                MaterialId = int.Parse(Request["MaterialId"]),
                MaterialName = _matService.GetElement(int.Parse(Request["MaterialId"])).MaterialName,
                Count = int.Parse(Request["Count"])
            };
            candy.CandyMaterials.Add(material);
            Session["Candy"] = candy;
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