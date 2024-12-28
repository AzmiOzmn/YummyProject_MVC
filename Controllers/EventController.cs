using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class EventController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Events.ToList();
            return View(values);
        }
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event model)
        {
            var values = context.Events.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEvent(int id)
        {
            var values = context.Events.Find(id);
            context.Events.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEvent(int id)
        {
            var values = context.Events.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateEvent(Event model)
        {
            var values = context.Events.Find(model.EventId);
            values.ImageUrl = model.ImageUrl;
            values.Title = model.Title;
            values.Description = model.Description;
            values.Price = model.Price;         
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}