using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{

    public class DashboardController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            ViewBag.soupCount = context.Products.Count(x => x.Category.CategoryName == "Çorbalar");
            ViewBag.mostExpensive = context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.avgPrice = context.Products.Average(x => x.Price);
            ViewBag.cheapestPrice = context.Products.OrderBy(x => x.Price).Select(y => y.ProductName).FirstOrDefault();

            ViewBag.chefCount = context.Chefs.Count();
            ViewBag.eventCount = context.Events.Count();
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.productCount = context.Products.Count();

            var values = context.Products.OrderByDescending(a => a.ProductId).Take(10).ToList();
            return View(values);
        }
    }
}