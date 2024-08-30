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
    /// Interaction logic for BVNDet.xaml
    /// </summary>
    public partial class BVNDet : Window
    {
        string vals = "";
        private Process _touchKeyboardProcess = null;

        public BVNDet()
        {
            InitializeComponent();
        }

        public BVNDet(string val)
        {
            InitializeComponent();
            vals = val;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bvnField.Content = vals;
        }

        private void dismiss_Click(object sender, RoutedEventArgs e)
        {
            YorN y = new YorN();
            bool? val = y.ShowDialog();
            if (val.HasValue && val.Value)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            valerr.Content = "";
            if (val.Text == "")
            {
                valerr.Content = "Please fill the required Information";
            }
            else
            {
                if (bvnField.Content.ToString() == "First Name" || bvnField.Content.ToString() == "Last Name")
                {
                    this.DialogResult = true;
                    Application.Current.Resources["bvnVal"] = bvnField+"?"+val.Text;
                    this.Close();
                }
                if (bvnField.Content.ToString() == "Phone Number")
                {
                    Regex rg = new Regex("^0[789][01]\\d{8}$");
                    Regex rr = new Regex("^[0345678][0123456789]\\d{7}$");

                    var b = rg.IsMatch(val.Text);
                    var c = rr.IsMatch(val.Text);
                    if (b || c)
                    {
                        this.DialogResult = true;
                        Application.Current.Resources["bvnVal"] = bvnField + "?" + val.Text;
                        this.Close();
                    }
                    else
                    {
                        val.Text = "";
                        valerr.Content = "Invalid Mobile Number";
                    }
                }
                if (bvnField.Content.ToString() == "Email")
                {
                    Regex rg = new Regex("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+[a-zA-Z]$");

                    var b = rg.IsMatch(val.Text);
                    if (!b)
                    {
                        val.Text = "";
                        valerr.Content = "Invalid Email";
                    }
                    else
                    {
                        this.DialogResult = true;
                        Application.Current.Resources["bvnVal"] = bvnField + "?" + val.Text;
                        this.Close();
                    }
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void bvn_GotFocus(object sender, RoutedEventArgs e)
        {
            //string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

            //replace Process.Start line from the previous listing with
            //  _touchKeyboardProcess = Process.Start(touchKeyboardPath);

            if (!val.IsKeyboardFocused)
            {
                Keyboard.Focus(val);
            }

        }

      /**  private void bvn_LostFocus(object sender, RoutedEventArgs e)
        {
            withoutBVN wbv = new withoutBVN();
            try
            {
                Keyboard.ClearFocus();
                wbv.closeOnscreenKeyboard();
                _touchKeyboardProcess.CloseMainWindow();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                wbv.closeOnscreenKeyboard();
            }
        }*/

        private void Val_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            key keyboardWindow = new key(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }
    }
}
