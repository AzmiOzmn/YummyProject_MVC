using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AboutController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About model)
        {
            var values = context.Abouts.Add(model);
            context.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About model)
        {
            var values = context.Abouts.Find(model.AboutId);
            values.ImageUrl = model.ImageUrl;
            values.Item1 = model.Item1;
            values.Item2 = model.Item2;
            values.Item3 = model.Item3;
            values.Description = model.Description;
            values.VideoUrl = model.VideoUrl;
            values.PhoneNumber = model.PhoneNumber;
            values.ImageUrl2 = model.ImageUrl2;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}