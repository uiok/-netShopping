using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Discounts
{
    public class CouponCode : BaseModel
    {
        public string CouponCodeId { get; set; }

        public int DiscountType { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CouponCodeStartDate { get; set; }

        public DateTime? CouponCodeEndDate { get; set; }

        public virtual Discount Discount { get; set; }
    }
}