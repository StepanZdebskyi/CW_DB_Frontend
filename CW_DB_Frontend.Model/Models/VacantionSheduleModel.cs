using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_DB_Frontend.Model.Models
{
    public class VacantionSheduleModel
    {
        [Required]
        public int SheduleItemID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public DateTime VacantionStartDate { get; set; }

        [Required]
        public DateTime VacantionEndDate { get; set; }
    }
}
