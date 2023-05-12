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
    public class EditPatAttendDocCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientAttendingDoctorsViewModel curRecord;

        public EditPatAttendDocCommand(MyViewModel mdl, PatientAttendingDoctorsViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            PatientAttendingDoctorsModel recordModel = Mapper.Map<PatientAttendingDoctorsViewModel, PatientAttendingDoctorsModel>(curRecord);
            var result = _model.aspDataModel.GetPatientAttendingDoctorsConnection().EditRecord(recordModel);

            PatientAttendingDoctorsViewModel rec = new PatientAttendingDoctorsViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<PatientAttendingDoctorsModel> allRecords = _model.aspDataModel.GetPatientAttendingDoctorsConnection().GetRecords();
                rec = Mapper.Map<PatientAttendingDoctorsModel, PatientAttendingDoctorsViewModel>(allRecords.First(o => o.RecordID == curRecord.RecordID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllPatAttendDocRecords.First(o => o.RecordID == curRecord.RecordID).DoctorID = rec.DoctorID;
            _model.aspViewModel.AllPatAttendDocRecords.First(o => o.RecordID == curRecord.RecordID).PatientID = rec.PatientID;
        }
    }
}
