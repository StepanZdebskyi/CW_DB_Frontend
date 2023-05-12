using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.Commands;

namespace CW_DB_Frontend.UI.ViewModels
{
    public class VacantionSheduleViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditVacShedule { get; set; }
        public ICommand DeleteVacShedule { get; set; }

        public VacantionSheduleViewModel()
        {
            EditVacShedule = new EditVacSheduleCommand(model, this);
            DeleteVacShedule = new DeleteVacSheduleCommand(model, this);
        }

        public VacantionSheduleViewModel(VacantionSheduleViewModel obj)
        {
            EditVacShedule = new EditVacSheduleCommand(model, this);
            DeleteVacShedule = new DeleteVacSheduleCommand(model, this);

            this.SheduleItemID = obj.SheduleItemID;
            this.DoctorID = obj.DoctorID;
            this.VacantionStartDate = obj.VacantionStartDate;
            this.VacantionEndDate = obj.VacantionEndDate;
        }

        private int _sheduleItemID;
        public int SheduleItemID {
            get { return _sheduleItemID; }
            set { _sheduleItemID = value; OnPropertyChanged("SheduleItemID"); }
        }

        private int _doctorID;
        public int DoctorID {
            get { return _doctorID; }
            set { _doctorID = value; OnPropertyChanged("DoctorID"); }
        }

        private DateTime _vacantionStartDate;
        public DateTime VacantionStartDate { 
            get { return _vacantionStartDate; }
            set { _vacantionStartDate = value; OnPropertyChanged("VacantionStartDate"); }
        }

        private DateTime _vacantionEndDate;
        public DateTime VacantionEndDate {
            get { return _vacantionEndDate; }
            set { _vacantionEndDate = value; OnPropertyChanged("VacantionEndDate"); }
        }
    }
}
