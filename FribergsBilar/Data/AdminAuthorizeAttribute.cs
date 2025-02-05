using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FribergsBilar.Data
{
    public class AdminAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check if the user is an admin
            if (filterContext.HttpContext.Session.GetString("isAdmin") != "True")
            {
                // Redirect to login or unauthorized page
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
