using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
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
using RestSharp;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Page
    {
        bool b = false; 
        CancellationToken token; 
        CancellationTokenSource source; 
        Window darkwindow;

        public CreateAccount()
        {
            InitializeComponent();
        }

        public CreateAccount(string opt)
        {
            InitializeComponent();

            if (opt == "No")
            {

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            countries ct = new countries();
            dtt.Content = String.Format("{0:dddd, dd MMMM yyyy}", DateTime.Now);
           /** ctryRes.Items.Clear();
            foreach (var item in ct.count)
            {
                ctryRes.Items.Add(item);
            }*/
        }

        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (firstName.Text != "")
            {
                gen.SetValue(Border.BorderBrushProperty, Brushes.Green);
                lastName.IsEnabled = true;
               // gImg.Visibility = Visibility.Visible;
            }
        }

        private void FirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!firstName.IsKeyboardFocused)
            {
                Keyboard.Focus(firstName);
            }
        }

        private void FirstName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            key keyboardWindow = new key(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }

        private void MiddleName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!firstName.IsKeyboardFocused)
            {
                Keyboard.Focus(firstName);
            }
        }

        private void MiddleName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lastName.Text != "")
            {
                gen.SetValue(Border.BorderBrushProperty, Brushes.Green);
                lastName.IsEnabled = true;
               // gImg.Visibility = Visibility.Visible;
            }
        }

        private void LastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!lastName.IsKeyboardFocused)
            {
                Keyboard.Focus(lastName);
            }
        }

        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lastName.Text != "")
            {
                gen.SetValue(Border.BorderBrushProperty, Brushes.Green);
                phone.IsEnabled = true;
              //  gImg.Visibility = Visibility.Visible;
            }
        }

        private void PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!phone.IsKeyboardFocused)
            {
                Keyboard.Focus(phone);
            }
        }

        private void PhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!phone.IsKeyboardFocused)
            {
                Keyboard.Focus(phone);
            }
        }

        private void PhoneNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            Keypad keyboardWindow = new Keypad(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }

        private void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (phone.Text != "")
            {
               // marital.IsEnabled = true;

                Regex rg = new Regex("^0[789][01]\\d{8}$");
                Regex rr = new Regex("^[0345678][0123456789]\\d{7}$");

                var b = rg.IsMatch(phone.Text);
                var c = rr.IsMatch(phone.Text);
                if (b || c)
                {
                    Keyboard.ClearFocus();
                    phone.SetValue(Border.BorderBrushProperty, Brushes.Green);
                    
                   // phImg.Visibility = Visibility.Visible;
                }
                else
                {
                    phone.Text = "";
                    Keyboard.ClearFocus();
                    unavailable un = new unavailable("Invalid Mobile Number");
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
                  //  email.IsEnabled = false;
                }
            }
            else
            {
                phone.SetValue(Border.BorderBrushProperty, Brushes.Black);
              //  email.IsEnabled = false;
            }
        }

        private void Phone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!phone.IsKeyboardFocused)
            {
                Keyboard.Focus(phone);
               // marital.IsEnabled = true;
            }
        }
       

        private void Newdat_GotFocus(object sender, RoutedEventArgs e)
        {
            calendar cd = new calendar();
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
            bool? val = cd.ShowDialog();
            if (val.HasValue && val.Value)
            {
                darkwindow.Close();
                newdat.Text = Application.Current.FindResource("cal").ToString();
                gen.IsEnabled = true;
                marital.IsEnabled = true;
            }
            else
            {
                darkwindow.Close();
                newdat.Text = "";
            }
        }
        private void Newdat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (newdat.Text != "")
            {
                newdat.SetValue(Border.BorderBrushProperty, Brushes.Green);
               // dobImg.Visibility = Visibility.Visible;
            }
            else
            {
                newdat.SetValue(Border.BorderBrushProperty, Brushes.Black);
                gen.IsEnabled = false;
                marital.IsEnabled = false;
            }
        }

        private void Gen_DropDownClosed(object sender, EventArgs e)
        {
            if (gen.Text != "")
            {
                gen.SetValue(Border.BorderBrushProperty, Brushes.Green);
               // gImg.Visibility = Visibility.Visible;
            }
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
                    single += rnd.Next(0, 14).ToString();
                }
                num += single + ",";
                single = string.Empty;
            }
            return num;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                prog.IsActive = false;
                cont.Content = "";
                NavigationService.Navigate(new Uri("AccountTypes.xaml", UriKind.Relative));

            }
            catch (Exception)
            {
                NavigationService.Navigate(new Uri("AccountTypes.xaml", UriKind.Relative));
            }

        }

        private void LastName_GotFocus_1(object sender, RoutedEventArgs e)
        {

        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
 
        internal int loadRefNum()
        {
            var settings = new Dictionary<string, object>();
            int num = 0;

            BinaryFormatter formatter = new BinaryFormatter();
            var store = IsolatedStorageFile.GetUserStoreForAssembly();

            // Load
            using (var stream = store.OpenFile("referenceNum.cfg", FileMode.OpenOrCreate, FileAccess.Read))
            {
                settings = (Dictionary<string, object>)formatter.Deserialize(stream);
            }

            num = Convert.ToInt32(settings["refNum"]);
            return num;
        }

        internal void saveRefNum(int num)
        {
            var settings = new Dictionary<string, object>();
            settings.Add("refNum", num);

            BinaryFormatter formatter = new BinaryFormatter();
            var store = IsolatedStorageFile.GetUserStoreForAssembly();

            // Save
            using (var stream = store.OpenFile("referenceNum.cfg", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(stream, settings);
            }

        }

      /**  private async void ContinueCreate_Click(object sender, RoutedEventArgs e)
        {

            prog.IsActive = true; 
            cont.Content = "Creating Account ...";

            using (var client = new HttpClient())
            {
                if (firstName.Text != "" && lastName.Text != "" && newdat.Text != "" && phone.Text != "" && gen.Text != "")
                {
                    string sex = "";
                    string status = "";
                    string salute = "";


                    switch (title.Text)
                    {
                        case "Mr":
                            salute = "Mr";
                            break;
                        case "Mrs":
                            salute = "Mrs";
                            break;
                        case "Miss":
                            salute = "Miss";
                            break;

                    }
                    switch (gen.Text)
                    {
                        case "Male":
                            sex = "M";
                            break;
                        case "Female":
                            sex = "F";
                            break;

                    }
                    switch (marital.Text)
                    {
                        case "Single":
                            status = "SNG";
                            break;
                        case "Married":
                            status = "MAR";
                            break;
                        case "Divorce":
                            status = "DIV";
                            break;

                    }

                    string date = String.Format("{0:yyyy-MM-dd'T'HH:mm:ss}", Convert.ToDateTime(newdat.Text));
                   // string date = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(newdat.Text));
                    DateTime currentDateTime = DateTime.Now;
                    string formattedDateTime = currentDateTime.ToString("0,yyyy-MM-dd'T'HH:mm:ss");
                   // string sDate = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(DateTimeOffset.Now));
                    //check this format
                    string[] refNum = refrenceNumber().Split(',');

                 //   MessageBox.Show(date);
                   
                    /** Root request = new Root()
                     {

                         firstName = firstName.Text,
                         middleName = middleName.Text,
                         lastName = lastName.Text,
                         motherMaidenName = "NA",
                         dob = Convert.ToDateTime(newdat.Text),
                         gender = sex,
                         bvnMobileNumber = phone.Text,
                         preferredMobileNumber = phone.Text,
                         email = email.Text,
                         bvn = bvn.Text,
                         maritalStatus = "SNG",
                         occupation = "NA",
                         employmentStatus = "employed",
                         image = "NA",
                         addImageFromBVN = true,
                         requestId = refNum[0],
                         address = new Address()
                         {
                             addrLine1 = address.Text,
                             houseNum = "",
                             streetName = "",
                             city = "",
                             state = "LG",
                             country = "NG"
                         },
                         configCredentials = new ConfigCredentials()
                         {
                             clientId = "250",
                             productId = "14"
                         }
                     };*/
      /**
                    Root request = new Root()
                    {

                        firstName = firstName.Text,
                        middleName = middleName.Text,
                        lastName = lastName.Text,
                        motherMaidenName = "",
                       // dob = Convert.ToDateTime(newdat.Text),
                        dob = date,
                        gender = sex,
                        bvnMobileNumber = phone.Text,
                        email = email.Text,
                        address = new Address()
                        {
                           addrLine1 = address.Text,
                           addrLine2 = "Nigeria",
                           city = "LAG",
                           country= "NG",
                           houseNum ="",
                           startDate= formattedDateTime,
                           state= "LG",
                           streetName= "",
                           streetNum= null,
                           postalCode="234",

                        },
                        bvn = bvn.Text,
                        maritalStatus= status,
                        employmentStatus= "Other",
                        occupation="",
                        salutation=salute,
                        requestId= refNum[0],
                        addImageFromBVN= true,
                        configCredentials = new ConfigCredentials()
                        {
                            clientId="250",
                            productId="14"
                        }
                    };

                    var jsonString = JsonConvert.SerializeObject(request);

                   // MessageBox.Show(jsonString);
             
                    client.BaseAddress = new Uri("https://devapi.fcmb.com/selfservicekiosk/api/Accounts/v1/");
                    client.DefaultRequestHeaders.Add("client_id", "250");
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "55d7f996f5994e0c846e203bec3880b1");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var response = client.PostAsync("CreateRetailAccountMiniData", new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                    var content1 = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));

                    MessageBox.Show(content1.description);

                    prog.IsActive = false;
                 //  cont.Content = content.ResponseMessage;

                   /** string txt = "Dear " + firstName.Text + " " + lastName.Text + " , your Account has been created Successfully ";

                    alert un = new alert(txt);
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
                    NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));*/

                 /**   if (response.IsSuccessStatusCode)
                    {
                        // MessageBox.Show("successful");
                        var content = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));

                        prog.IsActive = false;
                        cont.Content = content.description;

                        string txt = "Dear " + firstName.Text + " " + lastName.Text + " , your Account has been created Successfully " +"Your Account number is :" + content1.data.accountNumber;

                        alert un = new alert(txt);
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
                        // MessageBox.Show("successful Error");
                        unavailable un = new unavailable("Sorry, Account creation fail as a result of : " + content1.description);
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
                            NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                        }
                    }

                }
                else
                {

                    prog.IsActive = false;
                    cont.Content = "";
                    MessageBox.Show("value");
                    unavailable un = new unavailable("Input needs to be pass on all input field.");
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


        }*/

        private void ContinueCreate_Click1(object sender, RoutedEventArgs e)
        {

            prog.IsActive = true; cont.Content = "Creating Wallet...";

            using (var client = new HttpClient())
            {
                if (firstName.Text != "" && lastName.Text != "" && newdat.Text != "" && phone.Text != "" && gen.Text != "")
                {
                    string sex = "";

                    switch (gen.Text)
                    {
                        case "Male":
                            sex = "M";
                            break;
                        case "Female":
                            sex = "F";
                            break;

                    }


                    string date = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(newdat.Text));
                    //check this format
                    string[] refNum = refrenceNumber().Split(',');

                    WalletRequest req = new WalletRequest()
                    {
                        auth = new Auth()
                        {
                            clientApiKeyField = "94DF6CECB284BEA9",
                            clientIdField = "structuredres",
                            mACField = "046825bf38249c3cb0b52e0209985b91ee57f2e69d6f4e3e348cf3028c8f9220"
                        },

                        requestId = refNum[0],
                        // sourcePhone = code.Content+phone.Text,
                        sourcePhone = "234" + phone.Text,
                        first_name = firstName.Text,
                        last_name = lastName.Text,
                        gender = sex,
                        dob = date
                    };

                    var jsonString = JsonConvert.SerializeObject(req);

                   // MessageBox.Show(jsonString);

                    client.BaseAddress = new Uri("https://structurewallet.fcmb.com:2217/");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var response = client.PostAsync("EnrolCustomer", new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                       // MessageBox.Show("successful");
                        var content = JsonConvert.DeserializeObject<WalletResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));

                        prog.IsActive = false;
                        cont.Content = content.ResponseMessage;

                        string txt = "Dear " + firstName.Text + " " + lastName.Text + " , your wallet has been created Successfully ";

                        alert un = new alert(txt);
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
                       // MessageBox.Show("successful Error");
                        unavailable un = new unavailable("Sorry, wallet creation fail.");
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
                else {

                    prog.IsActive = false;
                    cont.Content = "";
                    MessageBox.Show("value");
                    unavailable un = new unavailable("Value needs to be pass on all input field.");
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

        private void Marital_DropDownClosed(object sender, EventArgs e)
        {
           if (marital.Text != "")
            {
                marital.SetValue(Border.BorderBrushProperty, Brushes.Green);
                // gImg.Visibility = Visibility.Visible;
            }
        }

        private void Title_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void firstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void createAccount(object sender, RoutedEventArgs e)
        {
            try 
            {
                backborder.Visibility = Visibility.Visible;
              //  plainborder.Visibility = Visibility.Visible;
                contV.Content = "Creating Account ...";

             
                using (var client = new HttpClient())
                {

                    if (firstName.Text != "" && lastName.Text != "" && newdat.Text != "" && phone.Text != "" && gen.Text != "")
                    {
                        string sex = "";
                        string status = "";
                        string salute = "";


                        switch (title.Text)
                        {
                            case "Mr":
                                salute = "Mr";
                                break;
                            case "Mrs":
                                salute = "Mrs";
                                break;
                            case "Miss":
                                salute = "Miss";
                                break;

                        }
                        switch (gen.Text)
                        {
                            case "Male":
                                sex = "M";
                                break;
                            case "Female":
                                sex = "F";
                                break;

                        }
                        switch (marital.Text)
                        {
                            case "Single":
                                status = "SNG";
                                break;
                            case "Married":
                                status = "MAR";
                                break;
                            case "Divorce":
                                status = "DIV";
                                break;
                            case "Others":
                                status = "OTHR";
                                break;

                        }


                        string date = String.Format("{0:yyyy-MM-dd'T'HH:mm:ss}", Convert.ToDateTime(newdat.Text));
                        // string date = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(newdat.Text));
                        DateTime currentDateTime = DateTime.Now;
                        string formattedDateTime = currentDateTime.ToString("0,yyyy-MM-dd'T'HH:mm:ss");

                        string[] refNum = refrenceNumber().Split(',');


                        Root request = new Root()
                        {

                            firstName = firstName.Text,
                            middleName = middleName.Text,
                            lastName = lastName.Text,
                            motherMaidenName = "",
                            dob = date,
                            gender = sex,
                            bvnMobileNumber = phone.Text,
                            email = email.Text,
                            address = new Address()
                            {
                                addrLine1 = address.Text,
                                addrLine2 = "Nigeria",
                                city = "LAG",
                                country = "NG",
                                houseNum = "",
                                startDate = formattedDateTime,
                                state = "LG",
                                streetName = "",
                                streetNum = null,
                                postalCode = "234",

                            },
                            bvn = bvn.Text,
                            maritalStatus = status,
                            employmentStatus = "Other",
                            occupation = "",
                            salutation = salute,
                            requestId = refNum[0],
                            addImageFromBVN = true,
                            configCredentials = new ConfigCredentials()
                            {
                                clientId = "250",
                                productId = "14"
                            }
                        };


                        var jsonString = JsonConvert.SerializeObject(request);

                        client.BaseAddress = new Uri("https://devapi.fcmb.com/selfservicekiosk/api/Accounts/v1/");
                        client.DefaultRequestHeaders.Add("client_id", "250");
                        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "55d7f996f5994e0c846e203bec3880b1");

                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        var response = client.PostAsync("CreateRetailAccountMiniData", new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                        var content1 = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));


                        if (response.IsSuccessStatusCode)
                        {
                            var content = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));

                            backborder.Visibility = Visibility.Hidden;
                            //plainborder.Visibility = Visibility.Hidden;
                            contV.Content = "";

                            string txt = "Dear " + firstName.Text + " " + lastName.Text + " , your Account has been created Successfully " + "Your Account number is :" + content1.data.accountNumber;

                            alert un = new alert(txt);
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
                            backborder.Visibility = Visibility.Hidden;
                          //  plainborder.Visibility = Visibility.Hidden;
                            // MessageBox.Show("successful Error");
                            unavailable un = new unavailable("Sorry, Account creation fail as a result of : " + content1.description);
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
                                NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                            }
                        }

                    }
                    else
                    {

                        backborder.Visibility = Visibility.Hidden;
                        //plainborder.Visibility = Visibility.Hidden;
                        contV.Content = "";
                        unavailable un = new unavailable("Input needs to be pass on all input field.");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

           

        }



        private void create_Click(object sender, RoutedEventArgs e)
        {

            using (var client = new HttpClient())
            {

                

                if (firstName.Text != "" && lastName.Text != "" && newdat.Text != "" && phone.Text != "" && gen.Text != "")
                {
                    string sex = "";
                    string status = "";
                    string salute = "";


                    switch (title.Text)
                    {
                        case "Mr":
                            salute = "Mr";
                            break;
                        case "Mrs":
                            salute = "Mrs";
                            break;
                        case "Miss":
                            salute = "Miss";
                            break;

                    }
                    switch (gen.Text)
                    {
                        case "Male":
                            sex = "M";
                            break;
                        case "Female":
                            sex = "F";
                            break;

                    }
                    switch (marital.Text)
                    {
                        case "Single":
                            status = "SNG";
                            break;
                        case "Married":
                            status = "MAR";
                            break;
                        case "Divorce":
                            status = "DIV";
                            break;
                        case "Others":
                            status = "OTHR";
                            break;

                    }


                    string date = String.Format("{0:yyyy-MM-dd'T'HH:mm:ss}", Convert.ToDateTime(newdat.Text));
                    // string date = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(newdat.Text));
                    DateTime currentDateTime = DateTime.Now;
                    string formattedDateTime = currentDateTime.ToString("0,yyyy-MM-dd'T'HH:mm:ss");

                    string[] refNum = refrenceNumber().Split(',');

                    MessageBox.Show("test test");
                    cont.Content = "Creating Account ...";
                    prog.IsActive = true;

                    Root request = new Root()
                    {

                        firstName = firstName.Text,
                        middleName = middleName.Text,
                        lastName = lastName.Text,
                        motherMaidenName = "",
                        dob = date,
                        gender = sex,
                        bvnMobileNumber = phone.Text,
                        email = email.Text,
                        address = new Address()
                        {
                            addrLine1 = address.Text,
                            addrLine2 = "Nigeria",
                            city = "LAG",
                            country = "NG",
                            houseNum = "",
                            startDate = formattedDateTime,
                            state = "LG",
                            streetName = "",
                            streetNum = null,
                            postalCode = "234",

                        },
                        bvn = bvn.Text,
                        maritalStatus = status,
                        employmentStatus = "Other",
                        occupation = "",
                        salutation = salute,
                        requestId = refNum[0],
                        addImageFromBVN = true,
                        configCredentials = new ConfigCredentials()
                        {
                            clientId = "250",
                            productId = "14"
                        }
                    };


                    var jsonString = JsonConvert.SerializeObject(request);

                    client.BaseAddress = new Uri("https://devapi.fcmb.com/selfservicekiosk/api/Accounts/v1/");
                    client.DefaultRequestHeaders.Add("client_id", "250");
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "55d7f996f5994e0c846e203bec3880b1");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var response = client.PostAsync("CreateRetailAccountMiniData", new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                    var content1 = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));


                    if (response.IsSuccessStatusCode)
                    {
                        var content = JsonConvert.DeserializeObject<AccountResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));

                        cont.Content = "";
                        prog.IsActive = false;

                        string txt = "Dear " + firstName.Text + " " + lastName.Text + " , your Account has been created Successfully " + "Your Account number is :" + content1.data.accountNumber;

                        alert un = new alert(txt);
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
                       
                        unavailable un = new unavailable("Sorry, Account creation fail as a result of : " + content1.description);
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
                            NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                        }
                    }

                }
                else
                {

                    prog.IsActive = false;
                    cont.Content = "";
                    unavailable un = new unavailable("Input needs to be pass on all input field.");
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
    }
}
