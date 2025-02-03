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
        private readonly DonorInsightModel _donorModel;
        private readonly UsersViewModel _usersViewModel;

        // Use the correct type for the collection
        public ObservableCollection<DonorDonationInfo> Donations { get; set; }

        public InsightDonorViewModel(UsersViewModel usersViewModel)
        {
            _donorModel = new DonorInsightModel();
            _usersViewModel = usersViewModel;

            Donations = new ObservableCollection<DonorDonationInfo>();

            LoadDonations();
        }

        private void LoadDonations()
        {
            var currentUser = _usersViewModel.Users.FirstOrDefault();

            if (currentUser == null)
            {
                return;
            }

            // GetUserDonations should return DonorDonationInfo
            var donations = _donorModel.GetUserDonations(currentUser.UserID);

            Donations.Clear();
            donations.ForEach(donation => Donations.Add(donation));
        }
    }
}

