using System;
using System.Web.Mvc;
using AFS.Payment.BusinessObjects;
using AFS.Payment.BusinessObjects.CardValidation;
using AFS.Payment.Models;

namespace AFS.Payment.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Orders _orders;
        private readonly BinCodesValidator _cardValidator;

        public PaymentController(Orders orders, BinCodesValidator cardValidator)
        {
            _orders = orders;
            _cardValidator = cardValidator;
        }

        public PaymentController() : this(new Orders(), new BinCodesValidator())
        {
        }

        public ActionResult GenerateLink() =>
            _orders.GetRandom().Map(o => View(new GenerateLinkModel(o))).OrElse(View("Error"));

        public ActionResult Welcome(Guid id) =>
            _orders.GetBy(id)
                .Map(o => View("Welcome", new WelcomeModel {OrderId = id}))
                .OrElse(View("Error"));

        [HttpPost]
        public ActionResult Order(WelcomeModel welcome) =>
            !ModelState.IsValid
                ? View("Error") as ActionResult
                : RedirectToAction("Order", new {orderId = welcome.OrderId, dateOfBirth = welcome.DateOfBirth});

        public ActionResult Order(Guid orderId, DateTime dateOfBirth) =>
            _orders.View(orderId, dateOfBirth)
                .Map(o => View(new OrderModel(o)) as ActionResult)
                .OrElse(() =>
                {
                    ViewBag.ErrorMessage = "Date of birth is invalid";
                    return Welcome(orderId);
                });

        [HttpPost]
        public ActionResult Pay(CreditCardModel creditCard) => View("ThankYou");
    }
}