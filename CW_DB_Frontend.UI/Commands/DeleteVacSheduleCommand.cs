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
    public class DeleteVacSheduleCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly VacantionSheduleViewModel curRecord;

        public DeleteVacSheduleCommand(MyViewModel mdl, VacantionSheduleViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            VacantionSheduleModel infoModel = Mapper.Map<VacantionSheduleViewModel, VacantionSheduleModel>(curRecord);
            _model.aspDataModel.GetVacantionsSheduleConnection().DeleteRecord(infoModel);

            _model.aspViewModel.AllVacSheduleRecords.Remove(_model.aspViewModel.AllVacSheduleRecords.First(o => o.SheduleItemID == curRecord.SheduleItemID));
        }
    }
}
