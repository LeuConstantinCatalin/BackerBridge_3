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
        private readonly BackerBridgeEntities _dbContext;
        private readonly UsersViewModel usersViewModel;

        private string totalDonationAmount;
        public string TotalDonationAmount
        {
            get => totalDonationAmount;
            set => SetProperty(ref totalDonationAmount, value);
        }

        public ObservableCollection<DonationInfo> Donations { get; set; }

        public InsightDonorViewModel(UsersViewModel usersViewModel)
        {
            this.usersViewModel = usersViewModel;
            _dbContext = new BackerBridgeEntities();

            Donations = new ObservableCollection<DonationInfo>();

            LoadDonations();
        }

        private void LoadDonations()
        {
            try
            {
                // Retrieve the logged-in user from the UsersViewModel
                var loggedUser = usersViewModel.Users.FirstOrDefault();

                if (loggedUser == null)
                {
                    TotalDonationAmount = "$0.00";
                    return;
                }

                // Calculate total donation amount
                var totalDonationAmount = _dbContext.Payments
                    .Where(p => p.Donations.UserID == loggedUser.UserID)
                    .Sum(p => (double?)p.Amount) ?? 0;

                TotalDonationAmount = $"${totalDonationAmount:N2}";

                // Fetch donations with valid payments
                var donations = _dbContext.Donations
                    .Where(d => d.UserID == loggedUser.UserID && d.Payments.Any(p => p.Amount > 0))
                    .Select(d => new DonationInfo
                    {
                        DonationMessage = d.DonationMessage,
                        DonationDate = d.DonationDate,
                        Amount = d.Payments.Sum(p => p.Amount)
                    })
                    .Where(d => d.Amount > 0)
                    .ToList();

                // Populate the ObservableCollection
                Donations.Clear();
                donations.ForEach(Donations.Add);
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., logging)
            }
        }
    }

    public class DonationInfo
    {
        public string DonationMessage { get; set; }
        public DateTime DonationDate { get; set; }
        public double Amount { get; set; }
    }
}

