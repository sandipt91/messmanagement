using messManagementSystem.messContext;
using messManagementSystem.messContext.Interface;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace messManagementSystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();


                        
            //RouteTable.Routes.MapHttpRoute(
            //    name: "mm",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //RouteTable.Routes.MapHttpRoute(
            //    name: "mmUpdate",
            //    routeTemplate: "mm/api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
          //  GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
           // LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            //AreaRegistration.RegisterAllAreas();

          
          StructureMapConfiguration();
          //  AutoMapConfiguration();
        }

        private void StructureMapConfiguration()
        {
            ObjectFactory.Initialize(o => //Initialize the static ObjectFactory container
            {
                o.For<mInterface>().Use<MessCustContext>();
            });
        }       

        }
    }
