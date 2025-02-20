using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using static Payments.BusinessObjects.Class;

namespace Payments.Controllers
{
    public class Payments : Controller
    {
        [BindProperty]
        public OrderDetails orderDetails { get; set; }
        public IActionResult Payment(CardData cardData)
        {
            return View();
        }
        public IActionResult OrderCreate(OrderDetails orderDetails)
        {

            string key = "rzp_test_hWuNit5g2YzlJC";
            string secret = "azF27wzy6WifiDNuOqKnRVwq";

            Random random = new Random();
            string transID = random.Next(0, 10000).ToString();

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount",Convert.ToDecimal(orderDetails.amount)*100); // Amount is in currency subunits. Default currency is INR. Hence, 50000 refers to 50000 paise
            input.Add("currency", "INR");
            input.Add("receipt", transID);
            RazorpayClient client = new RazorpayClient(key, secret);
            Razorpay.Api.Order order = client.Order.Create(input);

            ViewBag.orderId = order["id"].ToString();
            return View("paymentsss", orderDetails);
        }

        public async Task<ActionResult> PaymentCreated(string razorpay_payment_id,string razorpay_order_id,string razorpay_signature)
        {
            RazorpayClient client = new RazorpayClient("rzp_test_hWuNit5g2YzlJC", "azF27wzy6WifiDNuOqKnRVwq");

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("razorpay_order_id", razorpay_order_id);
            options.Add("razorpay_payment_id", razorpay_payment_id);
            options.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentSignature(options);

            OrderDetails orderDetails=new OrderDetails();

            orderDetails.TransactionID = razorpay_payment_id;
            orderDetails.OrderID = razorpay_order_id;
            orderDetails.DateTime = DateTime.Now;

            return View("PaymentSuccess", orderDetails);
        }
    }
}
