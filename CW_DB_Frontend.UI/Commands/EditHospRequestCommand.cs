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
    public class EditHospRequestCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly HospitalizationRequestViewModel curRecord;

        public EditHospRequestCommand(MyViewModel mdl, HospitalizationRequestViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            HospitalizationRequestModel recordModel = Mapper.Map<HospitalizationRequestViewModel, HospitalizationRequestModel>(curRecord);
            var result = _model.aspDataModel.GetHospitalizationRequestsConnection().EditRequest(recordModel);

            HospitalizationRequestViewModel rec = new HospitalizationRequestViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<HospitalizationRequestModel> allRecords = _model.aspDataModel.GetHospitalizationRequestsConnection().GetRequests();
                rec = Mapper.Map<HospitalizationRequestModel, HospitalizationRequestViewModel>(allRecords.First(o => o.RequestID == curRecord.RequestID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID).HealthComplaints = rec.HealthComplaints;
            _model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID).PatientID = rec.PatientID;
            _model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID).RequestDate = rec.RequestDate;
            _model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID).IsRequestProcessed = rec.IsRequestProcessed;
            _model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID).ClinicName = rec.ClinicName;

        }
    }
}
