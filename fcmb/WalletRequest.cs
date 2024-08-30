using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fcmb
{
    public class WalletRequest
    {
        public Auth auth { get; set; } //Required

        public string requestId { get; set; }//required
        public string sourcePhone { get; set; }//required
        public string first_name { get; set; }//required
        public string last_name { get; set; }//required
        public string gender { get; set; }//required
        public string dob { get; set; }//required
    }

    public class AccountRequest
    {
        public string accountNumber { get; set; }
        public string userId { get; set; }
        public string reference { get; set; }
    }


    public class Auth
    {
        public string clientApiKeyField { get; set; } //required
        public string clientIdField { get; set; } //required
        public string mACField { get; set; } //required
    }

    public class WalletResponse
    {
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
    }

    public class IssuanceRequest
    {
        
    public string accountNumber { get; set; }
    public string CardProfileID { get; set; }
     }

    public class DebitRequest { 
    public string RequestID { get; set; }
    }

    public class ChipDataRequest
    {
        public string OTP { get; set; }
    }


    public class AccountResponse
    {
        public DataResponse data { get; set; }
        public string description { get; set; }
        public string customerId { get; set; }
        public string code { get; set; }
        public object referralCode { get; set; }
    }

    public class DataResponse
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string phoneNumber { get; set; }
        public object email { get; set; }
        public string cifId { get; set; }
        public bool pnd { get; set; }
        public bool isMandateImageAdded { get; set; }
        public bool isBVNLinked { get; set; }
    }

}
