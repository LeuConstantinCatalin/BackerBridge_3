using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class InsightFundraiserModel
    {
        private readonly BackerBridgeEntities _dbContext;

        public InsightFundraiserModel()
        {
            _dbContext = new BackerBridgeEntities();
        }

        // Get campaigns for a specific user
        public List<CampaignItem> GetCampaignsByUserId(int userId)
        {
            return _dbContext.Campaign
                .Where(c => c.UserID == userId)
                .Select(c => new CampaignItem
                {
                    CampaignID = c.CampaignID,
                    CampaignName = c.CampaignName,
                    GoalAmount = (double)c.GoalAmount,
                    CurrentAmount = (double)c.CurrentAmount,
                    CampaignStatus = c.CampaignStatus,
                    Progress = (double)(c.GoalAmount > 0 ? (c.CurrentAmount / c.GoalAmount) * 100 : 0),
                    ButtonContent = c.CampaignStatus == "Stopped" ? "Resume" : "Stop"
                })
                .ToList();
        }

        // Update campaign status
        public void UpdateCampaignStatus(int campaignId, string newStatus)
        {
            var campaign = _dbContext.Campaign.SingleOrDefault(c => c.CampaignID == campaignId);
            if (campaign != null)
            {
                campaign.CampaignStatus = newStatus;
                _dbContext.SaveChanges();
            }
        }

        // Mark a campaign as completed
        public void CompleteCampaign(int campaignId)
        {
            var campaign = _dbContext.Campaign.SingleOrDefault(c => c.CampaignID == campaignId);
            if (campaign != null && campaign.CampaignStatus != "Completed")
            {
                campaign.CampaignStatus = "Completed";
                _dbContext.SaveChanges();
            }
        }

        // Get donations for a specific campaign
        public List<CampaignDonationInfo> GetDonationsByCampaignId(int campaignId)
        {
            return _dbContext.Donations
                .Where(d => d.CampaignID == campaignId)
                .Select(d => new CampaignDonationInfo
                {
                    UserName = d.Users.FirstName + " " + d.Users.LastName,
                    Amount = d.Payments.Sum(p => p.Amount),
                    DonationMessage = d.DonationMessage
                })
                .ToList();
        }
    }

    public class CampaignItem
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public double GoalAmount { get; set; }
        public double CurrentAmount { get; set; }
        public string CampaignStatus { get; set; }
        public double Progress { get; set; }
        public string ButtonContent { get; set; }
    }

    public class CampaignDonationInfo
    {
        public string UserName { get; set; }
        public double Amount { get; set; }
        public string DonationMessage { get; set; }
    }
}
