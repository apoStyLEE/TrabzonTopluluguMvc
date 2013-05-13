using System.Web;
using System.Web.Mvc;

namespace TrabzonToplulugu.ActionFilters
{
    public class ApiAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            if (httpContext.Request.QueryString["secret_key"] != "123")
            {
                throw new HttpException(401,"yetkiniz yok");
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}