using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Tresana.Resolver;
using Tresana.Web.Services;

namespace Tresana.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();


            //Para que esto funcione, tienen que copiar y pegar los dll de Tresana.Data.Access.dll, 
            //Tresana.Data.Repository.dll y Tresana.Web.Services.dll en la carpeta bin de Tresana.Web.Api.
            //Como cortamos las referencias, sino no puede cargar el assembly. 
            //La otra opción es modificar el path para que reconozca la carpeta correspondientes.
            ComponentLoader.LoadContainer(container, ".\\bin", "Tresana.*.dll");

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}