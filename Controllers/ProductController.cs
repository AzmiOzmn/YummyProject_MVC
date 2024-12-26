using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProductController : Controller
    {
        YummyContext context = new YummyContext();

        private void CategoryDropDown()
        {
            var categoryList = context.Categories.ToList(); // Kategorileri alıyoruz

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName, // Kategori adı
                                                   Value = x.CategoryId.ToString() // Kategori ID
                                               }).ToList();
            ViewBag.categories = categories;

            if (!categoryList.Any())
            {
                throw new Exception("Veritabanında hiçbir kategori bulunamadı.");
            }
        }

        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        public ActionResult CreateProduct()
        {
            CategoryDropDown();
            return View();
        }


        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bir hata olursa kategori listesini yeniden doldur
            CategoryDropDown();
            return View(model);

           
        }

        public ActionResult DeleteProduct(int id)

        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            CategoryDropDown();
            var values = context.Products.Find(id);
            return View(values);
        }


        [HttpPost]
        public ActionResult UpdateProduct(Product model)
        {
            var values = context.Products.Find(model.ProductId);
            values.ImageUrl = model.ImageUrl;
            values.ProductName = model.ProductName;
            values.Ingredients = model.Ingredients;
            values.Price = model.Price;
            values.CategoryId = model.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}