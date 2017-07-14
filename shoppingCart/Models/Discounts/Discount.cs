using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Discounts
{
    public enum DiscountType
    {
        ForAllProduct = 0, SpecificProduct = 1
    }
    public class Discount : BaseModel
    {
        public string DiscountId { get; set; }

        public string DiscountName { get; set; }

        public int DiscountTypeId { get; set; }

        public bool UsePercentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal? MaximumDiscountAmount { get; set; }

        public bool RequiresCouponCode { get; set; }

        public string ProductCategory { get; set; }

        public DateTime? DiscountStratDate { get; set; }

        public DateTime? DiscountEndDate { get; set; }

        public ICollection<CouponCode> CouponCode { get; set; }

        public DiscountType DiscountType
        {
            get
            {
                return (DiscountType)this.DiscountTypeId;
            }
            set
            {
                this.DiscountTypeId = (int)value;
            }
        }
    }
}