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
    public class EditDoctorCombinedCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly DoctorCombinedViewModel curRecord;

        public EditDoctorCombinedCommand(MyViewModel mdl, DoctorCombinedViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            DoctorCombinedViewModel rec = new DoctorCombinedViewModel(curRecord);

            if (!_model.aspDataModel.AllSpecs.Any(o => o.SpecName == curRecord.SpecName))
            {
                rec = new DoctorCombinedViewModel(Mapper.Map<DoctorCombinedModel, DoctorCombinedViewModel>(_model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID)));
                MessageBox.Show("Incorrect speciality name!", "Message");
            }
            else 
            {
                int specID = _model.aspDataModel.AllSpecs.First(o => o.SpecName == curRecord.SpecName).SpecID;

                DoctorsInfoModel doctorsInfoModel = Mapper.Map<DoctorsInfoViewModel, DoctorsInfoModel>(new DoctorsInfoViewModel()
                {
                    DoctorID = curRecord.DoctorID,
                    DoctorExperience = curRecord.DoctorExperience,
                    DoctorGraduation = curRecord.DoctorGraduation,
                    DoctorSalary = curRecord.DoctorSalary,
                    DoctorRemarks = curRecord.DoctorRemarks
                });

                var result1 = _model.aspDataModel.GetDoctorsInfoConnection().EditInfo(doctorsInfoModel);

                DoctorModel doctorModel = Mapper.Map<DoctorViewModel, DoctorModel>(new DoctorViewModel()
                {
                    DoctorID = curRecord.DoctorID,
                    DoctorName = curRecord.DoctorName,
                    DoctorSurname = curRecord.DoctorSurname,
                    SpecID = (int)specID
                });

                var result2 = _model.aspDataModel.GetDoctorsConnection().EditDoctor(doctorModel);

                if (!result1.Contains("Record updated successfully!"))
                {
                    MessageBox.Show(result1, "Message");
                }
                else if (!result2.Contains("Record updated successfully!"))
                {
                    MessageBox.Show(result2, "Message");
                }
                else
                {
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorName = rec.DoctorName;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorSurname = rec.DoctorSurname;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).SpecName = rec.SpecName;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorExperience = rec.DoctorExperience;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorGraduation = rec.DoctorGraduation;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorSalary = rec.DoctorSalary;
                    _model.aspDataModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorRemarks = rec.DoctorRemarks;
                }
            }

            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorName = rec.DoctorName;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorSurname = rec.DoctorSurname;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).SpecName = rec.SpecName;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorExperience = rec.DoctorExperience;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorGraduation = rec.DoctorGraduation;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorSalary = rec.DoctorSalary;
            _model.aspViewModel.AllDoctorsCombined.First(o => o.DoctorID == curRecord.DoctorID).DoctorRemarks = rec.DoctorRemarks;
        }
    }
}
