using POS_API.DomainModels;

namespace POS_API.Services
{
    public interface ICategoryService
    {
         Task<List< Category>> GetCategories();
         Task<bool> PostCategories(Category category);
    }
}
