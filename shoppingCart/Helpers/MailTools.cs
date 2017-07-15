using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingCart.Helpers
{
    public class MailTools
    {
        public enum EmailType { Account,ChangePassword}

        public string BodyGenerate(EmailType emailType, string callbackUrl)
        {
            string mailBody = string.Empty;
            if (emailType.ToString() == EmailType.Account.ToString())
            {
                mailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Content/AccountTemplate.html"));
            }
            else if (emailType.ToString() == EmailType.ChangePassword.ToString())
            {
                mailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Content/ChangePasswordTemplate.html"));
            }
            mailBody = mailBody.Replace("{{callbackUrl}}", callbackUrl);
            return mailBody;
        }
    }
}