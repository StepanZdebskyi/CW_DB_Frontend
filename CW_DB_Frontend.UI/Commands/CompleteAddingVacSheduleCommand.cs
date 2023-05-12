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
    public class CompleteAddingVacSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingVacSheduleCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentVacantionSheduleRecord.SheduleItemID = _model.aspViewModel.AllVacSheduleRecords.Max(o => o.SheduleItemID) + 1;
            VacantionSheduleViewModel newRec = new VacantionSheduleViewModel(_model.aspViewModel.CurrentVacantionSheduleRecord);
            VacantionSheduleModel infoModel = Mapper.Map<VacantionSheduleViewModel, VacantionSheduleModel>(newRec);
            var result = _model.aspDataModel.GetVacantionsSheduleConnection().AddRecord(infoModel);
            
            _model.CurrentUserControl = "VacSheduleControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllVacSheduleRecords.Add(newRec);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
