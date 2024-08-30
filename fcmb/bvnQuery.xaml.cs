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
using System.Windows.Shapes;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for bvnQuery.xaml
    /// </summary>
    public partial class bvnQuery : Window
    {
        public bvnQuery()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["close"] = "close";
            this.Close();
        }

        private void bvnNo_Click(object sender, RoutedEventArgs e)
        {
            accountOptions ao = new accountOptions();
            this.DialogResult = false;
            Application.Current.Resources["close"] = "closed";
            this.Close();
        }

        private void bvnYees_Click(object sender, RoutedEventArgs e)
        {
            accountOptions ao = new accountOptions();
            this.DialogResult = true;
            Application.Current.Resources["close"] = "closed";
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
