using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents an order for medication, including details like quantity, status, and order date.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        [Key]
        public string OrderID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the medication associated with the order.
        /// This property is a foreign key referencing the Medication entity.
        /// </summary>
        [ForeignKey("Medication")]
        public string MedicationID { get; set; }

        /// <summary>
        /// Navigation property for the medication associated with the order.
        /// </summary>
        public Medication Medication { get; set; } // Navigation property

        /// <summary>
        /// Gets or sets the quantity of the medication ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the date the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the order (e.g., pending, completed, canceled).
        /// The order status has a maximum length of 50 characters.
        /// </summary>
        [MaxLength(50)]
        public string OrderStatus { get; set; }
    }
}