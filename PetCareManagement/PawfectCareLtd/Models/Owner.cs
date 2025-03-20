using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents a pet owner with details like name, contact information, and address.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Gets or sets the unique identifier for the owner.
        /// </summary>
        [StringLength(10)]
        public string OwnerID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the owner.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the owner.
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the owner.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the physical address of the owner.
        /// </summary>
        public string Address { get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}