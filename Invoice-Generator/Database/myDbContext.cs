using InvoiceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Database
{
    public class myDbContext : DbContext
    {
        public myDbContext()
        {
        }

        public myDbContext(DbContextOptions options) : base (options){ }

        public DbSet<Invoice_Table> T_Invoice{ get; set; }
        public DbSet<Invoice_Detail> Invoice_Detail{ get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<ErrorHandaling> ErrorHandaling { get; set; }

    }
}
