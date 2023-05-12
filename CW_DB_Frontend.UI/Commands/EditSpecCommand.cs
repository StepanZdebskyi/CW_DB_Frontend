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
    public class EditSpecCommand : CommandBase
    {
        private readonly MyViewModel _model;
        private readonly SpecialityViewModel curRecord;

        public EditSpecCommand(MyViewModel mdl, SpecialityViewModel record)
        {
            curRecord = record;
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            SpecialityModel recordModel = Mapper.Map<SpecialityViewModel, SpecialityModel>(curRecord);
            var result = _model.aspDataModel.GetSpecialityConnection().EditSpec(recordModel);

            SpecialityViewModel rec = new SpecialityViewModel(curRecord);

            if (!result.Contains("Record updated successfully!"))
            {
                List<SpecialityModel> allPats = _model.aspDataModel.GetSpecialityConnection().GetSpecs();
                rec = Mapper.Map<SpecialityModel, SpecialityViewModel>(allPats.First(o => o.SpecID == curRecord.SpecID));
                MessageBox.Show(result, "Message");
            }

            _model.aspViewModel.AllSpecs.First(o => o.SpecID == curRecord.SpecID).SpecName = rec.SpecName;
        }
    }
}
