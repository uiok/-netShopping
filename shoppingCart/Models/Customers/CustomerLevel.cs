using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Customers
{
    public class CustomerLevel : BaseModel
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public string Level { get; set; }

        public DateTime CreatedTinme { get; set; }

        public DateTime ModifiedTime { get; set; }


        public Customer Customer { get; set; }
    }
}