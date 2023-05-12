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
    public class CompleteAddingSpecCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public CompleteAddingSpecCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.aspViewModel.CurrentSpec.SpecID = _model.aspViewModel.AllSpecs.Max(o => o.SpecID) + 1;
            SpecialityViewModel newRec = new SpecialityViewModel(_model.aspViewModel.CurrentSpec);
            SpecialityModel infoModel = Mapper.Map<SpecialityViewModel, SpecialityModel>(newRec);
            var result = _model.aspDataModel.GetSpecialityConnection().AddSpec(infoModel);
            
            _model.CurrentUserControl = "SpecControl";

            if (result.Contains("New record added successfully!"))
            {
                _model.aspViewModel.AllSpecs.Add(newRec);
            }
            else
            {
                MessageBox.Show(result, "Message");
            }


            
        }
    }
}
