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
    public class CompleteAddingHospRequestCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingHospRequestCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentHospitalizaionRequest.RequestID = _model.aspViewModel.AllHospRequests.Max(o => o.RequestID) + 1;
            HospitalizationRequestViewModel newObj = new HospitalizationRequestViewModel(_model.aspViewModel.CurrentHospitalizaionRequest);
            HospitalizationRequestModel infoModel = Mapper.Map<HospitalizationRequestViewModel, HospitalizationRequestModel>(newObj);
            var result = _model.aspDataModel.GetHospitalizationRequestsConnection().AddRequest(infoModel);
            
            _model.CurrentUserControl = "HospRequestsControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllHospRequests.Add(newObj);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
