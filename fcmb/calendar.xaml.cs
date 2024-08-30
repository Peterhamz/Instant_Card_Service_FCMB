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
    /// Interaction logic for calendar.xaml
    /// </summary>
    public partial class calendar : Window
    {
        Window darkwindow;
        public calendar()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            string date = String.Format("{0:yyyy-MM-dd}",cal.SelectedDate);
            if (date == "")
            {
                unavailable un = new unavailable("Please select your Birth Date");
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
                bool? val = un.ShowDialog();
                if (!val.Value)
                {
                    darkwindow.Close();
                }
            }
            else
            {
                this.DialogResult = true;
                Application.Current.Resources["cal"] = date;
                this.Close();
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
