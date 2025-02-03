using BackerBridge_3.Models;
using BackerBridge_3.Views.BackerBridge_3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackerBridge_3.Models.UsersModel;
using System.Windows.Input;

namespace BackerBridge_3.ViewModels
{
    internal class TransactionViewModel : BaseViewModel
    {
        private readonly TransactionModel _transactionModel;

        public event Action<int, UsersViewModel> RequestDonationSetup;

        public ObservableCollection<PendingCampaignItem> Campaigns { get; set; }

        private readonly UsersViewModel _usersViewModel;

        public ICommand DonateCommand { get; }

        public TransactionViewModel(UsersViewModel usersViewModel)
        {
            this._usersViewModel = usersViewModel;
            _transactionModel = new TransactionModel();
            Campaigns = new ObservableCollection<PendingCampaignItem>();

            DonateCommand = new RelayCommand<PendingCampaignItem>(DonateToCampaign, CanDonate);

            LoadCampaigns();
        }

        private bool CanDonate(PendingCampaignItem campaign)
        {
            // Ensure there's a logged-in user and a selected campaign
            return _usersViewModel.Users.Count > 0 && campaign != null;
        }

        private void LoadCampaigns()
        {
            var campaigns = _transactionModel.GetPendingCampaigns();

            Campaigns.Clear();
            foreach (var campaign in campaigns)
            {
                Campaigns.Add(campaign);
            }
        }

        private void DonateToCampaign(PendingCampaignItem campaign)
        {
            if (campaign == null || _usersViewModel.Users.Count == 0) return;

            // Raise event to notify MainWindow to switch to donation setup view
            RequestDonationSetup?.Invoke(campaign.CampaignID, _usersViewModel);
        }

        /*private _User GetCurrentUser()
        {
            // Logic to get the currently logged-in user
            return new _User(); // Replace with actual logic
        }*/
    }
}
