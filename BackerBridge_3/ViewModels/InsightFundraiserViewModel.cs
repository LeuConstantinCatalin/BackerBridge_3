using BackerBridge_3.Models;
using BackerBridge_3.Views.BackerBridge_3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BackerBridge_3.ViewModels
{
    internal class InsightFundraiserViewModel : BaseViewModel
    {
        private readonly InsightFundraiserModel _fundraiserModel;
        private readonly UsersViewModel _usersViewModel;

        public ObservableCollection<CampaignItem> Campaigns { get; set; }

        public ICommand StopResumeCampaignCommand { get; }
        public ICommand CompleteCampaignCommand { get; }
        public ICommand ViewDonationsCommand { get; }

        public InsightFundraiserViewModel(UsersViewModel usersViewModel)
        {
            _fundraiserModel = new InsightFundraiserModel();
            _usersViewModel = usersViewModel;

            Campaigns = new ObservableCollection<CampaignItem>();

            StopResumeCampaignCommand = new RelayCommand<CampaignItem>(StopResumeCampaign);
            CompleteCampaignCommand = new RelayCommand<CampaignItem>(CompleteCampaign);
            ViewDonationsCommand = new RelayCommand<CampaignItem>(ViewDonations);

            LoadCampaigns();
        }

        private void LoadCampaigns()
        {
            var currentUser = _usersViewModel.Users.FirstOrDefault();

            if (currentUser == null)
            {
                MessageBox.Show("No logged-in user found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var campaigns = _fundraiserModel.GetCampaignsByUserId(currentUser.UserID);
            Campaigns.Clear();
            campaigns.ForEach(Campaigns.Add);
        }

        private void StopResumeCampaign(CampaignItem campaign)
        {
            string newStatus = campaign.CampaignStatus == "Stopped" ? "Pending" : "Stopped";
            _fundraiserModel.UpdateCampaignStatus(campaign.CampaignID, newStatus);
            LoadCampaigns();
        }

        private void CompleteCampaign(CampaignItem campaign)
        {
            _fundraiserModel.CompleteCampaign(campaign.CampaignID);
            LoadCampaigns();
        }

        private void ViewDonations(CampaignItem campaign)
        {
            var donations = _fundraiserModel.GetDonationsByCampaignId(campaign.CampaignID);
            if (donations.Any())
            {
                string message = string.Join("\n", donations.Select(d => $"Name: {d.UserName}, Amount: {d.Amount:C}, Message: {d.DonationMessage}"));
                MessageBox.Show(message, "Donations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No donations found for this campaign.", "Donations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
