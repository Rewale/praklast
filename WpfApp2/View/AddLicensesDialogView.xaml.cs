using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Base;
using WpfApp2.Model;

namespace WpfApp2.View
{
    /// <summary>
    /// Логика взаимодействия для AddLicensesDialogView.xaml
    /// </summary>
    public partial class AddLicensesDialogView : Window
    {
        private licence licence = new licence();
        bool isNew = true;

        public AddLicensesDialogView()
        {
            InitializeComponent();
            DataContext = licence;
        }
        public AddLicensesDialogView(licence licence)
        {
            this.licence = licence;
            InitializeComponent();
            DataContext = licence;
            isNew = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();
         
                if (isNew)
                    db.GetContext().licence.Add(licence);
                db.GetContext().SaveChanges();
                Close();
           
        }
    }
}
