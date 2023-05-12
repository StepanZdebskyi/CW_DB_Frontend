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
    public class EditPatCaseCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientCaseViewModel curRecord;

        public EditPatCaseCommand(MyViewModel mdl, PatientCaseViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            PatientCaseModel recordModel = Mapper.Map<PatientCaseViewModel, PatientCaseModel>(curRecord);
            var result = _model.aspDataModel.GetPatientCasesConnection().EditCase(recordModel);

            PatientCaseViewModel rec = new PatientCaseViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<PatientCaseModel> allRecords = _model.aspDataModel.GetPatientCasesConnection().GetCases();
                rec = Mapper.Map<PatientCaseModel, PatientCaseViewModel>(allRecords.First(o => o.CaseID == curRecord.CaseID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).PatientID = rec.PatientID;
            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).IsCaseClosed = rec.IsCaseClosed;
            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).IllnessDescription = rec.IllnessDescription;
            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).Remarks = rec.Remarks;
            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).CaseOpeningDate = rec.CaseOpeningDate;
            _model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID).ConclusionsNotes = rec.ConclusionsNotes;
        }
    }
}
