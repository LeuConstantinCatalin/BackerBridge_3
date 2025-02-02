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
using BackerBridge_3.Models;

namespace BackerBridge_3.ViewModels
{
    public class SettingsAdminViewModel : BaseViewModel
    {
        private readonly SettingsAdminModel _settingsAdminModel;

        public ObservableCollection<RequestItem> PendingRequests { get; set; }

        public ICommand AcceptRequestCommand { get; }
        public ICommand DeclineRequestCommand { get; }


        public SettingsAdminViewModel()
        {
            _settingsAdminModel = new SettingsAdminModel();
            PendingRequests = new ObservableCollection<RequestItem>();

            AcceptRequestCommand = new RelayCommand<RequestItem>(AcceptRequest);
            DeclineRequestCommand = new RelayCommand<RequestItem>(DeclineRequest);

            LoadPendingRequests();
        }


        public void LoadPendingRequests()
        {
            try
            {
                var requests = _settingsAdminModel.GetPendingRequests();

                PendingRequests.Clear();
                requests.ForEach(PendingRequests.Add);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading requests: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AcceptRequest(RequestItem request)
        {
            if (request == null)
                return;

            if (_settingsAdminModel.AcceptRequest(request.RequestID, request.UserID))
            {
                MessageBox.Show($"Request {request.RequestID} accepted. User {request.UserID} is now a Fundraiser.", "Request Accepted", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadPendingRequests();
            }
            else
            {
                MessageBox.Show("Failed to accept the request.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeclineRequest(RequestItem request)
        {
            if (request == null)
                return;

            if (_settingsAdminModel.DeclineRequest(request.RequestID))
            {
                MessageBox.Show($"Request {request.RequestID} has been declined.", "Request Declined", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadPendingRequests();
            }
            else
            {
                MessageBox.Show("Failed to decline the request.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
