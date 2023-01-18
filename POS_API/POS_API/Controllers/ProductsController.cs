using Microsoft.AspNetCore.Mvc;
using POS_API.DomainModels;
using POS_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts() =>
           await productService.GetProducts();
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

       
    }
}
