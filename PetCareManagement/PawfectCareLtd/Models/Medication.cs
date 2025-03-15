using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a medication in the system, including details like name, supplier, stock quantity, and pricing.
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// Gets or sets the unique identifier for the medication.
        /// </summary>
        [Key]
        public string MedicationID { get; set; }

        /// <summary>
        /// Gets or sets the name of the medication.
        /// This field is required and has a maximum length of 100 characters.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string MedicationName { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the supplier of the medication.
        /// This property is a foreign key referencing the Supplier entity.
        /// </summary>
        [ForeignKey("Supplier")]
        public string SupplierID { get; set; }

        /// <summary>
        /// Navigation property for the supplier associated with the medication.
        /// </summary>
        public Supplier Supplier { get; set; } // Navigation property

        /// <summary>
        /// Gets or sets the stock quantity of the medication.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the category of the medication (e.g., antibiotic, painkiller).
        /// The category has a maximum length of 50 characters.
        /// </summary>
        [MaxLength(50)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the medication.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the medication.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Navigation property for orders associated with the medication.
        /// A medication can be part of many orders.
        /// </summary>
        public ICollection<Order> Orders { get; set; } = new List<Order>(); /// NEED TO CHECK!!!!!

        /// <summary>
        /// Navigation property for prescriptions associated with the medication.
        /// A medication can be part of many prescriptions.
        /// </summary>
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = new List<PrescriptionMedication>();
    }
}