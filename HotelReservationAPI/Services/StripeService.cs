using HotelReservationAPI.Dtos.Invoice;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.IO;
using static HotelReservationAPI.Controllers.StripeController;


namespace HotelReservationAPI.Services
{
    public class StripeService
    {
    
        private readonly ProductService _productService;
        private readonly PriceService _priceService;
        private readonly CustomerService _customerService;
        private readonly EmailService _emailService;
        public StripeService(ProductService productService, PriceService priceService, CustomerService customerService, EmailService emailService)
        {
            _productService = productService;
            _priceService = priceService;
            _customerService = customerService;
            _emailService = emailService;
        }
        
        public string Pay(string customerEmail, string priceID, int quantity)
        {
            return GenerateInvoices(customerEmail, priceID, quantity).HostedInvoiceUrl;
            //var options = new SessionCreateOptions
            //{
            //    LineItems = new List<SessionLineItemOptions>
            //    {
            //        new SessionLineItemOptions
            //        {
            //            Price = priceID,
            //            Quantity = quantity,
            //        },
            //    },
            //    Mode = "payment",
            //    SuccessUrl = "https://SuccessUrl",
            //    CancelUrl = "https://CancelUrl",
            //};
            //var service = new SessionService().Create(options);
            //return service.Url;
        }

        public bool CreateProduct(Room room) // ask mentor: should I make IProduct interface and implement it in Room class or should I make a DTO?
        {
            var options = new ProductCreateOptions
            {
                Name = $"Room {room.Number}"
            };

            Product product = _productService.Create(options);
            bool priceAdded = AddPriceToProduct(product.Id, room.Price);
            return product is not null && priceAdded;

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
        // need test
        public Product GetProductById(string productId)
        {
            return _productService.Get(productId);
        }

        // need test
        public bool DeleteProduct(string productId)
        {
            Product product = GetProductById(productId);
            _priceService.Update(product.DefaultPriceId, new PriceUpdateOptions
            {
                Active = false
            });
            return _productService.Delete(productId) is not null;
        }
        public Invoice CreateInvoice(string customerStripeId)
        {

            StripeCustomer stripeCustomer = GetCustomer(customerStripeId);
            var options = new InvoiceCreateOptions
            {
                Customer = $"{stripeCustomer.Id}",
                CollectionMethod = "send_invoice",
                DaysUntilDue = 30,
                AutoAdvance = true,
                Currency = "EGP"
            };
            var service = new InvoiceService();
            return service.Create(options);
        }
        public InvoiceDTO GenerateInvoices(string CustomerEmail,string priceId, int quantity)
        {
            string customerStripeId = _customerService.GetCustomerStripeId(CustomerEmail);
            Invoice invoice = CreateInvoice(customerStripeId);

            bool isAdded = AddInvoiceItemToInvoice(invoice.CustomerId, priceId, quantity, invoice.Id);
            Console.WriteLine(invoice.HostedInvoiceUrl);
            
            // just to generate HostedInvoiceUrl
            invoice = SendInvoice(invoice.Id);
            _emailService.SendEmail(new MailData()
            {
                EmailToId = CustomerEmail,
                EmailToName = invoice.CustomerName,
                EmailSubject = "Payment Invoice",
                EmailBody = $"You have a new invoice, please check the link: {invoice.HostedInvoiceUrl}"
            });

            return invoice.Map<InvoiceDTO>();
            
        }

        public bool AddInvoiceItemToInvoice(string customerId, string priceId,int quantity, string invoiceId)
        {
            var options = new InvoiceItemCreateOptions
            {
                Customer = $"{customerId}",
                Price = $"{priceId}",
                Quantity = quantity,
                Invoice = $"{invoiceId}",
                Currency = "EGP"
            };
            var service = new InvoiceItemService();
            return service.Create(options) is not null;
        }
        public StripeCustomer CreateCustomer(string email)
        {
            var options = new CustomerCreateOptions
            {
                Email = email,
            };
            var service = new Stripe.CustomerService();
            return service.Create(options).Map<StripeCustomer>();
        }
        public StripeCustomer GetCustomer(string customerId)
        {
            var service = new Stripe.CustomerService();
            return service.Get(customerId).Map<StripeCustomer>();
        }
        public Invoice SendInvoice(string invoiceId)
        {
            var service = new InvoiceService();
            return service.SendInvoice(invoiceId);
        }

       
    }



}
