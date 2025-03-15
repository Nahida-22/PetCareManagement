using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a veterinarian in the system. A vet can have many appointments with pets.
    /// </summary>
    public class Vet
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vet.
        /// </summary>
        [Key]
        [StringLength(10)]
        public string VetID { get; set; }

        /// <summary>
        /// Gets or sets the name of the vet.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string VetName { get; set; }

        /// <summary>
        /// Gets or sets the specialisation of the vet (e.g surgery, dermatology, etc.).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Specialisation { get; set; }

        /// <summary>
        /// Gets or sets the phone number for contacting the vet.
        /// </summary>
        [Required]
        [StringLength(15)]
        public string PhoneNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the vet.
        /// Ensures that the email is in a valid format.
        /// </summary>
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the vet.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        /// <summary>
        /// Navigation property representing the appointments associated with the vet.
        /// A vet can have many appointments with pets.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}