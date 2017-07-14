using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Product
{
    public class Products : BaseModel
    {
        public string ProductId { get; set; }

        public int ProductCategory { get; set; }

        public string ProductName { get; set; }

        /// <summary>
        /// 上一個ckedit
        /// </summary>
        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal Tax { get; set; }

        public ICollection<ProductDetail> ProductDetail { get; set; }

    }
}