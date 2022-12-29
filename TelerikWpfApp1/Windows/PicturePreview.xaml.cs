using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
//using Microsoft.Practices.Prism.Commands;

using System.Windows.Shapes;

namespace TelerikWpfApp1.Windows
{
    /// <summary>
    /// Interaction logic for PicturePreview.xaml
    /// </summary>
    public partial class PicturePreview : Window
    {
        double scale = 1.0;
        double minScale = 0.5;
        double maxScale = 2.5;
        public ImageSource ImageSource
        {
            get { return MyImage.Source; }
            set { MyImage.Source = value; }
        }
        public PicturePreview()
        {
            InitializeComponent();
        }
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                MyImage.RenderTransform = null;

                var position = e.MouseDevice.GetPosition(MyImage);

                if (e.Delta > 0)
                    scale += 0.1;
                else
                    scale -= 0.1;

                if (scale > maxScale)
                    scale = maxScale;
                if (scale < minScale)
                    scale = minScale;

                MyImage.RenderTransform = new ScaleTransform(scale, scale, position.X, position.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MyImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
                _FullscreenMode();
        }
        private void _FullscreenMode()
        {
            if(WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            _FullscreenMode();
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG (*.jpeg)|*.jpeg|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == true)
                MessageBox.Show("FaleName ==>" + saveFileDialog.FileName);
                //File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        }
    }
}
