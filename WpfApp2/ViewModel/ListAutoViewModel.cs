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
    class ListAutoViewModel : Notify
    {
        public Auto selectedDriver { get; set; }
        private List<Auto> _auto;
        public List<Auto> Auto
        {
            get
            {
                return _auto;
            }
            set
            {
                _auto = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand addDriver { get; set; }
        public RelayCommand DoubleCommand { get; set; }
        public ListAutoViewModel()
        {
            //db.importNewBase();
            Auto = db.GetContext().Auto.ToList();

            addDriver = new RelayCommand(o =>
            {
                new AddAutoDDialogView().ShowDialog();
                Auto = db.GetContext().Auto.ToList();
            });

            DoubleCommand = new RelayCommand(o =>
            {
                if (selectedDriver == null)
                    return;
                new AddAutoDDialogView(selectedDriver).ShowDialog();
            });
        }
    }
}
