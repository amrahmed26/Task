using System.ComponentModel.DataAnnotations;

namespace POS_API.DomainModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name{ get; set; } 
    }
}
