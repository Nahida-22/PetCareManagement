namespace PawfectCareLtd.Models.DTO
{
    public class AppointmentDTO
    {
        public string PetID { get; set; }
        public string VetID { get; set; }
        public string ServiceType { get; set; }
        public DateTime ApptDate { get; set; }
        public string Status { get; set; }
        public string LocationID { get; set; }
    }
}
