using InvoiceApplication.Database;
using InvoiceApplication.Models;
using InvoiceApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Stripe.Checkout;

namespace InvoiceApplication.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly myDbContext context;
        public IInvoiceService service = new InvoiceService();

        public InvoiceController(myDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = service.GetInvoices();
            return View(data);
        }

        [HttpGet]
        [Route("/CreateInvoice")]
        public IActionResult CreateInvoice()
        {
            return View();
        }

        [HttpPost]
        [Route("/CreateInvoice")]
        public IActionResult CreateInvoice(Invoice_Table invoice, string ProductJson)
        {
            string errormessage = "";
            try
            {
                var products = JsonConvert.DeserializeObject<List<InvoiceProduct>>(ProductJson);
                service.CreateInvoice(invoice, products);

            }
            catch (SqlException ex)
            {
                errormessage = ex.Message + "Location : " +  ex.StackTrace;
                service.ErrorHandaling(ex);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message + "Location : " +  ex.StackTrace;
                service.ErrorHandaling(ex);
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = errormessage;
                return View();
            }
        }



        [HttpGet]
        [Route("/EditInvoice")]
        public IActionResult EditInvoice(int id)
        {
            var data = service.GetById(id);
            return View(data);
        }

        [HttpPost]
        [Route("/EditInvoice")]
        public IActionResult EditInvoice(Invoice_Table invoice, string ProductJson)
        {

            try
            {
                var products = JsonConvert.DeserializeObject<List<InvoiceProduct>>(ProductJson);
                service.EditInvoice(invoice, products);
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                service.ErrorHandaling(ex);

            }
            catch (Exception ex)
            {
                service.ErrorHandaling(ex);

            }
            return RedirectToAction("EditInvoice");
        }

        [HttpGet]
        [Route("/DetailInvoice")]
        public IActionResult DetailInvoice(int id)
        {
            var data = service.GetById(id);
            return View(data);
        }

        [HttpGet]
        [Route("/DeleteInvoice")]
        public IActionResult DeleteInvoice(int id)
        {
            var data = service.GetById(id);
            return View(data);
        }

        [HttpPost]
        [Route("/DeleteInvoices")]
        public IActionResult DeleteInvoices(int Invoice_Number)
        {
            try
            {
                service.deleteInvoice(Invoice_Number);
                return RedirectToAction("Index");

            }
            catch (SqlException ex)
            {
                service.ErrorHandaling(ex);

            }
            catch (Exception ex)
            {
                service.ErrorHandaling(ex);
            }
            return RedirectToAction("DeleteInvoice");
        }

        //PAYMENT
        // [Route("/CreateCheckoutSession")]

        public IActionResult CreateCheckoutSession(int invoiceId)
        {

            var invoice = service.GetById(invoiceId);

            decimal subtotal = invoice.Products.Sum(x => x.Total ?? 0);
            decimal tax = Math.Round(subtotal * 0.09m, 2);
            decimal charge = 50;
            decimal finalTotal = subtotal + tax + charge;

            long stripeAmount = (long)(finalTotal * 100);

            var domain = "https://localhost:7213";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = stripeAmount,
                        Currency = "inr",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Invoice #{invoice.Invoice_Number}"
                        }
                    },
                    Quantity = 1
                }
            },
                Mode = "payment",
                SuccessUrl = domain + "/Invoice/Success",
                CancelUrl = domain + "/Invoice/Cancel"
            };

            var serviceStripe = new SessionService();
            Session session = serviceStripe.Create(options);

            Console.WriteLine("Stripe URL: " + session.Url);

            return Redirect(session.Url);
        }



        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        [HttpGet]
        [Route("/Error")]
        public IActionResult Error()
        {
            var errors = context.ErrorHandaling.ToList();
            return View(errors);
        }

        [HttpGet]
        [Route("/Produtlist")]
        public IActionResult Productlist()
        {
            var products = context.InvoiceProducts.ToList();
            return View(products);
        }
    }
}
