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
using courseworkDemo.View.UsingPage;
using courseworkDemo.Core;

namespace courseworkDemo.View.UsingPage.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserPayConrol.xaml
    /// </summary>
    public partial class UserPayConrol : UserControl
    {
        public UserPayConrol()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new UserBasketConrtol());
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            var resultDeleteOneOrder = MessageBox.Show("Спасибо за оплату! Чек отправлен вам на посту.",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            FrameNavigate.FrameObject.Navigate(new UserBasketConrtol());
        }
    }
}
