using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    public class Supplier
    {
        [Key]
        [StringLength(10)]  // Limit the length of SupplierID to 10 characters
        [Required]          // Mark SupplierID as required
        public string SupplierID { get; set; }

        [StringLength(100)] // Limit the length of SupplierName to 100 characters
        [Required]          // Mark SupplierName as required
        public string SupplierName { get; set; }

        [StringLength(20)]  // Limit the length of PhoneNumber to 20 characters
        [Required]          // Mark PhoneNumber as required
        public string PhoneNumber { get; set; }

        [StringLength(200)] // Limit the length of Address to 200 characters
        [Required]          // Mark Address as required
        public string Address { get; set; }

        [StringLength(100)] // Limit the length of Email to 100 characters
        [Required]          // Mark Email as required
        [EmailAddress]      // Ensure the email follows the proper format
        public string Email { get; set; }

        // Navigation property for related Medications
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();

    }
}
