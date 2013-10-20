using System.Web.Mvc;
using LocalizationMvc.Filters;

namespace LocalizationMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SomeAction());
            filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }


    public class SomeAction : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // throw new System.NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int a = 5;
            int b = a;
        }
    }
}