using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    public class Pet
    {
        [Key]
        [StringLength(10)]
        public string PetID { get; set; }

        [Required]
        [StringLength(100)]
        public string OwnerID { get; set; }

        [Required]
        [StringLength(50)]
        public string PetName { get; set; }

        [Required]
        [StringLength(15)]
        public string PetType { get; set; }

        [Required]
        [StringLength(100)]
        public string Breed { get; set; }

        [Required]
        [Range(0, 30)]  // Assuming age is between 0 and 30 years.
        public string Age { get; set; }
    }
}
