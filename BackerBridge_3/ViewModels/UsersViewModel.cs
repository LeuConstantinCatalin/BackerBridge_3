using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using BackerBridge_3.Views;
using System.Windows.Controls;
using System.Windows;
using BackerBridge_3.Models;
using static BackerBridge_3.Models.UsersModel;

namespace BackerBridge_3.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<UsersModel.User> Users { get; set; }

        private readonly UsersModel _usersModel;

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
            _usersModel = new UsersModel();
        }

        public bool VerifyPassword(string password)
        {
            byte[] bytes = HashPassword(password);
            return bytes.SequenceEqual(Users.First().UserPassword);
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return bytes;
            }
        }

        public bool AuthenticateUser(string email, string password)
        {
            // Get the user from the model
            var user = _usersModel.GetUserByEmail(email);

            if (user == null)
                return false;  // User not found

            // Hash the input password
            byte[] hashedPassword = HashPassword(password);

            // Verify the password
            if (user.UserPassword.SequenceEqual(hashedPassword))
            {
                // Add the authenticated user to the collection
                Users.Clear();
                Users.Add(user);

                return true;
            }

            return false;
        }

        public bool SignUpUser(string firstName, string lastName, string email, string password, DateTime birthDate)
        {
            // Check if the user already exists
            if (_usersModel.UserExists(email))
            {
                Console.WriteLine("User already exists!!!");
                return false;
            }

            // Hash the password
            byte[] hashedPassword = HashPassword(password);

            // Create a new user instance
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserPassword = hashedPassword,
                BirthDate = birthDate,
                UserType = "donor"
            };

            // Add the user to the database
            _usersModel.AddUser(newUser);

            // Add the user to the collection
            Users.Clear();
            Users.Add(newUser);

            return true;
        }

        public UserControl GetSettingsControl()
        {
            // Retrieve the logged-in user
            var loggedUser = Users.FirstOrDefault();

            if (loggedUser == null)
            {
                MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            // Determine which settings control to load based on user type
            string userType = loggedUser.UserType.ToLower();

            switch (userType)
            {
                case "fundraiser":
                    return new SettingsFundraiserUC_View(this);

                case "donor":
                    return new SettingsDonorUC_View(this);

                case "admin":
                    return new SettingsAdminUC_View(this);

                default:
                    MessageBox.Show($"Unknown user type: {loggedUser.UserType}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
            }
        }

        public UserControl GetInsightControl()
        {
            // Retrieve the logged-in user
            var loggedUser = Users.FirstOrDefault();

            if (loggedUser == null)
            {
                MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            // Determine which control to load based on user type
            string userType = loggedUser.UserType.ToLower();

            switch (userType)
            {
                case "fundraiser":
                    return new InsightFundraiserUC_View(this);

                case "donor":
                    return new InsightDonorUC_View(this);

                case "admin":
                    return new InsightAdminUC_View(this);

                default:
                    MessageBox.Show($"Unknown user type: {loggedUser.UserType}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
            }
        }
    }
}
