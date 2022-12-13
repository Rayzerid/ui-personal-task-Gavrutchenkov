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
using courseworkDemo.Core;
using courseworkDemo.View.AdministrationPage.UserControls;
using courseworkDemo.View.LoginPage;

namespace courseworkDemo.View.AdministrationPage
{
    /// <summary>
    /// Логика взаимодействия для MainAdministratorPage.xaml
    /// </summary>
    public partial class MainAdministratorPage : Page
    {
        public MainAdministratorPage()
        {
            InitializeComponent();
        }

        private void MenuItemUser_Click(object sender, RoutedEventArgs e)
        {
            GridContentLoad.Children.Clear();
            GridContentLoad.Children.Add(new AdminInfoUserControl());
        }

        private void MenuItemOrders_Click(object sender, RoutedEventArgs e)
        {
            GridContentLoad.Children.Clear();
            GridContentLoad.Children.Add(new AdminInfoOrdersControl());
        }

        private void MenuItemProduct_Click(object sender, RoutedEventArgs e)
        {
            GridContentLoad.Children.Clear();
            GridContentLoad.Children.Add(new AdminInfoProductsControl());
        }

        private void MenuItemProductsList_Click(object sender, RoutedEventArgs e)
        {
            GridContentLoad.Children.Clear();
            GridContentLoad.Children.Add(new AdminInfoProductsItemControl());
        }

        private void MenuItemBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }
    }
}
