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
    public class DeleteDoctorsInfoCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorsInfoViewModel curRecord;

        public DeleteDoctorsInfoCommand(MyViewModel mdl, DoctorsInfoViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorsInfoModel infoModel = Mapper.Map<DoctorsInfoViewModel, DoctorsInfoModel>(curRecord);
            _model.aspDataModel.GetDoctorsInfoConnection().DeleteInfo(infoModel);

            _model.aspViewModel.AllDoctorsInfo.Remove(_model.aspViewModel.AllDoctorsInfo.First(o => o.DoctorID == curRecord.DoctorID));
        }
    }
}
