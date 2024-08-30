using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace fcmb
{
   
    public partial class accountOptions : Page
    {
        Window darkwindow;
        public accountOptions()
        {
            InitializeComponent();
        }

        private void newCust_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AccountTypes.xaml", UriKind.Relative));
            /** bvnQuery bv = new bvnQuery();

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

             bool? val = bv.ShowDialog();

             //  if (val.HasValue && val.Value)
             if (val.Value)
             {
                 darkwindow.Close();

                 enterBvn un = new enterBvn();

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

                 bool? var = un.ShowDialog();
                 if (!var.Value)
                 {
                     darkwindow.Close();
                 }

                // string bvnRes = un.bvn.Text;
                 string res = Application.Current.FindResource("bvn").ToString();
                 string close = Application.Current.FindResource("close").ToString();
                 if (close == "close")
                 {
                     NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                 }
                 else
                 {
                     darkwindow.Close();
                     CheckBVN(res);
                 }
             }
             else
             {
                 darkwindow.Close();
                 string close = Application.Current.FindResource("close").ToString();
                 if (close == "close")
                 {
                     NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                 }
                 else
                 {
                     //withoutBVN op = new withoutBVN("No");
                     CreateAccount ca = new CreateAccount("No");
                     this.NavigationService.Navigate(ca);
                 }
             } */
        }

        private async void CheckBVN(string bvn)
        {
            try
            {
                dynamic content = null;
                BVNRespMessage ap = new BVNRespMessage();
                prog.IsActive = true;
                cont.Content = "Fetching Data...";

                using (var client = new HttpClient())
                {
                    /*client.BaseAddress = new Uri("https://uat.firstcitygrouponline.com/onlineaccountopeningservice/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("AppId", "12345");
                    client.DefaultRequestHeaders.Add("AppKey", "123456");*/

                    //specify to use TLS 1.2 as default connection
                    System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    client.BaseAddress = new Uri("https://devapi.fcmb.com/BVN/api/BVNServiceContoller/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("client_id","250");
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key","55d7f996f5994e0c846e203bec3880b1");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var resp = await client.GetAsync("GetSingleBVNFullDetails?BVN=" + bvn);

                  //  MessageBox.Show(resp.Content.ReadAsStringAsync().Result);

                    if (resp.IsSuccessStatusCode)
                    {
                        // Use this if you want JSON type returned
                        content = JsonConvert.DeserializeObject<BVNRoot>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                        prog.IsActive = false;
                        cont.Content = "";
                        if (!content.code.Contains("00"))
                        {
                            unavailable un = new unavailable(content.Message);

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

                            bool? var = un.ShowDialog();
                            if (var.Value)
                            {
                                darkwindow.Close();
                            }
                            else
                            {
                                darkwindow.Close();
                            }
                        }
                        else
                        {
                            withBVN op = new withBVN(content);
                            this.NavigationService.Navigate(op);
                        }
                    }
                    else
                    {
                        prog.IsActive = false;
                        cont.Content = "";
                        unavailable un = new unavailable(resp.ReasonPhrase);

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

                        bool? var = un.ShowDialog();
                        if (var.Value)
                        {
                            darkwindow.Close();
                        }
                        else
                        {
                            darkwindow.Close();
                        }
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                prog.IsActive = false;
                cont.Content = "";
                unavailable un = new unavailable(e.Message);

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

                bool? var = un.ShowDialog();
                if (var.Value)
                {
                    darkwindow.Close();
                }
                else
                {
                    darkwindow.Close();
                }
            }
        }

        private void existCust_Click(object sender, RoutedEventArgs e)
        {
            unavailable pi = new unavailable();
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

            bool? val = pi.ShowDialog();
            if (val.HasValue && !val.Value)
            {
                darkwindow.Close();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("start.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Content = String.Format("{0:dddd, dd MMMM yyyy}", DateTime.Now);
        }

        private void exstImg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            unavailable un = new unavailable();
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
            if (val.HasValue && !val.Value)
            {
                darkwindow.Close();
            }
        }

        private void cutImg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bvnQuery bv = new bvnQuery();

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

            bool? val = bv.ShowDialog();

            if (val.HasValue && val.Value)
            {
                darkwindow.Close();

                enterBvn un = new enterBvn();

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

                bool? var = un.ShowDialog();
                if (var.Value)
                {
                    darkwindow.Close();
                }
                else
                {
                    darkwindow.Close();
                }

                string bvn = un.bvn.Text;
                string res = Application.Current.FindResource("bvn").ToString();
                string close = Application.Current.FindResource("close").ToString();
                if (close == "close")
                {
                    NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                }
                else
                {
                    CheckBVN(res);
                }
            }
            else
            {
                darkwindow.Close();
                string close = Application.Current.FindResource("close").ToString();
                if (close == "close")
                {
                    NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                }
                else
                {
                    //withoutBVN op = new withoutBVN("No");
                    CreateAccount ca = new CreateAccount("No");
                    this.NavigationService.Navigate(ca);
                }
            }
        }

    }
}
