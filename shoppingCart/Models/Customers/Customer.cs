using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shoppingCart.Models.Customers
{
    public class Customer : BaseModel, IUser<int>
    {

        [Required]
        [StringLength(36)]
        public string CustomerId { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string CellPhone { get; set; }

        [Required]
        public string Email { get; set; }


        public string Phone { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public bool IsActive { get; set; }

        public DateTime CustomerBirthday { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public ICollection<CustomerLevel> CustomerLevel { get; set; }

        
    }
}