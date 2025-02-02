using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace BackerBridge_3.ViewModels
{
    public class UsersViewModel
    {
        public ObservableCollection<Users> Users { get; set; }

        public UsersViewModel() {
            Users = new ObservableCollection<Users>();
        }

        public bool FindUser(string email)
        {
            using (var ctx = new BackerBridgeEntities())
            {
                var user = ctx.Users.SingleOrDefault(u => u.Email == email);
                if(user != null)
                {
                    Users.Add(user);
                    return true;
                }
                return false;
            }
        }

        public bool VerifyPassword(string password)
        {
            byte[] bytes = HashPassword(password);
            return bytes.SequenceEqual(Users.First().UserPassword);
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return bytes;
            }
        }

        public bool AuthenticateUser(string email, string password)
        {
            using (var ctx = new BackerBridgeEntities())
            {
                // Find the user by email
                var user = ctx.Users.SingleOrDefault(u => u.Email == email);

                if (user == null)
                    return false; // User not found

                // Hash the input password
                byte[] hashedPassword = HashPassword(password);

                // Verify the password
                return user.UserPassword.SequenceEqual(hashedPassword);
            }
        }

        public bool SignUpUser(string firstName, string lastName, string email, string password, DateTime birthDate)
        {
            using (var ctx = new BackerBridgeEntities())
            {
                if (ctx.Users.Any(u => u.Email == email))
                {
                    Console.WriteLine("User already exists!!!");
                    return false; 
                }

                byte[] hashedPassword = HashPassword(password);

                var newUser = new Users
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserPassword = hashedPassword,
                    BirthDate = birthDate,
                    UserType = "donor" 
                };

                ctx.Users.Add(newUser);
                ctx.SaveChanges();

                Users.Add(newUser);

                return true;
            }
        }
    }
}
