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
    public class DeleteMedRecordCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly MedicalRecordViewModel curRecord;

        public DeleteMedRecordCommand(MyViewModel mdl, MedicalRecordViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            MedicalRecordModel infoModel = Mapper.Map<MedicalRecordViewModel, MedicalRecordModel>(curRecord);
            _model.aspDataModel.GetMedicalRecordsConnection().DeleteRecord(infoModel);

            _model.aspViewModel.AllMedRecords.Remove(_model.aspViewModel.AllMedRecords.First(o => o.RecordID == curRecord.RecordID));
        }
    }
}
