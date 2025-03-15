using System.ComponentModel.DataAnnotations;

namespace PawfectCareLtd.Models
{
    ///<summary>
    /// Represents a junction table for the many-to-many relationship between Prescription and Medication.
    /// This class links prescriptions and medications, defining which medications are associated with which prescriptions.
    ///</summary>
    public class PrescriptionMedication

    {
        /// <summary>
        /// Gets or sets the unique identifier for the prescription.
        /// This is a foreign key referencing the Prescription entity.
        /// </summary>
        [StringLength(10)]
        public string PrescriptionID { get; set; }

        /// <summary>
        /// Navigation property for the prescription associated with this record.
        /// </summary>
        public Prescription Prescription { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the medication.
        /// This is a foreign key referencing the Medication entity.
        /// </summary>
        public string MedicationID { get; set; }

        /// <summary>
        /// Navigation property for the medication associated with this record.
        /// </summary>
        public Medication Medication { get; set; }
    }
}