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
    /// Interaction logic for NumKeypad.xaml
    /// </summary>
    public partial class NumKeypad : Window
    {
        withoutBVN withoutbvn; enterBvn ebvnn;
        public NumKeypad()
        {
            InitializeComponent();
        }

        public NumKeypad(withoutBVN wobvn)
        {
            InitializeComponent();
            withoutbvn = wobvn;
        }

        public NumKeypad(enterBvn ebvn)
        {
            InitializeComponent();
            ebvnn = ebvn;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "1";
            }
            catch (Exception ex)
            {
                enterBvn ebvn = new enterBvn();
                ebvn.bvn.Text += "1";
            }
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "2";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "2";
            }
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "3";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "3";
            }
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "4";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text
                    += "4";
            }
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "5";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "5";
            }
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "6";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "6";
            }
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "7";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "7";
            }
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "8";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "8";
            }
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "9";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "9";
            }
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withoutbvn.ph.Text += "0";
            }
            catch (Exception ex)
            {
                ebvnn.bvn.Text += "0";
            }
        }

        private void bks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = withoutbvn.ph.Text.Length;
                if (i > 0)
                {
                    withoutbvn.ph.Text = withoutbvn.ph.Text.Remove(--i);
                }    
            }
            catch (Exception)
            {
                int i = ebvnn.bvn.Text.Length;
                if (i > 0)
                {
                    ebvnn.bvn.Text = ebvnn.bvn.Text.Remove(--i);
                }  
            }
                    
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
