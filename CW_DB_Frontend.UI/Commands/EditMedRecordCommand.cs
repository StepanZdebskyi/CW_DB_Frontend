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
    public class EditMedRecordCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly MedicalRecordViewModel curRecord;

        public EditMedRecordCommand(MyViewModel mdl, MedicalRecordViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            MedicalRecordModel recordModel = Mapper.Map<MedicalRecordViewModel, MedicalRecordModel>(curRecord);
            var result = _model.aspDataModel.GetMedicalRecordsConnection().EditRecord(recordModel);

            MedicalRecordViewModel rec = new MedicalRecordViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<MedicalRecordModel> allRecords = _model.aspDataModel.GetMedicalRecordsConnection().GetRecords();
                rec = Mapper.Map<MedicalRecordModel, MedicalRecordViewModel>(allRecords.First(o => o.RecordID == curRecord.RecordID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).DoctorID = rec.DoctorID;
            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).RecordTime = rec.RecordTime;
            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).RecordDate = rec.RecordDate;
            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).RecordBody = rec.RecordBody;
            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).RecordHeader = rec.RecordHeader;
            _model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID).PatientID = rec.PatientID;

        }
    }
}
