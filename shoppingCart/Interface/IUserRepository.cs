using Microsoft.AspNet.Identity;
using shoppingCart.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Interface
{
    public interface IUserRepository : IUserClaimStore<Customer, int>
    {
    }
}