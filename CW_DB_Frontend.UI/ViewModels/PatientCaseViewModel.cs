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
    public class PatientCaseViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditPatientCase { get; set; }
        public ICommand DeletePatientCase { get; set; }

        public PatientCaseViewModel()
        {
            EditPatientCase = new EditPatCaseCommand(model, this);
            DeletePatientCase = new DeletePatCaseCommand(model, this);
        }

        public PatientCaseViewModel(PatientCaseViewModel obj)
        {
            EditPatientCase = new EditPatCaseCommand(model, this);
            DeletePatientCase = new DeletePatCaseCommand(model, this);

            this.PatientID = obj.PatientID;
            this.CaseID = obj.CaseID;
            this.CaseOpeningDate = obj.CaseOpeningDate;
            this.ConclusionsNotes = obj.ConclusionsNotes;
            this.IsCaseClosed = obj.IsCaseClosed;
            this.IllnessDescription = obj.IllnessDescription;
            this.Remarks = obj.Remarks;
        }

        private int _patientID;
        public int PatientID {
            get { return _patientID; }
            set { _patientID = value; OnPropertyChanged("PatientID"); }
        }

        private int _caseID;
        public int CaseID { 
            get { return _caseID; }
            set { _caseID = value; OnPropertyChanged("CaseID"); }
        }

        private bool _isCaseClosed;
        public bool IsCaseClosed { 
            get { return _isCaseClosed; }
            set { _isCaseClosed = value; OnPropertyChanged("IsCaseClosed"); }
        }

        private DateTime _caseOpeningDate;
        public DateTime CaseOpeningDate {
            get { return _caseOpeningDate; }
            set { _caseOpeningDate = value; OnPropertyChanged("CaseOpeningDate"); }
        }

        private string _illnessDescription;
        public string IllnessDescription {
            get { return _illnessDescription; }
            set { _illnessDescription = value; OnPropertyChanged("IllnessDescription"); }
        }

        private string _conclusionsNotes; 
        public string ConclusionsNotes {
            get { return _conclusionsNotes; }
            set { _conclusionsNotes = value; OnPropertyChanged("ConclusionsNotes"); }
        }

        private string _remasks;
        public string Remarks {
            get { return _remasks; }
            set { _remasks = value; OnPropertyChanged("Remarks"); }
        }
    }
}
