﻿using courseworkDemo.Core;
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

namespace courseworkDemo.View.AdministrationPage.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AdminInfoUserControl.xaml
    /// </summary>
    public partial class AdminInfoUserControl : UserControl
    {
        public AdminInfoUserControl()
        {
            InitializeComponent();
            DataUserInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.Login).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idUser = (DataUserInfo.SelectedItem as User).UserID;
            var result = MessageBox.Show("Хотите удалить пользователя?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    int idOrder = (from u in FrameNavigate.DB.Orders where u.UserID == idUser select u.OrdersID).FirstOrDefault();
                    List<ProductsContain> productsContains = (from u in FrameNavigate.DB.ProductsContains where u.OrdersID == idOrder select u).ToList();
                    foreach(ProductsContain productsContain in productsContains)
                    {
                        FrameNavigate.DB.ProductsContains.Remove(productsContain);
                    }    
                    Order order = (from u in FrameNavigate.DB.Orders where u.OrdersID == idOrder select u).FirstOrDefault();
                    User user = (from u in FrameNavigate.DB.Users where u.UserID == idUser select u).SingleOrDefault();
                    FrameNavigate.DB.Orders.Remove(order);
                    FrameNavigate.DB.Users.Remove(user);
                    FrameNavigate.DB.SaveChanges();
                    DataUserInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.Login).ToList();
                }
                catch
                {
                    User user = (from u in FrameNavigate.DB.Users where u.UserID == idUser select u).SingleOrDefault();
                    FrameNavigate.DB.Users.Remove(user);
                    FrameNavigate.DB.SaveChanges();
                    DataUserInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.Login).ToList();
                }
            }
        }
    }
}
