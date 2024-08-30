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
    /// Interaction logic for pin.xaml
    /// </summary>
    public partial class pin : Window
    {
        int textField;
        public string Pin { get; set; }
             
        
        public pin()
        {
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

        private void CancelPrint_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void PrintCard_Click(object sender, RoutedEventArgs e)
        {
            if(pin1.Password == pinValue.Password)
            {
                Pin = pin1.Password;

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                error.Content = "Pin Must Match";
            }
        }

        private void Clr_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0)
            {
                int i = pin1.Password.Length;
                if (i > 0)
                {
                    pin1.Password = pin1.Password.Remove(--i);
                }
                else
                {
                    pin1.Password = "";
                }

                //account.Text = "";
            }
            if (textField == 1)
            {

                int i = pinValue.Password.Length;
                if (i > 0)
                {
                    pinValue.Password = pinValue.Password.Remove(--i);
                }
                else
                {
                    pinValue.Password = "";
                }
            }
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {

                pinValue.Password += (sender as Button).Content;

            }
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (textField == 0 && pin1.Password.Length <= 3)
            {

                pin1.Password += (sender as Button).Content;
            }
            if (textField == 1 && pinValue.Password.Length <= 3)
            {
               
                pinValue.Password += (sender as Button).Content;

            }
        }

        private void Pin1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textField = 0;
        }

      
        private void PinValue_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textField = 1;
        }
    }
}
