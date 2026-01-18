using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models
{
    public class Invoice_Detail
    {
        [Key]
        public int Detail_Id { get; set; }
        public int? Invoice_Number { get; set; }
        public string? Product_Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
    }
}
