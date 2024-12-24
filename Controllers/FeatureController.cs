using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    
    public class FeatureController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }

        public ActionResult CreateFeature()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateFeature(Feature model)
        {

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            context.Features.Add(model);
            int result = context.SaveChanges();
            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature (int id)

        {
            var value = context.Features.Find(id);
            context.Features.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFeature()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UpdateFeature(Feature model)
        {
            context.Features.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}