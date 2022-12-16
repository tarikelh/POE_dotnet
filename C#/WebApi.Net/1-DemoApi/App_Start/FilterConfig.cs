using _1_DemoApi.Filtres;
using System.Web;
using System.Web.Mvc;

namespace _1_DemoApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new MyGlobalExceptionFilter());
        }
    }
}
