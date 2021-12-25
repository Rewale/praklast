using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
using Color = System.Drawing.Color;

namespace WpfApp2.View
{
    /// <summary>
    /// Логика взаимодействия для AddDriverDialogView.xaml
    /// </summary>
    public partial class AddDriverDialogView : Window
    {
        private Drivers driver = new Drivers();
        bool isNew = true;
        public AddDriverDialogView()
        {
            InitializeComponent();
            DataContext = driver;
        }
        
        public AddDriverDialogView(Drivers driver)
        {
            this.driver = driver;
            InitializeComponent();
            DataContext = driver;
            isNew = false;
        }
        // Написать вью модел
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();
            try
            {
                if(isNew)
                    db.GetContext().Drivers.Add(driver);
                db.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());   
            }
        }

        private void PhotoTextBox_Click(object sender, RoutedEventArgs e)
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
                    driver.photoBinary = File.ReadAllBytes(filePath);
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения картинки");
                }
            }

                
            
            
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            RelayCommand.ResetTimer();

            const int x_text = 340;
            const int y_text = 230;

            const int image_x_start = 80;
            const int image_y_start = 240;

            const int image_x_end = 250;
            const int image_y_end = 500;

            const int fontSize = 24;
            const int offsetHeigt = 80;
            const int offsetWidth = 50;

            const int textOffset = fontSize + 10;

            System.Drawing.Image photoDriver = ConvertImageFromByte(driver.photoBinary);
            System.Drawing.Image maket = System.Drawing.Image.FromFile(@"C:\Users\usersql\Desktop\УП 01 Учебная практика\Ресурсы\Сессия 3\driver_license_template.jpg");

            photoDriver = ResizeImage(photoDriver, image_x_end - image_x_start + offsetWidth, image_y_end - image_y_start + offsetHeigt);

            Graphics g = Graphics.FromImage(maket);
            Font font = new Font("Segoe UI Bold", fontSize);
            

 
            SolidBrush color = new SolidBrush(Color.Black);
            int lastx = x_text;
            int lasty = y_text;
            g.DrawString($"ФИО: {driver.name} {driver.middlename}", font, color, lastx, lasty);
            lasty += textOffset;
            g.DrawString($"Дата выдачи: {driver.CurrentLicence.licence_date}", font, color, lastx, lasty);
            lasty += textOffset;
            g.DrawString($"До: {driver.CurrentLicence.expire_date}", font, color, lastx, lasty);
            lasty += textOffset;
            g.DrawString($"{driver.CurrentLicence.licence_series} {driver.CurrentLicence.number}", font, color, lastx, lasty);
            lasty += textOffset;
            g.DrawString($"{driver.address}", font, color, lastx, lasty);
            lasty += textOffset;

            g.DrawString($"Категория: {driver.CurrentLicence.CategoriesString}", font, color, lastx, lasty);
            lasty += textOffset;



            g.DrawImage(photoDriver, image_x_start, image_y_start);

            maket.Save($@"C:\Users\usersql\Desktop\УП 01 Учебная практика\{driver.name}.jpeg", ImageFormat.Jpeg);
        }

        private System.Drawing.Image ConvertImageFromByte(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
