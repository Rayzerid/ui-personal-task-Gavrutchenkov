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

namespace courseworkDemo.View.AdministrationPage.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AdminInfoProductsItemControl.xaml
    /// </summary>
    public partial class AdminInfoProductsItemControl : UserControl
    {
        public AdminInfoProductsItemControl()
        {
            InitializeComponent();
            DataProductsInfo.ItemsSource = FrameNavigate.DB.Products.OrderBy(u => u.ProductsID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idProducts = (DataProductsInfo.SelectedItem as Product).ProductsID;
            var resultDeleteOneOrder = MessageBox.Show("Хотите удалить продукт?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if(resultDeleteOneOrder == MessageBoxResult.Yes)
            {
                Product product = (from u in FrameNavigate.DB.Products where u.ProductsID == idProducts select u).SingleOrDefault();
                FrameNavigate.DB.Products.Remove(product);
                FrameNavigate.DB.SaveChanges();
                DataProductsInfo.ItemsSource = FrameNavigate.DB.Products.OrderBy(u => u.ProductsID).ToList();
            }
        }
    }
}
