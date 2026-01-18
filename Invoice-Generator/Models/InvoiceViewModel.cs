namespace InvoiceApplication.Models
{
    public class InvoiceViewModel
    {
        public Invoice_Table Invoice { get; set; }
        public List<InvoiceProduct> Products { get; set; }
    }
}
