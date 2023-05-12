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
    public class CompleteAddingDoctorsInfoCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingDoctorsInfoCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            //_model.aspViewModel.CurrentDoctorsInfo.DoctorID = _model.aspViewModel.AllDoctorsInfo.Max(o => o.DoctorID) + 1;
            DoctorsInfoViewModel newObj = new DoctorsInfoViewModel(_model.aspViewModel.CurrentDoctorsInfo);
            DoctorsInfoModel infoModel = Mapper.Map<DoctorsInfoViewModel, DoctorsInfoModel>(newObj);
            var result = _model.aspDataModel.GetDoctorsInfoConnection().AddInfo(infoModel);
            
            _model.CurrentUserControl = "DoctorsInfoControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllDoctorsInfo.Add(newObj);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }           
        }
    }
}
