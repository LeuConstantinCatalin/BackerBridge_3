using BackerBridge_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static BackerBridge_3.Models.CampaignModel;

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for SetUpUC_View.xaml
    /// </summary>
    public partial class SetUpUC_View : UserControl
    {
        public SetUpUC_View(int campaignId, UsersViewModel usersViewModel)
        {
            InitializeComponent();
            DataContext = new DonationViewModel(campaignId, usersViewModel);
        }

        private void RecurringCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Show the recurring options when the checkbox is checked
            RecurringOptionsPanel.Visibility = Visibility.Visible;
        }

        private void RecurringCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Hide the recurring options when the checkbox is unchecked
            RecurringOptionsPanel.Visibility = Visibility.Collapsed;
        }
    }
}
