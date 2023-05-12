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
    public class DeleteSpecCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly SpecialityViewModel curRecord;

        public DeleteSpecCommand(MyViewModel mdl, SpecialityViewModel doc)
        {
            curRecord = doc;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            SpecialityModel infoModel = Mapper.Map<SpecialityViewModel, SpecialityModel>(curRecord);
            _model.aspDataModel.GetSpecialityConnection().DeleteSpec(infoModel);

            _model.aspViewModel.AllSpecs.Remove(_model.aspViewModel.AllSpecs.First(o => o.SpecID == curRecord.SpecID));
        }
    }
}
