using POS_API.DomainModels;

namespace POSView.Models
{
    public class ItemsModel
    {

        public List<Product>? Products { get; set; }=new List<Product>();
        public int ProductId { get; set; }
        public List<Category> Categories  { get; set; }
        public int CategoryId  { get; set; }
    }
}
