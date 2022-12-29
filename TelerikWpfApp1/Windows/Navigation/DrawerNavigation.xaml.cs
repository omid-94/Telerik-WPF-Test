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
using Telerik.Windows.Controls;
using TelerikWpfApp1.UserControls.NavPages;

namespace TelerikWpfApp1.Windows.Navigation
{
    /// <summary>
    /// Interaction logic for DrawerNavigation.xaml
    /// </summary>
    public partial class DrawerNavigation : Window
    {
        public DrawerNavigation()
        {
            InitializeComponent();

            navigationMap = new SortedDictionary<string, UserControl>();
        }
        private SortedDictionary<string, UserControl> navigationMap;

        private void navigationView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var navItem = (RadNavigationViewItem)navigationView.SelectedValue;
                _LoadItem(navItem.Content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void _LoadItem(string navItemName)
        {
            switch (navItemName)
            {
                case "Bookmarks":
                    if (!navigationMap.ContainsKey(navItemName))
                        navigationMap[navItemName] = new UcBookMarkNav();
                    break;
                case "Favorites":
                    if (!navigationMap.ContainsKey(navItemName))
                        navigationMap[navItemName] = new UcFavoritesNav();
                    break;
                case "Files":
                    if (!navigationMap.ContainsKey(navItemName))
                        navigationMap[navItemName] = new UcFilesNav();
                    break;
                default :
                    MessageBox.Show("Navigation item not found...");
                    break;
            }
            navigationView.Content = navigationMap[navItemName];
        }
    }
}
