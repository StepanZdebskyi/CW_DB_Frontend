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
    public class DeletePatCaseCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientCaseViewModel curRecord;

        public DeletePatCaseCommand(MyViewModel mdl, PatientCaseViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            PatientCaseModel infoModel = Mapper.Map<PatientCaseViewModel, PatientCaseModel>(curRecord);
            _model.aspDataModel.GetPatientCasesConnection().DeleteCase(infoModel);

            _model.aspViewModel.AllCases.Remove(_model.aspViewModel.AllCases.First(o => o.CaseID == curRecord.CaseID));
        }
    }
}
