using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using shoppingCart.Models;
using shoppingCart.Manager;
using shoppingCart.Models.Customers;
using shoppingCart.GenericRepository;
using shoppingCart.Helpers;

namespace shoppingCart.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SecureAuthUserManager _secureAuthUserManager;
        private SecureAuthUserSingInManager _secureAuthUserSingInManager;
        private CustomerRepository _customerRepository;


        private SecureAuthUserManager SecureAuthUserManager
        {
            get
            {
                return _secureAuthUserManager ?? HttpContext.GetOwinContext().GetUserManager<SecureAuthUserManager>();
            }
            set
            {
                _secureAuthUserManager = value;
            }
        }

        private SecureAuthUserSingInManager SecureAuthUserSingInManager
        {
            get
            {
                return _secureAuthUserSingInManager ?? HttpContext.GetOwinContext().Get<SecureAuthUserSingInManager>();
            }
            set
            {
                _secureAuthUserSingInManager = value;
            }
        }

        private CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ?? new CustomerRepository();
            }
            set
            {
                _customerRepository = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Customer { UserName = model.Email, Email = model.Email };
                var result = await SecureAuthUserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    string code = await SecureAuthUserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    code = System.Web.HttpUtility.UrlEncode(code);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                   
                    string mailBody = new MailTools().BodyGenerate(MailTools.EmailType.Account, callbackUrl);
                    await SecureAuthUserManager.SendEmailAsync(user.Id, "確認您的帳戶", mailBody);

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            
            return View(model);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            //登出
            SecureAuthUserSingInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            // Create claims identity(移進去SecureAuthUserManager)
            //ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            // Add claims (使用者資料)
            //IList<Claim> claimList = new List<Claim>();
            //identity.AddClaims(claimList);
            //連資料庫把客戶抓出來
            var customer = CustomerRepository.GetById(model.Email);
            //處理登入cookie
            var identity = await SecureAuthUserManager.CreateIdentityAsync(customer, DefaultAuthenticationTypes.ApplicationCookie);


            SecureAuthUserSingInManager.AuthenticationManager.SignIn(new AuthenticationProperties { AllowRefresh = true, IsPersistent = false }, identity);

            return RedirectToAction("Index");
        }


        public ActionResult Logout()
        {
            try
            {
                SecureAuthUserSingInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                //Response.SetCookie(SecureAuthUserSingInManager.GetExpiredCookie(REQUEST_VERIFICATION_COOKIE_NAME));
                return View();
            }
            catch (Exception ex)
            {
                //_handler.Handle(string.Empty, ex);
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
           code = System.Web.HttpUtility.UrlDecode(code);  
           //外丟要再對應回主鍵
           var result = await SecureAuthUserManager.ConfirmEmailAsync(int.Parse(userId), code);
          //if (result.Succeeded)
          //{
          //    return RedirectToAction("Index", "Home");
          //}
          //else
          //{
          //    //轉向錯誤畫面
          //    return RedirectToAction("Index", "Home");
          //}
           return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_userManager != null)
                //{
                //    _userManager.Dispose();
                //    _userManager = null;
                //}

                //if (_signInManager != null)
                //{
                //    _signInManager.Dispose();
                //    _signInManager = null;
                //}
            }

            base.Dispose(disposing);
        }

        #region Helper
        // 新增外部登入時用來當做 XSRF 保護
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}