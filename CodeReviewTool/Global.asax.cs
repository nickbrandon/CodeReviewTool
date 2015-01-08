using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace CodeReviewTool
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        //Where is the right place to do this RavenDBDocumentStore initialiation?

        //public static IDocumentStore RavenDbDocumentStore { get; private set; }

        //private static void CreateRavenDBDocumentStore()
        //{
        //    RavenDbDocumentStore = new DocumentStore
        //    {
        //        ConnectionStringName = "ravenDB"
        //    }.Initialize();
        //}
    }
}
