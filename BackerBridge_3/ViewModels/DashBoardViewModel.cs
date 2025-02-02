using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BackerBridge_3.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly BackerBridgeEntities _dbContext;

        private string totalDonations;
        private string totalDonors;
        private string donationsThisMonth;

        public string TotalDonations
        {
            get => totalDonations;
            set => SetProperty(ref totalDonations, value);
        }

        public string TotalDonors
        {
            get => totalDonors;
            set => SetProperty(ref totalDonors, value);
        }

        public string DonationsThisMonth
        {
            get => donationsThisMonth;
            set => SetProperty(ref donationsThisMonth, value);
        }

        public ObservableCollection<string> RecentActivities { get; set; }
        public ObservableCollection<CampaignProgress> KeyCampaigns { get; set; }
        public ObservableCollection<TopDonor> TopDonors { get; set; }

        public DashboardViewModel()
        {
            _dbContext = new BackerBridgeEntities();

            RecentActivities = new ObservableCollection<string>();
            KeyCampaigns = new ObservableCollection<CampaignProgress>();
            TopDonors = new ObservableCollection<TopDonor>();

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Pre-compute dates and handle operations outside of LINQ-to-Entities
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                // Calculate statistics without string formatting
                var totalDonationsAmount = _dbContext.Payments.Sum(p => p.Amount);
                var totalDonorCount = _dbContext.Users.Count(u => u.UserType == "donor");
                var donationsThisMonthAmount = _dbContext.Payments
                    .Where(p => p.PaymentDate >= firstDayOfMonth)
                    .Sum(p => (double?)p.Amount) ?? 0;

                // Format values for display after query execution
                TotalDonations = $"${totalDonationsAmount:N2}";
                TotalDonors = totalDonorCount.ToString();
                DonationsThisMonth = $"${donationsThisMonthAmount:N2}";

                // Recent Activities
                var recentActivities = _dbContext.Donations
                    .OrderByDescending(d => d.DonationDate)
                    .Take(5)
                    .Select(d => new { d.DonationDate, d.DonationMessage }) // Project to raw data first
                    .ToList(); // Fetch from database

                // Format the display text in memory
                RecentActivities.Clear();
                foreach (var activity in recentActivities)
                {
                    RecentActivities.Add($"{activity.DonationDate:MMM dd, yyyy}: {activity.DonationMessage}");
                }

                // Key Campaigns
                var keyCampaigns = _dbContext.Campaign
                    .Where(c => c.CampaignStatus.ToLower() == "active")
                    .OrderByDescending(c => c.CurrentAmount / c.GoalAmount)
                    .Take(5)
                    .Select(c => new
                    {
                        c.CampaignName,
                        Progress = (c.GoalAmount > 0 ? c.CurrentAmount / c.GoalAmount : 0) * 100
                    })
                    .ToList();
                KeyCampaigns.Clear();
                foreach (var campaign in keyCampaigns)
                {
                    KeyCampaigns.Add(new CampaignProgress { CampaignName = campaign.CampaignName, Progress = (double)campaign.Progress });
                }

                // Top Donors
                var topDonors = _dbContext.Payments
                    .GroupBy(p => p.Donations.UserID)
                    .Select(g => new
                    {
                        UserId = g.Key,
                        TotalAmount = g.Sum(p => p.Amount)
                    })
                    .OrderByDescending(g => g.TotalAmount)
                    .Take(5)
                    .ToList() // Fetch from database first
                    .Join(_dbContext.Users.ToList(), // Convert Users to a list to perform in-memory join
                          g => g.UserId,
                          u => u.UserID,
                          (g, u) => new TopDonor
                          {
                              Name = $"{u.FirstName} {u.LastName}",
                              Amount = g.TotalAmount
                          });
                TopDonors.Clear();
                foreach (var donor in topDonors)
                {
                    TopDonors.Add(donor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public class CampaignProgress
        {
            public string CampaignName { get; set; }
            public double Progress { get; set; }
        }

        public class TopDonor
        {
            public string Name { get; set; }
            public double Amount { get; set; }
        }
    }
}
