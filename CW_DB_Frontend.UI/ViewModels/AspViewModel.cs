using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW_DB_Frontend.UI.Base;

namespace CW_DB_Frontend.UI.ViewModels
{
    public class AspViewModel : ViewModelBase
    {
        public AspViewModel()
        {
            CurrentDoctor = new DoctorViewModel();
            CurrentDoctorsInfo = new DoctorsInfoViewModel();
            CurrentDoctorsSheduleRecord = new DoctorsSheduleViewModel();
            CurrentHospitalizaionRequest = new HospitalizationRequestViewModel();
            CurrentMedicalRecord = new MedicalRecordViewModel();
            CurrentPatAttendDocRecord = new PatientAttendingDoctorsViewModel();
            CurrentPatient = new PatientViewModel();
            CurrentPatientCase = new PatientCaseViewModel();
            CurrentSpec = new SpecialityViewModel();
            CurrentVacantionSheduleRecord = new VacantionSheduleViewModel();
            CurrentDoctorsCombined = new DoctorCombinedViewModel();
        }

        private HospitalizationRequestCombinedViewModel _currentHospRequestCombined;
        public HospitalizationRequestCombinedViewModel CurrentHospRequestCombined
        {
            get { return _currentHospRequestCombined; }
            set { _currentHospRequestCombined = value; OnPropertyChanged("CurrentHospRequestCombined"); }
        }

        private DoctorCombinedViewModel _currentDoctorsCombined;
        public DoctorCombinedViewModel CurrentDoctorsCombined
        {
            get { return _currentDoctorsCombined; }
            set { _currentDoctorsCombined = value; OnPropertyChanged("CurrentDoctorsCombined"); }
        }

        private DoctorsInfoViewModel _currentDoctorsInfo;
        public DoctorsInfoViewModel CurrentDoctorsInfo
        {
            get { return _currentDoctorsInfo; }
            set { _currentDoctorsInfo = value;  OnPropertyChanged("CurrentDoctorsInfo"); }
        }

        private DoctorsSheduleViewModel _currentDoctorsSheduleRecord;
        public DoctorsSheduleViewModel CurrentDoctorsSheduleRecord
        {
            get { return _currentDoctorsSheduleRecord; }
            set { _currentDoctorsSheduleRecord = value; OnPropertyChanged("CurrentDoctorsSheduleRecord"); }
        }

        private DoctorViewModel _currentDoctor;
        public DoctorViewModel CurrentDoctor 
        {
            get { return _currentDoctor; }
            set { _currentDoctor = value; OnPropertyChanged("CurrentDoctor"); }
        }

        private HospitalizationRequestViewModel _currentHospitalizationRequest;
        public HospitalizationRequestViewModel CurrentHospitalizaionRequest
        {
            get { return _currentHospitalizationRequest; }
            set { _currentHospitalizationRequest = value; OnPropertyChanged("CurrentHospitalizaionRequest"); }
        }

        private MedicalRecordViewModel _currentMedicalRecord;
        public MedicalRecordViewModel CurrentMedicalRecord
        {
            get { return _currentMedicalRecord; }
            set { _currentMedicalRecord = value; OnPropertyChanged("CurrentMedicalRecord"); }
        }

        private PatientAttendingDoctorsViewModel _currentPatAttendDocRecord;
        public PatientAttendingDoctorsViewModel CurrentPatAttendDocRecord
        {
            get { return _currentPatAttendDocRecord; }
            set { _currentPatAttendDocRecord = value; OnPropertyChanged("CurrentPatAttendDocRecord"); }
        }

        private PatientCaseViewModel _currentPatientCase;
        public PatientCaseViewModel CurrentPatientCase
        {
            get { return _currentPatientCase; }
            set { _currentPatientCase = value; OnPropertyChanged("CurrentPatientCase"); }
        }

        private PatientViewModel _currentPatient;
        public PatientViewModel CurrentPatient
        {
            get { return _currentPatient; }
            set { _currentPatient = value; OnPropertyChanged("CurrentPatient"); }
        }

        private SpecialityViewModel _currentSpec;
        public SpecialityViewModel CurrentSpec
        {
            get { return _currentSpec; }
            set { _currentSpec = value; OnPropertyChanged("CurrentSpec"); }
        }

        private VacantionSheduleViewModel _currentVacantionSheduleRecord;
        public VacantionSheduleViewModel CurrentVacantionSheduleRecord
        {
            get { return _currentVacantionSheduleRecord; }
            set { _currentVacantionSheduleRecord = value; OnPropertyChanged("CurrentVacantionSheduleRecord"); }
        }

        private ObservableCollection<HospitalizationRequestCombinedViewModel> _allHospRequestsCombined;
        public ObservableCollection<HospitalizationRequestCombinedViewModel> AllHospRequestsCombined
        {
            get { return _allHospRequestsCombined; }
            set { _allHospRequestsCombined = value; OnPropertyChanged("AllHospRequestsCombined"); }
        }

        private ObservableCollection<DoctorCombinedViewModel> _allDoctorsCombined;
        public ObservableCollection<DoctorCombinedViewModel> AllDoctorsCombined
        {
            get { return _allDoctorsCombined; }
            set { _allDoctorsCombined = value; OnPropertyChanged("AllDoctorsCombined"); }
        }

        private ObservableCollection<DoctorsInfoViewModel> _allDoctorsInfo;
        public ObservableCollection<DoctorsInfoViewModel> AllDoctorsInfo
        {
            get { return _allDoctorsInfo; }
            set { _allDoctorsInfo = value; OnPropertyChanged("AllDoctorsInfo"); }
        }

        private ObservableCollection<DoctorsSheduleViewModel> _allDoctorsSheduleRecords;
        public ObservableCollection<DoctorsSheduleViewModel> AllDoctorsSheduleRecords
        {
            get { return _allDoctorsSheduleRecords; }
            set { _allDoctorsSheduleRecords = value; OnPropertyChanged("AllDoctorsSheduleRecords"); }
        }

        private ObservableCollection<DoctorViewModel> _allDoctors;
        public ObservableCollection<DoctorViewModel> AllDoctors
        {
            get { return _allDoctors; }
            set { _allDoctors = value; OnPropertyChanged("AllDoctors"); }
        }

        private ObservableCollection<HospitalizationRequestViewModel> _allHospRequests;
        public ObservableCollection<HospitalizationRequestViewModel> AllHospRequests
        {
            get { return _allHospRequests; }
            set { _allHospRequests = value; OnPropertyChanged("AllHospRequests"); }
        }

        private ObservableCollection<MedicalRecordViewModel> _allMedRecords;
        public ObservableCollection<MedicalRecordViewModel> AllMedRecords
        {
            get { return _allMedRecords; }
            set { _allMedRecords = value; OnPropertyChanged("AllMedRecords"); }
        }

        private ObservableCollection<PatientAttendingDoctorsViewModel> _allPatAttendDocRecords;
        public ObservableCollection<PatientAttendingDoctorsViewModel> AllPatAttendDocRecords
        {
            get { return _allPatAttendDocRecords; }
            set { _allPatAttendDocRecords = value; OnPropertyChanged("AllPatAttendDocRecords"); }
        }

        private ObservableCollection<PatientCaseViewModel> _allCases;
        public ObservableCollection<PatientCaseViewModel> AllCases
        {
            get { return _allCases; }
            set { _allCases = value; OnPropertyChanged("AllCases"); }
        }

        private ObservableCollection<PatientViewModel> _allPatients;
        public ObservableCollection<PatientViewModel> AllPatients
        {
            get { return _allPatients; }
            set { _allPatients = value; OnPropertyChanged("AllPatients"); }
        }

        private ObservableCollection<SpecialityViewModel> _allSpecs;
        public ObservableCollection<SpecialityViewModel> AllSpecs
        {
            get { return _allSpecs; }
            set { _allSpecs = value; OnPropertyChanged("AllSpecs"); }
        }

        private ObservableCollection<VacantionSheduleViewModel> _allVacSheduleRecords;
        public ObservableCollection<VacantionSheduleViewModel> AllVacSheduleRecords
        {
            get { return _allVacSheduleRecords; }
            set { _allVacSheduleRecords = value; OnPropertyChanged("AllVacSheduleRecords"); }
        }
    }
}
