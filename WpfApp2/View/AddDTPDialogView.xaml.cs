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
        }
        //private byte[] InkCanvasToByte()
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        if (ink.Strokes.Count > 0)
        //        {
        //            ink.Strokes.Save(ms, true);
        //            byte[] unencryptedSignature = ms.ToArray();
        //            //File.WriteAllBytes(@"C:\Users\usersql\Desktop\test.png", unencryptedSignature);
        //            return unencryptedSignature;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
        //[Serializable]
        //public sealed class MyCustomStrokes
        //{
        //    public MyCustomStrokes() { }
        //    /// <SUMMARY>
        //    /// The first index is for the stroke no.
        //    /// The second index is for the keep the 2D point of the Stroke.
        //    /// </SUMMARY>
        //    public Point[][] StrokeCollection;
        //}
        //private void setCanvas()
        //{
        //    try
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        MemoryStream ms = new MemoryStream(dtp.DTP_Photo.FirstOrDefault().Photo);
        //        MyCustomStrokes customStrokes = bf.Deserialize(ms) as MyCustomStrokes;
        //        for (int i = 0; i < customStrokes.StrokeCollection.Length; i++)
        //        {
        //            if (customStrokes.StrokeCollection[i] != null)
        //            {
        //                StylusPointCollection stylusCollection = new
        //                  StylusPointCollection(customStrokes.StrokeCollection[i]);
        //                Stroke stroke = new Stroke(stylusCollection);
        //                StrokeCollection strokes = new StrokeCollection();
        //                strokes.Add(stroke);
        //                this.ink.Strokes.Add(strokes);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show(ex.Message);
        //    }
        //}

        public AddDTPDialogView(DTP dtp)
        {
            this.dtp = dtp;
            InitializeComponent();
            DataContext = dtp;
            isNew = false;
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
    }
}
