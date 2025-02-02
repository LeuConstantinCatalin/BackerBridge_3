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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for SignUpUC_View.xaml
    /// </summary>
    public partial class SignUpUC_View : UserControl
    {
        public event EventHandler BackToLogInRequested;
        public event EventHandler SignUpSuccessful;
        private const double aspectRatio = 1.497;
        private int cnt = 0;
        private int[] allowValidation;
        private bool showPassword = true;
        private bool showConfirmPassword = true;
        private int id = 3;
        private UsersViewModel userViewModel;



        public SignUpUC_View(UsersViewModel usersViewModel)
        {
            allowValidation = new int[6];
            InitializeComponent();
            this.userViewModel = usersViewModel;
        }

        private void tbLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbLastName.Text == "Your Last Name")
                this.tbLastName.Text = string.Empty;
        }

        private void tbLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbLastName.Text == string.Empty)
                this.tbLastName.Text = "Your Last Name";
            else
                allowValidation[0] = 1;
        }

        private void tbFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbFirstName.Text == "Your First Name")
                this.tbFirstName.Text = string.Empty;
        }

        private void tbFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbFirstName.Text == string.Empty)
                this.tbFirstName.Text = "Your First Name";
            else
                allowValidation[1] = 1;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWidth = e.NewSize.Width;
            double newHeight = newWidth / aspectRatio;
            this.Height = newHeight;
        }

        private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbEmail.Text == "Your Email")
                this.tbEmail.Text = string.Empty;
        }

        private void tbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == string.Empty)
                this.tbEmail.Text = "Your Email";
            else
                allowValidation[2] = 1;
        }

        private void tbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            allowValidation[3] = 0;
        }

        private void tbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPasswordVisible.Text = tbPassword.Password;
            if (this.tbPassword.Password == string.Empty)
                this.tbPassword.Password = string.Empty;
            else
                allowValidation[3] = 1;
        }

        private void tbBirthDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbBirthDate.Text == "Your Birth Date")
                this.tbBirthDate.Text = string.Empty;
        }

        private void tbBirthDate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbBirthDate.Text == string.Empty)
                this.tbBirthDate.Text = "Your Birth Date";
            else
                allowValidation[5] = 1;
        }


        private void tbConfirmPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            allowValidation[4] = 0;
        }

        private void tbConfirmPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            tbConfirmPasswordVisible.Text = tbConfirmPassword.Password;
            if (this.tbPassword.Password == this.tbConfirmPassword.Password)
                allowValidation[4] = 1;
        }

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            BackToLogInRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            LbMessage.Content = string.Empty;


            int validationSum = 0;
            Console.WriteLine("=======ValidationSum=========");
            for (int i = 0; i < 6; i++)
            {
                validationSum += allowValidation[i];
                Console.WriteLine($"index {i} : {allowValidation[i]}");
            }
            Console.WriteLine($"Total sum : {validationSum}/6");

            if (validationSum == 6)
            {
                if(userViewModel.SignUpUser(this.tbFirstName.Text, this.tbLastName.Text, this.tbEmail.Text, this.tbPassword.Password, DateTime.Parse(this.dpBirthDate.Text)))
                {
                    SignUpSuccessful?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Signup didn't work.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private byte[] GenerateSalt(int length = 16)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[length];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return bytes;
            }
        }

        private void dpBirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine($"DEBUG: birth date = {this.dpBirthDate.Text}");
            tbBirthDate.Text = this.dpBirthDate.Text;
            allowValidation[5] = 1;
        }

        private void btShowPassword_Click(object sender, RoutedEventArgs e)
        {
            showPassword = !showPassword;
            if (showPassword)
            {
                tbPassword.Visibility = Visibility.Visible;
                tbPasswordVisible.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbPassword.Visibility = Visibility.Collapsed;
                tbPasswordVisible.Visibility = Visibility.Visible;
            }
        }

        private void tbPasswordVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            allowValidation[3] = 0;
        }

        private void tbPasswordVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPassword.Password = tbPasswordVisible.Text;
            if (this.tbPasswordVisible.Text == tbPassword.Password)
                allowValidation[3] = 1;
        }

        private void tbConfirmPasswordVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            allowValidation[4] = 0;
        }

        private void tbConfirmPasswordVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            tbConfirmPassword.Password = tbConfirmPasswordVisible.Text;
            if (this.tbConfirmPasswordVisible.Text == tbConfirmPassword.Password)
                allowValidation[4] = 1;
        }

        private void btShowConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            showConfirmPassword = !showConfirmPassword;
            if (showConfirmPassword)
            {
                tbConfirmPassword.Visibility = Visibility.Visible;
                tbConfirmPasswordVisible.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbConfirmPassword.Visibility = Visibility.Collapsed;
                tbConfirmPasswordVisible.Visibility = Visibility.Visible;
            }
        }

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            cnt++;
            Console.WriteLine($"DEBUG: password(hidden) changed event {cnt}");
        }

        private void tbPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            cnt++;
            Console.WriteLine($"DEBUG: password(visible) changed event {cnt}");
        }

        private void tbConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            cnt++;
            Console.WriteLine($"DEBUG: Vpassword(hidden) changed event {cnt}");
        }

        private void tbConfirmPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            cnt++;
            Console.WriteLine($"DEBUG: Vpassword(visible) changed event {cnt}");
        }
    }

}

