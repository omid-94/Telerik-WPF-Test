using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelerikWpfApp1.Data;

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.MyCarousel.ItemsSource = EmployeeService.GetEmployees();
            this.MyCarousel.ItemsSource = CarouselImageData.GetData();

            this.MyGrid.ItemsSource = ProblemGridData.GetData();
            this.MyGrid.HeaderNames = ProblemGridData.GetHeaderNames();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "MP4 Files (*.mp4)|*.mp4|" +
                "JPEG Files (*.jpeg)|*.jpeg|" +
                "PNG Files (*.png)|*.png|" +
                "JPG Files (*.jpg)|*.jpg|" +
                "GIF Files (*.gif)|*.gif|" +
                "PDF Files (*pdf)|*.pdf" +
                "Word Files (*doc)|*.doc" +
                "Word Files (*docx)|*.docx";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable <bool> result = dlg.ShowDialog();
            if(result == true)
            {
                OpenWithDefaultProgram(dlg.FileName);
            }
        }

        public static void OpenWithDefaultProgram(string path)
        {
            try
            {
                var fileopener = new Process();

                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + path + "\"";
                fileopener.Start();
            }
            catch
            {
                MessageBox.Show("Cannot open file " + path);
            }
        }
    }
}
