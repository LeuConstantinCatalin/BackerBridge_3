using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class CampaignModel
    {
        public class Campaign : INotifyPropertyChanged
        {
            private readonly BackerBridgeEntities _dbContext;

            private string campaignID;
            private string campaignName;
            private int companyID;
            private int userID;
            private string projectDescription;
            private float goalAmount;
            private float currentAmount;
            private string campaignStatus;

            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }

            public string CampaignID
            {
                get { return campaignID; }
                set
                {
                    campaignID = value;
                    if (PropertyChanged != null)
                    {
                        RaisePropertyChanged("CampaignID");
                    }
                }
            }

            public string CampaignName
            {
                get { return campaignName; }
                set
                {
                    campaignName = value;
                    if (PropertyChanged != null)
                    {
                        RaisePropertyChanged("CampaignName");
                    }
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
                        RaisePropertyChanged("CompanyID");
                    }
                }
            }

            public int UserID
            {
                get { return userID; }
                set
                {
                    userID = value;
                    if (PropertyChanged != null)
                    {
                        RaisePropertyChanged("UserID");
                    }
                }
            }

            public string ProjectDescription
            {
                get { return projectDescription; }
                set
                {
                    projectDescription = value;
                    if(PropertyChanged!=null)
                    {
                        RaisePropertyChanged("ProjectDescription");
                    }
                }
            }

            public float GoalAmount
            {
                get { return goalAmount; }
                set
                {
                    goalAmount = value;
                    if (PropertyChanged != null)
                    {
                        RaisePropertyChanged("GoalAmount");
                    }
                }
            }

            public float CurrentAmount
            {
                get { return currentAmount; }
                set
                {
                    currentAmount = value;
                    if(PropertyChanged != null)
                    {
                        RaisePropertyChanged("CurrentAmount");
                    }
                }
            }

            public string CampaignStatus
            {
                get { return campaignStatus; }
                set
                {
                    campaignStatus = value;
                    if(PropertyChanged != null)
                    {
                        RaisePropertyChanged("CampaignStatus");
                    }
                }
            }
        }
    }
}
