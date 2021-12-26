using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
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
            classComboBox.ItemsSource = db.GetContext().Class_DTP.ToList();
        }
       
        public AddDTPDialogView(DTP dtp)
        {
            this.dtp = dtp;
            InitializeComponent();
            DataContext = dtp;
            isNew = false;
            classComboBox.ItemsSource = db.GetContext().Class_DTP.ToList();

            //setCanvas();
        }
        // Написать вью модел
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();

            //var array = InkCanvasToByte();
            //dtp.DTP_Photo.Add(new DTP_Photo() { Photo = array });
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

        private void addPhotoClick(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if ((bool)openFileDialog.ShowDialog())
            {

                //Get the path of specified file
                var filePath = openFileDialog.FileName;
                try
                {
                    dtp.DTP_Photo.Add(new DTP_Photo() { Photo = File.ReadAllBytes(filePath) });
                    photo.ItemsSource = dtp.DTP_Photo.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения картинки");
                }
            }
        }

        private void addMemberClick(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();

            dtp.Members_DTP.Add(new Members_DTP() { Name = "Участник 1", Nomer = 22222 });
            members.ItemsSource = dtp.Members_DTP.ToList();
        }

        private void rotateImage(object sender, RoutedEventArgs e)
        {
            var photoBinary = (((sender as Button).DataContext) as DTP_Photo).Photo;
            System.Drawing.Image photoDTP = ConvertImageFromByte(photoBinary);

            photoDTP.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);

            (((sender as Button).DataContext) as DTP_Photo).Photo = imageToByteArray(photoDTP);

            db.GetContext().SaveChanges();

            photo.ItemsSource = dtp.DTP_Photo.ToList();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static System.Drawing.Image ConvertImageFromByte(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
}
