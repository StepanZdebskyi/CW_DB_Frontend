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
    public class DoctorsSheduleViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditDoctorsShedule { get; set; }
        public ICommand DeleteDoctorsShedule { get; set; }

        public DoctorsSheduleViewModel()
        {
            EditDoctorsShedule = new EditDoctorsSheduleCommand(model, this);
            DeleteDoctorsShedule = new DeleteDoctorsSheduleCommand(model, this);
        }

        public DoctorsSheduleViewModel(DoctorsSheduleViewModel obj)
        {
            EditDoctorsShedule = new EditDoctorsSheduleCommand(model, this);
            DeleteDoctorsShedule = new DeleteDoctorsSheduleCommand(model, this);

            this.SheduleItemID = obj.SheduleItemID;
            this.StartWorkTime = obj.StartWorkTime;
            this.FinishWorkTime = obj.FinishWorkTime;
            this.DoctorID = obj.DoctorID;
            this.WorkDate = obj.WorkDate;
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

        private DateTime _workDate; 
        public DateTime WorkDate {
            get { return _workDate; }
            set { _workDate = value; OnPropertyChanged("WorkDate"); }
        }

        private DateTime _startWorkTime;
        public DateTime StartWorkTime {
            get { return _startWorkTime; }
            set { _startWorkTime = value; OnPropertyChanged("StartWorkTime"); }
        }

        private DateTime _finishWorkTime;
        public DateTime FinishWorkTime {
            get { return _finishWorkTime; }
            set { _finishWorkTime = value; OnPropertyChanged("FinishWorkTime"); } 
        }
    }
}
