using System;      
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
using System.Xml;
using Newtonsoft.Json;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Page
    {
        private string BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
        public start()
        {
            InitializeComponent();
        }        
        
        private void openAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AccountTypes.xaml", UriKind.Relative));
        }

        private void instantCard_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                plainborder.Visibility = Visibility.Visible;

                account acn = new account();
                bool? result = acn.ShowDialog();

                if (result.Value)
                {

                    plainborder.Visibility = Visibility.Visible;

                    card accVal = new card();

                    bool? accountValidate = accVal.ShowDialog();

                    if (accountValidate.Value)
                    {
                        string acc = acn.accountNumber.Text;
                      //  GenerateAccountDetail(acc);


                        data da = new data();
                        da.AccountNumber = acc;

                       /** string accountNo = acn.accountNumber.Text;
                        string fingerprint = accVal.finger;
                        string fingerType = accVal.fingerType;*/

                        plainborder.Visibility = Visibility.Visible;
                        // backborder.Visibility = Visibility.Visible;



                      /*  data da = new data();
                        da.AccountNumber = accountNo;*/

                      //  contV.Content = "Printing Card...";

                        cardPrint cp = new cardPrint(da);
                        bool? cpRes = cp.ShowDialog();

                        if (cpRes.Value)
                        {
                            plainborder.Visibility = Visibility.Hidden;
                            backborder.Visibility = Visibility.Hidden;

                        }
                        else
                        {
                            plainborder.Visibility = Visibility.Hidden;
                            backborder.Visibility = Visibility.Hidden;
                            NavigationService.Navigate(new Uri("start.xaml", UriKind.Relative));

                        }
                        // work on this session 

                        // GenerateAccountDetail(accountNo);

                        // GenerateAccountDetail("0012225018");

                        //    validate(fingerprint, fingerType, accountNo);
                    }
                    else
                    {
                        plainborder.Visibility = Visibility.Hidden;
                        backborder.Visibility = Visibility.Hidden;
                    }
                }
                else
                {

                    plainborder.Visibility = Visibility.Hidden;
                }
            }

            /**
            //ask user if he wants a new card or replace existing
            reprint pi = new reprint();

            bool? val = pi.ShowDialog();

            if (!val.Value) {

                // card acn = new card();

                account acn = new account();
                bool? result = acn.ShowDialog();

                if (result.Value) {

                 

                    plainborder.Visibility = Visibility.Visible;
                    //backborder.Visibility = Visibility.Visible;

                    card accVal = new card();

                    bool? accountValidate = accVal.ShowDialog();

                    if (accountValidate.Value) {

                        string accountNo = acn.accountNumber.Text;
                        string fingerprint = accVal.finger;
                        string fingerType = accVal.fingerType;

                        plainborder.Visibility = Visibility.Visible;
                       // backborder.Visibility = Visibility.Visible;



                        data da = new data();
                        da.AccountNumber = accountNo;

                        contV.Content = "Printing Card...";

                        AccountPrint cp = new AccountPrint(da);
                        bool? cpRes = cp.ShowDialog();

                        if (cpRes.Value)
                        {

                            contV.Content = "";
                            plainborder.Visibility = Visibility.Hidden;
                            backborder.Visibility = Visibility.Hidden;
                             
                           // contV.Content = "Processing Printing";
                            
                        }
                        else
                        {
                            plainborder.Visibility = Visibility.Hidden;
                            backborder.Visibility = Visibility.Hidden;
                            NavigationService.Navigate(new Uri("start.xaml", UriKind.Relative));

                        }
                        // work on this session 

                        // GenerateAccountDetail(accountNo);

                        // GenerateAccountDetail("0012225018");

                      //    validate(fingerprint, fingerType, accountNo);
                    }
                    else
                    {
                        plainborder.Visibility = Visibility.Hidden;
                        backborder.Visibility = Visibility.Hidden;
                    }
                }
                else
                {

                    plainborder.Visibility = Visibility.Hidden;
                }
            }
            else
            {

                account acn = new account();
                bool? result = acn.ShowDialog();

                if (result.Value)
                {
                    plainborder.Visibility = Visibility.Hidden;
                    backborder.Visibility = Visibility.Visible;

                    /** string accountNo = acn.acc;



                     plainborder.Visibility = Visibility.Hidden;
                     backborder.Visibility = Visibility.Visible;

                      //GenerateAccountDetail(accountNo);

                      GenerateAccountDetail("0012225018");
                      //GetAccountDetail("0012225018");*/

            /** card accVal = new card();

                     bool? accountValidate = accVal.ShowDialog();

                     if (accountValidate.Value)
                     {

                         string accountNo = acn.accountNumber.Text;
                         string fingerprint = accVal.finger;
                         string fingerType = accVal.fingerType;

                         plainborder.Visibility = Visibility.Hidden;
                         backborder.Visibility = Visibility.Visible;


                         // GenerateAccountDetail(accountNo);

                         // GenerateAccountDetail("0012225018");

                         validate(fingerprint, fingerType, accountNo);
                     }
                     else
                     {
                         plainborder.Visibility = Visibility.Hidden;
                         backborder.Visibility = Visibility.Hidden;
                     }
                 }
                 else
                 {

                     plainborder.Visibility = Visibility.Hidden;
                 }

                 /**
                 unavailable un = new unavailable("Sorry, this functionality is not yet available on the kiosk");
                 var vall = un.ShowDialog();
                 if (!vall.Value)
                 {
                     plainborder.Visibility = Visibility.Hidden;
                 }
             }   
         }*/
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
           
        }

        private void depositCheque_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            plainborder.Visibility = Visibility.Visible;

            unavailable pi = new unavailable();

            bool? val = pi.ShowDialog();
            if (val.HasValue && !val.Value)
            {
                plainborder.Visibility = Visibility.Hidden;
            }
        }

        /**

        // new process flow for card  process
        private async void GetAccountDetail1(string acc)
        {
            MainWindow mn = new MainWindow();
            data obj2 = new data();
            backborder.Visibility = Visibility.Visible;
            try
            {
                using (var client = new HttpClient())
                {
                    string username = "testkiosk";
                    string password = "fnFe4BmvgVQWDn3U";

                    client.BaseAddress = new Uri("https://fcmbtest.primecms.cloud/FCMBPrimeKioskIntegrator/api/kiosk/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));


                    Dictionary<string, object> para = new Dictionary<string, object>();
                    para.Add("accountNumber", acc);
                    para.Add("userId", "test");
                    para.Add("reference", "1234423423432");


                    var jsonString = JsonConvert.SerializeObject(para);

                    HttpResponseMessage resp = await client.PostAsync("retrieveaccountdetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                    
                   // obj2.CardProfiles = te.CardProfiles;

                    try
                    {
                        if (obj2.ResponseCode.Equals("00"))
                        {
                            backborder.Visibility = Visibility.Hidden;
                            ContinueProcess(obj2);
                        }
                        else
                        {
                            ShowError(obj2.ResponseDesc, mn);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("An error occurred - " + ex.Message, mn);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Incorrect Details", mn);
            }
        }

        private async void GetAccountDetail(string acc)
        {
            MainWindow mn = new MainWindow();
            data obj2 = new data();
            backborder.Visibility = Visibility.Visible;

            try
            {
                using (var client = new HttpClient())
                {
                    string username = "testkiosk";
                    string password = "fnFe4BmvgVQWDn3U";


                    client.BaseAddress = new Uri("https://fcmbtest.primecms.cloud/FCMBPrimeKioskIntegrator/api/kiosk/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

                     Dictionary<string, object> para = new Dictionary<string, object>();
                     para.Add("accountNumber", acc);
                     para.Add("userId", "test");
                     para.Add("reference", "1234423423432");


                     var jsonString = JsonConvert.SerializeObject(para);

                     try {

                        // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                        // HttpResponseMessage resp = await client.PostAsync("retrieveaccountdetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                         var resp = await client.PostAsync("retrieveaccountdetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                         obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                         //get card profiles
                         HttpResponseMessage resp1 = await client.GetAsync("GetCardProfiles");
                         data te = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp1.Content.ReadAsByteArrayAsync().Result));

                         obj2.CardProfiles = te.CardProfiles;


                         if (obj2.ResponseCode.Equals("00"))
                         {
                             backborder.Visibility = Visibility.Hidden;
                             ContinueProcess(obj2);
                         }
                         else
                         {
                             ShowError(obj2.ResponseDesc, mn);
                         }
                     }
                     catch (Exception ex)
                     {
                         ShowError("Incorrect Account Details Information", mn);
                     }
                    
                    
                 }
             }
             catch (Exception ex)
             {
                 ShowError("Incorrect Details", mn);
             }
             
             /**try
             {
                 using (var client = new HttpClient())
                 {
                     string username = "testkiosk";
                     string password = "fnFe4BmvgVQWDn3U";

                   
                     client.BaseAddress = new Uri("https://fcmbtest.primecms.cloud/FCMBPrimeKioskIntegrator/api/kiosk/");
                     //client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

                    /** AccountRequest req = new AccountRequest
                     {
                         accountNumber = acc,
                         userId = "test",
                         reference = "1234423423432"
                     };

                     Dictionary<string, object> para = new Dictionary<string, object>();
                     para.Add("accountNumber", acc);
                     para.Add("userId", "test");
                     para.Add("reference", "1234423423432");


                     var jsonString = JsonConvert.SerializeObject(para);

                     try {

                        // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                        
                        // HttpResponseMessage resp = await client.PostAsync("retrieveaccountdetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                         var resp = await client.PostAsync("retrieveaccountdetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                         obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                         //get card profiles
                         HttpResponseMessage resp1 = await client.GetAsync("GetCardProfiles");
                         data te = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp1.Content.ReadAsByteArrayAsync().Result));

                         obj2.CardProfiles = te.CardProfiles;


                         if (obj2.ResponseCode.Equals("00"))
                         {
                             backborder.Visibility = Visibility.Hidden;
                             ContinueProcess(obj2);
                         }
                         else
                         {
                             ShowError(obj2.ResponseDesc, mn);
                         }
                     }
                     catch (Exception ex)
                     {
                         ShowError("Incorrect Account Details Information", mn);
                     }
                    
                    
                 }
             }
             catch (Exception ex)
             {
                 ShowError("Incorrect Details", mn);
             } 
                }*/

/**
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

        private void ContinueProcess(data res)
        {
            MainWindow mn = new MainWindow();
            plainborder.Visibility = Visibility.Visible;

            //initiate card printing
            AccountPrint cp = new AccountPrint(res);
            bool? cpRes = cp.ShowDialog();

            if (cpRes.Value)
            {
                data value = cp.res;
                plainborder.Visibility = Visibility.Hidden;
                backborder.Visibility = Visibility.Visible;

                //initiate Fetch Card Profile

                MessageBox.Show(value.AccountNo);

                DebitUserAccount(value.AccountNo,"24", value.pin);
            }
            else
            {
                plainborder.Visibility = Visibility.Hidden;
                return;
            }
        }

        private async void DebitUserAccount(string accNum, string cardProfileId, string pin)
        {
            data obj = new data();
            MainWindow mn = new MainWindow();
            try
            {
                using (var client = new HttpClient())
                {
                    string username = "testkiosk";
                    string password = "fnFe4BmvgVQWDn3U";

                    client.BaseAddress = new Uri("https://fcmbtest.primecms.cloud/FCMBPrimeKioskIntegrator/api/kiosk/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

                   
                    IssuanceRequest req = new IssuanceRequest
                    {
                        accountNumber = accNum,
                        CardProfileID = cardProfileId
                    };

                    var jsonString = JsonConvert.SerializeObject(req);

                    var resp = await client.PostAsync("GetIssuanceAccountDetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                    obj = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));


                    // HttpResponseMessage resp = await client.PostAsync("GetIssuanceAccountDetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                   /// obj = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));
                   
                    try
                    {
                        if (obj.ResponseCode =="00")
                        {
                            DebitRequest request = new DebitRequest
                            {

                                RequestID = obj.RequestID
                            };

                            var jsonString1 = JsonConvert.SerializeObject(request);

                            var resp1 = await client.PostAsync("DebitCustomerAndGenerateChipData", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                            data obj1 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp1.Content.ReadAsByteArrayAsync().Result));

                           // HttpResponseMessage resp1 = await client.PostAsync("kiosk/DebitCustomerAndGenerateChipData", new StringContent(jsonString1, Encoding.UTF8, "application/json"));

                           // data obj1 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp1.Content.ReadAsByteArrayAsync().Result));

                            try
                            {
                                if (obj1.ResponseCode == "00")
                                {
                                    ChipDataRequest req1 = new ChipDataRequest
                                    {
                                        OTP = obj1.OTP
                                    };
                                   

                                    var jsonString2 = JsonConvert.SerializeObject(req1);

                                    var resp2 = await client.PostAsync("DebitCustomerAndGenerateChipData", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                                    data obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp2.Content.ReadAsByteArrayAsync().Result));


                                  //  HttpResponseMessage resp2 = await client.PostAsync("kiosk/RetrieveChipData", new StringContent(jsonString2, Encoding.UTF8, "application/json"));

                                  //  data obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp2.Content.ReadAsByteArrayAsync().Result));
      
                                            if (obj2.ChipData != null)
                                            {
                                                string chipData = obj2.ChipData + "|||||" + pin;

                                                printingCard(obj1.CardData, chipData, "mastercard", obj.requestID);
                                            }
                                            else
                                            {
                                            ShowError("Error Code - " + "05| an error occured while Verifying the OTP.", mn);
                                            }    
                                    
                                }

                            }
                            catch (Exception ex)
                            {

                                ShowError(ex.Message, mn);
                            }
                            
                        }
                        else {
                            ShowError("Error Code - " + "05| an error occured while Verifying the card.", mn);
                        }
                       
                       
                    }
                    catch (Exception ex)
                    {
                        //obj2.error = ex.Message;
                        ShowError(ex.Message, mn);
                        //return obj2;
                    }
                }
            }
            catch (Exception ex)
            {
                //obj2.error = ex.Message;
                ShowError(ex.Message, mn);
                //return obj2;
            }
        }  */ 

        // main method for usage

        private async void GenerateAccountDetail(string acc)
        {
            MainWindow mn = new MainWindow();
            data obj2 = new data();
            backborder.Visibility = Visibility.Visible;
            contV.Content = "Generating Account Info...";

            try
            {
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Dictionary<string, object> para = new Dictionary<string, object>();
                    para.Add("accountNumber", acc);

                    var jsonString = JsonConvert.SerializeObject(para);

                    HttpResponseMessage resp = await client.PostAsync("srbl_api/api/fcmb/accountDetails", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                    //get card profiles
                    HttpResponseMessage resp1 = await client.GetAsync("srbl_api/api/fcmb/getCardProfile");
                    data te = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp1.Content.ReadAsByteArrayAsync().Result));

                    obj2.CardProfiles = te.CardProfiles;

                    try
                    {
                        if (obj2.ResponseCode.Equals("00"))
                        {
                            backborder.Visibility = Visibility.Hidden;
                            Continue(obj2);
                        }
                        else
                        {
                            contV.Content = "";
                            ShowError(obj2.ResponseDesc, mn);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("An error occurred - " + ex.Message, mn);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Incorrect Details", mn);
            }
        }
        private void Continue(data res)
        {
            MainWindow mn = new MainWindow();
            plainborder.Visibility = Visibility.Visible;
            contV.Content = "";


            //initiate card printing
            AccountPrint cp = new AccountPrint(res);
            bool? cpRes = cp.ShowDialog();

            if (cpRes.Value)
            {
                data value = cp.res;
                plainborder.Visibility = Visibility.Hidden;
                backborder.Visibility = Visibility.Visible;
                //initiate Fetch Card Profile contactless
                DebitUser(value.AccountNo, "24", value.pin);

                //initiate Fetch Card Profile contactless
                // DebitUser(value.AccountNo, "13", value.pin);

            }
            else
            {
                contV.Content = " ";
                plainborder.Visibility = Visibility.Hidden;
                return;
            }
        }

        private async void DebitUser(string accNum, string cardProfileId, string pin)
        {
            data obj2 = new data();
            MainWindow mn = new MainWindow();
            try
            {

                contV.Content = "Validating card Information... ";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Dictionary<string, object> para = new Dictionary<string, object>();
                    para.Add("accountNumber", accNum);
                    para.Add("cardProfileID", cardProfileId);
                    para.Add("pin", pin);

                    var jsonString = JsonConvert.SerializeObject(para);
                    HttpResponseMessage resp = await client.PostAsync("srbl_api/api/fcmb/debitAccount", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                    obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));
                    try
                    {
                        if (obj2.error == null)
                        {
                            if (obj2.cardData != null)
                            {
                                printingCard(obj2.cardData, obj2.chipData, "mastercard", obj2.RequestID);
                            }
                            else
                            {
                                contV.Content = " ";
                                ShowError(obj2.responseDesc, mn);
                            }
                            //return obj2;
                        }
                        else
                        {
                            //obj2.error = "Error Code - " + obj2.error;
                            contV.Content = " ";
                            ShowError("Error Code - " + obj2.responseDesc, mn);
                            //return obj2;
                        }
                    }
                    catch (Exception ex)
                    {
                        //obj2.error = ex.Message;
                        contV.Content = " ";
                        ShowError(ex.Message, mn);
                        //return obj2;
                    }
                }
            }
            catch (Exception ex)
            {
                //obj2.error = ex.Message;
                contV.Content = " ";
                ShowError(ex.Message, mn);
                //return obj2;
            }
        }

        private string printerName()
        {
            string result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:3000/api/printer/get");
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
                //cont.Content = "";
                unavailable un = new unavailable(ex.Message);
                un.ShowDialog();
            }
            return result;
        }

        private async void printingCard(string cardData, string chipData, string cardscheme, string requestID)
        {
            MainWindow mn = new MainWindow();
            try
            {
                contV.Content = "Printing Card...";
                string nm = printerName();
                if (nm != "")
                {
                    var values = new Dictionary<string, string>
                    {
                       { "cardData", cardData },
                       { "chipData", chipData },
                       { "dcardScheme", cardscheme}
                    };

                    HttpClient cli = new HttpClient();
                    var content = new FormUrlEncodedContent(values);
                    var response = await cli.PostAsync("http://localhost:3000/api/printer/FullPersoCard", content);

                   
                    string responseString = await response.Content.ReadAsStringAsync();

                    //MessageBox.Show(responseString.Split('|')[1].Trim('"'));

                    if (responseString.ToLower().Contains("printing completed"))
                    {
                        contV.Content = "";

                        string enc = responseString.Split('|')[1].Trim('"');

                        ShowError("Dear Customer card printing successful", mn);

                       // linkCard(requestID, enc);
                    }
                    else if (responseString.Contains("previously personalized"))
                    {
                        //prog.IsActive = false;
                        contV.Content = "";
                        ShowError("This Card has already been previously personalized", mn);
                    }
                    else
                    {
                        //prog.IsActive = false;
                        //cont.Content = "";
                        contV.Content = "";
                        ShowError("This Card has already been previously personalized", mn);
                    }
                }

                else
                {
                    contV.Content = "";
                    backborder.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                contV.Content = "";
                ShowError(ex.Message, mn);
            }
        }

        private async void linkCard(string requestId, string enc)
        {

          //  MessageBox.Show(enc);
            data obj2 = new data();
            MainWindow mn = new MainWindow();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Dictionary<string, object> para = new Dictionary<string, object>();
                    para.Add("requestID", requestId);
                    para.Add("encryptedBlock", enc);

                    var jsonString = JsonConvert.SerializeObject(para);
                    HttpResponseMessage resp = await client.PostAsync("srbl_api/api/fcmb/linkAccountToCard", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                    obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                   
                        if (obj2.ResponseCode.Equals("00"))
                        {
                            ShowError("Your Card has been personalized and linked. Thank you for banking with us ", mn);
                            //ShowError(obj2.ResponseDesc.Replace("\\", ""), mn);
                        }
                        else
                        {
                           // ShowError("Your Card has been personalized and linked Thank you for banking with us ", mn);
                            ShowError("Error Code - "  + obj2.ResponseDesc, mn);
                            //return obj2;
                        }
                   
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, mn);
            }
        }

        private void ShowError(string msg, MainWindow mn)
        {
            unavailable un = new unavailable(msg);
            var vall = un.ShowDialog();
            if (!vall.Value)
                backborder.Visibility = Visibility.Hidden;
        }

        private async void validate(string finger, string fingerType,string account) {

            data obj2 = new data();
            MainWindow mw = new MainWindow();

            try
            {
                backborder.Visibility = Visibility.Visible;
                contV.Content = "Verifying Fingerprint... ";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://firstcitygrouponline.com/FingerPrintBvnValidation/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    

                    BiometricRequest req = new BiometricRequest
                    {

                        AccountNunmber = account,
                        DeviceId = "Z002142F100",
                        FingerImage = new FingerImage
                        {
                            nist_impression_type = "0",
                            position = fingerType,
                            value = finger,
                            type = "ISO_2005"
                        },
                        AppId = "SSKIOSK",
                        AppKey = "E655865E1D4F4D84857D1609D10EA016"
                    };

                    var jsonString = JsonConvert.SerializeObject(req);
                    var resp = await client.PostAsync("BVN/FP_Validation_With_AcctNos", new StringContent(jsonString, Encoding.UTF8, "application/json"));

                    obj2 = JsonConvert.DeserializeObject<data>(Encoding.UTF8.GetString(resp.Content.ReadAsByteArrayAsync().Result));

                    // reverse it once it start working 

                    if (obj2.Message.Equals("Successfully verified "))
                    {

                        GenerateAccountDetail("0012225018");
                    }
                    else
                    {
                        backborder.Visibility = Visibility.Hidden;
                        contV.Content = " ";
                        ShowError("Fingerprint not verified kindly select the Appropriate Finger type and confirm Account Number ", mw);

                        return;
                    }


                }
            }
            catch (Exception ex)
            {
                contV.Content = " ";
                ShowError(ex.Message, mw);
            }
           

        }
    }

 }

