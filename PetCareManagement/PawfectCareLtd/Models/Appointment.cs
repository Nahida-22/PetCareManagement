using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
///<summary>
/// Represents an appointment in the system.
///</summary>
{
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the appointment.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string AppointmentID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the pet associated with the appointment.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string PetID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vet associated with the appointment.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string VetID { get; set; }

        /// <summary>
        /// Gets or sets the type of service provided during the appointment (e.g check-up, surgery).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the appointment.
        /// </summary>
        [Required]
        public DateTime ApptDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the appointment (e.g scheduled, completed, canceled).
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vet associated with the appointment.
        /// </summary>
        [Required]
        
        public string LocationID { get; set; }

        /// <summary>
        /// Gets or sets the vet associated with the appointment.
        /// This is a navigation property.
        /// </summary>
        [ForeignKey("VetID")]
        public Vet Vet { get; set; }

        /// <summary>
        /// Gets or sets the pet associated with the appointment.
        /// This is a navigation property.
        /// </summary>
        [ForeignKey("PetID")]
        public Pet Pet { get; set; }

        /// <summary>
        /// Gets or sets the Location associated with the appointment.
        /// This is a navigation property.
        /// </summary>
        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        /// <summary>
        /// Navigation property for One-to-One Payment
        /// </summary>
        public Payment Payment { get; set; } 

    }

}