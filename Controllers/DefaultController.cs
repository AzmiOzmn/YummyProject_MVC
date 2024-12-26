using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {

            ViewBag.chefCount = context.Chefs.Count();
            ViewBag.eventCount = context.Events.Count();
            ViewBag.avgPrice = context.Products.Average(x => x.Price);
            ViewBag.productCount = context.Products.Count();
            return View();
        }

        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProduct()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }

        [HttpGet]

        public ActionResult Booking()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Booking(Booking model)
        {
            model.IsApproved = false;
            context.Bookings.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultContact()
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public ActionResult Message()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Message(Message model)
        {
            model.IsRead = false;
            context.Messages.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}