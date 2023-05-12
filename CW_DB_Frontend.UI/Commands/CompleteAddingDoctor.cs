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
    public class CompleteAddingDoctor : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingDoctor(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentDoctor.DoctorID = _model.aspViewModel.AllDoctors.Max(o => o.DoctorID) + 1;
            DoctorViewModel newObj = new DoctorViewModel(_model.aspViewModel.CurrentDoctor);
            DoctorModel doctorModel = Mapper.Map<DoctorViewModel, DoctorModel>(newObj);
            var result = _model.aspDataModel.GetDoctorsConnection().AddDoctor(doctorModel);
            
            _model.CurrentUserControl = "DoctorsControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllDoctors.Add(newObj);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }
        }
    }
}
