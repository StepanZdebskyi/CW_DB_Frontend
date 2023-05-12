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
    public class CompleteAddingPatCaseCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingPatCaseCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentPatientCase.CaseID = _model.aspViewModel.AllCases.Max(o => o.CaseID) + 1;
            PatientCaseViewModel newRec = new PatientCaseViewModel(_model.aspViewModel.CurrentPatientCase);
            PatientCaseModel infoModel = Mapper.Map<PatientCaseViewModel, PatientCaseModel>(newRec);
            var result = _model.aspDataModel.GetPatientCasesConnection().AddCase(infoModel);
            
            _model.CurrentUserControl = "PatCasesControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllCases.Add(newRec);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
