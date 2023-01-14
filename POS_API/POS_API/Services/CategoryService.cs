using Microsoft.EntityFrameworkCore;
using POS_API.DomainModels;

namespace POS_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Category>> GetCategories() =>
         await   _unitOfWork.Categories.ToListAsync();
       

        public async Task<bool> PostCategories(Category category)
        {
           await _unitOfWork.Categories.AddAsync(category);
          var res=  await  _unitOfWork.SaveChangesAsync();
            return res > 0;
        }
    }
}
