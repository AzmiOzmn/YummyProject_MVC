using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        YummyContext context = new YummyContext();

        [HttpGet]
        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Admin model,string returnUrl)
        {
            var admin = context.Admins.FirstOrDefault(a=>a.UserName==model.UserName && a.Password==model.Password);
            if (admin == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı !");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(admin.UserName,false);
            Session["currentUser"] = admin.UserName;

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index","Dashboard");  

            
        }

        
        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }
    }
}