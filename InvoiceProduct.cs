using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models
{
    public class InvoiceProduct
    {
        [Key]
        public int Detail_Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public decimal? Total { get; set; }

    }
}
