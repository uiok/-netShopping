using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Discounts
{
    public class DiscountUsedHistory : BaseModel
    {
        public int DiscountId { get; set; }

        public int OrderId { get; set; }

        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }

    }
}