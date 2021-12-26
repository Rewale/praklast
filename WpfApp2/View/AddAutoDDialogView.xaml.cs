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
            colorCombobox.ItemsSource = db.GetContext().Color.ToList();
            ownerComboBox.ItemsSource = db.GetContext().Drivers.ToList();
            typeOfEngineCombobox.ItemsSource = db.GetContext().EngineType.ToList();

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

            StringBuilder stringBuilder = new StringBuilder();

            if (!VIN_LIB.VIN.CheckVIN(auto.VIN))
                stringBuilder.Append("Неверный вин номер");

            if (auto.Drivers == null)
                stringBuilder.Append("Укажите водителя");

            if (auto.EngineType == null)
                stringBuilder.Append("Укажите тип двигателя");

            if (auto.Model == null)
                stringBuilder.Append("Укажите модель");

            if (auto.Color1 == null)
                stringBuilder.Append("Укажите цвет");

            if(stringBuilder.Length>0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
