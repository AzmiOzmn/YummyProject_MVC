using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class BookingController : Controller
    {
        YummyContext context = new YummyContext();

        // Rezervasyonları tarihe göre sıralayıp listeleme
        public ActionResult Index()
        {
            var values = context.Bookings
                                .OrderByDescending(b => b.BookingDate) // Tarihe göre azalan sırada sıralama
                                .ToList();
            return View(values);
        }

        // Rezervasyonu onayla
        public ActionResult TrueBooking(int id)
        {
            var booking = context.Bookings.FirstOrDefault(x => x.BookingId == id);
            if (booking != null)
            {
                booking.IsApproved = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Rezervasyonu reddet
        public ActionResult FalseBooking(int id)
        {
            var booking = context.Bookings.FirstOrDefault(x => x.BookingId == id);
            if (booking != null)
            {
                booking.IsApproved = false;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
