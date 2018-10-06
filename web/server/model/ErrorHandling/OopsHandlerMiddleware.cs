using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace model
{
    public class OopsHandlerMiddleware : OwinMiddleware
    {
        public OopsHandlerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (AppException ex)
            {
                await this.Handle(context, 400, ex);
            }
            catch (Exception ex)
            {
                await this.Handle(context, 500, ex);
            }
        }

        private async Task Handle(IOwinContext context, int errorCode, Exception ex)
        {
            context.Response.StatusCode = errorCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
        }
    }
}