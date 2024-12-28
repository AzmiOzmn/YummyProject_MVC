using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var chefs = context.Chefs.ToList();  // Yalnızca şefler
            return View(chefs);  // Verileri View'a gönderiyoruz
        }


        public ActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateChef(Chef model)
        {
            if (ModelState.IsValid)
            {
                // Şef bilgilerini veritabanına ekle
                context.Chefs.Add(model);
                context.SaveChanges();  // Şef kaydedildi

                // Sosyal medya bilgilerini yalnızca URL doluysa ekle
                if (model.ChefSocials != null)
                {
                    foreach (var social in model.ChefSocials)
                    {
                        if (!string.IsNullOrEmpty(social.Url))  // URL boş değilse
                        {
                            social.ChefId = model.ChefId;  // Şef ile ilişkilendir
                            context.ChefSocials.Add(social);  // Sosyal medya kaydını ekle
                        }
                    }

                    context.SaveChanges();  // Sosyal medya bilgilerini kaydet
                }
            }

            return RedirectToAction("Index");
        }





        public ActionResult DeleteChef(int id)
        {
            var values = context.Chefs.Find(id);
            context.Chefs.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateChef(int id)
        {
            var values = context.Chefs.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef model)
        {
            var values = context.Chefs.Find(model.ChefId);
            values.ImageUrl = model.ImageUrl;
            values.Name = model.Name;
            values.Title = model.Title;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}