using Microsoft.AspNetCore.Mvc;
using POS_API.DomainModels;
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

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5259/categories");
            var res=  await client.GetAsync(client.BaseAddress);
          //  product.Categories = JsonConvert.DeserializeObject<List<Category>>(await res.Content.ReadAsStringAsync());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}