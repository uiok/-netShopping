using Microsoft.AspNet.Identity;
using shoppingCart.Models;
using shoppingCart.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace shoppingCart.Manager
{
    public class SecureAuthUserManager : UserManager<Customer, int>
    {
        public SecureAuthUserManager(SecureAuthUserRepository store)
            : base(store)
        {
        }

        public static SecureAuthUserManager Create()
        {
            var manager = new SecureAuthUserManager(new SecureAuthUserRepository());

            manager.PasswordHasher = new PasswordHasherManager();

            manager.UserValidator = new UserValidator<Customer,int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return manager;
        }

        public override Task<Customer> FindAsync(string account, string password)
        {
            Task<Customer> task = Task.Run(() =>
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.Customers.Where(a => a.Account == account).FirstOrDefault();
                }
            });
            return task;
        }


        public override Task<ClaimsIdentity> CreateIdentityAsync(Customer user, string authenticationType)
        {
            Task<ClaimsIdentity> baseTask = base.CreateIdentityAsync(user, authenticationType);

            Task<ClaimsIdentity> task = Task.Run(() =>
            {
                ClaimsIdentity identity = baseTask.Result;

                List<Claim> claims = new List<Claim>{
                        new Claim("Email", user.Email),
                };

                identity.AddClaims(claims);
                return identity;
            });
            return task;
        }

       
        public override async Task<IdentityResult> CreateAsync(Customer user, string password)
        {
            //if (Users.Any(u => u.Email.Equals(user.Email, StringComparison.InvariantCultureIgnoreCase)))
            if (false)
            {
                var result = new IdentityResult(new[] { "Email exists" });
                return result;
            }
            Task<IdentityResult> task = Task.Run(() =>
            {
                return new IdentityResult();
            });
            return await task;
        }

        private string EncodePassword()
        {
            return null;
        }

        private string DecodePassword()
        {
            return null;
        }


    }
}