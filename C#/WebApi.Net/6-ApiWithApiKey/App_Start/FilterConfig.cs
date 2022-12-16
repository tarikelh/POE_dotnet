using System.Web;
using System.Web.Mvc;

namespace _6_ApiWithApiKey
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
