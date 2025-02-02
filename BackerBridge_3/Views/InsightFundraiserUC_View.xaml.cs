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
    /// Interaction logic for InsightFundraiserUC_View.xaml
    /// </summary>
    public partial class InsightFundraiserUC_View : UserControl
    {
        UsersViewModel usersViewModel;

        public InsightFundraiserUC_View(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            this.usersViewModel = usersViewModel;
        }
    }
}
