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

namespace courseworkDemo.View.UsingPage.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserBasketConrtol.xaml
    /// </summary>
    public partial class UserBasketConrtol : UserControl
    {
        public UserBasketConrtol()
        {
            InitializeComponent();
            LViewProductsBasket.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
            TbSum.Text = (from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Count() != 0 ? Convert.ToString((from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Sum()): "0";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idProduct = ((sender as Button)?.DataContext as ProductsContain).ProductsID;
            int CountProductContain = (FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID)).ToList().Count;
            var resultDeleteOneOrder = MessageBox.Show("Хотите удалить товар из корзины?",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            if(resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain == 1)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.UserID == FrameNavigate.idUser select u).SingleOrDefault();
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == FrameNavigate.idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                LViewProductsBasket.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
                TbSum.Text = (from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Count() != 0 ? Convert.ToString((from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Sum()) : "0";
            }
            if (resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain != 1)
            {
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == FrameNavigate.idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.SaveChanges();
                LViewProductsBasket.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
                TbSum.Text = (from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Count() != 0 ? Convert.ToString((from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Sum()) : "0";
            }
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            int idProduct = ((sender as Button)?.DataContext as ProductsContain).ProductsID;
            int CountOrders = (FrameNavigate.DB.Orders.OrderBy(u => u.OrdersID)).ToList().Count;
            var resultDeleteOneOrder = MessageBox.Show("Хотите удалить товар из корзины?",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            if (resultDeleteOneOrder == MessageBoxResult.Yes)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.UserID == FrameNavigate.idUser select u).SingleOrDefault();
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == FrameNavigate.idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                LViewProductsBasket.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
                TbSum.Text = (from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Count() != 0 ? Convert.ToString((from u in FrameNavigate.DB.ProductsContains where u.Order.UserID == FrameNavigate.idUser select u.Product.ProductsPrice).Sum()) : "0";
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainUserPage());
        }
    }
}
