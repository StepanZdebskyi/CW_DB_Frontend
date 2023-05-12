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
    public class CompleteAddingPatAttendDocCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingPatAttendDocCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentPatAttendDocRecord.RecordID = _model.aspViewModel.AllPatAttendDocRecords.Max(o => o.RecordID) + 1;
            PatientAttendingDoctorsViewModel newRec = new PatientAttendingDoctorsViewModel(_model.aspViewModel.CurrentPatAttendDocRecord);
            PatientAttendingDoctorsModel infoModel = Mapper.Map<PatientAttendingDoctorsViewModel, PatientAttendingDoctorsModel>(newRec);
            var result = _model.aspDataModel.GetPatientAttendingDoctorsConnection().AddRecord(infoModel);
            
            _model.CurrentUserControl = "PatAttendDocControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllPatAttendDocRecords.Add(newRec);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
