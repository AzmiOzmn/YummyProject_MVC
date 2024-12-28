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
            var values = context.Chefs.ToList();
            return View(values);
        }

        public ActionResult CreateChef()
        {
            // Boş bir Chef modeli oluştur ve ChefSocials listesini başlat
            var model = new Chef
            {
                ChefSocials = new List<ChefSocial>
        {
            new ChefSocial { SocialMediaName = "Twitter" },
            new ChefSocial { SocialMediaName = "Facebook" },
            new ChefSocial { SocialMediaName = "Instagram" },
            new ChefSocial { SocialMediaName = "LinkedIn" }
        }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateChef(Chef model)
        {
            if (ModelState.IsValid)
            {
                // Şef bilgilerini veritabanına ekle
                var values = context.Chefs.Add(model);
                context.SaveChanges();  // Şef kaydedildi

                // Sosyal medya bilgilerini sadece URL doluysa ekle
                foreach (var social in model.ChefSocials)
                {
                    if (!string.IsNullOrEmpty(social.Url))  // URL boş değilse
                    {
                        social.ChefId = model.ChefId;  // Şef ile ilişkilendir
                        context.ChefSocials.Add(social);  // Sosyal medya kaydını ekle
                    }
                }

                context.SaveChanges();  // Sosyal medya bilgilerini kaydet

                return RedirectToAction("Index");
            }

            return View(model); // Hatalıysa formu geri döndür
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