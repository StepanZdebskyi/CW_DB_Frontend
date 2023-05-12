using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_DB_Frontend.Model.Models
{
    public class DoctorCombinedModel
    {
        [Required]
        public int DoctorID { get; set; }

        [Required]
        [MinLength(2)]
        public string DoctorName { get; set; }

        [Required]
        [MinLength(2)]
        public string DoctorSurname { get; set; }

        [Required]
        [MinLength(2)]
        public string SpecName { get; set; }

        public string DoctorExperience { get; set; }

        public string DoctorGraduation { get; set; }

        public float DoctorSalary { get; set; }

        public string DoctorRemarks { get; set; }
    }
}
