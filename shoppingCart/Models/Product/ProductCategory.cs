using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Product
{
    public class ProductCategory : BaseModel
    {
        public string ProductCategoryId { get; set; }

        public int ProductCategoryLevel { get; set; }

        public ICollection<ProductCategory> ChildCategory { get; set; }
    }
}