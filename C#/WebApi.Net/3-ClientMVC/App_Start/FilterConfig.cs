using _3_ClientMVC.Filtres;
using System.Web;
using System.Web.Mvc;

namespace _3_ClientMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LoginFilter());
        }
    }
}
