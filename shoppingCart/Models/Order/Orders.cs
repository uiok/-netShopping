using shoppingCart.Models.Customers;
using shoppingCart.Models.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Order
{
    public enum OrderStatusType
    {
        [Description("確認中")]
        Process = 0,
        [Description("訂單成立")]
        Deal = 1,
        [Description("訂單取消")]
        Reject = 2
    }
    public enum PaymentStatusType
    {
        [Description("未付款")]
        Process = 0,
        [Description("已付款")]
        Deal = 1,
        [Description("交易失敗")]
        Reject = 2,
        [Description("退款")]
        ReturnFund = 3,

    }
    public enum ShippingStatusType
    {
        [Description("處理中")]
        NotYetShipped = 0,
        [Description("出貨中")]
        Shipped = 1,
        [Description("已出貨")]
        Delivered = 2
    }
    public enum PaymentType
    {
        [Description("ATM")]
        ATM = 0,
        [Description("CreditCart")]
        CreditCart = 1,
        [Description("超商")]
        CVS = 2
    }

    public class Orders : BaseModel
    {
        public string OrderId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public string DiscountId { get; set; }

        public int OrderStatus { get; set; }

        public int PaymentStatus { get; set; }

        public int PaymentTool { get; set; }

        public int ShippingStatus { get; set; }

        public string PaymentName { get; set; }

        public string CouponCode { get; set; }

        public string ShippingAddress { get; set; }

        public string BillAddress { get; set; }

        public string SpecialNeed { get; set; }

        public string Gift { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Discount Discount { get; set; }

        public ICollection<PaymentHistory> PaymentHistory { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }

        public OrderStatusType OrderStatusType
        {
            get
            {
                return (OrderStatusType)this.OrderStatus;
            }
            set
            {
                this.OrderStatus = (int)value;
            }
        }

        public PaymentStatusType PaymentStatusType
        {
            get
            {
                return (PaymentStatusType)this.PaymentStatus;
            }
            set
            {
                this.PaymentStatus = (int)value;
            }
        }

        public ShippingStatusType ShippingStatusType
        {
            get
            {
                return (ShippingStatusType)this.ShippingStatus;
            }
            set
            {
                this.ShippingStatus = (int)value;
            }
        }

        public PaymentType PaymentType
        {
            get
            {
                return (PaymentType)this.PaymentTool;
            }
            set
            {
                this.PaymentTool = (int)value;
            }
        }

    }
}