using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Customers
{
    public class Address : BaseModel
    {
        public string AddressId { get; set; }
        
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public string ShippingAddress { get; set; }

        public string BillAddress { get; set; }

        public virtual Customer Customer { get; set; }
    }
}