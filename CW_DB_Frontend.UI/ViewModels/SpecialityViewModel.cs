using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.Commands;

namespace CW_DB_Frontend.UI.ViewModels
{
    public class SpecialityViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditSpeciality { get; set; }
        public ICommand DeleteSpeciality { get; set; }

        public SpecialityViewModel()
        {
            EditSpeciality = new EditSpecCommand(model, this);
            DeleteSpeciality = new DeleteSpecCommand(model, this);
        }

        public SpecialityViewModel(SpecialityViewModel obj)
        {
            EditSpeciality = new EditSpecCommand(model, this);
            DeleteSpeciality = new DeleteSpecCommand(model, this);

            this.SpecID = obj.SpecID;
            this.SpecName = obj.SpecName;
        }

        private int _specID;
        public int SpecID {
            get { return _specID; }
            set { _specID = value; OnPropertyChanged("SpecID"); }
        }

        private string _specName;
        public string SpecName {
            get { return _specName; }
            set { _specName = value; OnPropertyChanged("SpecName"); }
        }
    }
}
