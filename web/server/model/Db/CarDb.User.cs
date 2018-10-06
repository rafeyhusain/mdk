using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using EntityFrameworkPaginate;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Collections;
using System.Net.Http;
using System.Security.Policy;

namespace model
{
    public partial class CarDb
    {
        public static Account GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity) System.Web.HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Account account = new Account()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return account;
        }

        public static async IdentityResult Signup(Account account)
        {
            var userStore = new UserStore<ApplicationUser>(new CarDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = account.Email, Email = account.Email };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };

            user.FirstName = account.FirstName;
            user.LastName = account.LastName;
            account.Roles = new string[] { "User" };
            account.Password = "12x";

            IdentityResult result = manager.Create(user, account.Password);
            OopsHandler.Handle(result);

            result = manager.AddToRoles(user.Id, account.Roles);
            OopsHandler.Handle(result);

            string code = await manager.GenerateEmailConfirmationTokenAsync(user.Id);
            result = await manager.ConfirmEmailAsync(user.Id, code);
            OopsHandler.Handle(result);

            Mailer.Send(account.Email, @"assets/mail-templates/signup/update", new
            {
                url = String.Format("{0}/api/user/activate/{1}", System.Web.HttpContext.Current.Request.Url.Scheme, code)
            });

            return result;
        }

        public static bool ActivateUser()
        {
            return true;
        }

        public static IList GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new CarDbContext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var list = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();

            return list;
        }
    }
}
