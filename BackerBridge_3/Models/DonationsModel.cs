using System;
using System.ComponentModel;

namespace BackerBridge_3.Models
{
    public class DonationsModel
    {
        public class Donations : INotifyPropertyChanged
        {
            private int donationID;
            private string userID;
            private DateTime donationTime;
            private string donationMessage;
            private string donationStatus;
            private string donationType;
            private int campaignID;

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }

            public int DonationID
            {
                get { return donationID; }
                set
                {
                    if (donationID != value)
                    {
                        donationID = value;
                        RaisePropertyChanged(nameof(DonationID));
                    }
                }
            }

            public string UserID
            {
                get { return userID; }
                set
                {
                    if (userID != value)
                    {
                        userID = value;
                        RaisePropertyChanged(nameof(UserID));
                    }
                }
            }

            public DateTime DonationTime
            {
                get { return donationTime; }
                set
                {
                    if (donationTime != value)
                    {
                        donationTime = value;
                        RaisePropertyChanged(nameof(DonationTime));
                    }
                }
            }

            public string DonationMessage
            {
                get { return donationMessage; }
                set
                {
                    if (donationMessage != value)
                    {
                        donationMessage = value;
                        RaisePropertyChanged(nameof(DonationMessage));
                    }
                }
            }

            public string DonationStatus
            {
                get { return donationStatus; }
                set
                {
                    if (donationStatus != value)
                    {
                        donationStatus = value;
                        RaisePropertyChanged(nameof(DonationStatus));
                    }
                }
            }

            public string DonationType
            {
                get { return donationType; }
                set
                {
                    if (donationType != value)
                    {
                        donationType = value;
                        RaisePropertyChanged(nameof(DonationType));
                    }
                }
            }

            public int CampaignID
            {
                get { return campaignID; }
                set
                {
                    if (campaignID != value)
                    {
                        campaignID = value;
                        RaisePropertyChanged(nameof(CampaignID));
                    }
                }
            }
        }
    }
}
