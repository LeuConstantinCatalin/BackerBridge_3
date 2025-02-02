using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    public class CompaniesViewModel
    {
        public ObservableCollection<Companies> Companies { get; set; }

        public CompaniesViewModel()
        {
            Companies = new ObservableCollection<Companies>();
        }
    }
}
