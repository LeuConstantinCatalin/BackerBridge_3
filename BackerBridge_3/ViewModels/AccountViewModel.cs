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

namespace BackerBridge_3.ViewModels
{
    internal class AccountViewModel : BaseViewModel
    {
        private readonly BackerBridgeEntities _dbContext;
        private readonly UsersViewModel usersViewModel;
        public ICommand LogOutCommand { get; }
        public ICommand SendRequestCommand { get; }

        // Properties to bind to the view
        private string firstName;
        private string lastName;
        private string email;
        private string birthDate;
        private bool isDonor;

        private string requestMessage;
        public string RequestMessage
        {
            get => requestMessage;
            set => SetProperty(ref requestMessage, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string BirthDate
        {
            get => birthDate;
            set => SetProperty(ref birthDate, value);
        }

        public bool IsDonor
        {
            get => isDonor;
            set => SetProperty(ref isDonor, value);
        }

        public AccountViewModel(UsersViewModel usersViewModel)
        {
            _dbContext = new BackerBridgeEntities();
            this.usersViewModel = usersViewModel;

            LogOutCommand = new RelayCommand(LogOut);
            SendRequestCommand = new RelayCommand(SendFundraiserRequest);

            LoadUserData();
        }

        private void LogOut()
        {
            try
            {
                // Clear the current user from UsersViewModel
                usersViewModel.Users.Clear();

                // Close the MainWindowView and navigate to ConnectView
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Close the current MainWindow
                    var mainWindow = Application.Current.Windows.OfType<MainWindowView>().FirstOrDefault();
                    mainWindow?.Close();

                    // Open the ConnectView
                    var connectView = new ConnectView();
                    connectView.Show();

                    // Update the main application window
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
            var currentUser = usersViewModel.Users.FirstOrDefault();

            if (currentUser == null)
            {
                MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Populate the view model properties
            FirstName = currentUser.FirstName;
            LastName = currentUser.LastName;
            Email = currentUser.Email;
            BirthDate = currentUser.BirthDate.ToString("dd-MM-yyyy");
            IsDonor = currentUser.UserType.ToLower() == "donor";
        }

        public void ApplyChanges()
        {
            try
            {
                var currentUser = usersViewModel.Users.FirstOrDefault();

                if (currentUser == null)
                {
                    MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Update user data in the database
                var userToUpdate = _dbContext.Users.SingleOrDefault(u => u.UserID == currentUser.UserID);
                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = FirstName;
                    userToUpdate.LastName = LastName;
                    userToUpdate.Email = Email;
                    userToUpdate.BirthDate = DateTime.Parse(BirthDate);

                    _dbContext.SaveChanges();

                    // Update the current user in the ViewModel
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

        void SendFundraiserRequest()
        {
            try
            {
                var currentUser = usersViewModel.Users.FirstOrDefault();

                if (currentUser == null)
                {
                    MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Check for an existing request
                var existingRequest = _dbContext.Requests.SingleOrDefault(r => r.UserID == currentUser.UserID);

                if (existingRequest != null)
                {
                    string statusMessage;

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

                // Ensure the message is not empty
                if (string.IsNullOrWhiteSpace(RequestMessage))
                {
                    MessageBox.Show("Please write a message before sending the request.", "Message Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create and save the new request
                var newRequest = new Requests
                {
                    UserID = currentUser.UserID,
                    RequestDate = DateTime.Now,
                    Status = "Pending",
                    Message = RequestMessage
                };

                _dbContext.Requests.Add(newRequest);
                _dbContext.SaveChanges();

                MessageBox.Show("Your request to become a fundraiser has been sent successfully.", "Request Sent", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the message
                RequestMessage = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

