using shoppingCart.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.GenericRepository
{
    public class CustomerRepository: GenericRepository<Customer>
    {
        public Customer GetById(string id)
        {
            return this.Get(x => x.CustomerId == id);
        }
    }
}