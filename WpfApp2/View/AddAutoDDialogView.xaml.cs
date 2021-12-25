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
    /// Логика взаимодействия для AddAutoDDialogView.xaml
    /// </summary>
    public partial class AddAutoDDialogView : Window
    {
        private Auto auto = new Auto();
        bool isNew = true;
        public AddAutoDDialogView()
        {
            InitializeComponent();
            DataContext = auto;
        }
       
     

        public AddAutoDDialogView(Auto auto)
        {
            this.auto = auto;
            InitializeComponent();
            DataContext = auto;
            isNew = false;
        }
        // Написать вью модел
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (VIN_LIB.VIN.CheckVIN(vINTextBox.Text))
            {
                RelayCommand.ResetTimer();
                try
                {
                    if (isNew)
                        db.GetContext().Auto.Add(auto);
                    db.GetContext().SaveChanges();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ошибка в вин номере");
            }
           
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
