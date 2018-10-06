using Microsoft.AspNet.Identity;
using System;
using System.Text;
using System.Web.Http.ExceptionHandling;

namespace model
{
    public class OopsHandler : ExceptionHandler
    {
        public static void Handle(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var error = new StringBuilder();

                foreach (var err in result.Errors)
                {
                    error.Append(err);
                }

                throw new AppException(error.ToString());
            }
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new OopsResult(context.Request);
        }
    }
}