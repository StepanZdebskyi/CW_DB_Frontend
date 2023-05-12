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
    public class DeleteDoctorCombinedCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorCombinedViewModel curDoctor;

        public DeleteDoctorCombinedCommand(MyViewModel mdl, DoctorCombinedViewModel doc)
        {
            curDoctor = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorModel doctorModel = Mapper.Map<DoctorViewModel, DoctorModel>(new DoctorViewModel() { 
            DoctorID = curDoctor.DoctorID, 
            });

            _model.aspDataModel.GetDoctorsConnection().DeleteDoctor(doctorModel);

            _model.aspViewModel.AllDoctorsCombined.Remove(_model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curDoctor.DoctorID));
        }
    }
}
