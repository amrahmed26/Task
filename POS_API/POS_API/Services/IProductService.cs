using POS_API.DomainModels;

namespace POS_API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsbyCategory(int CategoryId);
        Task<bool> PostProduct(Product product);
    }
}
