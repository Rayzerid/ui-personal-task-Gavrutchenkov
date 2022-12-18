using courseworkDemo.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminInfoProductsControl.xaml
    /// </summary>
    public partial class AdminInfoProductsControl : UserControl
    {
        public AdminInfoProductsControl()
        {
            InitializeComponent();
        }

        private byte[] imageDB;

        private async void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TbProductsName.Text) || string.IsNullOrEmpty(TbPrice.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(FrameNavigate.DB.Products.Count(u => u.ProductsName == TbProductsName.Text) > 0)
                {
                    MessageBox.Show("Продукт с таким названием уже есть!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                FrameNavigate.DB.Products.Add(new Model.Product
                {
                    ProductsName = TbProductsName.Text,
                    ProductsPrice = double.Parse(TbPrice.Text),
                    ProductsImage = imageDB
                });

                await FrameNavigate.DB.SaveChangesAsync();
                MessageBox.Show("Продукт добвален!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameNavigate.FrameObject.Navigate(new MainAdministratorPage());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainAdministratorPage());
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            byte[] image_bytes = File.ReadAllBytes(openFileDialog.FileName);
            Uri fileUri = new Uri(openFileDialog.FileName);
            image.Source = new BitmapImage(fileUri);
            imageDB = image_bytes;
        }
    }
}
