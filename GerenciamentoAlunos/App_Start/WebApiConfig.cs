using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GerenciamentoAlunos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{ra}",
                defaults: new { ra = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ApiFindId",
                routeTemplate: "api/{controller}/id/{id}",
                defaults: new { id = RouteParameter.Optional, action = "GetAlunoPorId" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiDeleteId",
                routeTemplate: "api/{controller}/apagar/{id}",
                defaults: new { id = RouteParameter.Optional, action = "ApagarAluno" }
            );
        }
    }
}
