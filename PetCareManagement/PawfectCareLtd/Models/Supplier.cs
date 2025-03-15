using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a supplier in the system. A supplier provides medications and can have multiple associated medications.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        [StringLength(100)]
        [Required]

        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        [StringLength(20)]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
        [StringLength(200)]
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// </summary>
        [StringLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Navigation property for related medications provided by the supplier.
        /// A supplier can supply multiple medications.
        /// </summary>
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();

    }
}