using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Oracle;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace readData
{
    public class forTable1
    {
        public int userID;
        public string Username;
        public string Password;
        public string PhoneN;
        public string Address;
        public string Description;
        public string Department;
        public string Name;
        public string Surname;

        public int userIDS
        {
            get { return userID; }
            set { userID = value; }
        }
        public string userNames
        {
            get { return Username; }
            set { Username = value; }
        }
        public string passwords
        {
            get { return Password; }
            set { Password = value; }
        }

        public string Addreses
        {
            get { return Address; }
            set { Address = value; }
        }
        public string Descriptions
        {
            get { return Description; }
            set { Description = value; }
        }
        public string phoneNumber
        {
            get { return PhoneN; }
            set { PhoneN = value; }
        }
        public string Departmans
        {
            get { return Department; }
            set { Department = value; }
        }
        public string Names
        {
            get { return Name; }
            set { Name = value; }
        }
        public string surnames
        {
            get { return Surname; }
            set { Surname = value; }
        }


    }
}
