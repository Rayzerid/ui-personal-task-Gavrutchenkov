using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
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
using courseworkDemo.Model;

namespace courseworkDemo.View.AdministrationPage.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AdminInfoOrdersControl.xaml
    /// </summary>
    public partial class AdminInfoOrdersControl : UserControl
    {
        public AdminInfoOrdersControl()
        {
            InitializeComponent();
            DataOrderInfo.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idProduct = (DataOrderInfo.SelectedItem as ProductsContain).ProductsID;
            int idUser = (DataOrderInfo.SelectedItem as ProductsContain).Order.UserID;
            int CountProductContain = (FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID)).ToList().Count;
            var resultDeleteOneOrder = MessageBox.Show("Хотите удалить товар из корзины?",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            if (resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain == 1)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.UserID == idUser select u).SingleOrDefault();
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                DataOrderInfo.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
            }
            if (resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain != 1)
            {
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.SaveChanges();
                DataOrderInfo.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
            }
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            int idProduct = (DataOrderInfo.SelectedItem as ProductsContain).ProductsID;
            int idUser = (DataOrderInfo.SelectedItem as ProductsContain).Order.UserID;
            int CountProductContain = (FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID)).ToList().Count;
            var resultDeleteOneOrder = MessageBox.Show("Хотите удалить товар из корзины?",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            if (resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain == 1)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.UserID == idUser select u).SingleOrDefault();
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                DataOrderInfo.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
            }
            if (resultDeleteOneOrder == MessageBoxResult.Yes && CountProductContain != 1)
            {
                ProductsContain productsContain = (from u in FrameNavigate.DB.ProductsContains where u.ProductsID == idProduct && u.Order.UserID == idUser select u).FirstOrDefault();
                FrameNavigate.DB.ProductsContains.Remove(productsContain);
                FrameNavigate.DB.SaveChanges();
                DataOrderInfo.ItemsSource = FrameNavigate.DB.ProductsContains.OrderBy(u => u.ProductsContainID).ToList();
            }
        }

    }
}
