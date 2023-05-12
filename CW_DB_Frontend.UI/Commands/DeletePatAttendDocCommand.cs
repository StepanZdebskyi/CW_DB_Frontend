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
    public class DeletePatAttendDocCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientAttendingDoctorsViewModel curRecord;

        public DeletePatAttendDocCommand(MyViewModel mdl, PatientAttendingDoctorsViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            PatientAttendingDoctorsModel infoModel = Mapper.Map<PatientAttendingDoctorsViewModel, PatientAttendingDoctorsModel>(curRecord);
            _model.aspDataModel.GetPatientAttendingDoctorsConnection().DeleteRecord(infoModel);

            _model.aspViewModel.AllPatAttendDocRecords.Remove(_model.aspViewModel.AllPatAttendDocRecords.First(o => o.RecordID == curRecord.RecordID));
        }
    }
}
