using System;
using System.Web.Mvc;
using AFS.Payment.BusinessObjects;
using AFS.Payment.Models;

namespace AFS.Payment.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Welcome(Guid id) => WelcomeView(id, false);

        public ActionResult WelcomeRetry(Guid id) => WelcomeView(id, true);

        private ActionResult WelcomeView(Guid orderId, bool dateInvalid)
            => new Orders().GetBy(orderId)
                .Map(o => View("Welcome", new WelcomeModel {OrderId = orderId, DateInvalid = dateInvalid}))
                .OrElse(View("Error"));

        [HttpPost]
        public ActionResult Order(WelcomeModel welcome) => !ModelState.IsValid
            ? View("Error")
            : new Orders().GetBy(welcome.OrderId, welcome.DateOfBirth).Map(o => View(new OrderModel(o)) as ActionResult)
                .OrElse(RedirectToAction("WelcomeRetry", new {Id = welcome.OrderId}));


    }
}