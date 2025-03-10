using HotelReservationAPI.Models;
using Stripe;
using Stripe.Checkout;

namespace HotelReservationAPI.Services
{
    public class StripeService
    {
    
        private readonly ProductService _productService;
        private readonly PriceService _priceService;
        public StripeService(ProductService productService, PriceService priceService)
        {
            _productService = productService;
            _priceService = priceService;
        }
        public string Pay(string priceID, int quantity)
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = priceID,
                        Quantity = quantity,
                    },
                },
                Mode = "payment",
                SuccessUrl = "https://SuccessUrl",
                CancelUrl = "https://CancelUrl",
            };
            var service = new SessionService().Create(options);
            return service.Url;
        }

        public void CreateProduct(Room room) // ask mentor: should I make IProduct interface and implement it in Room class or should I make a DTO?
        {
            var options = new ProductCreateOptions
            {
                Name = $"Room {room.Number}"
            };

            Product product = _productService.Create(options);
           AddPriceToProduct(product.Id, room.Price);
        }
        public bool AddPriceToProduct(string productId, long price) // ask mentor what is I wanna price decimal instead of long
        {
            var priceOptions = new PriceCreateOptions
            {
                Product = productId,
                UnitAmount = price * 100,
                Currency = "EGP",
            };
            var priceCreated = _priceService.Create(priceOptions);
            return priceCreated != null;
        }
        public bool ChangeProductPrice(string productId, long newPrice)
        {
            return AddPriceToProduct(productId, newPrice);
        }
        public StripeList<Product> GetAllProducts()
        {
            var options = new ProductListOptions
            {
                Expand = new List<string>() { "data.default_price" }
            };
            var products = _productService.List(options);
            
            return products;
        }
        public Product UpdateProduct(string productId, ProductUpdateOptions productUpdateOptions)
        {
            return _productService.Update(productId, productUpdateOptions);
        }
        public void DeleteProduct(string productId)
        {
            _productService.Delete(productId);
        }
    }



}
