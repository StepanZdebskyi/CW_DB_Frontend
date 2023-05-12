using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CW_DB_Frontend.Model.ASP_NET_Model;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.Commands;
using CW_DB_Frontend.UI.RedirectionCommands;
using CW_DB_Frontend.UI.Views;

namespace CW_DB_Frontend.UI.ViewModels
{
    public class MyViewModel : ViewModelBase
    {
        public MainWindow mainWindow { get; set; }

        public AspViewModel aspViewModel { get; set; }
        public AspDataModel aspDataModel { get; set; }

        //All commands
        public ICommand AddNewDoctor { get; set; }
        public ICommand CompleteAddingDoctor { get; set; }

        public ICommand AddNewDoctorsInfo { get; set; }
        public ICommand CompleteAddingDoctorsInfo { get; set; }

        public ICommand AddNewDoctorsShedule { get; set; }
        public ICommand CompleteAddingDoctorsShedule { get; set; }

        public ICommand AddNewHospRequest { get; set; }
        public ICommand CompleteAddingHospRequest { get; set; }

        public ICommand AddNewMedRecord { get; set; }
        public ICommand CompleteAddingMedRecord { get; set; }

        public ICommand AddNewPatAttendDoc { get; set; }
        public ICommand CompleteAddingPatAttendDoc { get; set; }

        public ICommand AddNewPatCase { get; set; }
        public ICommand CompleteAddingPatCase { get; set; }

        public ICommand AddNewPat { get; set; }
        public ICommand CompleteAddingPat { get; set; }

        public ICommand AddNewSpec { get; set; }
        public ICommand CompleteAddingSpec { get; set; }

        public ICommand AddNewVacShedule { get; set; }
        public ICommand CompleteAddingVacShedule { get; set; }

        //Redirection commands
        public ICommand RedirectToDoctors { get; set; }
        public ICommand RedirectToDoctorsInfo { get; set; }
        public ICommand RedirectToDoctorsShedule { get; set; }
        public ICommand RedirectToHospRequests { get; set; }
        public ICommand RedirectToMedRecords { get; set; }
        public ICommand RedirectToPatAttendDoc { get; set; }
        public ICommand RedirectToPatCases { get; set; }
        public ICommand RedirectToPat { get; set; }
        public ICommand RedirectToSpec { get; set; }
        public ICommand RedirectToVacShedule { get; set; }
        public ICommand RedirectToDoctorsCombined { get; set; }
        public ICommand RedirectToHospRequestsCombined { get; set; }


        public MyViewModel()
        {
            CurrentUserControl = "DoctorsControl";

            //Commands init
            AddNewDoctor = new AddNewDoctorCommand(this);
            CompleteAddingDoctor = new CompleteAddingDoctor(this);

            AddNewDoctorsInfo = new AddNewDoctorsInfoCommand(this);
            CompleteAddingDoctorsInfo = new CompleteAddingDoctorsInfoCommand(this);

            AddNewDoctorsShedule = new AddNewDoctorsSheduleCommand(this);
            CompleteAddingDoctorsShedule = new CompleteAddingDoctorsSheduleCommand(this);

            AddNewHospRequest = new AddNewHospRequestCommand(this);
            CompleteAddingHospRequest = new CompleteAddingHospRequestCommand(this);

            AddNewMedRecord = new AddNewMedRecordCommand(this);
            CompleteAddingMedRecord = new CompleteAddingMedRecordCommand(this);

            AddNewPatAttendDoc = new AddNewPatAttendDocCommand(this);
            CompleteAddingPatAttendDoc = new CompleteAddingPatAttendDocCommand(this);

            AddNewPatCase = new AddNewPatCaseCommand(this);
            CompleteAddingPatCase = new CompleteAddingPatCaseCommand(this);

            AddNewPat = new AddNewPatCommand(this);
            CompleteAddingPat = new CompleteAddingPatCommand(this);

            AddNewSpec = new AddNewSpecCommand(this);
            CompleteAddingSpec = new CompleteAddingSpecCommand(this);

            AddNewVacShedule = new AddNewVacSheduleCommand(this);
            CompleteAddingVacShedule = new CompleteAddingVacSheduleCommand(this);

            //Redirection commands init
            RedirectToDoctors = new RedirectToDoctorsCommand(this);
            RedirectToDoctorsInfo = new RedirectToDoctorsInfoCommand(this);
            RedirectToDoctorsShedule = new RedirectToDoctorsSheduleCommand(this);
            RedirectToHospRequests = new RedirectToHospRequestsCommand(this);
            RedirectToMedRecords = new RedirectToMedRecordsCommand(this);
            RedirectToPatAttendDoc = new RedirectToPatAttendDocCommand(this);
            RedirectToPatCases = new RedirectToPatCasesCommand(this);
            RedirectToPat = new RedirectToPatCommand(this);
            RedirectToSpec = new RedirectToSpecCommand(this);
            RedirectToVacShedule = new RedirectToVacSheduleCommand(this);
            RedirectToDoctorsCombined = new RedirectToDoctorsCombinedCommand(this);
            RedirectToHospRequestsCombined = new RedirectToHospRequestsCombinedCommand(this);

            DoctorCombinedViewModel.model = this;
            DoctorsInfoViewModel.model = this;
            DoctorsSheduleViewModel.model = this;
            DoctorViewModel.model = this;
            HospitalizationRequestViewModel.model = this;
            MedicalRecordViewModel.model = this;
            PatientAttendingDoctorsViewModel.model = this;
            PatientCaseViewModel.model = this;
            PatientViewModel.model = this;
            SpecialityViewModel.model = this;
            VacantionSheduleViewModel.model = this;
            HospitalizationRequestCombinedViewModel.model = this;
        }

        private string _currentUserControl;
        public string CurrentUserControl
        {
            get { return _currentUserControl; }
            set { _currentUserControl = value; OnPropertyChanged("CurrentUserControl"); }
        }
    }
}
