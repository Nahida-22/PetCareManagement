using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    public class Medication
    {
        [Key]
        public string MedicationID { get; set; }

        [StringLength(100)]
        [Required]
        public string MedicationName { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierID { get; set; }
        public Supplier Supplier { get; set; } // Navigation property

        public int StockQuantity { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime ExpiryDate { get; set; }

        // Navigation property: A Medication can have MANY Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>(); /// NEED TO CHECK!!!!!

        // Navigation property for PrescritionMedication
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = new List<PrescriptionMedication>();
    }
}
