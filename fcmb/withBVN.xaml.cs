using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for withBVN.xaml
    /// </summary>
    public partial class withBVN : Page
    {
        BVNRoot heav; Window darkwindow;
        CancellationToken token; CancellationTokenSource source;
        public withBVN()
        {
            InitializeComponent();
        }

        public withBVN(BVNRoot bv)
        {

            MessageBox.Show(bv.data.bvn);
            InitializeComponent();
            heav = bv;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtt.Content = String.Format("{0:dddd, dd MMMM yyyy}", DateTime.Now);
            try
            {
                if (heav.data.phoneNumber1 == "")
                {
                    phone.Content = heav.data.phoneNumber2;
                }
                else {
                    phone.Content = heav.data.phoneNumber1;
                }
                fullname.Content = heav.data.firstName + " " + heav.data.middleName + " " + heav.data.lastName;
                dob.Content = heav.data.dateOfBirth;
                email.Content = heav.data.email;
                gen.Content = heav.data.gender+ ", "+ heav.data.maritalStatus;
                nat.Content = heav.data.stateOfOrigin+", "+heav.data.nationality;
               // phone.Content = heav.PhoneNumber2;
                res.Document.Blocks.Clear();
                res.Document.Blocks.Add(new Paragraph(new Run(heav.data.residentialAddress)));//to get value, use string txt = new TextRange(res.Document.ContentStart, res.Document.ContentEnd).Text;
            }
            catch (Exception)
            {
                //this happens if no BVN
            }
        }
       
        private void signature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                signature pi = new signature();
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
                if (!val.Value)
                {
                    darkwindow.Close();
                }
                if (val.HasValue && val.Value)
                {
                    darkwindow.Close();
                    continueCreate.IsEnabled = true;
                    two.Fill = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    darkwindow.Close();
                    two.Fill = System.Windows.Media.Brushes.Red;
                }
            }
            catch (Exception)
            {
                unavailable un = new unavailable("Please Ensure that your signature hardware is properly connected.");
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
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prog.IsActive = false;
                cont.Content = "";
                NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
               /** source.Cancel();
                if (token.IsCancellationRequested)
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                } */
            }
            catch (Exception)
            {
                NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
            }
        }
                
        private async void continueCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                source = new CancellationTokenSource();
                token = source.Token;

                withoutBVN wb = new withoutBVN();
                dynamic content = null;
                prog.IsActive = true;
                cont.Content = "Creating Account...";
                int refe = 0;
                string fn = "", mn = "", ln = "", ph = "", em = "";

                BitmapImage img = (BitmapImage)photo.Source;
                BitmapImage sig = (BitmapImage)sign.Source;

                string base64Passport = "", base64Sign = "";
                try
                {
                    base64Passport = wb.BitmapToString(img);
                }
                catch (Exception)
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    unavailable un = new unavailable("Please take a Passport Photograph");
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
                    return;
                }

                try
                {
                    base64Sign = wb.BitmapToString(sig);
                }
                catch (Exception)
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    unavailable un = new unavailable("Please append your Signature");
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
                    return;
                }

                if (base64Passport != "" && base64Sign != "")
                {
                    using (var client = new HttpClient())
                    {
                        /**System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                        client.BaseAddress = new Uri("https://uat.firstcitygrouponline.com/onlineaccountopeningservice/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Add("AppId", "12345");
                        client.DefaultRequestHeaders.Add("AppKey", "123456");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));*/

                        try
                        {
                            refe = wb.loadRefNum();
                            refe = refe + 1;
                        }
                        catch (Exception)
                        {
                            refe = 1;
                        }

                        wb.saveRefNum(refe);

                        string[] nm = fullname.Content.ToString().Split(' ');

                        string date = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dob.Content));//check this format
                        string resAdd = new TextRange(res.Document.ContentStart, res.Document.ContentEnd).Text;
                        string[] st = nat.Content.ToString().Split(',');
                        string[] ge = gen.Content.ToString().Split(',');
                        string txt = new TextRange(res.Document.ContentStart, res.Document.ContentEnd).Text;

                        if (nm.Count() == 3) { fn = nm[0]; mn = nm[1]; ln = nm[2]; }
                        else { fn = nm[0]; mn = ""; ln = nm[1]; }

                        ph = phone.Content.ToString();
                        em = email.Content.ToString();

                        //checking if BVN brings empty field
                        if(heav.data.title == "")
                        {
                            Title = "";
                        }
                        if (heav.data.firstName == "")
                        {
                            BVNDet bv = new BVNDet("First Name");
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
                         /**   bool? val = bv.ShowDialog();
                            if (val.HasValue && val.Value)
                            {
                                darkwindow.Close();
                                string valu = Application.Current.FindResource("bvnVal").ToString();
                                string[] v = valu.Split('?');
                                fn = v[1];

                                fullname.Content = "";
                                fullname.Content = fn + " " + heav.data.middleName + " " + heav.data.lastName;
                            }
                            else
                            {
                                darkwindow.Close();
                               // NavigationService.Navigate(new Uri("accountOptions.xaml"), UriKind.Relative);
                            }*/
                        }
                        if (heav.data.lastName == "")
                        {
                            BVNDet bv = new BVNDet("Last Name");
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
                          /*  bool? val = bv.ShowDialog();
                            
                            if (val.HasValue && val.Value)
                            {
                                darkwindow.Close();
                                string valu = Application.Current.FindResource("bvnVal").ToString();
                                string[] v = valu.Split('?');
                                ln = v[1];

                                fullname.Content = "";
                                fullname.Content = heav.data.firstName + " " + heav.data.middleName + " " + ln;
                            }
                            else
                            {
                                darkwindow.Close();
                               // NavigationService.Navigate(new Uri("accountOptions.xaml"), UriKind.Relative);
                            }*/
                        }
                        if (heav.data.phoneNumber1 == "" && heav.data.phoneNumber2 == "")
                        {
                            BVNDet bv = new BVNDet("Phone Number");
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
                           /* bool? val = bv.ShowDialog();
                            
                            if (val.HasValue && val.Value)
                            {
                                darkwindow.Close();
                                string valu = Application.Current.FindResource("bvnVal").ToString();
                                string[] v = valu.Split('?');
                                ph = v[1];
                                phone.Content = "";
                                phone.Content = ph;
                            }
                            else
                            {
                                darkwindow.Close();
                               // NavigationService.Navigate(new Uri("accountOptions.xaml"), UriKind.Relative);
                            }*/
                        }
                        else
                        {
                            if(heav.data.phoneNumber1 != "")
                            {
                                ph = heav.data.phoneNumber1;
                            }
                            if (heav.data.phoneNumber2 != "")
                            {
                                ph = heav.data.phoneNumber2;
                            }
                        }
                        if (heav.data.email == "")
                        {
                            BVNDet bv = new BVNDet("Email");
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
                           /* bool? val = bv.ShowDialog();
                            
                            if (val.HasValue && val.Value)
                            {
                                darkwindow.Close();
                                string valu = Application.Current.FindResource("bvnVal").ToString();
                                string[] v = valu.Split('?');
                                em = v[1];
                                email.Content = "";
                                email.Content = em;
                            }
                            else
                            {
                                darkwindow.Close();
                               // NavigationService.Navigate(new Uri("accountOptions.xaml"), UriKind.Relative);
                            }*/
                        }
                        string[] refNum = refrenceNumber().Split(',');
                        AccountOpeningRequest req = new AccountOpeningRequest
                        {
                            //Title = "Mr",
                            Complete = "Yes",
                            MotherMaidenName = "NA",
                            PreferredBranch = "001",
                            ReferenceNo = refNum[0],
                            Resident = "Yes",
                            BVNNumber = heav.data.bvn,
                            FirstName = fn,
                            MiddleName = mn,
                            LastName = ln,
                            Gender = ge[0],
                            MaritalStatus = ge[1],
                            Nationality = st[1],
                            DateOfBirth = date,
                            SchemeCode = "SB114",
                            Channel_Id = "ATM01",
                            Email = em,
                            PhoneNumber = ph,
                            ResidentialAddress = txt,
                            Photo = base64Passport,
                            Signature = base64Sign
                        };

                        var jsonString = JsonConvert.SerializeObject(req);
                        var resp = await client.PostAsync("api/accountopening/createaccount", new StringContent(jsonString, Encoding.UTF8, "application/json"), token);

                        //account demo

                        prog.IsActive = false;
                        cont.Content = "";
                        string thxt = "Dear " + fn + " " + ln + " , your account has been created.Your account number is " + content.accountNumberField + ". Kindly fund account before initiating card request";
                        alert un = new alert(thxt);
                        //unavailable un = new unavailable("Dear Customer an error occur kindly contact the cashier for further assistance");
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
                        /** if (resp.IsSuccessStatusCode)
                          {
                              // use this if you want object type returned
                              content = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                              prog.IsActive = false;
                              cont.Content = content.responseMessageField;

                              string thxt = "Dear " + fn + " " + ln + " , your account has been created.Your account number is " + content.accountNumberField + ". Kindly fund account before initiating card request";
                              alert un = new alert(thxt);
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
                              if (val.Value)
                              {
                                  darkwindow.Close();
                              }
                              NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                          }
                          else
                          {
                              prog.IsActive = false;
                              cont.Content = "";
                              string thxt = "Dear " + fn + " " + ln + " , your account has been created.Your account number is " + content.accountNumberField + ". Kindly fund account before initiating card request";
                              alert un = new alert(thxt);
                              //unavailable un = new unavailable("Dear Customer an error occur kindly contact the cashier for further assistance");
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
                          } */
                    }
                }
                else
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    unavailable un = new unavailable("All Fields are required");
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
            }
            catch (Exception ex)
            {
                prog.IsActive = false;
                cont.Content = "";
                if (ex.Message == "A task was cancelled")
                {
                    unavailable un = new unavailable("Account Creation Cancelled");
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
                    unavailable un = new unavailable(ex.Message);
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
            }
        }

        private void cam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                passport pi = new passport();
                bool? val = pi.ShowDialog();
                if (val.HasValue && val.Value)
                {
                    signature.IsEnabled = true;
                    one.Fill = System.Windows.Media.Brushes.Green;
                }
            }
            catch (Exception)
            {
                unavailable un = new unavailable("Please Ensure that your Hardware is properly connected.");
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
        }

        private void title_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private string refrenceNumber()
        {
            string num = string.Empty;
            int i = 3; string single = string.Empty;

            Random rnd = new Random();
            for (int j = 0; j < i; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    single += rnd.Next(0, 9).ToString();
                }
                num += single + ",";
                single = string.Empty;
            }
            return num;
        }

    }
}
