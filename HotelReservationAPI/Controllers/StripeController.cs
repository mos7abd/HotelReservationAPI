using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Customer")]

        public ResponseViewModel<string> Pay(string priceId, int quantity)
        {
            string url = _stripeService.Pay(priceId,quantity);
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
        //[HttpDelete]
        //public ResponseViewModel<bool> DeleteProduct(string productId)
        //{
        //     bool isDeleted = _stripeService.DeleteProduct(productId);
        //     return ResponseViewModel<bool>.Success(isDeleted);
        //}


    }
}
