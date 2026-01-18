using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApplication.Models
{
    [Table("ErrorHandaling")]
    public class ErrorHandaling
    {
        [Key]
        public int ErrorId { get; set; }
        public DateTime? ErrorTime { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Location { get; set; }

    }
}
