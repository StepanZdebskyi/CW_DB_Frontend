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
    public class HospitalizationRequestViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditHospRequest { get; set; }
        public ICommand DeleteHospRequest { get; set; }

        public HospitalizationRequestViewModel()
        {
            EditHospRequest = new EditHospRequestCommand(model, this);
            DeleteHospRequest = new DeleteHospRequestCommand(model, this);
        }

        public HospitalizationRequestViewModel(HospitalizationRequestViewModel obj)
        {
            EditHospRequest = new EditHospRequestCommand(model, this);
            DeleteHospRequest = new DeleteHospRequestCommand(model, this);

            this.RequestID = obj.RequestID;
            this.PatientID = obj.PatientID;
            this.HealthComplaints = obj.HealthComplaints;
            this.ClinicName = obj.ClinicName;
            this.RequestDate = obj.RequestDate;
            this.IsRequestProcessed = obj.IsRequestProcessed;
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

        private bool _isRequestProccesed; 
        public bool IsRequestProcessed {
            get { return _isRequestProccesed; }
            set { _isRequestProccesed = value; OnPropertyChanged("IsRequestProcessed"); }
        }
    }
}
