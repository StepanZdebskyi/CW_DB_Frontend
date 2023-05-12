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
    public class DeleteDoctorsSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorsSheduleViewModel curRecord;

        public DeleteDoctorsSheduleCommand(MyViewModel mdl, DoctorsSheduleViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorsSheduleModel infoModel = Mapper.Map<DoctorsSheduleViewModel, DoctorsSheduleModel>(curRecord);
            _model.aspDataModel.GetDoctorsSheduleConnection().DeleteRecord(infoModel);

            _model.aspViewModel.AllDoctorsSheduleRecords.Remove(_model.aspViewModel.AllDoctorsSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID));
        }
    }
}
