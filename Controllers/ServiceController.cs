using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ServiceController : Controller
    {
       YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service model)
        {
            var values = context.Services.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var values = context.Services.Find(id);
            context.Services.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateService(int id)
        {
            var values = context.Services.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(Service model)
        {
            var values = context.Services.Find(model.ServiceId);
            values.Title = model.Title;
            values.Description = model.Description;
            values.Icon = model.Icon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}