using Microsoft.EntityFrameworkCore;
using POS_API.DomainModels;

namespace POS_API.Services
{
    public class ProductService : IProductService
    {
        private UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetProducts() =>
          await  _unitOfWork.Products.ToListAsync();
        

        public async Task<List<Product>> GetProductsbyCategory(int CategoryId)=>
            await _unitOfWork.Products.Where(x=>x.CategoryId==CategoryId).ToListAsync();
        

        public async Task<bool> PostProduct(Product product)
        {
           await _unitOfWork.Products.AddAsync(product);
            var res= await _unitOfWork.SaveChangesAsync();
            return res > 0;
        }
    }
}
