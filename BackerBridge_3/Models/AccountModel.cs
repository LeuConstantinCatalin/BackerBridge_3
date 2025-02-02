using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackerBridge_3.Models.UsersModel;

namespace BackerBridge_3.Models
{
    public class AccountModel
    {
        private readonly BackerBridgeEntities _dbContext;

        public AccountModel()
        {
            _dbContext = new BackerBridgeEntities();
        }

        // Retrieve the current user's data
        public User GetUserData(int userId)
        {
            var userEntity = _dbContext.Users.SingleOrDefault(u => u.UserID == userId);

            if (userEntity == null)
                return null;

            // Map the entity to the model class
            return new User
            {
                UserID = userEntity.UserID,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                BirthDate = userEntity.BirthDate,
                UserType = userEntity.UserType
            };
        }

        // Update the user's details
        public bool UpdateUserDetails(User user)
        {
            var userToUpdate = _dbContext.Users.SingleOrDefault(u => u.UserID == user.UserID);
            if (userToUpdate == null) return false;

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.BirthDate = user.BirthDate;

            _dbContext.SaveChanges();
            return true;
        }

        // Check if a fundraiser request already exists for the user
        public Requests GetExistingRequest(int userId)
        {
            return _dbContext.Requests.SingleOrDefault(r => r.UserID == userId);
        }

        // Send a new fundraiser request
        public void SendFundraiserRequest(int userId, string message)
        {
            var newRequest = new Requests
            {
                UserID = userId,
                RequestDate = DateTime.Now,
                Status = "Pending",
                Message = message
            };

            _dbContext.Requests.Add(newRequest);
            _dbContext.SaveChanges();
        }
    }
}
