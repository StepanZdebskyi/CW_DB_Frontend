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
    public class CompleteAddingMedRecordCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingMedRecordCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentMedicalRecord.RecordID = _model.aspViewModel.AllMedRecords.Max(o => o.RecordID) + 1;
            MedicalRecordViewModel newRec = new MedicalRecordViewModel(_model.aspViewModel.CurrentMedicalRecord);
            MedicalRecordModel infoModel = Mapper.Map<MedicalRecordViewModel, MedicalRecordModel>(newRec);
            var result = _model.aspDataModel.GetMedicalRecordsConnection().AddRecord(infoModel);
            
            _model.CurrentUserControl = "MedRecordsControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllMedRecords.Add(newRec);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
