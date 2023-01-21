using POS_API.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace POS_API.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public float Price { get; set; }
        public string CategoryName
        {
            get; set;
        }
    }
}
