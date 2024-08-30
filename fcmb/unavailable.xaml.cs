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
    /// Interaction logic for unavailable.xaml
    /// </summary>
    public partial class unavailable : Window
    {
        string message = "";
        public unavailable()
        {
            InitializeComponent();
        }

        public unavailable(string mes)
        {
            InitializeComponent();
            message = mes;
        }

        private void dismiss_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(message == "")
            {
                res.Document.Blocks.Clear();
                res.Document.Blocks.Add(new Paragraph(new Run("This Functionality is currently not available on the Kiosk.")));
            }
            else
            {
                res.Document.Blocks.Clear();
                res.Document.Blocks.Add(new Paragraph(new Run(message)));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

       
    }
}
