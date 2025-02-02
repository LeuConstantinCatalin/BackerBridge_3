using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    public class RequestsViewModel
    {
        public ObservableCollection<Requests> Requests { get; set; }

        public RequestsViewModel()
        {
            Requests = new ObservableCollection<Requests>();
        }
    }
}
