using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
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
    /// Interaction logic for withoutBVN.xaml
    /// </summary>
    public partial class withoutBVN : Page
    {
        //inside the class definition
        private Process _touchKeyboardProcess = null;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        bool b = false; CancellationToken token; CancellationTokenSource source; Window darkwindow;

        public withoutBVN()
        {
            InitializeComponent();
        }

        public withoutBVN(string opt)
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
            ctryRes.Items.Clear();
            foreach (var item in ct.count)
            {
                ctryRes.Items.Add(item);
            }
        }

        private void em_LostFocus(object sender, RoutedEventArgs e)
        {
            if (em.Text != "")
            {
                Regex rg = new Regex("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+[a-zA-Z]$");

                b = rg.IsMatch(em.Text);
                if (!b)
                {
                    em.Text = "";
                    Keyboard.ClearFocus();
                    unavailable un = new unavailable("Invalid Email");
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
                    dobImg.IsEnabled = false;
                }
                else
                {
                    Keyboard.ClearFocus();
                    em.SetValue(Border.BorderBrushProperty, Brushes.Green);
                    emImg.Visibility = Visibility.Visible;
                }
            }
            else
            {
                em.SetValue(Border.BorderBrushProperty, Brushes.Black);
                newdat.IsEnabled = false;
            }
            try
            {
                Keyboard.ClearFocus();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {

            }
        }

        private void cam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                passport pi = new passport();
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
                if (val.HasValue && val.Value)
                {
                    darkwindow.Close();
                    signature.IsEnabled = true;
                }
                else
                {
                    darkwindow.Close();
                    signature.IsEnabled = false;
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
                if (val.HasValue && val.Value)
                {
                    darkwindow.Close();
                    continueCreate.IsEnabled = true;
                }
                else
                {
                    darkwindow.Close();
                    continueCreate.IsEnabled = false;
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                source.Cancel();
                if (token.IsCancellationRequested)
                {
                    prog.IsActive = false;
                    cont.Content = "";
                    NavigationService.Navigate(new Uri("accountOptions.xaml", UriKind.Relative));
                }
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
                dynamic content = null; prog.IsActive = true; cont.Content = "Creating Account..."; int refe = 0;

                BitmapImage img = (BitmapImage)photo.Source; BitmapImage sig = (BitmapImage)sign.Source;
                string base64Passport = "", base64Sign = "", marit = "";
                try
                {
                    base64Passport = BitmapToString(img);
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
                    base64Sign = BitmapToString(sig);
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

                if (fn.Text != "" && ln.Text != "" && newdat.Text != "" && em.Text != "" && ctryRes.Text != "" && ph.Text != "" && gen.Text != "" && marital.Text != "" && title.Text != "" && ra.Text != "" && base64Passport != "" && base64Sign != "")
                {
                    switch (marital.Text)
                    {
                        case "Single":
                            marit = "SNG";
                            break;
                        case "Married":
                            marit = "MAR";
                            break;
                        case "Divorced":
                            marit = "DIV";
                            break;
                    }
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://uat.firstcitygrouponline.com/onlineaccountopeningservice/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Add("AppId", "12345");
                        client.DefaultRequestHeaders.Add("AppKey", "123456");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        try
                        {
                            refe = loadRefNum();
                            refe = refe + 1;
                        }
                        catch (Exception)
                        {
                            refe = 1;
                        }
                        saveRefNum(refe);

                        string date = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(newdat.Text));//check this format
                        string[] refNum = refrenceNumber().Split(',');

                        AccountOpeningRequest req = new AccountOpeningRequest
                        {
                            Title = title.Text,
                            Complete = "Yes",
                            MotherMaidenName = "NA",
                            PreferredBranch = "001",
                            ReferenceNo = refNum[0],
                            Resident = "Yes",
                            BVNNumber = "",
                            FirstName = fn.Text,
                            MiddleName = mn.Text,
                            LastName = ln.Text,
                            Gender = gen.Text,
                            MaritalStatus = marit,
                            Nationality = ctryRes.Text,
                            DateOfBirth = date,
                            Email = em.Text,
                            PhoneNumber = ph.Text,
                            ResidentialAddress = ra.Text,
                            Photo = base64Passport,
                            Signature = base64Sign
                        };

                        var jsonString = JsonConvert.SerializeObject(req);
                        var resp = await client.PostAsync("api/accountopening/createaccount", new StringContent(jsonString, Encoding.UTF8, "application/json"), token);

                        if (resp.IsSuccessStatusCode)
                        {
                            // use this if you want object type returned
                            content = JsonConvert.DeserializeObject<SendAccountCreationDetResponse>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                            prog.IsActive = false;
                            cont.Content = content.responseMessageField;

                            string txt = "Dear " + fn.Text + " " + ln.Text + " , your account has been created.Your account number is " + content.accountNumberField + ".";
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
                            bool? val = un.ShowDialog();
                            if (!val.Value)
                            {
                                darkwindow.Close();
                            }
                        }
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

        public string BitmapToString(BitmapImage bitmapImage)
        {
            byte[] image = ConvertToBytes(bitmapImage);
            return Convert.ToBase64String(image);
        }

        public byte[] ConvertToBytes(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private void newdat_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (b)
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
                }
                else
                {
                    darkwindow.Close();
                    newdat.Text = "";
                }
            }
            else
            {
                dobImg.IsEnabled = false;
            }
        }

        private void ph_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void fn_GotFocus(object sender, RoutedEventArgs e)
        {

            /**string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

            //replace Process.Start line from the previous listing with
            _touchKeyboardProcess = Process.Start(touchKeyboardPath);
            */
            if (!fn.IsKeyboardFocused)
            {
                Keyboard.Focus(fn);
            }
            mn.IsEnabled = true;

        }

        private void fn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fn.Text != "")
            {
                fn.SetValue(Border.BorderBrushProperty, Brushes.Green);
                fnImg.Visibility = Visibility.Visible;
            }
            else
            {
                fn.SetValue(Border.BorderBrushProperty, Brushes.Black);
                mn.IsEnabled = false;
            }
            try
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
                _touchKeyboardProcess.CloseMainWindow();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
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
                    single += rnd.Next(0, 9).ToString();
                }
                num += single + ",";
                single = string.Empty;
            }
            return num;
        }

        private void mn_GotFocus(object sender, RoutedEventArgs e)
        {
            /* string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

             //replace Process.Start line from the previous listing with
             _touchKeyboardProcess = Process.Start(touchKeyboardPath);
             */
            if (!mn.IsKeyboardFocused)
            {
                Keyboard.Focus(mn);
            }
            ln.IsEnabled = true;
        }

        private void mn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (mn.Text != "")
            {
                mn.SetValue(Border.BorderBrushProperty, Brushes.Green);
                mnImg.Visibility = Visibility.Visible;
            }
            else
            {
                mn.SetValue(Border.BorderBrushProperty, Brushes.Black);
                ln.IsEnabled = false;
            }
            try
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
            }
        }

        private void rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Keyboard.ClearFocus();
                rect.Focus();
                closeOnscreenKeyboard();
                _touchKeyboardProcess.CloseMainWindow();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;

            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                rect.Focus();
            }
        }

        private void ln_GotFocus(object sender, RoutedEventArgs e)
        {
            /* string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

             //replace Process.Start line from the previous listing with
             _touchKeyboardProcess = Process.Start(touchKeyboardPath);
             */
            if (!ln.IsKeyboardFocused)
            {
                Keyboard.Focus(ln);
            }

            ph.IsEnabled = true;
        }

        private void ph_GotFocus(object sender, RoutedEventArgs e)
        {
            /** NumKeypad nm = new NumKeypad(this);
             bool? val = nm.ShowDialog();
             if (val.HasValue && val.Value)
             {
                 //ph.Text = Application.Current.FindResource("num").ToString();
             }
             else
             {
                 ph.Text = "";
             } */
            if (!ph.IsKeyboardFocused)
            {
                Keyboard.Focus(ph);
            }
            em.IsEnabled = true;
        }

        private void em_GotFocus(object sender, RoutedEventArgs e)
        {
            /** string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

             //replace Process.Start line from the previous listing with
             _touchKeyboardProcess = Process.Start(touchKeyboardPath);
             */
            if (!em.IsKeyboardFocused)
            {
                Keyboard.Focus(em);
            }
            newdat.IsEnabled = true;
        }

        private void ra_GotFocus(object sender, RoutedEventArgs e)
        {
            /**string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

            //replace Process.Start line from the previous listing with
            _touchKeyboardProcess = Process.Start(touchKeyboardPath);
            cam.IsEnabled = true;*/

            if (!ra.IsKeyboardFocused)
            {
                Keyboard.Focus(ra);
            }
            cam.IsEnabled = true;
        }

        private void ln_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ln.Text != "")
            {
                ln.SetValue(Border.BorderBrushProperty, Brushes.Green);
                lnImg.Visibility = Visibility.Visible;
            }
            else
            {
                ln.SetValue(Border.BorderBrushProperty, Brushes.Black);
                ph.IsEnabled = false;
            }
            try
            {
                closeOnscreenKeyboard();
                Keyboard.ClearFocus();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
            }
        }

        private void ph_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ph.Text != "")
            {
                Regex rg = new Regex("^0[789][01]\\d{8}$");
                Regex rr = new Regex("^[0345678][0123456789]\\d{7}$");

                var b = rg.IsMatch(ph.Text);
                var c = rr.IsMatch(ph.Text);
                if (b || c)
                {
                    Keyboard.ClearFocus();
                    ph.SetValue(Border.BorderBrushProperty, Brushes.Green);
                    phImg.Visibility = Visibility.Visible;
                }
                else
                {
                    ph.Text = "";
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
                    em.IsEnabled = false;
                }
            }
            else
            {
                ph.SetValue(Border.BorderBrushProperty, Brushes.Black);
                em.IsEnabled = false;
            }
            try
            {
                closeOnscreenKeyboard();
                Keyboard.ClearFocus();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                closeOnscreenKeyboard();
            }
        }

        private void ra_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ra.Text != "")
            {
                ra.SetValue(Border.BorderBrushProperty, Brushes.Green);
                cam.IsEnabled = true;
            }
            else
            {
                ra.SetValue(Border.BorderBrushProperty, Brushes.Black);
                cam.IsEnabled = false;
            }
            try
            {
                closeOnscreenKeyboard();
                Keyboard.ClearFocus();
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess.Close();
                _touchKeyboardProcess.Dispose();
                _touchKeyboardProcess = null;
            }
            catch (Exception)
            {
                Keyboard.ClearFocus();
                closeOnscreenKeyboard();
            }
        }

        public void closeOnscreenKeyboard()
        {
            // retrieve the handler of the window  
            int iHandle = FindWindow("IPTIP_Main_Window", "");
            if (iHandle > 0)
            {
                // close the window using API        
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }
        }

        private void title_DropDownClosed(object sender, EventArgs e)
        {
            if (title.Text != "")
            {
                title.SetValue(Border.BorderBrushProperty, Brushes.Green);
                fn.IsEnabled = true;
                titImg.Visibility = Visibility.Visible;
            }
        }

        private void gen_DropDownClosed(object sender, EventArgs e)
        {
            if (gen.Text != "")
            {
                gen.SetValue(Border.BorderBrushProperty, Brushes.Green);
                marital.IsEnabled = true;
                gImg.Visibility = Visibility.Visible;
            }
        }

        private void marital_DropDownClosed(object sender, EventArgs e)
        {
            if (marital.Text != "")
            {
                marital.SetValue(Border.BorderBrushProperty, Brushes.Green);
                ctryRes.IsEnabled = true;
                mImg.Visibility = Visibility.Visible;
            }
        }

        private void ctryRes_DropDownClosed(object sender, EventArgs e)
        {
            if (ctryRes.Text != "")
            {
                ctryRes.SetValue(Border.BorderBrushProperty, Brushes.Green);
                ra.IsEnabled = true;
                natImg.Visibility = Visibility.Visible;
            }
        }

        private void newdat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (newdat.Text != "")
            {
                newdat.SetValue(Border.BorderBrushProperty, Brushes.Green);
                dobImg.Visibility = Visibility.Visible;
            }
            else
            {
                newdat.SetValue(Border.BorderBrushProperty, Brushes.Black);
                gen.IsEnabled = false;
            }
            closeOnscreenKeyboard();
        }

        private void camIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                passport pi = new passport();
                bool? val = pi.ShowDialog();
                if (val.HasValue && val.Value)
                {
                    signature.IsEnabled = true;
                }
                else
                {
                    signature.IsEnabled = false;
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

        private void signIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                signature pi = new signature();
                bool? val = pi.ShowDialog();
                if (val.HasValue && val.Value)
                {
                    continueCreate.IsEnabled = true;
                }
                else
                {
                    continueCreate.IsEnabled = false;
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

        private void Fn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBox textbox = sender as TextBox;
            key keyboardWindow = new key(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }

        private void Fn_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!fn.IsKeyboardFocused)
            {
                Keyboard.Focus(fn);
            }
        }

        private void Mn_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!mn.IsKeyboardFocused)
            {
                Keyboard.Focus(mn);
            }
        }

        private void Mn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            key keyboardWindow = new key(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }

        private void Ln_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!mn.IsKeyboardFocused)
            {
                Keyboard.Focus(mn);
            }
        }

        private void Ph_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!ph.IsKeyboardFocused)
            {
                Keyboard.Focus(ph);
            }
        }

        private void Ph_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            Keypad keyboardWindow = new Keypad(textbox, this);
            if (keyboardWindow.ShowDialog() == true)
                textbox.Text = keyboardWindow.Result;
        }

        private void Em_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!em.IsKeyboardFocused)
            {
                Keyboard.Focus(em);
            }
        }

        private void Ra_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!ra.IsKeyboardFocused)
            {
                Keyboard.Focus(ra);
            }
        }
    }
}
