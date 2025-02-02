using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class UsersModel
    {
        public class User : INotifyPropertyChanged
        {
            private int userID;
            private string firstName;
            private string lastName;
            private string email;
            private string userAddress;
            private DateTime birthdate;
            private string userType;
            private byte[] userPassword;

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }

            public int UserID
            {
                get { return userID; }
                set
                {
                    if(userID != value)
                    {
                        userID = value;
                        RaisePropertyChanged("UserID");
                    }
                }
            }

            public string FirstName
            {
                get { return firstName; }
                set { 
                    if(firstName != value) {
                        firstName = value;
                        RaisePropertyChanged("FirstName");
                    } 
                }
            }

            public string LastName
            {
                get => lastName;
                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        RaisePropertyChanged("LastName");
                    }
                }
            }

            public string Email
            {
                get { return email; }
                set
                {
                    if (email != value)
                    {
                        email = value;
                        RaisePropertyChanged("Email");
                    }
                }
            }

            public string UserAddress
            {
                get { return userAddress; }
                set
                {
                    if (userAddress != value)
                    {
                        userAddress = value;
                        RaisePropertyChanged("UserAddress");
                    }
                }
            }

            public string UserType
            {
                get { return userType; }
                set
                {
                    if (userType != value)
                    {
                        userType = value;
                        RaisePropertyChanged("UserType");
                    }
                }
            }

            public byte[] UserPassword
            {
                get { return userPassword; }
                set
                {
                    if (userPassword != value)
                    {
                        userPassword = value;
                        RaisePropertyChanged("UserPassword");
                    }
                }
            }

            public DateTime BirthDate
            {
                get { return birthdate; }
                set
                {
                    if (birthdate != value)
                    {
                        birthdate = value;
                        RaisePropertyChanged("BirthDate");
                    }
                }
            }

        }
    }
}
