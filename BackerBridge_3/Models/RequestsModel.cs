using System;
using System.ComponentModel;

namespace BackerBridge_3.Models
{
    public class RequestsModel
    {
        public class Requests : INotifyPropertyChanged
        {
            private int requestID;
            private int userID;
            private DateTime requestTime;
            private string status;
            private string message;

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public int RequestID
            {
                get { return requestID; }
                set
                {
                    if (requestID != value)
                    {
                        requestID = value;
                        RaisePropertyChanged(nameof(RequestID));
                    }
                }
            }

            public int UserID
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

            public DateTime RequestTime
            {
                get { return requestTime; }
                set
                {
                    if (requestTime != value)
                    {
                        requestTime = value;
                        RaisePropertyChanged(nameof(RequestTime));
                    }
                }
            }

            public string Status
            {
                get { return status; }
                set
                {
                    if (status != value)
                    {
                        status = value;
                        RaisePropertyChanged(nameof(Status));
                    }
                }
            }

            public string Message
            {
                get { return message; }
                set
                {
                    if (message != value)
                    {
                        message = value;
                        RaisePropertyChanged(nameof(Message));
                    }
                }
            }
        }
    }
}
