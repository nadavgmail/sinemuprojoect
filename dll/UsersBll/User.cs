using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum permission { Admin, Regular };
namespace UsersBll
{
    
    public class User
    {
        
        public User() { }

        private int userCode;

        public int UserCode
        {
            get { return userCode; }
            set { userCode = value; }
        }
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private string cardType;
        private permission permission;
        private string cardNumber;
        private DateTime expiratinDate;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
       

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
       

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        

        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
   
   

    
    

    public DateTime ExpiratinDate
    {
        get { return expiratinDate; }
        set { expiratinDate = value; }
    }
    

    public permission Permission
    {
        get { return permission; }
        set { permission = value; }
    }
    public void InsertUser(string firstName, string lastName, string username, string password, string cardType, permission permission, string cardNumber, DateTime expiratinDate)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = username;
        Password = password;
        CardType = cardType;
        CardNumber = cardNumber;
        Permission = permission;
        ExpiratinDate = expiratinDate;
    }
    }
}
