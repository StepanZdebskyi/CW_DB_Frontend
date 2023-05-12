using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW_DB_Frontend.Model.ASP_NET_Connection;
using CW_DB_Frontend.Model.Models;

namespace CW_DB_Frontend.Model.ASP_NET_Model
{
    public class AspDataModel
    {
        private readonly string DoctorsAddress = "http://localhost:44359/api/Doctors";
        private readonly string DoctorsInfoAddress = "http://localhost:44359/api/DoctorsInfo";
        private readonly string DoctorsSheduleAddress = "http://localhost:44359/api/DoctorsShedule";
        private readonly string HospitalizationRequestsAddress = "http://localhost:44359/api/HospitalizationRequests";
        private readonly string MedicalRecordsAddress = "http://localhost:44359/api/MedicalRecords";
        private readonly string PatientAttendingDoctorsAddress = "http://localhost:44359/api/PatientAttendingDoctors";
        private readonly string PatientCasesAddress = "http://localhost:44359/api/PatientsCases";
        private readonly string PatientsAddress = "http://localhost:44359/api/Patients";
        private readonly string SpecialitiesAddress = "http://localhost:44359/api/Specialities";
        private readonly string VacantionsSheduleAddress = "http://localhost:44359/api/VacantionsShedule";

        public IEnumerable<DoctorModel> AllDoctors { get; set; }
        public IEnumerable<DoctorsInfoModel> AllDoctorsInfo { get; set; }
        public IEnumerable<DoctorsSheduleModel> AllDoctorsSheduleRecords { get; set; }
        public IEnumerable<HospitalizationRequestModel> AllHospRequests { get; set; }
        public IEnumerable<MedicalRecordModel> AllMedRecords { get; set; }
        public IEnumerable<PatientAttendingDoctorsModel> AllPatAttendDocRecords { get; set; }
        public IEnumerable<PatientCaseModel> AllCases { get; set; }
        public IEnumerable<PatientModel> AllPatients { get; set; }
        public IEnumerable<SpecialityModel> AllSpecs { get; set;}
        public IEnumerable<VacantionSheduleModel> AllVacSheduleRecords { get; set; }
        public List<DoctorCombinedModel> AllDoctorsCombined { get; set; }
        public List<HospitalizationRequestCombinedModel> AllHospRequestsCombined { get; set; }

        private DoctorsConnection doctorsConn;
        private DoctorsInfoConnection doctorsInfoConn;
        private DoctorsSheduleConnection doctorsSheduleConn;
        private HospitalizationRequestsConnection hospRequestsConn;
        private MedicalRecordsConnection medicalRecConn;
        private PatientAttendingDoctorsConnection patAttendDocConn;
        private PatientCasesConnection patCasesConn;
        private PatientsConnection patientsConn;
        private SpecialityConnection specConn;
        private VacantionsSheduleConnection vacantionConn;

        public AspDataModel()
        {
            doctorsConn = new DoctorsConnection(DoctorsAddress);
            doctorsInfoConn = new DoctorsInfoConnection(DoctorsInfoAddress);
            doctorsSheduleConn = new DoctorsSheduleConnection(DoctorsSheduleAddress);
            hospRequestsConn = new HospitalizationRequestsConnection(HospitalizationRequestsAddress);
            medicalRecConn = new MedicalRecordsConnection(MedicalRecordsAddress);
            patAttendDocConn = new PatientAttendingDoctorsConnection(PatientAttendingDoctorsAddress);
            patCasesConn = new PatientCasesConnection(PatientCasesAddress);
            patientsConn = new PatientsConnection(PatientsAddress);
            specConn = new SpecialityConnection(SpecialitiesAddress);
            vacantionConn = new VacantionsSheduleConnection(VacantionsSheduleAddress);

            AllDoctors = doctorsConn.GetDoctors();
            AllDoctorsInfo = doctorsInfoConn.GetInfo();
            AllDoctorsSheduleRecords = doctorsSheduleConn.GetShedule();
            AllHospRequests = hospRequestsConn.GetRequests();
            AllMedRecords = medicalRecConn.GetRecords();
            AllPatAttendDocRecords = patAttendDocConn.GetRecords();
            AllCases = patCasesConn.GetCases();
            AllPatients = patientsConn.GetPatients();
            AllSpecs = specConn.GetSpecs();
            AllVacSheduleRecords = vacantionConn.GetShedule();
            AllDoctorsCombined = new List<DoctorCombinedModel>();
            AllHospRequestsCombined = new List<HospitalizationRequestCombinedModel>();

            //AllDoctorsCombined init
            var result = from doc in AllDoctors
                         join spec in AllSpecs
                         on doc.SpecID equals spec.SpecID
                         join info in AllDoctorsInfo
                         on doc.DoctorID equals info.DoctorID
                         select new
                         {
                             DoctorID = doc.DoctorID,
                             DoctorName = doc.DoctorName,
                             DoctorSurname = doc.DoctorSurname,
                             SpecName = spec.SpecName,
                             DoctorExperience = info.DoctorExperience,
                             DoctorGraduation = info.DoctorGraduation,
                             DoctorSalary = info.DoctorSalary,
                             DoctorRemarks = info.DoctorRemarks
                         };

            foreach (var elem in result)
            {
                AllDoctorsCombined.Add(new DoctorCombinedModel()
                {
                    DoctorID = elem.DoctorID,
                    DoctorName = elem.DoctorName,
                    DoctorSurname = elem.DoctorSurname,
                    DoctorExperience = elem.DoctorExperience,
                    SpecName = elem.SpecName,
                    DoctorGraduation = elem.DoctorGraduation,
                    DoctorRemarks = elem.DoctorRemarks,
                    DoctorSalary = elem.DoctorSalary
                });
            }

            // AllHospRequestsCombined init

            var result1 = from hosp in AllHospRequests
                          join pat in AllPatients
                          on hosp.PatientID equals pat.PatientID
                          select new
                          {
                              RequestID = hosp.RequestID,
                              PatientID = hosp.PatientID,
                              HealthComplaints = hosp.HealthComplaints,
                              ClinicName = hosp.ClinicName,
                              RequestDate = hosp.RequestDate,
                              IsRequestProcessed = hosp.IsRequestProcessed,
                              PatientName = pat.PatientName,
                              PatientSurname = pat.PatientSurname,
                              PatientAge = pat.PatientAge,
                              PatientGender = pat.PatientGender,
                              PatientPassportNumber = pat.PatientPassportNumber
                          };

            foreach (var elem in result1)
            {
                AllHospRequestsCombined.Add(new HospitalizationRequestCombinedModel()
                {
                    RequestID = elem.RequestID,
                    PatientID = elem.PatientID,
                    HealthComplaints = elem.HealthComplaints,
                    ClinicName = elem.ClinicName,
                    RequestDate = elem.RequestDate,
                    IsRequestProcessed = elem.IsRequestProcessed,
                    PatientName = elem.PatientName,
                    PatientSurname = elem.PatientSurname,
                    PatientAge = elem.PatientAge,
                    PatientGender = elem.PatientGender,
                    PatientPassportNumber = elem.PatientPassportNumber
                });
            }
        }

        public DoctorsConnection GetDoctorsConnection()
        {
            return doctorsConn; 
        }

        public DoctorsInfoConnection GetDoctorsInfoConnection()
        {
            return doctorsInfoConn; 
        }

        public DoctorsSheduleConnection GetDoctorsSheduleConnection()
        {
            return doctorsSheduleConn; 
        }

        public HospitalizationRequestsConnection GetHospitalizationRequestsConnection()
        {
            return hospRequestsConn; 
        }

        public MedicalRecordsConnection GetMedicalRecordsConnection()
        {
            return medicalRecConn; 
        }

        public PatientAttendingDoctorsConnection GetPatientAttendingDoctorsConnection()
        {
            return patAttendDocConn; 
        }

        public PatientCasesConnection GetPatientCasesConnection()
        {
            return patCasesConn; 
        }

        public PatientsConnection GetPatientsConnection()
        {
            return patientsConn; 
        }

        public SpecialityConnection GetSpecialityConnection()
        {
            return specConn; 
        }

        public VacantionsSheduleConnection GetVacantionsSheduleConnection()
        {
            return vacantionConn; 
        }
    }
}
