using MultiLayer.Services.FormServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MultiLayer.Presentation.Models;

namespace MultiLayer.Presentation.Controllers
{
    [Authorize]
    public class FormsController : Controller
    {
        private readonly IFormsService _formService;

        public FormsController(IFormsService formService)
        {
            _formService = formService;
        }

        public ActionResult Index()
        {
            return View(_formService.GetForms());
        }

        public ActionResult forms(int id)
        {
            ViewBag.Fields = _formService.GetFields(id).ToList();
            return View(_formService.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Forms model, string fields)
        {
            model.createdAt = DateTime.Now;
            model.createdBy = User.Identity.GetUserId();
            fields = fields.Remove(fields.Length - 1);
            try
            {

                _formService.Insert(model);
                int id = model.id;
                if(id > 0)
                {
                    string[] fArr = fields.Split('€');
                    foreach (var fa in fArr)
                    {
                        string[] alanlar = fa.Split('#');
                        fields f = new fields();
                        f.name = alanlar[1];
                        f.dataType = alanlar[2];
                        if(alanlar[3] == "checked")
                        {
                            f.required = true;
                        }else
                        {
                            f.required = false;
                        }
                        f.formsId = id;

                        _formService.InsertFields(f);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult jsonRes(int id)
        {
            return RedirectToAction("getJson", new { id= id});
        }

        public JsonResult getJson(int id)
        {
            jsonR ret = new jsonR();
            ret.formBilgileri = _formService.Find(id);
            ret.alanlar = _formService.GetFields(id).ToList();

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }

    public class jsonR
    {
        public Forms formBilgileri { get; set; }
        public List<fields> alanlar { get; set; }
    }
}