using POS_API.DomainModels;

namespace POS_API.ViewModels
{
    public class InvoiceViewModel
    {
        
        public int InvoicetId { get; set; }
        public string ProductName { get; set; }
        public int QTY { get; set; }
        public float TotalPrice { get; set; }
    }
}
