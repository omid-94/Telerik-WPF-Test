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
    /// Interaction logic for SimpleDataGrid.xaml
    /// </summary>
    public partial class SimpleDataGrid : UserControl
    {
        private SortedList<string, string> _HeaderNames;
        public object ItemsSource
        {
            get { return DataGrid.ItemsSource; }
            set { DataGrid.ItemsSource = value; }
        }
        public SortedList<string , string> HeaderNames
        {
            get { return this._HeaderNames; }
            set {
                this._HeaderNames = value;
                _SetHeaderNames();
            }
        }
        public SimpleDataGrid()
        {
            InitializeComponent();
        }
        private void _SetHeaderNames()
        {
            foreach(KeyValuePair<string, string> item in _HeaderNames)
            {
                DataGrid.Columns[item.Key].Header = item.Value;
            }
        }
    }
}
