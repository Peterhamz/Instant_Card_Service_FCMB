using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fcmb
{
    public class data
    {
        public List<CardProfiles> CardProfiles = new List<CardProfiles>();
        public List<data> Mandate = new List<data>();
        public List<data> Accounts = new List<data>();
        public List<ExistingCards> ExistingCards = new List<ExistingCards>();


        public string id { get; set; }

        public string name { get; set; }
        public string pin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string accesscode { get; set; }
        public string contact { get; set; }
        public string success { get; set; }
        public string error { get; set; }

        public string finger { get; set; }
        public string fingerType { get; set; }
        public string fingerAcc { get; set; }


        public string responseCode { get; set; }

        public string responseDescription { get; set; }

        public string ResponseDescription { get; set; }

        public string ResponseCode { get; set; }
        public string ResponseDesc { get; set; }
        public string responseDesc { get; set; }
        public string Bra_code { get; set; }
        public string Cusnum { get; set; }
        public string Cardholdername { get; set; }
        public string AccountName { get; set; }
        public string Cardtype { get; set; }
        public string CardProfileId { get; set; }
        public string Count { get; set; }
        public string CardStatus { get; set; }
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public string Nuban { get; set; }
        public string hash { get; set; }
        public string Balance { get; set; }
        public string cardData { get; set; }
        public string requestID { get; set; }
        public string chipData { get; set; }

        public string RequestID { get; set; }

        public string OTP { get; set; }

        public string AccountNumber { get; set; }
        public string accountNumber { get; set; }
        public string ProductCode { get; set; }
        public string CardHoldername { get; set; }
        public string BranchCode { get; set; }
        public string CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Currency { get; set; }
        public string ExtraFields { get; set; }
        public string Status { get; set; }
        public string FreeQualified { get; set; }


        public string Message { get; set; }


        public string CardIssuanceProfileCardIssuanceProfile { get; set; }
        public string CardCostType { get; set; }
        public string CardCostAmount { get; set; }
        public string CardUniqueId { get; set; }
        public string MaskedPan { get; set; }
        public string NameOnCard { get; set; }
        public string ExpiryDate { get; set; }
        public string CardType { get; set; }
        public string EncryptedPan { get; set; }
        public string RequestingUser { get; set; }

        public string DateRequested { get; set; }

        public string approvinguser { get; set; }

        public string requestinguseremail { get; set; }

        public string AccountCurrency { get; set; }

        public string OldAccountNumber { get; set; }

        public string RetrievalReferenceNumber { get; set; }

        public string ChargeAccount { get; set; }

        public string ChargeAccountType { get; set; }
        public string CardId { get; set; }
        public string MappedProfileID { get; set; }
        public string DisplayName { get; set; }
        public string InstitutionCode { get; set; }

    }

    public class ExistingCards
    {
        public string MaskedPan { get; set; }
        public string ProductCode { get; set; }
        public string EncryptedPan { get; set; }
        public string ExpiryDate { get; set; }
        public string SequenceNo { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public string CardProgram { get; set; }
    }

    public class CardProfiles
    {
        public string ID { get; set; }
        public string CardProfileName { get; set; }
        public string Currency { get; set; }
        public string PanPrefix { get; set; }
    }


}
