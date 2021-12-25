using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Base;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    class MainViewModel:Notify
    {
        private object _currentView;
        public RelayCommand clickOnDrive { get; set; }

        public RelayCommand clickOnLicenses { get; set; }
        public RelayCommand clickOnDTP { get;  set; }

        public RelayCommand clickOnAuto { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
           
        }

        public MainViewModel()
        {
            clickOnDrive = new RelayCommand(p =>
            {
                CurrentView = new ListDriverViewModel();                 
                
            });
            clickOnLicenses = new RelayCommand(p =>
            {
                CurrentView = new ListLicensesViewModel();
            });
            clickOnDTP = new RelayCommand(p =>
            {
                CurrentView = new ListDTPViewModel();
            });
            clickOnAuto = new RelayCommand(p =>
            {
                CurrentView = new ListAutoViewModel();
            });
        }
    }
}
