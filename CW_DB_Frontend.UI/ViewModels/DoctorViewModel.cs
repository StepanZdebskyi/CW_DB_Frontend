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
    public class DoctorViewModel: ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditDoctor { get; set; }
        public ICommand DeleteDoctor { get; set; }

        public DoctorViewModel()
        {
            EditDoctor = new EditDoctorCommand(model, this);
            DeleteDoctor = new DeleteDoctorCommand(model, this);
        }

        public DoctorViewModel(DoctorViewModel obj)
        {
            EditDoctor = new EditDoctorCommand(model, this);
            DeleteDoctor = new DeleteDoctorCommand(model, this);

            this.DoctorID = obj.DoctorID;
            this.DoctorName = obj.DoctorName;
            this.DoctorSurname = obj.DoctorSurname;
            this.SpecID = obj.SpecID;
        }

        private int _doctorID; 
        public int DoctorID { 
            get { return _doctorID; }
            set { _doctorID = value;  OnPropertyChanged("DoctorID"); }
        }

        private string _doctorName; 
        public string DoctorName {
            get { return _doctorName; }
            set { _doctorName = value; OnPropertyChanged("DoctorName"); }
        }

        private string _doctorSurname; 
        public string DoctorSurname {
            get { return _doctorSurname; }
            set { _doctorSurname = value; OnPropertyChanged("DoctorSurname"); }
        }

        private int _specID;
        public int SpecID {
            get { return _specID; }
            set { _specID = value; OnPropertyChanged("SpecID"); }
        }
    }
}
