using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_API.DomainModels;
using POS_API.ViewModels;
using POSView.Models;
using System.Diagnostics;

namespace POSView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5259/api/categories");
            var res=  await client.GetAsync(client.BaseAddress);
            ItemsModel model = new ();
            model.Categories = new List<Category>();
            //if (res.IsSuccessStatusCode)
            //{

            //   model.Categories = JsonConvert.DeserializeObject<List<Category>>(await res.Content.ReadAsStringAsync());

            //}
            
            return View();
        }
        public async Task< List<Product>> GetProducts(int CategoryId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5259/api/Products/");
            var res = await client.GetAsync($"GetProductsByCategory/{CategoryId}");
            ItemsModel model = new();
            if (res.IsSuccessStatusCode)
            {

                var Products = JsonConvert.DeserializeObject<List<Product>>(await res.Content.ReadAsStringAsync());
                return Products;

            }
            return new List<Product>();
           

        }
        [HttpPost]
        public async Task<IActionResult> PostToInvoice(ProductInvoice productInvoice)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5259/api/Invoices/");
            var res = await client.PostAsJsonAsync($"PostProductsToInvoice",productInvoice);
            if (res.IsSuccessStatusCode)
                return Ok();
            else
                return BadRequest();
        }

        public async Task<List<InvoiceViewModel>> GetInvoice()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5259/api/Invoices/");
            var res = await client.GetAsync($"GetInvoiceDetails/1");
            ItemsModel model = new();
            if (res.IsSuccessStatusCode)
            {

                var Invoice = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(await res.Content.ReadAsStringAsync());
                return Invoice;

            }
            return new List<InvoiceViewModel>();
        }
    }
}