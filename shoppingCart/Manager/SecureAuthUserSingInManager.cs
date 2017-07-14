using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using shoppingCart.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace shoppingCart.Manager
{
    public class SecureAuthUserSingInManager : SignInManager<Customer, int>
    {
        public SecureAuthUserSingInManager(SecureAuthUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
        public static SecureAuthUserSingInManager Create(IdentityFactoryOptions<SecureAuthUserSingInManager> options, IOwinContext context)
        {
            return new SecureAuthUserSingInManager(context.GetUserManager<SecureAuthUserManager>(), context.Authentication);
        }

        
        public override async Task<SignInStatus> PasswordSignInAsync(string empno, string password, bool isPersistent = false, bool shouldLockout = true)
        {
            var user = await UserManager.FindAsync(empno, password);
            if (user != null)
            {
                return SignInStatus.Success;
            }
            else
            {
                return SignInStatus.Failure;
            }
        }


        public HttpCookie GetExpiredCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName, "deleted")
            {
                Expires = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Path = "/"
            };
            return cookie;
        }
    }
}