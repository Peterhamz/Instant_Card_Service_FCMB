using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Xml;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for AccountPrint.xaml
    /// </summary>
    public partial class AccountPrint : Window
    {

        data da = new data();
        public data res { get; set; }
        private string BaseUrl = ConfigurationManager.AppSettings["baseUrl"];

        MainWindow mw = new MainWindow();
        public AccountPrint()
        {
            InitializeComponent();
        }

        public AccountPrint(data d)
        {
            InitializeComponent();
            da = d;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //populate username
           // username.Text = da.CardHoldername;
           //  balance.Content += da.Balance;

            //populate account numbers
            //  string[] accs = new string[da.Accounts.Count];


            account acc = new account();

            //username.Text = da.Name;

            username.Text = selectName();

            //populate account numbers
            string[] accs = accountNumbers().Split(',');

            acc1.Content = da.AccountNumber;
            acc2.Content = accs[1];
            acc3.Content = accs[2];

           /** switch (da.Accounts.Count.ToString())
            {
                case "1":
                    acc1.Content = da.Accounts.ElementAt(0).AccountNumber;
                    acc2.Visibility = Visibility.Hidden;
                    acc3.Visibility = Visibility.Hidden;
                  /**  acc4.Visibility = Visibility.Hidden;
                    acc5.Visibility = Visibility.Hidden;
                    break;
                case "2":
                    acc1.Content = da.Accounts.ElementAt(0).AccountNumber;
                    acc2.Content = da.Accounts.ElementAt(1).AccountNumber;
                    acc3.Visibility = Visibility.Hidden;
                    /**acc4.Visibility = Visibility.Hidden;
                    acc5.Visibility = Visibility.Hidden;
                    break;
                case "3":
                    acc1.Content = da.Accounts.ElementAt(0).AccountNumber;
                    acc2.Content = da.Accounts.ElementAt(1).AccountNumber;
                    acc3.Content = da.Accounts.ElementAt(2).AccountNumber;
                   /** acc4.Visibility = Visibility.Hidden;
                    acc5.Visibility = Visibility.Hidden;
                    break;
                case "4":
                    acc1.Content = da.Accounts.ElementAt(0).AccountNumber;
                    acc2.Content = da.Accounts.ElementAt(1).AccountNumber;
                    acc3.Content = da.Accounts.ElementAt(2).AccountNumber;
                   /** acc4.Content = da.Accounts.ElementAt(3).AccountNumber;
                    acc5.Visibility = Visibility.Hidden;
                    break;
                case "5":
                    acc1.Content = da.Accounts.ElementAt(0).AccountNumber;
                    acc2.Content = da.Accounts.ElementAt(1).AccountNumber;
                    acc3.Content = da.Accounts.ElementAt(2).AccountNumber;
                  /**  acc4.Content = da.Accounts.ElementAt(3).AccountNumber;
                    acc5.Content = da.Accounts.ElementAt(4).AccountNumber;
                    break;
               
            }*/
        }


        private void Print_Click(object sender, RoutedEventArgs e)
        {
           
            try
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
               /* else if (acc4.IsChecked == true)
                {
                    da.AccountNo = acc4.Content.ToString();
                }
                else if (acc5.IsChecked == true)
                {
                    da.AccountNo = acc5.Content.ToString();
                }*/
                else
                {
                    ShowError("Please select an account number", mw);
                    return;
                }

                pin acn = new pin();

                bool? result = acn.ShowDialog();
                if (result.Value)
                {
                   

                    try
                    {
                        prog.IsActive = true;
                        string cardData = generatePan() + "|" + username.Text;
                        printingCard(cardData);

                        //new definition for Entrust for kiosk

                        /** RequestCardPrint request = new RequestCardPrint()
                         {

                            
                             dataItems = new List<DataItem>()
                             {
                                 new DataItem{identifier = "@CardHolderName@", value= username.Text },
                                 new DataItem{identifier = "@ExpirationDate@", value="03/2023" },
                                 new DataItem{identifier = "@PAN2@", value= "4338281000246297" },
                                 new DataItem{identifier = "@CVV2@", value="786" }
                                 
                             },
                             overrideTokenList = new List<object>()
                             {

                             },
                             impersonatedUser = new ImpersonatedUser()
                             {
                                 RequesterUserName = "wizard1!",
                                 RequesterPCName = "win-mho171op77a"
                             },
                             RequesterPCName = false,
                             isAutoGeneratePIN=false

                         };

                         entrustPrint(request);*/
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

                res = da;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void showError(string str)
        {
            unavailable jj = new unavailable(str);

            bool? val = jj.ShowDialog();
            if (val.Value)
            {
            }
        }

        private void ShowError(string msg, MainWindow mw)
        {
            unavailable un = new unavailable(msg);
            var vall = un.ShowDialog();
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
                    //  prog.IsActive = true;
                    // cont.Content = responseString.Replace("\\", "");
                    // this.DialogResult = false;
                    // this.Close();

                    unavailable un = new unavailable(" Thank you for banking with us. Printing completed");
                    un.ShowDialog();

                }
                else
                {
                    //  prog.IsActive = false;
                    // cont.Content = "";
                    unavailable un = new unavailable("Thank you for banking with us now. Printing completed");
                    un.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // prog.IsActive = false;
                // cont.Content = "";
                unavailable un = new unavailable(ex.Message);
                un.ShowDialog();
            }
        }
        /** private async void printingCard(string data)
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
                   // prog.IsActive = false;
                   //  cont.Content = responseString.Replace("\\", "");
                     this.DialogResult = false;
                     this.Close();

                     unavailable un = new unavailable(" Thank you for banking with us. Printing completed");
                     un.ShowDialog();

                 }
                 else
                 {
                   //  prog.IsActive = false;
                    // cont.Content = "";
                     unavailable un = new unavailable("Thank you for banking with us now. Printing completed");
                     un.ShowDialog();
                 }
             }
             catch (Exception ex)
             {
                // prog.IsActive = false;
                // cont.Content = "";
                 unavailable un = new unavailable(ex.Message);
                 un.ShowDialog();
             }
         } */

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
                //prog.IsActive = false;
               // cont.Content = "";
                unavailable un = new unavailable(ex.Message);
                un.ShowDialog();
            }
            return result;
        }
    }
}
