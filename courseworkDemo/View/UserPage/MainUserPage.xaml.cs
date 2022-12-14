using courseworkDemo.Core;
using courseworkDemo.Model;
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
using courseworkDemo.View.LoginPage;
using courseworkDemo.View.AdministrationPage.UserControls;
using courseworkDemo.View.UsingPage.UserControls;

namespace courseworkDemo.View.UsingPage
{
    /// <summary>
    /// Логика взаимодействия для MainUserPage.xaml
    /// </summary>
    public partial class MainUserPage : Page
    {
        public MainUserPage()
        {
            InitializeComponent();
            LViewProducts.ItemsSource = FrameNavigate.DB.Products.OrderBy(u => u.ProductsID).ToList();
        }

        private void UpdateProduct()
        {
            var prod = FrameNavigate.DB.Products.ToList();
            prod = prod.Where(u => u.ProductsName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewProducts.ItemsSource = prod;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int idUser = FrameNavigate.idUser;
            int idProduct = ((sender as Button)?.DataContext as Product).ProductsID;
            Order order = (from u in FrameNavigate.DB.Orders where u.UserID == idUser select u).SingleOrDefault();
            if (order == null)
            {
                FrameNavigate.DB.Orders.Add(new Order
                {
                    UserID = idUser,
                    Times = DateTime.Today,
                    Status = "Обработка",
                });
                FrameNavigate.DB.SaveChanges();
            }
            int idOrder = (from u in FrameNavigate.DB.Orders where u.UserID == idUser select u.OrdersID).SingleOrDefault();
            FrameNavigate.DB.ProductsContains.Add(new ProductsContain
            {
                OrdersID = idOrder,
                ProductsID = idProduct,
            });
            FrameNavigate.DB.SaveChanges();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }

        private void BtnBusket_Click(object sender, RoutedEventArgs e)
        {
            GridContentLoad.Children.Clear();
            GridContentLoad.Children.Add(new UserBasketConrtol());
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
