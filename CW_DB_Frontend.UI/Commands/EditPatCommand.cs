using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CW_DB_Frontend.Model.Models;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.ViewModels;
using System.Windows;

namespace CW_DB_Frontend.UI.Commands
{
    public class EditPatCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly PatientViewModel curRecord;

        public EditPatCommand(MyViewModel mdl, PatientViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        { 
            PatientModel recordModel = Mapper.Map<PatientViewModel, PatientModel>(curRecord);
            string result = _model.aspDataModel.GetPatientsConnection().EditPatient(recordModel);
            
            PatientViewModel rec = new PatientViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<PatientModel> allPats = _model.aspDataModel.GetPatientsConnection().GetPatients();
                rec = Mapper.Map<PatientModel, PatientViewModel>(allPats.First(o => o.PatientID == curRecord.PatientID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID).PatientName = rec.PatientName;
            _model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID).PatientSurname = rec.PatientSurname;
            _model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID).PatientAge = rec.PatientAge;
            _model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID).PatientGender = rec.PatientGender;
            _model.aspViewModel.AllPatients.First(o => o.PatientID == curRecord.PatientID).PatientPassportNumber = rec.PatientPassportNumber;
        }
    }
}
