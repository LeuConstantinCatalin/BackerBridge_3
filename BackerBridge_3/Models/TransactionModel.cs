using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class TransactionModel
    {
        private readonly BackerBridgeEntities _dbContext;


        public TransactionModel()
        {
            _dbContext = new BackerBridgeEntities();
        }


        // Fetch pending campaigns
        public List<PendingCampaignItem> GetPendingCampaigns()
        {
            return _dbContext.Campaign
                .Where(c => c.CampaignStatus.ToLower() == "pending")
                .Select(c => new PendingCampaignItem
                {
                    CampaignID = c.CampaignID,
                    CampaignName = c.CampaignName,
                    ProjectDescription = c.ProjectDescription,
                    GoalAmount = c.GoalAmount ?? 0,
                    CurrentAmount = c.CurrentAmount ?? 0
                })
                .ToList();
        }
    }

    public class PendingCampaignItem
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string ProjectDescription { get; set; }
        public double GoalAmount { get; set; }
        public double CurrentAmount { get; set; }
    }
}
