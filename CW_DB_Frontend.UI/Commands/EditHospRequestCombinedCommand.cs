using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using CW_DB_Frontend.Model.Models;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.ViewModels;

namespace CW_DB_Frontend.UI.Commands
{
    public class EditHospRequestCombinedCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly HospitalizationRequestCombinedViewModel curRecord;

        public EditHospRequestCombinedCommand(MyViewModel mdl, HospitalizationRequestCombinedViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            HospitalizationRequestCombinedViewModel rec = new HospitalizationRequestCombinedViewModel(curRecord);

            if (!_model.aspDataModel.AllPatients.Any(o => o.PatientPassportNumber == curRecord.PatientPassportNumber))
            {
                rec = new HospitalizationRequestCombinedViewModel(Mapper.Map<HospitalizationRequestCombinedModel, HospitalizationRequestCombinedViewModel>(_model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID)));
                MessageBox.Show("Incorrect patient's passport ID!", "Message");
            }
            else
            {
                int patID = _model.aspDataModel.AllPatients.First(o => o.PatientPassportNumber == curRecord.PatientPassportNumber).PatientID;

                HospitalizationRequestModel requestModel = Mapper.Map<HospitalizationRequestViewModel, HospitalizationRequestModel>(new HospitalizationRequestViewModel()
                {
                    RequestID = curRecord.RequestID, 
                    HealthComplaints = curRecord.HealthComplaints, 
                    ClinicName = curRecord.ClinicName, 
                    IsRequestProcessed = curRecord.IsRequestProcessed, 
                    PatientID = patID, 
                    RequestDate = curRecord.RequestDate
                });

                var result1 = _model.aspDataModel.GetHospitalizationRequestsConnection().EditRequest(requestModel);

                if (!result1.Contains("Record updated successfully!"))
                {
                    MessageBox.Show(result1, "Message");
                }
                else
                {
                    rec.PatientName = _model.aspViewModel.AllPatients.First(o => o.PatientID == patID).PatientName;
                    rec.PatientSurname = _model.aspViewModel.AllPatients.First(o => o.PatientID == patID).PatientSurname;
                    rec.PatientID = patID;
                    rec.PatientGender = _model.aspViewModel.AllPatients.First(o => o.PatientID == patID).PatientGender;
                    rec.PatientAge = _model.aspViewModel.AllPatients.First(o => o.PatientID == patID).PatientAge;

                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).HealthComplaints = rec.HealthComplaints;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).IsRequestProcessed = rec.IsRequestProcessed;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientAge = rec.PatientAge;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientGender = rec.PatientGender;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientID = rec.PatientID;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientName = rec.PatientName;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientPassportNumber = rec.PatientPassportNumber;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientSurname = rec.PatientSurname;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).RequestDate = rec.RequestDate;
                    _model.aspDataModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).ClinicName = rec.ClinicName;
                }
            }

            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).HealthComplaints = rec.HealthComplaints;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).IsRequestProcessed = rec.IsRequestProcessed;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientAge = rec.PatientAge;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientGender = rec.PatientGender;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientID = rec.PatientID;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientName = rec.PatientName;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientPassportNumber = rec.PatientPassportNumber;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).PatientSurname = rec.PatientSurname;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).RequestDate = rec.RequestDate;
            _model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID).ClinicName = rec.ClinicName;
        }
    }
}
