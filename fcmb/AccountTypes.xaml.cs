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

namespace fcmb
{
    /// <summary>
    /// Interaction logic for AccountTypes.xaml
    /// </summary>
    public partial class AccountTypes : Page
    {

        Window darkwindow;
        public AccountTypes()
        {
            InitializeComponent();
        }

        private void tier_threeImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            dt.Content = String.Format("{0:dddd, dd MMMM yyyy}", DateTime.Now);

        }

        private void tier_one_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("CreateAccount.xaml", UriKind.Relative));
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("start.xaml", UriKind.Relative));
        }

        private void tier_oneImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void tier_two_Click(object sender, RoutedEventArgs e)
        {
            unavailable pi = new unavailable();
            darkwindow = new Window()
            {
                Background = Brushes.Black,
                Opacity = 0.8,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                WindowState = WindowState.Maximized,
                Topmost = true
            };
            darkwindow.Show();

            bool? val = pi.ShowDialog();
            if (val.HasValue && !val.Value)
            {
                darkwindow.Close();
            }
        }

        private void tier_three_Click(object sender, RoutedEventArgs e)
        {

            unavailable pi = new unavailable();
            darkwindow = new Window()
            {
                Background = Brushes.Black,
                Opacity = 0.8,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                WindowState = WindowState.Maximized,
                Topmost = true
            };
            darkwindow.Show();

            bool? val = pi.ShowDialog();
            if (val.HasValue && !val.Value)
            {
                darkwindow.Close();
            }

        }
    }
}
