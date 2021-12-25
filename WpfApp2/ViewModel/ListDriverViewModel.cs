using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Base;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    class ListDriverViewModel:Notify
    {        
        public Drivers selectedDriver { get; set; }
        private List<Drivers> _drivers;
        public List<Drivers> drivers
        {
            get
            {
                return _drivers;
            }
            set
            {
                _drivers = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand addDriver { get; set; }
        public RelayCommand DoubleCommand { get; set; }
        public ListDriverViewModel() {
            //db.importNewBase();
            drivers = db.GetContext().Drivers.ToList();
            
            addDriver = new RelayCommand(o =>
            {
                new AddDriverDialogView().ShowDialog();
                drivers = db.GetContext().Drivers.ToList();
            });

            DoubleCommand = new RelayCommand(o =>
            {
                if (selectedDriver == null)
                    return;
                new AddDriverDialogView(selectedDriver).ShowDialog();                
            });
        }
    }
}
