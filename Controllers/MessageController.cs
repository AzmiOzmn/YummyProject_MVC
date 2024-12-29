using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class MessageController : Controller
    {
       YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Messages.Where(m => m.IsRead == false).ToList();
            return View(values);
        }


        public ActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public ActionResult MakeMessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = true;
                context.SaveChanges();
            }
            return View(value);
        }

        public ActionResult ReadMessages()
        {
            var value = context.Messages.Where(x => x.IsRead == true).ToList();
            return View(value);
        }

        public ActionResult DeleteMessage(int id)
        {
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}