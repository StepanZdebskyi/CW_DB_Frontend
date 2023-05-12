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
    public class CompleteAddingDoctorsSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingDoctorsSheduleCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentDoctorsSheduleRecord.SheduleItemID = _model.aspViewModel.AllDoctorsSheduleRecords.Max(o => o.SheduleItemID) + 1;
            DoctorsSheduleViewModel newObj = new DoctorsSheduleViewModel(_model.aspViewModel.CurrentDoctorsSheduleRecord);
            DoctorsSheduleModel infoModel = Mapper.Map<DoctorsSheduleViewModel, DoctorsSheduleModel>(newObj);
            var result = _model.aspDataModel.GetDoctorsSheduleConnection().AddRecord(infoModel);
            
            _model.CurrentUserControl = "DoctorsSheduleControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllDoctorsSheduleRecords.Add(newObj);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
