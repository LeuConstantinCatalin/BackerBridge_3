using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackerBridge_3.Models
{
    public class SettingsAdminModel
    {
        private readonly BackerBridgeEntities _dbContext;

        public SettingsAdminModel()
        {
            _dbContext = new BackerBridgeEntities();
        }

        // Fetch all pending requests
        public List<RequestItem> GetPendingRequests()
        {
            return _dbContext.Requests
                .Where(r => r.Status == "Pending")
                .Select(r => new RequestItem
                {
                    RequestID = r.RequestID,
                    UserID = r.UserID,
                    Message = r.Message,
                    RequestDate = r.RequestDate
                })
                .ToList();
        }

        // Accept a request by updating its status and changing the user's type
        public bool AcceptRequest(int requestId, int userId)
        {
            var request = _dbContext.Requests.SingleOrDefault(r => r.RequestID == requestId);
            var user = _dbContext.Users.SingleOrDefault(u => u.UserID == userId);

            if (request == null || user == null)
                return false;

            request.Status = "Approved";
            user.UserType = "Fundraiser";

            _dbContext.SaveChanges();
            return true;
        }

        // Decline a request by updating its status
        public bool DeclineRequest(int requestId)
        {
            var request = _dbContext.Requests.SingleOrDefault(r => r.RequestID == requestId);

            if (request == null)
                return false;

            request.Status = "Rejected";
            _dbContext.SaveChanges();
            return true;
        }
    }

    public class RequestItem
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
