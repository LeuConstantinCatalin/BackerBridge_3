using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class CompaniesModel
    {
        public class Companies : INotifyPropertyChanged 
        {
            private int companyID;
            private string companyName;
            private string companyEmail;
            private string companyAddress;
            private int userId;

            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }

            public int CompanyID
            {
                get { return companyID; }
                set
                {
                    companyID = value;
                    if(PropertyChanged != null)
                    {
                        RaisePropertyChanged("CompaniesID");
                    }
                }
            }

            public string CompanyName
            {
                get { return companyName; }
                set
                {
                    companyName = value;
                    if(PropertyChanged!=null)
                    {
                        RaisePropertyChanged("CompanyName");
                    }
                }
            }

            public string CompanyEmail
            {
                get { return companyEmail; }
                set
                {
                    companyEmail = value;
                    if(PropertyChanged!=null)
                    {
                        RaisePropertyChanged("CompanyEmail");
                    }
                }
            }

            public string CompanyAddress
            {
                get { return companyAddress; }
                set
                {
                    companyAddress = value;
                    if(PropertyChanged!= null)
                    {
                        RaisePropertyChanged("CompanyAddress");
                    }
                }
            }

            public int UserId
            { 
                get { return userId; } 
                set
                {
                    userId = value;
                    if(PropertyChanged!=null)
                    {
                        RaisePropertyChanged("UserID");
                    }
                } 
            }
        }
    }
}
