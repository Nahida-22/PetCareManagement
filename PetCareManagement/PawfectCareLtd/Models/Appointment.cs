using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    public class Appointment
    {
        [Key]
        [StringLength(10)]
        public string AppointmentID { get; set; }

        [Required]
        [StringLength(10)]
        public string PetID { get; set; }

        [Required]
        [StringLength(10)]
        public string VetID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; }
        public DateTime ApptDate { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        // Add navigation properties for relationships
        public Vet Vet { get; set; }
    }

}
