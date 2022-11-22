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
            DataOrderInfo.ItemsSource = FrameNavigate.DB.Orders.OrderBy(u => u.OrdersID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idOrders = (DataOrderInfo.SelectedItem as Order).OrdersID;
            var result = MessageBox.Show("Хотите удалить заказ?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.OrdersID == idOrders select u).SingleOrDefault();
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                DataOrderInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.Login).ToList();
            }
        }
    }
}
