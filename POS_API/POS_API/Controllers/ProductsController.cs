using Aelgak_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using POS_API.DomainModels;
using POS_API.Services;
using POS_API.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ExportToExcelService<ProductViewModel> exportToExcelService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
            exportToExcelService = ExportToExcelService<ProductViewModel>.GetInstance().Result;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts() =>
           await productService.GetProducts();
        [HttpGet("GetProductsView")]
        public async Task<List<ProductViewModel>> GetProductsView() =>
            await productService.GetProductsView();
        [HttpGet("GetProductsByCategory/{CategoryId}")]
        public async Task<IEnumerable<Product>> GetProductsByCategory( [FromRoute]int CategoryId) =>
           await productService.GetProductsbyCategory(CategoryId);
        
       

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody]Product product)
        {
           var res= await productService.PostProduct(product);
            return res ? Created(nameof(PostProduct), product):BadRequest();
        }
        [HttpGet("ExportToExcel")]
        public async Task<IActionResult> ExportToExcel()
        {
            string reportname = $"Products{DateTime.Now}.xlsx";
            var list = await productService.GetProductsView();
            if (list.Count > 0)
            {
                var exportbytes = await exportToExcelService.ExporttoExcel(list, reportname);
                return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportname);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
