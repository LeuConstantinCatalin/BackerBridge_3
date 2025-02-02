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

namespace BackerBridge_3.Views
{
    /// <summary>
    /// Interaction logic for AccountUC_View.xaml
    /// </summary>
    public partial class AccountUC_View : UserControl
    {
        private AccountViewModel viewModel;

        public AccountUC_View(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            viewModel = new AccountViewModel(usersViewModel);
            DataContext = viewModel;
        }

        private void ChangeDetails_Click(object sender, RoutedEventArgs e)
        {
            tbFirstName.IsReadOnly = false;
            tbLastName.IsReadOnly = false;
            tbEmail.IsReadOnly = false;
            tbBirthDate.IsReadOnly = false;

            btnApplyChanges.Visibility = System.Windows.Visibility.Visible;
        }

        private void ApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ApplyChanges();

            tbFirstName.IsReadOnly = true;
            tbLastName.IsReadOnly = true;
            tbEmail.IsReadOnly = true;
            tbBirthDate.IsReadOnly = true;

            btnApplyChanges.Visibility = System.Windows.Visibility.Collapsed;
        }

        /*private void LogOut_Click(object sender, RoutedEventArgs e)
        {

        }*/

        private void SendRequest_Click(object sender, RoutedEventArgs e)
        {
            //viewModel.SendFundraiserRequest(tbRequestMessage.Text);
        }
    }
}
