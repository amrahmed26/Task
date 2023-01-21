using POS_API.DomainModels;
using POS_API.ViewModels;

namespace POS_API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<ProductViewModel>> GetProductsView();
        Task<List<Product>> GetProductsbyCategory(int CategoryId);
        Task<bool> PostProduct(Product product);
    }
}
