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
    public class DeleteHospRequestCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly HospitalizationRequestViewModel curRecord;

        public DeleteHospRequestCommand(MyViewModel mdl, HospitalizationRequestViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            HospitalizationRequestModel infoModel = Mapper.Map<HospitalizationRequestViewModel, HospitalizationRequestModel>(curRecord);
            _model.aspDataModel.GetHospitalizationRequestsConnection().DeleteRequest(infoModel);

            _model.aspViewModel.AllHospRequests.Remove(_model.aspViewModel.AllHospRequests.First(o => o.RequestID == curRecord.RequestID));
        }
    }
}
