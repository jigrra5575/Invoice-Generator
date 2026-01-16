using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApplication.Models
{
    [Table("Invoice_table")]
    public class Invoice_Table
    {
        [Key]
        public int Invoice_Number { get; set; }
        public DateOnly? Invoice_Date{ get; set; }
        public string? Billing_Name{ get; set; }
        public string? Shipping_Name{ get; set; }
        public string? BillingAddress_Address{ get; set; }
        public string? BillingAddress_City{ get; set; }
        public string? BillingAddress_State{ get; set; }
        public string? BillingAddress_Phone{ get; set; }
        public string? ShippingAddress_Address{ get; set; }
        public string? ShippingAddress_City{ get; set; }
        public string? ShippingAddress_State{ get; set; }
        public string? ShippingAddress_Phone{ get; set; }
        public List<InvoiceProduct>? Products { get; set; } = new List<InvoiceProduct>();

        [NotMapped]
        public DateOnly? Invoice_Date_Plus20
        {
            get
            {
                return Invoice_Date?.AddDays(10);
            }
        }
        //public int Detail_Id { get; set; }


    }
}
