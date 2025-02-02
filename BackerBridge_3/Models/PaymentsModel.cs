using System;
using System.ComponentModel;

namespace BackerBridge_3.Models
{
    public class PaymentsModel
    {
        public class Payments : INotifyPropertyChanged
        {
            private int paymentID;
            private int donationId;
            private float amount;
            private DateTime paymentDate;
            private string paymentMethod;
            private string paymentStatus;

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public int PaymentID
            {
                get { return paymentID; }
                set
                {
                    if (paymentID != value)
                    {
                        paymentID = value;
                        RaisePropertyChanged(nameof(PaymentID));
                    }
                }
            }

            public int DonationID
            {
                get { return donationId; }
                set
                {
                    if (donationId != value)
                    {
                        donationId = value;
                        RaisePropertyChanged(nameof(DonationID));
                    }
                }
            }

            public float Amount
            {
                get { return amount; }
                set
                {
                    if (amount != value)
                    {
                        amount = value;
                        RaisePropertyChanged(nameof(Amount));
                    }
                }
            }

            public DateTime PaymentDate
            {
                get { return paymentDate; }
                set
                {
                    if (paymentDate != value)
                    {
                        paymentDate = value;
                        RaisePropertyChanged(nameof(PaymentDate));
                    }
                }
            }

            public string PaymentMethod
            {
                get { return paymentMethod; }
                set
                {
                    if (paymentMethod != value)
                    {
                        paymentMethod = value;
                        RaisePropertyChanged(nameof(PaymentMethod));
                    }
                }
            }

            public string PaymentStatus
            {
                get { return paymentStatus; }
                set
                {
                    if (paymentStatus != value)
                    {
                        paymentStatus = value;
                        RaisePropertyChanged(nameof(PaymentStatus));
                    }
                }
            }
        }
    }
}
