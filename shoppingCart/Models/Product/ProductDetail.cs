using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Product
{
    public class ProductDetail : BaseModel
    {
        public string ProductDetailId { get; set; }

        public string BarCode { get; set; }

        /// <summary>
        /// 預計拿來放顏色or大中小
        /// </summary>
        public string ProductDescription { get; set; }

        public string Picture { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}