using HotelReservationAPI.Dtos.Invoice;
using HotelReservationAPI.Models;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using Stripe;
using System.Reflection.Metadata.Ecma335;

namespace HotelReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public partial class StripeController : ControllerBase
    {
        public readonly StripeService _stripeService;
        public readonly StripeModel _stripeModel;
        public readonly EmailService _emailService;
        public StripeController(StripeService stripeService, IOptions<StripeModel> options, EmailService emailService)
        {
            _stripeService = stripeService;
            _stripeModel = options.Value;
            _emailService = emailService;
        }
        [HttpPost]
        public ResponseViewModel<string> Pay(string customerEmail, string priceId, int quantity)
        {
            string url = _stripeService.Pay(customerEmail, priceId,quantity);
            return ResponseViewModel<string>.Success(url);
        }
        [HttpPost]
        public ResponseViewModel<bool> ChangeProductPrice(string productId, long newPrice)
        {
            bool isChanged = _stripeService.ChangeProductPrice(productId, newPrice);
            return ResponseViewModel<bool>.Success(isChanged);
        }
        [HttpGet]
        public ResponseViewModel<StripeList<Product>> GetAllProducts()
        {
            StripeList<Product> products = _stripeService.GetAllProducts();
            return ResponseViewModel<StripeList<Product>>.Success(products);
        }
        [HttpPut]
        public ResponseViewModel<Product> UpdateProductName(string productId, string name)
        {
            Product product = _stripeService.UpdateProduct(productId, new ProductUpdateOptions
            {
                Name = name
            });
            return ResponseViewModel<Product>.Success(product);
        }
        [HttpDelete]
        public ResponseViewModel<bool> DeleteProduct(string productId)
        {
            bool isDeleted = _stripeService.DeleteProduct(productId);
            return ResponseViewModel<bool>.Success(isDeleted);
        }
            
        
        [HttpGet]
        public ResponseViewModel<InvoiceDTO> GenerateInvoices(string CustomerEmail,string priceId, int quantity)
        {
            InvoiceDTO invoice =  _stripeService.GenerateInvoices(CustomerEmail,priceId, quantity);
            return ResponseViewModel<InvoiceDTO>.Success(invoice);
        }
        [HttpGet]
       
        [HttpGet]
        public ResponseViewModel<string> sendNotification(string message)
        {
            return ResponseViewModel<string>.Success(_emailService.sendNotification(message));
        }
        [HttpPost]
        public async Task<IActionResult> WebHook()
        {

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);

                // Handle the event
                // If on SDK version < 46, use class Events instead of EventTypes
                if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    // Then define and call a method to handle the successful payment intent.
                    // handlePaymentIntentSucceeded(paymentIntent);
                    sendNotification("Payment Success");
                    
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }

    }
}
