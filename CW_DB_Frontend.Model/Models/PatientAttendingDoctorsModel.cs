using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_DB_Frontend.Model.Models
{
    public class PatientAttendingDoctorsModel
    {
        [Required]
        public int RecordID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int PatientID { get; set; }
    }
}