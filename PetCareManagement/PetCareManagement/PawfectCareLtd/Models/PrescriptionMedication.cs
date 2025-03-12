///<summary>
/// Class to define junction table for the many-to-many relationship between Prescription and Medication
///
///</summary>

namespace PawfectCareLtd.Models
{
    public class PrescriptionMedication
    {
        public string PrescriptionID { get; set; }
        public Prescription Prescription { get; set; }

        public string MedicationID { get; set; }
        public Medication Medication { get; set; }
    }

}
