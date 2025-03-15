using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a pet, including details like name, type, breed, and age.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pet.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string PetID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the owner of the pet.
        /// This property is required and is a foreign key referencing the Owner entity.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string OwnerID { get; set; }

        /// <summary>
        /// Gets or sets the name of the pet.
        /// This property is required and has a maximum length of 50 characters.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PetName { get; set; }

        /// <summary>
        /// Gets or sets the type of the pet (e.g., dog, cat).
        /// This property is required and has a maximum length of 15 characters.
        /// </summary>
        [Required]
        [StringLength(15)]
        public string PetType { get; set; }

        /// <summary>
        /// Gets or sets the breed of the pet.
        /// This property is required and has a maximum length of 100 characters.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Breed { get; set; }

        /// <summary>
        /// Gets or sets the age of the pet in years.
        /// This property is required and the value should be between 0 and 30 years.
        /// </summary>
        [Required]
        [Range(0, 30)]  // Assuming age is between 0 and 30 years.
        public string Age { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}