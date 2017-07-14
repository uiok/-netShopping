using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.News
{
    public class NewsComment : BaseModel
    {
        public string NewsCommentId { get; set; }

        public string NewsCommentTitle { get; set; }

        public string NewsCommentContent { get; set; }

        public int HintCount { get; set; }

    }
}