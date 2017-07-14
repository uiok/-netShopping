using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Order
{
    public class PaymentHistory : BaseModel
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public string PaymentHistoryId { get; set; }

        public string PaymentData { get; set; }

    }
}