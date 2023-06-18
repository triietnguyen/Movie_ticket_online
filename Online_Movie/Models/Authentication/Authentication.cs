using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Online_Movie.Models.Authentication
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.Session.GetString("UserName")==null) 
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"Controller","Account"},
                        {"Action","Login" }
                    });
            }
        }
    }
}
