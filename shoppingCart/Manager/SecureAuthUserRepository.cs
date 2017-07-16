using shoppingCart.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using shoppingCart.Interface;
using shoppingCart.Models;

namespace shoppingCart.Manager
{
    public class SecureAuthUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public SecureAuthUserRepository()
        {
            _db = new ApplicationDbContext();
        }

        private ApplicationDbContext DB
        {
            get
            {
                return _db;
            }
        }

        public Task<IList<Claim>> GetClaimsAsync(Customer user)
        {
            var result = ReadAndConvertClaimsList(user);
            return Task.FromResult(result);
        }

        public static IList<Claim> ReadAndConvertClaimsList(Customer user)
        {
            //回資料庫
            return new List<Claim>();
        }

        public void Dispose()
        {

        }
        #region IUserStore

        public Task CreateAsync(Customer user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer user)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserClaimStore

        public Task AddClaimAsync(Customer user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(Customer user, Claim claim)
        {
            throw new NotImplementedException();
        }


        #endregion
                   
    }
}