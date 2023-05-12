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
    public class MedicalRecordViewModel : ViewModelBase
    {
        public static MyViewModel model;

        public ICommand EditMedicalRecord { get; set; }
        public ICommand DeleteMedicalRecord { get; set; }

        public MedicalRecordViewModel()
        {
            EditMedicalRecord = new EditMedRecordCommand(model, this);
            DeleteMedicalRecord = new DeleteMedRecordCommand(model, this);
        }

        public MedicalRecordViewModel(MedicalRecordViewModel rec)
        {
            EditMedicalRecord = new EditMedRecordCommand(model, this);
            DeleteMedicalRecord = new DeleteMedRecordCommand(model, this);

            this.RecordID = rec.RecordID;
            this.DoctorID = rec.DoctorID;
            this.PatientID = rec.PatientID;
            this.RecordDate = rec.RecordDate;
            this.RecordTime = rec.RecordTime;
            this.RecordHeader = rec.RecordHeader;
            this.RecordBody = rec.RecordBody;
        }

        private int _recordID;
        public int RecordID {
            get { return _recordID; }
            set { _recordID = value; OnPropertyChanged("RecordID"); }
        }

        private int _doctorID;
        public int DoctorID { 
            get { return _doctorID; }
            set { _doctorID = value; OnPropertyChanged("DoctorID"); }
        }

        private int _patientID;
        public int PatientID { 
            get { return _patientID; }
            set { _patientID = value; OnPropertyChanged("PatientID"); }
        }

        private DateTime _recordDate;
        public DateTime RecordDate {
            get { return _recordDate; }
            set { _recordDate = value; OnPropertyChanged("RecordDate"); }
        }

        private DateTime _recordTime;
        public DateTime RecordTime {
            get { return _recordTime; }
            set { _recordTime = value; OnPropertyChanged("RecordTime"); }
        }

        private string _recordHeader;
        public string RecordHeader { 
            get { return _recordHeader; }
            set { _recordHeader = value; OnPropertyChanged("RecordHeader"); }
        }

        private string _recordBody;
        public string RecordBody {
            get { return _recordBody; }
            set { _recordBody = value; OnPropertyChanged("RecordBody"); }
        }
    }
}
