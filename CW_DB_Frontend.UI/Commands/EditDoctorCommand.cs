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
    public class EditDoctorCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorViewModel curRecord;

        public EditDoctorCommand(MyViewModel mdl, DoctorViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorModel doctorModel = Mapper.Map<DoctorViewModel, DoctorModel>(curRecord);
            var result = _model.aspDataModel.GetDoctorsConnection().EditDoctor(doctorModel);

            DoctorViewModel rec = new DoctorViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<DoctorModel> allRecords = _model.aspDataModel.GetDoctorsConnection().GetDoctors();
                rec = Mapper.Map<DoctorModel, DoctorViewModel>(allRecords.First(o => o.DoctorID == curRecord.DoctorID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllDoctors.First(o => o.DoctorID == curRecord.DoctorID).DoctorName = rec.DoctorName;
            _model.aspViewModel.AllDoctors.First(o => o.DoctorID == curRecord.DoctorID).DoctorSurname = rec.DoctorSurname;
            _model.aspViewModel.AllDoctors.First(o => o.DoctorID == curRecord.DoctorID).SpecID = rec.SpecID;

        }
    }
}
