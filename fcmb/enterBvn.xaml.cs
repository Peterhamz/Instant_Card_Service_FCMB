using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for enterBvn.xaml
    /// </summary>
    public partial class enterBvn : Window
    {
        //inside the class definition
        private Process _touchKeyboardProcess = null;

        int textField;

        public enterBvn()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["close"] = "close";
            this.DialogResult = false;
            this.Close();
        }

        private void bvn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void proceed_Click(object sender, RoutedEventArgs e)
        {
            if (bvn.Text != "")
            {
                withoutBVN ui = new withoutBVN();
                accountOptions ao = new accountOptions();
                this.DialogResult = true;
                Application.Current.Resources["bvn"] = bvn.Text;
                Application.Current.Resources["close"] = "closed";
                this.Close();

              /**  try
                {
                    ui.closeOnscreenKeyboard();
                    _touchKeyboardProcess.Kill();
                    _touchKeyboardProcess.Close();
                    _touchKeyboardProcess.Dispose();
                    _touchKeyboardProcess = null;
                }
                catch (Exception)
                {
                    ui.closeOnscreenKeyboard();
                } */
            }
            else
            {
               // bvnerr.Content = "BVN is required";
            }
        }

        private void bvn_GotFocus(object sender, RoutedEventArgs e)
        {
            /** bvnpass.Visibility = Visibility.Collapsed;
             bvnerr.Content = "";

             
             string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

             //replace Process.Start line from the previous listing with
             _touchKeyboardProcess = Process.Start(touchKeyboardPath);*/

            //NumKeypad nm = new NumKeypad();
            //bool? val = nm.ShowDialog();
            //if (val.HasValue && val.Value)
            //{
            //    //ph.Text = Application.Current.FindResource("num").ToString();
            //}
            //else
            //{
            //    bvn.Password = "";
            //}
        }

        private void bvn_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;

                if (bvn.Text == "")
                {
                   // bvnpass.Visibility = Visibility.Visible;
                }
                else
                {
                  //  bvnpass.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }

        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && bvn.Text.Length <= 11)
            {

                bvn.Text += (sender as Button).Content;
            }
        }

        private void Clr_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0)
            {
                int i = bvn.Text.Length;
                if (i > 0)
                {
                    bvn.Text = bvn.Text.Remove(--i);
                }
                else
                {
                    bvn.Text = "";
                }

            }
        }

        private void Pin1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textField = 0;
        }

        private void AccountNumber_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            textField = 1;
           // bvn.Focus();
        }
    }
}
