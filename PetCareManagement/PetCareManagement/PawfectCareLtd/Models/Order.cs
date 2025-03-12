using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }

        [ForeignKey("Medication")]
        public string MedicationID { get; set; }
        public Medication Medication { get; set; } // Navigation property

        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        [MaxLength(50)]
        public string OrderStatus { get; set; }
    }
}
