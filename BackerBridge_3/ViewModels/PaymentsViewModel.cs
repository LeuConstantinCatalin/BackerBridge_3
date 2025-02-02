using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    public class PaymentsViewModel
    {
        public ObservableCollection<Payments> Payments { get; set; }

        public PaymentsViewModel()
        {
            Payments = new ObservableCollection<Payments>();
        }
    }
}
