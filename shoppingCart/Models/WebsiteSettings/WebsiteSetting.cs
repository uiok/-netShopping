using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.WebsiteSettings
{
    public enum Config
    {
        Footer = 0, SEO = 1, Carousel = 2
    }

    public class WebsiteSetting
    {
        public string WebsiteSettingId { get; set; }

        public int Key { get; set; }

        public string Value { get; set; }

        public Config Config
        {
            get
            {
                return (Config)this.Key;
            }
            set
            {
                this.Key = (int)value;
            }
        }
    }
}