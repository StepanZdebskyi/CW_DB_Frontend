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
    public class DeletePatCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientViewModel curRecord;

        public DeletePatCommand(MyViewModel mdl, PatientViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            PatientModel infoModel = Mapper.Map<PatientViewModel, PatientModel>(curRecord);
            _model.aspDataModel.GetPatientsConnection().DeletePatient(infoModel);

            _model.aspViewModel.AllPatients.Remove(_model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID));
        }
    }
}
