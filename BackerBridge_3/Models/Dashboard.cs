using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DashboardModel
    {
        private readonly BackerBridgeEntities _dbContext;

        public DashboardModel()
        {
            _dbContext = new BackerBridgeEntities();
        }

        // Fetch statistics data
        public DashboardStatistics GetStatistics()
        {
            try
            {
                // Fetch data from the database
                var payments = _dbContext.Payments.ToList();
                var users = _dbContext.Users.ToList();

                // Calculate statistics in-memory to avoid translation issues
                var totalDonations = payments.Any() ? payments.Sum(p => p.Amount) : 0;
                var totalDonors = users.Count(u => u.UserType == "donor");

                var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var donationsThisMonth = payments
                    .Where(p => p.PaymentDate >= startOfMonth)
                    .Sum(p => p.Amount);

                // Log the results for debugging
                Console.WriteLine($"Total Donations: {totalDonations}");
                Console.WriteLine($"Total Donors: {totalDonors}");
                Console.WriteLine($"Donations This Month: {donationsThisMonth}");

                return new DashboardStatistics
                {
                    TotalDonations = totalDonations,
                    TotalDonors = totalDonors,
                    DonationsThisMonth = donationsThisMonth
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching dashboard statistics: {ex.Message}");
                return new DashboardStatistics
                {
                    TotalDonations = 0,
                    TotalDonors = 0,
                    DonationsThisMonth = 0
                };
            }
        }

        // Get recent activity logs
        public List<string> GetRecentActivities()
        {
            // Fetch raw data from the database
            var recentDonations = _dbContext.Donations
                .OrderByDescending(d => d.DonationDate)
                .Take(5)
                .Select(d => new { d.DonationDate, d.DonationMessage })
                .ToList();

            // Format the data in-memory
            return recentDonations.Select(d => $"{d.DonationDate:MMM dd, yyyy}: {d.DonationMessage}").ToList();
        }

        // Get key campaigns for display
        public List<KeyCampaignItem> GetKeyCampaigns()
        {
            return _dbContext.Campaign
                .Where(c => c.CampaignStatus == "active")
                .OrderByDescending(c => c.CurrentAmount / c.GoalAmount)
                .Take(5)
                .Select(c => new KeyCampaignItem
                {
                    CampaignName = c.CampaignName,
                    Progress = (double)(c.GoalAmount > 0 ? (c.CurrentAmount / c.GoalAmount) * 100 : 0)
                })
                .ToList();
        }

        // Get top donors by amount
        public List<TopDonorItem> GetTopDonors()
        {
            // Fetch raw data without string formatting
            var donors = _dbContext.Payments
                .GroupBy(p => p.Donations.UserID)
                .Select(g => new
                {
                    UserId = g.Key,
                    TotalAmount = g.Sum(p => p.Amount)
                })
                .OrderByDescending(g => g.TotalAmount)
                .Take(5)
                .ToList();

            // Fetch user details and format the data in-memory
            return donors
                .Join(_dbContext.Users, g => g.UserId, u => u.UserID, (g, u) => new TopDonorItem
                {
                    Name = u.FirstName + " " + u.LastName,  // Concatenate strings in-memory
                    Amount = g.TotalAmount
                })
                .ToList();
        }

    }

    // Supporting classes
    public class DashboardStatistics
    {
        public double TotalDonations { get; set; }
        public int TotalDonors { get; set; }
        public double DonationsThisMonth { get; set; }
    }

    public class KeyCampaignItem
    {
        public string CampaignName { get; set; }
        public double Progress { get; set; }
    }

    public class TopDonorItem
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}
