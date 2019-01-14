using System;
using System.Linq;
using System.Web.Mvc;
using AFS.Payment.Data;
using AFS.Payment.Models.CardValidator;
using AFS.Payment.Utility;
using Order = AFS.Payment.Models.Order;

namespace AFS.Payment.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Welcome(Guid id)
        {
            ViewResult view = View("Error");
            using (var context = new PaymentContext())
            {
                context.Orders.SingleOrDefault(o => o.Id == id).AsMaybe().Map(o => view = View(new Order { Id = id }));
            }
            return view;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Validate(string number)
        {
            new BinCodesValidator().Validate(number);
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public ActionResult OrderDetails(Order order)
        {
            if (ModelState.IsValid)
                new BinCodesValidator().Validate(order.DateOfBirth);
            return RedirectToAction("Contact");
        }
    }
}