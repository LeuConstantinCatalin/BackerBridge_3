using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    public class CampaignViewModel
    {
        public ObservableCollection<Campaign> Campaigns { get; set; }

        public CampaignViewModel()
        {
            Campaigns = new ObservableCollection<Campaign>();
        }
    }
}
