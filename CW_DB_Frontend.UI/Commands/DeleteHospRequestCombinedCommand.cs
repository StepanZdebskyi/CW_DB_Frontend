using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CW_DB_Frontend.Model.Models;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.ViewModels;

namespace CW_DB_Frontend.UI.Commands
{
    public class DeleteHospRequestCombinedCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly HospitalizationRequestCombinedViewModel curRecord;

        public DeleteHospRequestCombinedCommand(MyViewModel mdl, HospitalizationRequestCombinedViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            HospitalizationRequestModel infoModel = Mapper.Map<HospitalizationRequestViewModel, HospitalizationRequestModel>(new HospitalizationRequestViewModel()
            {
                RequestID = curRecord.RequestID,
                HealthComplaints = curRecord.HealthComplaints,
                ClinicName = curRecord.ClinicName,
                IsRequestProcessed = curRecord.IsRequestProcessed,
                PatientID = curRecord.PatientID,
                RequestDate = curRecord.RequestDate
            });

            _model.aspDataModel.GetHospitalizationRequestsConnection().DeleteRequest(infoModel);

            _model.aspViewModel.AllHospRequestsCombined.Remove(_model.aspViewModel.AllHospRequestsCombined.First(o => o.RequestID == curRecord.RequestID));
        }
    }
}
