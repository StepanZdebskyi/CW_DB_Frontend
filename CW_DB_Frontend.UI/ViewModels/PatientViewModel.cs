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
    public class PatientViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditPatient { get; set; }
        public ICommand DeletePatient { get; set; }

        public PatientViewModel()
        {
            EditPatient = new EditPatCommand(model, this);
            DeletePatient = new DeletePatCommand(model, this);
        }

        public PatientViewModel(PatientViewModel obj)
        {
            EditPatient = new EditPatCommand(model, this);
            DeletePatient = new DeletePatCommand(model, this);

            this.PatientID = obj.PatientID;
            this.PatientName = obj.PatientName;
            this.PatientSurname = obj.PatientSurname;
            this.PatientAge = obj.PatientAge;
            this.PatientGender = obj.PatientGender;
            this.PatientPassportNumber = obj.PatientPassportNumber;
        }

        private int _patientID;
        public int PatientID {
            get { return _patientID; }
            set { _patientID = value; OnPropertyChanged("PatientID"); }
        }

        private string _patientName;
        public string PatientName {
            get { return _patientName; }
            set { _patientName = value; OnPropertyChanged("PatientName"); }
        }

        private string _patientSurname;
        public string PatientSurname {
            get { return _patientSurname; }
            set { _patientSurname = value; OnPropertyChanged("PatientSurname"); }
        }

        private int _patientAge;
        public int PatientAge {
            get { return _patientAge; }
            set { _patientAge = value; OnPropertyChanged("PatientAge"); }
        }

        private int _patientGender;
        public int PatientGender {
            get { return _patientGender; }
            set { _patientGender = value; OnPropertyChanged("PatientGender"); }
        }

        private long _patientPassportNumber;
        public long PatientPassportNumber {
            get { return _patientPassportNumber; }
            set { _patientPassportNumber = value; OnPropertyChanged("PatientPassportNumber"); }
        }
    }
}
