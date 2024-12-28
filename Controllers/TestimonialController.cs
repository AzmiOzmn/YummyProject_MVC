using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class TestimonialController : Controller
    {

        YummyContext context = new YummyContext();
        
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial model)
        {
            var values = context.Testimonials.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial model)
        {
            var values = context.Testimonials.Find(model.TestimonialId);
            values.ImageUrl = model.ImageUrl;
            values.NameSurname = model.NameSurname;
            values.Title = model.Title;
            values.Comment = model.Comment;
            values.Rating = model.Rating;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}