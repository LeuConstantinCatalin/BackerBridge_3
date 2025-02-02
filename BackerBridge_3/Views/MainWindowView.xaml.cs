using BackerBridge_3.Properties;
using BackerBridge_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
using static BackerBridge_3.Models.UsersModel;

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private const double aspectRatio = 1.497;
        private float[] leftButtonsOpacity;
        private UsersViewModel usersViewModel;

        public MainWindowView(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            leftButtonsOpacity = new float[5];
            leftButtonsOpacity[0] = 1f;
            leftButtonsOpacity[1] = 0f;
            leftButtonsOpacity[2] = 0f;
            leftButtonsOpacity[3] = 0f;
            leftButtonsOpacity[4] = 0f;
            UpdateLeftButtonOpacity();
            this.usersViewModel = usersViewModel;
            ccContents.Content = new DashBoardUC_View();
        }

        private void UpdateLeftButtonOpacity()
        {
            this.imDashBoard.Opacity = leftButtonsOpacity[0];
            this.imInsight.Opacity = leftButtonsOpacity[1];
            this.imTransaction.Opacity = leftButtonsOpacity[2];
            this.imAccount.Opacity = leftButtonsOpacity[3];
            this.imSettings.Opacity = leftButtonsOpacity[4];
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWidth = e.NewSize.Width;
            double newHeight = newWidth / aspectRatio;
            this.Height = newHeight;
        }

        private void btDashboard_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imDashBoard.Opacity = 0.5f;
        }

        private void btDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (leftButtonsOpacity[0] == 0f)
                this.imDashBoard.Opacity = 0f;
            this.imDashBoard.Opacity = leftButtonsOpacity[0];
        }

        private void btInsight_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imInsight.Opacity = 0.5f;
        }

        private void btInsight_MouseLeave(object sender, MouseEventArgs e)
        {
            if (leftButtonsOpacity[1] == 0f)
                this.imInsight.Opacity = 0f;
            this.imInsight.Opacity = leftButtonsOpacity[1];
        }

        private void btTransaction_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imTransaction.Opacity = 0.5f;
        }

        private void btTransaction_MouseLeave(object sender, MouseEventArgs e)
        {
            if (leftButtonsOpacity[2] == 0f)
                this.imTransaction.Opacity = 0f;
            this.imTransaction.Opacity = leftButtonsOpacity[2];
        }

        private void btAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imAccount.Opacity = 0.5f;
        }

        private void btAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            if (leftButtonsOpacity[3] == 0f)
                this.imAccount.Opacity = 0f;
            this.imAccount.Opacity = leftButtonsOpacity[3];
        }

        private void btSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imSettings.Opacity = 0.5f;
        }

        private void btSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            if (leftButtonsOpacity[4] == 0f)
                this.imSettings.Opacity = 0f;
            this.imSettings.Opacity = leftButtonsOpacity[4];
        }

        private void btDashboard_Click(object sender, RoutedEventArgs e)
        {
            leftButtonsOpacity[0] = 1f;
            leftButtonsOpacity[1] = 0f;
            leftButtonsOpacity[2] = 0f;
            leftButtonsOpacity[3] = 0f;
            leftButtonsOpacity[4] = 0f;
            UpdateLeftButtonOpacity();
            ccContents.Content = new DashBoardUC_View();
            //ccContents.Content = new DashBoard(data);
        }

        private void btInsight_Click(object sender, RoutedEventArgs e)
        {
            leftButtonsOpacity[0] = 0f;
            leftButtonsOpacity[1] = 1f;
            leftButtonsOpacity[2] = 0f;
            leftButtonsOpacity[3] = 0f;
            leftButtonsOpacity[4] = 0f;
            UpdateLeftButtonOpacity();

            // Get the appropriate control from the ViewModel
            var insightControl = usersViewModel.GetInsightControl();

            if (insightControl != null)
            {
                ccContents.Content = insightControl;
            }
            
        }

        private void btTransaction_Click(object sender, RoutedEventArgs e)
        {
            leftButtonsOpacity[0] = 0f;
            leftButtonsOpacity[1] = 0f;
            leftButtonsOpacity[2] = 1f;
            leftButtonsOpacity[3] = 0f;
            leftButtonsOpacity[4] = 0f;
            UpdateLeftButtonOpacity();
            //ccContents.Content = new Transaction(loggedUser);
        }

        private void btAccount_Click(object sender, RoutedEventArgs e)
        {
            leftButtonsOpacity[0] = 0f;
            leftButtonsOpacity[1] = 0f;
            leftButtonsOpacity[2] = 0f;
            leftButtonsOpacity[3] = 1f;
            leftButtonsOpacity[4] = 0f;
            UpdateLeftButtonOpacity();
            //ccContents.Content = new Account(loggedUser);
            ccContents.Content = new AccountUC_View(usersViewModel);
        }

        private void btSettings_Click(object sender, RoutedEventArgs e)
        {
            leftButtonsOpacity[0] = 0f;
            leftButtonsOpacity[1] = 0f;
            leftButtonsOpacity[2] = 0f;
            leftButtonsOpacity[3] = 0f;
            leftButtonsOpacity[4] = 1f;
            UpdateLeftButtonOpacity();

            //if (loggedUser.UserType.ToLower() == "admin")
            //{
            //    ccContents.Content = new Settings(loggedUser);
            //}
            //if (loggedUser.UserType.ToLower() == "fundraiser")
            //{
            //    ccContents.Content = new Settings_Fundraiser(loggedUser);
            //}
            //if (loggedUser.UserType.ToLower() == "donor")
            //{
            //    ccContents.Content = new Settings_Donor();
            //}
            // Get the appropriate settings control from UsersViewModel
            var settingsControl = usersViewModel.GetSettingsControl();

            if (settingsControl != null)
            {
                ccContents.Content = settingsControl;  // Assuming 'ccSettingsContent' is a ContentControl for settings
            }
        }
    }
}

