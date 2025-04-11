using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a payment record in the system.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the payment.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string BillID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the related appointment.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string AppointmentID { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the payment.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the date of payment.
        /// Nullable since some payments may be pending.
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the payment (e.g., Completed, Pending).
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Navigation property for the related appointment.
        /// </summary>
        [ForeignKey("AppointmentID")]
        public Appointment Appointment { get; set; }
    }
}
