using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ExpenseTracker.API
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            //enable cross origin request to web api
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "DefaultRouting",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            //support only json.chrome default accepts xml we are overriding to 
            //send response in json
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            //remove xml formatter then only json will be returned

            // config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //support patch request (nuget of marvin )
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
               new MediaTypeHeaderValue("application/json-patch+json"));

            //return json result as formatted
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting
            //    = Newtonsoft.Json.Formatting.Indented;
            //return in camel case
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
            //    = new CamelCasePropertyNamesContractResolver();

            //caching handling using etag,send a get request the retunred etag use in the subsequent request header
            //if resource has not been changed then 304 will be returned
            config.MessageHandlers.Add(new CacheCow.Server.CachingHandler(config));
            return config;
             
        }
    }
}
