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
    class ListDTPViewModel : Notify
    {
        public DTP selectedDTP { get; set; }
        private List<DTP> _dTPs;
        public List<DTP> DTPs
        {
            get
            {
                return _dTPs;
            }
            set
            {
                _dTPs = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand addDTP { get; set; }
        public RelayCommand DoubleCommand { get; set; }
        public ListDTPViewModel()
        {
            //db.importNewBase();
            DTPs = db.GetContext().DTP.ToList();

            addDTP = new RelayCommand(o =>
            {
                new AddDTPDialogView().ShowDialog();
                DTPs = db.GetContext().DTP.ToList();
            });

            DoubleCommand = new RelayCommand(o =>
            {
                if (selectedDTP == null)
                    return;
                new AddDTPDialogView(selectedDTP).ShowDialog();
            });
        }
    }
}
