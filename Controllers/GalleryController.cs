using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class GalleryController : Controller
    {
       YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }

        public ActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGallery(PhotoGallery model)
        {
            var values = context.PhotoGalleries.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGallery(int id)
        {
            var values = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateGallery(int id)
        {
            var values = context.PhotoGalleries.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateGallery(PhotoGallery model)
        {
            var values = context.PhotoGalleries.Find(model.PhotoGalleryId);
            values.ImageUrl = model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}