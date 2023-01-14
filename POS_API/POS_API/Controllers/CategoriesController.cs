using Microsoft.AspNetCore.Mvc;
using POS_API.DomainModels;
using POS_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService; 
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories() =>
         await   categoryService.GetCategories();
        
       


        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Category category)
        {
           var res=await categoryService.PostCategories(category);
            return res ? Created(nameof(PostCategory), category):BadRequest();
        }

      
    }
}
