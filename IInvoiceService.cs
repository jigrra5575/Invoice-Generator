using InvoiceApplication.Models;
using Microsoft.Data.SqlClient;

namespace InvoiceApplication.Service
{
    public interface IInvoiceService
    {
       public List<Invoice_Table> GetInvoices();
        //public void CreateInvoice(Invoice_Table invoice);
        public void CreateInvoice(Invoice_Table invoice, List<InvoiceProduct> products);
        public Invoice_Table GetById(int id);
        public void EditInvoice(Invoice_Table invoice, List<InvoiceProduct> products);
        public void deleteInvoice(int id);
        public void ErrorHandaling(Exception error);
        public void ErrorHandaling(SqlException error);
    }
}
