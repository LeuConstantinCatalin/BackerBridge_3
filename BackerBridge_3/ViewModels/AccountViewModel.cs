using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackerBridge_3.Models.RequestsModel;
using System.Windows;
using System.Windows.Input;
using BackerBridge_3.Views;
using BackerBridge_3.Views.BackerBridge_3.Views;
using BackerBridge_3.Models;
using static BackerBridge_3.Models.UsersModel;

namespace BackerBridge_3.ViewModels
{
    internal class AccountViewModel : BaseViewModel
    {
        private readonly AccountModel _accountModel;
        private readonly UsersViewModel _usersViewModel;

        // Commands
        public ICommand LogOutCommand { get; }
        public ICommand SendRequestCommand { get; }

        // Properties to bind to the view
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _birthDate;
        private bool _isDonor;
        private string _requestMessage;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        public bool IsDonor
        {
            get => _isDonor;
            set => SetProperty(ref _isDonor, value);
        }

        public string RequestMessage
        {
            get => _requestMessage;
            set => SetProperty(ref _requestMessage, value);
        }

        public AccountViewModel(UsersViewModel usersViewModel)
        {
            _accountModel = new AccountModel();
            _usersViewModel = usersViewModel;

            LogOutCommand = new RelayCommand(LogOut);
            SendRequestCommand = new RelayCommand(SendFundraiserRequest);

            LoadUserData();
        }

        private void LogOut()
        {
            try
            {
                _usersViewModel.Users.Clear();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var mainWindow = Application.Current.Windows.OfType<MainWindowView>().FirstOrDefault();
                    mainWindow?.Close();

                    var connectView = new ConnectView();
                    connectView.Show();
                    Application.Current.MainWindow = connectView;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during logout: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadUserData()
        {
            var currentUser = _usersViewModel.Users.FirstOrDefault();

            if (currentUser == null)
            {
                MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = _accountModel.GetUserData(currentUser.UserID);
            if (user == null)
            {
                MessageBox.Show("User not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Populate the properties
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            BirthDate = user.BirthDate.ToString("dd-MM-yyyy");
            IsDonor = user.UserType.ToLower() == "donor";
        }

        public void ApplyChanges()
        {
            try
            {
                var currentUser = _usersViewModel.Users.FirstOrDefault();

                if (currentUser == null)
                {
                    MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Update user details
                var updatedUser = new User
                {
                    UserID = currentUser.UserID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    BirthDate = DateTime.Parse(BirthDate)
                };

                if (_accountModel.UpdateUserDetails(updatedUser))
                {
                    currentUser.FirstName = FirstName;
                    currentUser.LastName = LastName;
                    currentUser.Email = Email;
                    currentUser.BirthDate = DateTime.Parse(BirthDate);

                    MessageBox.Show("Account details updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("User not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the account details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SendFundraiserRequest()
        {
            try
            {
                var currentUser = _usersViewModel.Users.FirstOrDefault();

                if (currentUser == null)
                {
                    MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var existingRequest = _accountModel.GetExistingRequest(currentUser.UserID);

                if (existingRequest != null)
                {
                    string statusMessage;

                    // Use a traditional switch statement instead of a switch expression
                    switch (existingRequest.Status)
                    {
                        case "Pending":
                            statusMessage = "You already have a pending request to become a fundraiser.";
                            break;

                        case "Rejected":
                            statusMessage = "Your previous request was rejected. Please contact support.";
                            break;

                        default:
                            statusMessage = "You already have an active request or approval.";
                            break;
                    }

                    MessageBox.Show(statusMessage, "Request Status", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }


                if (string.IsNullOrWhiteSpace(RequestMessage))
                {
                    MessageBox.Show("Please write a message before sending the request.", "Message Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _accountModel.SendFundraiserRequest(currentUser.UserID, RequestMessage);

                MessageBox.Show("Your request to become a fundraiser has been sent successfully.", "Request Sent", MessageBoxButton.OK, MessageBoxImage.Information);

                RequestMessage = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


