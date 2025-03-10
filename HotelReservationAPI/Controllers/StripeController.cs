using HotelReservationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace HotelReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StripeController : ControllerBase
    {
        public readonly StripeService _stripeService;
        public StripeController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }
        [HttpPost]
        public string Pay(string priceId, int quantity)
        {
            return _stripeService.Pay(priceId,quantity);
        }
        [HttpPost]
        public bool ChangeProductPrice(string productId, long newPrice)
        {
            return _stripeService.ChangeProductPrice(productId, newPrice);
        }
        [HttpGet]
        public StripeList<Product> GetAllProducts()
        {
            return _stripeService.GetAllProducts();
        }
        [HttpPut]
        public Product UpdateProductName(string productId, string name)
        {
            return _stripeService.UpdateProduct(productId, new ProductUpdateOptions
            {
                Name = name
            });
        }
        [HttpDelete]
        public void DeleteProduct(string productId)
        {
             _stripeService.DeleteProduct(productId);
        }


    }
}
