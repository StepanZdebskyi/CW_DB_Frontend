using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_DB_Frontend.Model.Models
{
    public class HospitalizationRequestCombinedModel
    {
        [Required]
        public int RequestID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public string HealthComplaints { get; set; }

        [Required]
        public string ClinicName { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public bool IsRequestProcessed { get; set; }

        [Required]
        [MinLength(2)]
        public string PatientName { get; set; }

        [Required]
        [MinLength(2)]
        public string PatientSurname { get; set; }

        [Required]
        public int PatientAge { get; set; }

        [Required]
        public int PatientGender { get; set; }

        [Required]
        public long PatientPassportNumber { get; set; }
    }
}
