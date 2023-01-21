using System.ComponentModel.DataAnnotations;

namespace POS_API.DomainModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public float Price { get; set; }
        public int QTY { get; set; }
       // public virtual Category? Category { get; set; }
        public int CategoryId { get; set; }

    }
}
