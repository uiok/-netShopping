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

    }
}