using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for cardPrint.xaml
    /// </summary>
    public partial class cardPrint : Window
    {

        data da = new data();
        public data res { get; set; }

        CancellationToken token; CancellationTokenSource source;

    
        public DispatcherTimer timer = new DispatcherTimer();
        int cardId = 0, clickCount = 0;
        String admin = "", custName = "", custAcc = "", cardType = "";

       // string printerstatus = "", pstat = "", device = "Evolis Primacy";
        static string ip = "127.0.0.1"; static int port = 18000;
        public cardPrint()
        {
            InitializeComponent();
        }

        public cardPrint(data cc)
        {
            InitializeComponent();
            da = cc;
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string strUri2 = String.Format(@"pack://application:,,,Contents/atm.png");
            //  cd.Source = new BitmapImage(new Uri(strUri2));

            // account accToken = new account();


            // data da = new data();
            account acc = new account();

            //username.Text = da.Name;

            username.Text = selectName();

            //populate account numbers
            string[] accs = accountNumbers().Split(',');

            acc1.Content = da.AccountNumber;
            acc2.Content = accs[1];
            acc3.Content = accs[2];

            //populate username 



        }

        private string generatePan()
        {
            string pan = "555555", single = string.Empty;

            Random rnd = new Random();
            for (int k = 0; k < 10; k++)
            {
                single += rnd.Next(0, 9).ToString();
            }

            pan += single;

            return pan;
        }

        private string generateCvv()
        {
            string single = string.Empty;

            Random rnd = new Random();
            for (int k = 0; k < 3; k++)
            {
                single += rnd.Next(0, 2).ToString();
            }

            return single;
        }

        private void printCard_Click(object sender, RoutedEventArgs e)
        {

            if (acc1.IsChecked == true)
            {
                da.AccountNo = acc1.Content.ToString();
            }
            else if (acc2.IsChecked == true)
            {
                da.AccountNo = acc2.Content.ToString();
            }
            else if (acc3.IsChecked == true)
            {
                da.AccountNo = acc3.Content.ToString();
            }
           
            else
            {
                showError("Please select an account number");
                return;
            }
            pin acn = new pin();

            bool? result = acn.ShowDialog();
            if (result.Value)
            {

                try
                {
                    prog.IsActive = true;
                    cont.Content = "Card Printing processing";
                    string cardData = generatePan() + "|" + username.Text;
                    printingCard(cardData);
                }
                catch (Exception ex)
                {
                    showError(ex.Message);
                }
            }
            else
            {
                return;
            }

        }

        private void showError(string str)
        {
            unavailable jj = new unavailable(str);

            bool? val = jj.ShowDialog();
            if (val.Value)
            {
                this.DialogResult = false;
                this.Close();
            }

        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string accountNumbers()
        {
            string acc = string.Empty;
            int i = 3; string single = string.Empty;

            Random rnd = new Random();
            for (int j = 0; j < i; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    single += rnd.Next(0, 9).ToString();
                }
                acc += single + ",";
                single = string.Empty;
            }
            return acc;
        }

        private string selectName()
        {
            List<string> names = new List<string>();
            int item = 0;

            names.Add("John Snow");
            names.Add("Abel Yahaya");
            names.Add("James Macron");
            names.Add("Julie Modash");
            names.Add("Harry Neville");
            names.Add("Farouq Ahmed");
            names.Add("Julius Caesar");
            names.Add("David Olayinka");
            names.Add("Precious Abisoye");
            names.Add("Daramola Damilola");

            Random rnd = new Random();
            item = rnd.Next(0, 9);

            return names.ElementAt(item);
        }

        private string printerName()
        {
            string result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:3001/api/printer/get");
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse resp = request.GetResponse();
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    result = reader.ReadToEnd(); // do something fun...
                }

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(result);
                result = xml.InnerText;
            }
            catch (Exception ex)
            {
                prog.IsActive = false;
                cont.Content = "";
                unavailable un = new unavailable(ex.Message);
                un.ShowDialog();
            }
            return result;
        }

        private async void printingCard(string data)
        {
            try
            {
                string nm = printerName();

                var values = new Dictionary<string, string>
                {
                   { "cardData", data }
                };

                HttpClient cli = new HttpClient();
                var content = new FormUrlEncodedContent(values);
                var response = await cli.PostAsync("http://localhost:3001/api/printer/printcard", content);

                var responseString = await response.Content.ReadAsStringAsync();

                if (responseString.Contains("Printing completed"))
                {
                    prog.IsActive = false;
                    cont.Content = responseString.Replace("\\", "");
                    this.DialogResult = false;
                    this.Close();

                    unavailable un = new unavailable(" Thank you for banking with us. Printing completed");
                    un.ShowDialog();

                }
                else
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    unavailable un = new unavailable("Thank you for banking with us now. Printing completed");
                    un.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                prog.IsActive = false;
                cont.Content = "";
                unavailable un = new unavailable(ex.Message);
                un.ShowDialog();
            }
        }


    }
}
