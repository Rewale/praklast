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
    class ListLicensesViewModel:Notify
    {
        public RelayCommand DoubleClick { get; set; }

        public RelayCommand AddLicensesClick { get; set; }

        public licence selectedLicenses { get; set; }

        private List<licence> licences;

        public List<licence> Licences
        {
            get { return licences; }
            set
            {
                licences = value;
                OnPropertyChanged();
            }
        }


        public ListLicensesViewModel()
        {
            Licences = db.GetContext().licence.ToList();
            AddLicensesClick = new RelayCommand(o =>
            {
                new AddLicensesDialogView().ShowDialog();
                Licences = db.GetContext().licence.ToList();
            });

            DoubleClick = new RelayCommand(o =>
            {
                if (selectedLicenses == null)
                    return;
                new AddLicensesDialogView(selectedLicenses).ShowDialog();
            });
        }
    }
}
