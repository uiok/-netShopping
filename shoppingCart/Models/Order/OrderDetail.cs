using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Order
{
    public class OrderDetail : BaseModel
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public string OrderDetailId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal PriceExcludeTax { get; set; }

        public decimal PriceIncludeTax { get; set; }

        public decimal Tax { get; set; }

        public int Quantity { get; set; }

    }
}