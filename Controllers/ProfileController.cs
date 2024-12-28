using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProfileController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index(int id = 1) // Varsayılan id değeri
        {
            var values = context.Admins.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Admin model, string currentPassword)
        {
            var values = context.Admins.Find(model.AdminId);

            if (values.Password != currentPassword)
            {
                ViewBag.ErrorMessage = "Mevcut şifre yanlış.";
                return View(values);
            }

            values.ImageUrl = model.ImageUrl;
            values.NameSurname = model.NameSurname;
            values.UserName = model.UserName;
            values.Password = model.Password;
            context.SaveChanges();

            return RedirectToAction("Index", new { id = model.AdminId });
        }
    }
}
