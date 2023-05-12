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
    public class HospitalizationRequestCombinedViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditHospRequestCombined { get; set; }
        public ICommand DeleteHospRequestCombined { get; set; }

        public HospitalizationRequestCombinedViewModel()
        {
            EditHospRequestCombined = new EditHospRequestCombinedCommand(model, this);
            DeleteHospRequestCombined = new DeleteHospRequestCombinedCommand(model, this);
        }

        public HospitalizationRequestCombinedViewModel(HospitalizationRequestCombinedViewModel obj)
        {
            EditHospRequestCombined = new EditHospRequestCombinedCommand(model, this);
            DeleteHospRequestCombined = new DeleteHospRequestCombinedCommand(model, this);

            this.RequestID = obj.RequestID;
            this.RequestDate = obj.RequestDate;
            this.PatientID = obj.PatientID;
            this.HealthComplaints = obj.HealthComplaints;
            this.ClinicName = obj.ClinicName;
            this.IsRequestProcessed = obj.IsRequestProcessed;
            this.PatientName = obj.PatientName;
            this.PatientSurname = obj.PatientSurname;
            this.PatientPassportNumber = obj.PatientPassportNumber;
            this.PatientGender = obj.PatientGender;
            this.PatientAge = obj.PatientAge;
        }

        private int _requestID;
        public int RequestID {
            get { return _requestID; }
            set { _requestID = value; OnPropertyChanged("RequestID"); }
        }

        private int _patientID;
        public int PatientID {
            get { return _patientID; }
            set { _patientID = value; OnPropertyChanged("PatientID"); }
        }

        private string _healthComplaints;
        public string HealthComplaints {
            get { return _healthComplaints; }
            set { _healthComplaints = value; OnPropertyChanged("HealthComplaints"); }
        }

        private string _clinicName;
        public string ClinicName {
            get { return _clinicName; }
            set { _clinicName = value; OnPropertyChanged("ClinicName"); }
        }

        private DateTime _requestDate;
        public DateTime RequestDate {
            get { return _requestDate; }
            set { _requestDate = value; OnPropertyChanged("RequestDate"); }
        }

        private bool _isRequestProcessed;
        public bool IsRequestProcessed {
            get { return _isRequestProcessed; }
            set { _isRequestProcessed = value; OnPropertyChanged("IsRequestProcessed"); }
        }

        private string _patientName;
        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; OnPropertyChanged("PatientName"); }
        }

        private string _patientSurname;
        public string PatientSurname
        {
            get { return _patientSurname; }
            set { _patientSurname = value; OnPropertyChanged("PatientSurname"); }
        }

        private int _patientAge;
        public int PatientAge
        {
            get { return _patientAge; }
            set { _patientAge = value; OnPropertyChanged("PatientAge"); }
        }

        private int _patientGender;
        public int PatientGender
        {
            get { return _patientGender; }
            set { _patientGender = value; OnPropertyChanged("PatientGender"); }
        }

        private long _patientPassportNumber;
        public long PatientPassportNumber
        {
            get { return _patientPassportNumber; }
            set { _patientPassportNumber = value; OnPropertyChanged("PatientPassportNumber"); }
        }
    }
}
