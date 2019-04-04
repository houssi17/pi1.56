using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}