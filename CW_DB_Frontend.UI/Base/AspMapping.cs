using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CW_DB_Frontend.Model.ASP_NET_Model;
using CW_DB_Frontend.Model.Models;
using CW_DB_Frontend.UI.ViewModels;

namespace CW_DB_Frontend.UI.Base
{
    public class AspMapping
    {
        public void Create()
        {
            Mapper.CreateMap<AspDataModel, AspViewModel>();
            Mapper.CreateMap<AspViewModel, AspDataModel>();

            Mapper.CreateMap<DoctorsInfoModel, DoctorsInfoViewModel>();
            Mapper.CreateMap<DoctorsInfoViewModel, DoctorsInfoModel>();

            Mapper.CreateMap<DoctorsSheduleModel, DoctorsSheduleViewModel>();
            Mapper.CreateMap<DoctorsSheduleViewModel, DoctorsSheduleModel>();

            Mapper.CreateMap<DoctorModel, DoctorViewModel>();
            Mapper.CreateMap<DoctorViewModel, DoctorModel>();

            Mapper.CreateMap<HospitalizationRequestModel, HospitalizationRequestViewModel>();
            Mapper.CreateMap<HospitalizationRequestViewModel, HospitalizationRequestModel>();

            Mapper.CreateMap<MedicalRecordModel, MedicalRecordViewModel>();
            Mapper.CreateMap<MedicalRecordViewModel, MedicalRecordModel>();

            Mapper.CreateMap<PatientAttendingDoctorsModel, PatientAttendingDoctorsViewModel>();
            Mapper.CreateMap<PatientAttendingDoctorsViewModel, PatientAttendingDoctorsModel>();
           
            Mapper.CreateMap<PatientCaseModel, PatientCaseViewModel>();
            Mapper.CreateMap<PatientCaseViewModel, PatientCaseModel>();

            Mapper.CreateMap<PatientModel, PatientViewModel>();
            Mapper.CreateMap<PatientViewModel, PatientModel>();

            Mapper.CreateMap<SpecialityModel, SpecialityViewModel>();
            Mapper.CreateMap<SpecialityViewModel, SpecialityModel>();

            Mapper.CreateMap<VacantionSheduleModel, VacantionSheduleViewModel>();
            Mapper.CreateMap<VacantionSheduleViewModel, VacantionSheduleModel>();

            Mapper.CreateMap<DoctorCombinedModel, DoctorCombinedViewModel>();
            Mapper.CreateMap<DoctorCombinedViewModel, DoctorCombinedModel>();

            Mapper.CreateMap<HospitalizationRequestCombinedModel, HospitalizationRequestCombinedViewModel>();
            Mapper.CreateMap<HospitalizationRequestCombinedViewModel, HospitalizationRequestCombinedModel>();
        }
    }
}
