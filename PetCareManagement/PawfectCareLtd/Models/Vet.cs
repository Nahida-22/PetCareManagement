using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Required for JsonPropertyName

namespace PawfectCareLtd.Models
{
    public class Vet
    {
        [Key]
        [StringLength(10)]
        [JsonPropertyName("vetID")]
        public string VetID { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("vetName")]
        public string VetName { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("specialisation")]
        public string Specialisation { get; set; }

        [Required]
        [StringLength(15)]
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
