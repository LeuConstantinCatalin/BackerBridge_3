using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class DonorInsightModel
    {
        private readonly BackerBridgeEntities _dbContext;

        public DonorInsightModel()
        {
            _dbContext = new BackerBridgeEntities();
        }

        // Get total donation amount for a specific user
        public double GetTotalDonationAmount(int userId)
        {
            return _dbContext.Payments
                .Where(p => p.Donations.UserID == userId)
                .Sum(p => (double?)p.Amount) ?? 0;
        }

        // Get donations for a specific user
        public List<DonorDonationInfo> GetUserDonations(int userId)
        {
            return _dbContext.Donations
                .Where(d => d.UserID == userId && d.Payments.Any(p => p.Amount > 0))
                .Select(d => new DonorDonationInfo
                {
                    DonationMessage = d.DonationMessage,
                    DonationDate = d.DonationDate,
                    Amount = d.Payments.Sum(p => p.Amount)
                })
                .Where(d => d.Amount > 0)
                .ToList();
        }
    }

    public class DonorDonationInfo
    {
        public string DonationMessage { get; set; }
        public DateTime DonationDate { get; set; }
        public double Amount { get; set; }
    }
}
