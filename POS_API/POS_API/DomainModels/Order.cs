namespace POS_API.DomainModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
       
    }
}
