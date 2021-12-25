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
    /// Логика взаимодействия для AddDTPDialogView.xaml
    /// </summary>
    public partial class AddDTPDialogView : Window
    { 

        private DTP dtp = new DTP();
        bool isNew = true;
        public AddDTPDialogView()
        {
            InitializeComponent();
            DataContext = dtp;
        }
        
        public AddDTPDialogView(DTP dtp)
        {
            this.dtp = dtp;
            InitializeComponent();
            DataContext = dtp;
            isNew = false;
        }
        // Написать вью модел
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();
            try
            {
                if (isNew)
                    db.GetContext().DTP.Add(dtp);
                db.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
