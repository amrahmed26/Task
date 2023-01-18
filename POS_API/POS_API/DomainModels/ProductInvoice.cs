namespace POS_API.DomainModels
{
    public class ProductInvoice
    {
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
       // public virtual Product? Product { get; set; }
        //public virtual Invoice? Invoice { get; set; }
        public int QTY { get; set; }
        public float? TotalPrice { get; set; }
    }
}
