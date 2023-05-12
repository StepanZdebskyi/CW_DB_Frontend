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
    public class EditDoctorsSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorsSheduleViewModel curRecord;

        public EditDoctorsSheduleCommand(MyViewModel mdl, DoctorsSheduleViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorsSheduleModel recordModel = Mapper.Map<DoctorsSheduleViewModel, DoctorsSheduleModel>(curRecord);
            var result = _model.aspDataModel.GetDoctorsSheduleConnection().EditRecord(recordModel);

            DoctorsSheduleViewModel rec = new DoctorsSheduleViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<DoctorsSheduleModel> allRecords = _model.aspDataModel.GetDoctorsSheduleConnection().GetShedule();
                rec = Mapper.Map<DoctorsSheduleModel, DoctorsSheduleViewModel>(allRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllDoctorsSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).DoctorID = rec.DoctorID;
            _model.aspViewModel.AllDoctorsSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).WorkDate = rec.WorkDate;
            _model.aspViewModel.AllDoctorsSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).StartWorkTime = rec.StartWorkTime;
            _model.aspViewModel.AllDoctorsSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID).FinishWorkTime = rec.FinishWorkTime;

        }
    }
}
