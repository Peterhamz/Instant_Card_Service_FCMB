using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fcmb
{
    /**
    class Root
    {

        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string motherMaidenName { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string bvnMobileNumber { get; set; }
        public string preferredMobileNumber { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string bvn { get; set; }
        public string maritalStatus { get; set; }
        public string occupation { get; set; }
        public string employmentStatus { get; set; }
        public string image { get; set; }
        public bool addImageFromBVN { get; set; }
        public string requestId { get; set; }
        public ConfigCredentials configCredentials { get; set; }
    }

    public class Address
    {
        public string addrLine1 { get; set; }
        public string houseNum { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class ConfigCredentials
    {
        public string clientId { get; set; }
        public string productId { get; set; }
    }
    */


    public class Address
    {
        public string addrLine1 { get; set; }
        public string addrLine2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string houseNum { get; set; }
        public string startDate { get; set; }
        public string state { get; set; }
        public string streetName { get; set; }
        public object streetNum { get; set; }
        public string postalCode { get; set; }
    }

    public class ConfigCredentials
    {
        public string clientId { get; set; }
        public string productId { get; set; }
    }

    public class Root
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string motherMaidenName { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string bvnMobileNumber { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string bvn { get; set; }
        public string maritalStatus { get; set; }
        public string occupation { get; set; }
        public string employmentStatus { get; set; }
        public string salutation { get; set; }
        public string requestId { get; set; }
        public bool addImageFromBVN { get; set; }
        public ConfigCredentials configCredentials { get; set; }
    }

}
