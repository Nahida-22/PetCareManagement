using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    public class Vet
    {
        [Key]
        [StringLength(10)]
        public string VetID { get; set; }

        [Required]
        [StringLength(100)]
        public string VetName { get; set; }

        [Required]
        [StringLength(50)]
        public string Specialisation { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]  // Ensures valid email format
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }
    }
}
