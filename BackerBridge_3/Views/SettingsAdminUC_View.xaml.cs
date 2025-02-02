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
    /// Interaction logic for SettingsAdminUC_View.xaml
    /// </summary>
    public partial class SettingsAdminUC_View : UserControl
    {
        private  UsersViewModel usersViewModel;
        private  SettingsAdminViewModel viewModel;

        public SettingsAdminUC_View(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            this.usersViewModel = usersViewModel;

            viewModel = new SettingsAdminViewModel();
            DataContext = viewModel;

            viewModel.LoadPendingRequests();
        }
    }
}
