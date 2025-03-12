using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    public class Prescription
    {
        [Key]
        [StringLength(10)]
        public string PrescriptionID { get; set; }

        [ForeignKey("Pet")]
        public string PetID { get; set; }
        public Pet Pet { get; set; }  // Navigation property

        [ForeignKey("Vet")]
        public string VetID { get; set; }
        public Vet Vet { get; set; }  // Navigation property

        [Required]
        [StringLength(255)]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }


        // Many-to-Many Relationship
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = new List<PrescriptionMedication>();
    }
}
