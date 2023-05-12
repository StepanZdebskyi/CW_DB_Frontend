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
    public class PatientAttendingDoctorsViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditPatientAttendingDoctors { get; set; }
        public ICommand DeletePatientAttendingDoctors { get; set; }

        public PatientAttendingDoctorsViewModel()
        {
            EditPatientAttendingDoctors = new EditPatAttendDocCommand(model, this);
            DeletePatientAttendingDoctors = new DeletePatAttendDocCommand(model, this);
        }

        public PatientAttendingDoctorsViewModel(PatientAttendingDoctorsViewModel obj)
        {
            EditPatientAttendingDoctors = new EditPatAttendDocCommand(model, this);
            DeletePatientAttendingDoctors = new DeletePatAttendDocCommand(model, this);

            this.RecordID = obj.RecordID;
            this.DoctorID = obj.DoctorID;
            this.PatientID = obj.PatientID;
        }

        private int _recordID;
        public int RecordID {
            get { return _recordID; }
            set { _recordID = value; OnPropertyChanged("RecordID"); }
        }

        private int _doctorID;
        public int DoctorID {
            get { return _doctorID; }
            set { _doctorID = value;  OnPropertyChanged("DoctorID"); }
        }

        private int _patientID;
        public int PatientID { 
            get { return _patientID; }
            set { _patientID = value; OnPropertyChanged("PatientID"); }
        }
    }
}
