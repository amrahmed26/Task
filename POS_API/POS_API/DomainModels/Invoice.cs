using System.ComponentModel.DataAnnotations;

namespace POS_API.DomainModels
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
