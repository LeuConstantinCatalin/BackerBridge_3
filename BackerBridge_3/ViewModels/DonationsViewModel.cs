using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    public class DonationsViewModel
    {
        public ObservableCollection<Donations> Donations { get; set; }

        public DonationsViewModel()
        {
            Donations = new ObservableCollection<Donations>();
        }
    }
}
