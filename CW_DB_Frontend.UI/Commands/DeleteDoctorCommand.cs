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
    public class DeleteDoctorCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorViewModel curDoctor;

        public DeleteDoctorCommand(MyViewModel mdl, DoctorViewModel doc)
        {
            curDoctor = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorModel doctorModel = Mapper.Map<DoctorViewModel, DoctorModel>(curDoctor);
            _model.aspDataModel.GetDoctorsConnection().DeleteDoctor(doctorModel);

            _model.aspViewModel.AllDoctors.Remove(_model.aspViewModel.AllDoctors.First(o => o.DoctorID == curDoctor.DoctorID));
        }
    }
}
