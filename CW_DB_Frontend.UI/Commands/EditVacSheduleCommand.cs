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
    public class EditVacSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly VacantionSheduleViewModel curRecord;

        public EditVacSheduleCommand(MyViewModel mdl, VacantionSheduleViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            VacantionSheduleModel recordModel = Mapper.Map<VacantionSheduleViewModel, VacantionSheduleModel>(curRecord);
            var result = _model.aspDataModel.GetVacantionsSheduleConnection().EditRecord(recordModel);

            VacantionSheduleViewModel rec = new VacantionSheduleViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<VacantionSheduleModel> allRecords = _model.aspDataModel.GetVacantionsSheduleConnection().GetShedule();
                rec = Mapper.Map<VacantionSheduleModel, VacantionSheduleViewModel>(allRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllVacSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).DoctorID = rec.DoctorID;
            _model.aspViewModel.AllVacSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).VacantionStartDate = rec.VacantionStartDate;
            _model.aspViewModel.AllVacSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).VacantionEndDate = rec.VacantionEndDate;
        }
    }
}
