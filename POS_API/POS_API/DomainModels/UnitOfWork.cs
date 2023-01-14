using Microsoft.EntityFrameworkCore;

namespace POS_API.DomainModels
{
    public class UnitOfWork:DbContext
    {
        public UnitOfWork(DbContextOptions<UnitOfWork> options):base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInvoice>().HasKey(x => new { x.ProductId,x.InvoiceId });
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Invoice> Invoices  { get; set; }
        public DbSet<ProductInvoice> ProductInvoices  { get; set; }
    }
}
