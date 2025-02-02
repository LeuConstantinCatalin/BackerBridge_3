using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using BackerBridge_3.Views;
using BackerBridge_3.Views.BackerBridge_3.Views;

namespace BackerBridge_3.ViewModels
{
    public class RequestItem
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public string RequestDate { get; set; }
    }

    public class SettingsAdminViewModel : BaseViewModel
    {
        private readonly BackerBridgeEntities _dbContext;
        public ObservableCollection<RequestItem> PendingRequests { get; }

        public ICommand AcceptRequestCommand { get; }
        public ICommand DeclineRequestCommand { get; }

        public SettingsAdminViewModel()
        {
            _dbContext = new BackerBridgeEntities();
            PendingRequests = new ObservableCollection<RequestItem>();

            AcceptRequestCommand = new RelayCommand<RequestItem>(AcceptRequest);
            DeclineRequestCommand = new RelayCommand<RequestItem>(DeclineRequest);

            LoadPendingRequests();
        }

        public void LoadPendingRequests()
        {
            try
            {
                PendingRequests.Clear();

                // Fetch the raw data from the database
                var requests = _dbContext.Requests
                    .Where(r => r.Status == "Pending")
                    .Select(r => new
                    {
                        r.RequestID,
                        r.UserID,
                        r.Message,
                        r.RequestDate  // No ToString() here
                    })
                    .ToList();

                // Format the data in memory after fetching
                foreach (var request in requests)
                {
                    PendingRequests.Add(new RequestItem
                    {
                        RequestID = request.RequestID,
                        UserID = request.UserID,
                        Message = request.Message,
                        RequestDate = request.RequestDate.ToString("yyyy-MM-dd")  // Format here
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading requests: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AcceptRequest(object parameter)
        {
            if (parameter is RequestItem selectedRequest)
            {
                var request = _dbContext.Requests.SingleOrDefault(r => r.RequestID == selectedRequest.RequestID);
                var user = _dbContext.Users.SingleOrDefault(u => u.UserID == selectedRequest.UserID);

                if (request != null && user != null)
                {
                    request.Status = "Approved";
                    user.UserType = "Fundraiser";

                    _dbContext.SaveChanges();

                    MessageBox.Show($"Request {selectedRequest.RequestID} accepted. User {selectedRequest.UserID} is now a Fundraiser.",
                                    "Request Accepted", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadPendingRequests();
                }
            }
        }

        private void DeclineRequest(object parameter)
        {
            if (parameter is RequestItem selectedRequest)
            {
                var request = _dbContext.Requests.SingleOrDefault(r => r.RequestID == selectedRequest.RequestID);

                if (request != null)
                {
                    request.Status = "Rejected";

                    _dbContext.SaveChanges();

                    MessageBox.Show($"Request {selectedRequest.RequestID} has been declined.",
                                    "Request Declined", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadPendingRequests();
                }
            }
        }
    }
}
