using BackerBridge_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for LogInUC_View.xaml
    /// </summary>
    public partial class LogInUC_View : UserControl
    {
        public event EventHandler SignUpRequested;
        public event EventHandler LogInSuccessful;
        private readonly UsersViewModel userViewModel;

        public LogInUC_View(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            this.userViewModel = usersViewModel;
        }

        private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == "Your Email")
                tbEmail.Text = string.Empty;
        }

        private void tbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
                tbEmail.Text = "Your Email";
        }

        private void tbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            // Add logic if needed
        }

        private void tbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            // Add logic if needed
        }

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Password;

            if (userViewModel.AuthenticateUser(email, password))
            {
                new MainWindowView(userViewModel).Show();
                LogInSuccessful?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpRequested?.Invoke(this, EventArgs.Empty);
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
