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
    public class EditDoctorsInfoCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorsInfoViewModel curRecord;

        public EditDoctorsInfoCommand(MyViewModel mdl, DoctorsInfoViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorsInfoModel doctorModel = Mapper.Map<DoctorsInfoViewModel, DoctorsInfoModel>(curRecord);
            var result = _model.aspDataModel.GetDoctorsInfoConnection().EditInfo(doctorModel);

            DoctorsInfoViewModel rec = new DoctorsInfoViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<DoctorsInfoModel> allRecords = _model.aspDataModel.GetDoctorsInfoConnection().GetInfo();
                rec = Mapper.Map<DoctorsInfoModel, DoctorsInfoViewModel>(allRecords.First(o => o.DoctorID == curRecord.DoctorID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllDoctorsInfo.First(o => o.DoctorID == curRecord.DoctorID).DoctorExperience = rec.DoctorExperience;
            _model.aspViewModel.AllDoctorsInfo.First(o => o.DoctorID == curRecord.DoctorID).DoctorGraduation = rec.DoctorGraduation;
            _model.aspViewModel.AllDoctorsInfo.First(o => o.DoctorID == curRecord.DoctorID).DoctorSalary = rec.DoctorSalary;
            _model.aspViewModel.AllDoctorsInfo.First(o => o.DoctorID == curRecord.DoctorID).DoctorRemarks = rec.DoctorRemarks;

        }
    }
}
