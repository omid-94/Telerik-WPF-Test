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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelerikWpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for CarouselItem.xaml
    /// </summary>
    public partial class CarouselItem : UserControl
    {
        /// <summary>
        /// Default ImageHeight is 200
        /// </summary>
        public double ImageHeight
        {
            get { return MyImage.Height; }
            set { MyImage.Height = value; }
        }

        /// <summary>
        /// Default ImageWidth is 200
        /// </summary>
        public double ImageWidth
        {
            get { return MyImage.Width; }
            set { MyImage.Width = value; }
        }
        public ImageSource ImageSource
        {
            get { return MyImage.Source; }
            set { MyImage.Source = value; }
        }
        public string HeaderText
        {
            get { return MyHeader.Text; }
            set { MyHeader.Text = value; }
        }
        public string FooterText
        {
            get { return MyFooter.Text; }
            set { MyFooter.Text = value; }
        }
        public CarouselItem()
        {
            InitializeComponent();

            _InitialValues();
        }
        private void _InitialValues()
        {
            this.ImageHeight = 250;
            this.ImageWidth = 500;
        }
    }
}
