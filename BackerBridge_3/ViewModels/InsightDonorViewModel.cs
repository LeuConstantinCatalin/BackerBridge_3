using BackerBridge_3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.ViewModels
{
    internal class InsightDonorViewModel : BaseViewModel
    {
        private readonly DonorInsightModel _donorInsightModel;
        private readonly UsersViewModel _usersViewModel;

        private string _totalDonationAmount;
        public string TotalDonationAmount
        {
            get => _totalDonationAmount;
            set => SetProperty(ref _totalDonationAmount, value);
        }

        public ObservableCollection<DonationInfo> Donations { get; set; }

        public InsightDonorViewModel(UsersViewModel usersViewModel)
        {
            _donorInsightModel = new DonorInsightModel();
            _usersViewModel = usersViewModel;

            Donations = new ObservableCollection<DonationInfo>();

            LoadDonations();
        }

        private void LoadDonations()
        {
            try
            {
                // Retrieve the logged-in user from UsersViewModel
                var loggedUser = _usersViewModel.Users.FirstOrDefault();

                if (loggedUser == null)
                {
                    TotalDonationAmount = "$0.00";
                    return;
                }

                // Load total donation amount
                var totalDonationAmount = _donorInsightModel.GetTotalDonationAmount(loggedUser.UserID);
                TotalDonationAmount = $"${totalDonationAmount:N2}";

                // Load donations
                var donations = _donorInsightModel.GetUserDonations(loggedUser.UserID);

                // Populate the ObservableCollection
                Donations.Clear();
                donations.ForEach(Donations.Add);
            }
            catch (Exception ex)
            {
                // Handle errors, e.g., logging
                TotalDonationAmount = "Error loading donations";
            }
        }
    }
}

