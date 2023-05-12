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
    public class DoctorCombinedViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditDoctorsCombined { get; set; }
        public ICommand DeleteDoctorsCombined { get; set; }

        public DoctorCombinedViewModel()
        {
            EditDoctorsCombined = new EditDoctorCombinedCommand(model, this);
            DeleteDoctorsCombined = new DeleteDoctorCombinedCommand(model, this);
        }
        public DoctorCombinedViewModel(DoctorCombinedViewModel obj)
        {
            EditDoctorsCombined = new EditDoctorCombinedCommand(model, this);
            DeleteDoctorsCombined = new DeleteDoctorCombinedCommand(model, this);

            this.DoctorID = obj.DoctorID;
            this.DoctorExperience = obj.DoctorExperience;
            this.DoctorGraduation = obj.DoctorGraduation;
            this.DoctorSalary = obj.DoctorSalary;
            this.DoctorRemarks = obj.DoctorRemarks;
            this.DoctorName = obj.DoctorName;
            this.DoctorSurname = obj.DoctorSurname;
            this.SpecName = obj.SpecName;
        }

        private int _doctorID;
        public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; OnPropertyChanged("DoctorID"); }
        }

        private string _doctorName;
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; OnPropertyChanged("DoctorName"); }
        }

        private string _doctorSurname;
        public string DoctorSurname
        {
            get { return _doctorSurname; }
            set { _doctorSurname = value; OnPropertyChanged("DoctorSurname"); }
        }

        private string _specName;
        public string SpecName
        {
            get { return _specName; }
            set { _specName = value; OnPropertyChanged("SpecName"); }
        }

        private string _doctorExperience;
        public string DoctorExperience
        {
            get { return _doctorExperience; }
            set { _doctorExperience = value; OnPropertyChanged("DoctorExperience"); }
        }

        private string _doctorGraduation;
        public string DoctorGraduation
        {
            get { return _doctorGraduation; }
            set { _doctorGraduation = value; OnPropertyChanged("DoctorGraduation"); }
        }

        private float _doctorSalary;
        public float DoctorSalary
        {
            get { return _doctorSalary; }
            set { _doctorSalary = value; OnPropertyChanged("DoctorSalary"); }
        }

        private string _doctorRemarks;
        public string DoctorRemarks
        {
            get { return _doctorRemarks; }
            set { _doctorRemarks = value; OnPropertyChanged("DoctorRemarks"); }
        }
    }
}
