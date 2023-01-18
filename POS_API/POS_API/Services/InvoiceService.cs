using POS_API.DomainModels;
using POS_API.ViewModels;
using POS_API.Dapper;
using Microsoft.EntityFrameworkCore;

namespace POS_API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly UnitOfWork unitOfWork;
        private Dapper<InvoiceViewModel> dapper;
        public InvoiceService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dapper=Dapper<InvoiceViewModel>.GetInstance().Result;
        }
        public async Task<HashSet< InvoiceViewModel>> GetInvoiceView(int InvoiceId)
        {
                
          var invoice =dapper.GetAllData($"select Invoices.Id as InvoicetId,Products.Name as ProductName ,ProductInvoices.QTY,ProductInvoices.TotalPrice from Products inner join ProductInvoices on ProductInvoices.productId=products.Id and ProductInvoices.InvoiceId={InvoiceId}  inner join Invoices on Invoices.Id={InvoiceId} ").Result.ToHashSet();
            return invoice;
        }

        public async Task<bool> PostInvoice(Invoice invoice)
        {
          await unitOfWork.Invoices.AddAsync(invoice);
         var res=   await unitOfWork.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> PostProductsToInvoice(ProductInvoice productInvoice)
        {
            var product=await unitOfWork.ProductInvoices.FirstOrDefaultAsync(x=>x.ProductId==productInvoice.ProductId);
            if(product is not null)
            {
                return false;
            }
            else
            {
                var productprice = await unitOfWork.Products.Where(x => x.Id == productInvoice.ProductId).Select(x => x.Price).SingleOrDefaultAsync();
                productInvoice.TotalPrice = productprice * productInvoice.QTY;

                await unitOfWork.ProductInvoices.AddAsync(productInvoice);
               var res= await unitOfWork.SaveChangesAsync();    
                return res> 0; 

            }
            
        }
    }
}
