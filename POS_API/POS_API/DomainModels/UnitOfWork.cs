using Microsoft.EntityFrameworkCore;
using POS_API.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL8003.site4now.net;Initial Catalog=db_a9274b_server23;User Id=db_a9274b_server23_admin;Password=Engamr26#");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Invoice> Invoices  { get; set; }
        public DbSet<ProductInvoice> ProductInvoices  { get; set; }
        public DbSet<Order> Orders  { get; set; }
        [NotMapped]
        public DbSet<ProductViewModel> ProductViewModels  { get; set; }
    }
}
