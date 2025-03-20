namespace PawfectCareLtd.Models
{
    /// <summary>
    /// Represents the clinic branches with details like name, phone numer, and address.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the unique identifier for the clinic location.
        /// </summary>
        public string LocationID { get; set; }

        /// <summary>
        /// Gets or sets the name of the clinic branch
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the clinic.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the clinic.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the clinicbranch.
        /// </summary>
        public string Email { get; set; }

        // Navigation property for related appointments
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();



    }
}