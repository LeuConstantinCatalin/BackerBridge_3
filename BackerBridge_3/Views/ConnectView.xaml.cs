using BackerBridge_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Windows.Shapes;

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for ConnectView.xaml
    /// </summary>
    public partial class ConnectView : Window
    {
        SignUpUC_View signUpView;
        LogInUC_View logInView;

        private UsersViewModel usersViewModel;

        public ConnectView()
        {
            InitializeComponent();
            usersViewModel = new UsersViewModel();
            logInView = new LogInUC_View(usersViewModel);
            signUpView = new SignUpUC_View(usersViewModel);
            ShowLogInView();
        }

        private void ShowLogInView()
        {
            var logInView = new LogInUC_View(usersViewModel);
            logInView.SignUpRequested += OnSignUpRequested;
            logInView.LogInSuccessful += OnLogInSuccessful;

            ccContents.Content = logInView;
        }

        private void ShowSignUpView()
        {
            var signUpView = new SignUpUC_View(usersViewModel);
            signUpView.BackToLogInRequested += OnBackToLogInRequested;
            signUpView.SignUpSuccessful += OnSignUpSuccessful;
            ccContents.Content = signUpView;
        }

        private void OnSignUpSuccessful(object sender, EventArgs e)
        {
            OpenMainWindow();
        }

        private void OnLogInSuccessful(object sender, EventArgs e)
        {
            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            // Prevent opening multiple MainWindow instances
            if (Application.Current.Windows.OfType<MainWindowView>().Any())
                return;

            // Open the main window
            var mainWindow = new MainWindowView(usersViewModel);
            mainWindow.Show();

            // Close ConnectionView on the dispatcher to ensure proper window lifecycle management
            Dispatcher.Invoke(() =>
            {
                ccContents.Content = null;
                this.Close();
            });

            // Update MainWindow to prevent application shutdown issues
            Application.Current.MainWindow = mainWindow;
        }

        private void OnSignUpRequested(object sender, EventArgs e)
        {
            ShowSignUpView();
        }

        private void OnBackToLogInRequested(object sender, EventArgs e)
        {
            ShowLogInView();
        }
    }
}

