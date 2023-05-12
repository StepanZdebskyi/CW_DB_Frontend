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
    public class DoctorsInfoViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditDoctorsInfo { get; set; }
        public ICommand DeleteDoctorsInfo { get; set; }

        public DoctorsInfoViewModel()
        {
            EditDoctorsInfo = new EditDoctorsInfoCommand(model, this);
            DeleteDoctorsInfo = new DeleteDoctorsInfoCommand(model, this);  
        }
        public DoctorsInfoViewModel(DoctorsInfoViewModel obj)
        {
            EditDoctorsInfo = new EditDoctorsInfoCommand(model, this);
            DeleteDoctorsInfo = new DeleteDoctorsInfoCommand(model, this);

            this.DoctorID = obj.DoctorID;
            this.DoctorExperience = obj.DoctorExperience;
            this.DoctorGraduation = obj.DoctorGraduation;
            this.DoctorSalary = obj.DoctorSalary;
            this.DoctorRemarks = obj.DoctorRemarks;
        }

        private int _doctorID;
        public int DoctorID {
            get { return _doctorID; }
            set { _doctorID = value; OnPropertyChanged("DoctorID"); }
        }

        private string _doctorExperience; 
        public string DoctorExperience {
            get { return _doctorExperience; }
            set { _doctorExperience = value; OnPropertyChanged("DoctorExperience"); }
        }

        private string _doctorGraduation;
        public string DoctorGraduation {
            get { return _doctorGraduation; }
            set { _doctorGraduation = value; OnPropertyChanged("DoctorGraduation"); }
        }

        private float _doctorSalary;
        public float DoctorSalary {
            get { return _doctorSalary; }
            set { _doctorSalary = value; OnPropertyChanged("DoctorSalary"); }
        }

        private string _doctorRemarks;
        public string DoctorRemarks {
            get { return _doctorRemarks; }
            set { _doctorRemarks = value; OnPropertyChanged("DoctorRemarks"); }
        }
    }
}
