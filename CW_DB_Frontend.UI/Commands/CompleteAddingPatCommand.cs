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
    public class CompleteAddingPatCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingPatCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentPatient.PatientID = _model.aspViewModel.AllPatients.Max(o => o.PatientID) + 1;
            PatientViewModel newRec = new PatientViewModel(_model.aspViewModel.CurrentPatient);
            PatientModel infoModel = Mapper.Map<PatientViewModel, PatientModel>(newRec);
            var result = _model.aspDataModel.GetPatientsConnection().AddPatient(infoModel);

            _model.CurrentUserControl = "PatControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllPatients.Add(newRec);
            }
            else
            {
                 MessageBox.Show(result, "Message");
            }
        }
    }
}
