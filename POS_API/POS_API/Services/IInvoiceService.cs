using POS_API.DomainModels;
using POS_API.ViewModels;

namespace POS_API.Services
{
    public interface IInvoiceService
    {
        Task<HashSet< InvoiceViewModel>> GetInvoiceView(int InvoiceId);
        Task<bool> PostInvoice(Invoice invoice);
        Task<bool> PostProductsToInvoice(ProductInvoice productInvoice);
        Task<bool> ConfirmInvoice(int InvoiceId);
    }
}
