
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a prescription issued to a pet, including details about the pet, vet, diagnosis, and medication.
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// Gets or sets the unique identifier for the prescription.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string PrescriptionID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the pet associated with the prescription.
        /// This property is a foreign key referencing the Pet entity.
        /// </summary>
        [ForeignKey("Pet")]
        public string PetID { get; set; }

        /// <summary>
        /// Navigation property for the pet associated with the prescription.
        /// </summary>
        public Pet Pet { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vet who issued the prescription.
        /// This property is a foreign key referencing the Vet entity.
        /// </summary>
        [ForeignKey("Vet")]
        public string VetID { get; set; }

        /// <summary>
        /// Navigation property for the vet who issued the prescription.
        /// </summary>
        public Vet Vet { get; set; }

        /// <summary>
        /// Gets or sets the diagnosis for the prescription.
        /// This property is required and has a maximum length of 255 characters.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Diagnosis { get; set; }

        /// <summary>
        /// Gets or sets the dosage prescribed for the pet.
        /// This property is required and has a maximum length of 100 characters.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Dosage { get; set; }

        /// <summary>
        /// Gets or sets the date the prescription was issued.
        /// This property is required.
        /// </summary>
        [Required]
        public DateTime DateIssued { get; set; }

        /// <summary>
        /// Gets or sets the collection of medications associated with the prescription.
        /// This property represents a many-to-many relationship with the PrescriptionMedication entity.
        /// </summary>
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = new List<PrescriptionMedication>();
    }
}
