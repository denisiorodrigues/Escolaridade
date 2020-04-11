using DR.Escolaridade.Infra.CrossCutting.Filters;
using System.Web.Mvc;

namespace DR.Escolaridade.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
