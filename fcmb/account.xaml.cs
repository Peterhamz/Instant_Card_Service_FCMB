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
    /// Interaction logic for account.xaml
    /// </summary>
    public partial class account : Window
    {
        int textField;
    

        public data result { get; set; }

        public account()
        {
            InitializeComponent();
        }

        MainWindow mn1 = null;

        public account( MainWindow mw)
        {
            mn1 = mw;
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (Exception)
            {

            }
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            data dd = new data();

            dd.AccountNo = accountNumber.Text;           
            result = dd;

            this.DialogResult = true;
            this.Close();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = false;
            this.Close();

        }

        private void AccountNumber_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textField = 0;
           // accountNumber.Focus();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
            
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && accountNumber.Text.Length <= 9)
            {

                accountNumber.Text += (sender as Button).Content;
            }

        }

        private void Clr_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0)
            {
                int i = accountNumber.Text.Length;
                if (i > 0)
                {
                    accountNumber.Text = accountNumber.Text.Remove(--i);
                }
                else
                {
                    accountNumber.Text = "";
                }

            }
        }

    
    }
}
