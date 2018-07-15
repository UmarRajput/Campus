using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NHibernate;
using NHibernate.Context;

namespace CampusAcademiaApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /*This is very expensive, so make sure it is generated only once*/
        /*SF should be static in web context*/
        public static ISessionFactory SF = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SF = NHibernateSFGenerator.ReturnSessionFactory();
        }
        public override void Init()
        {
            base.Init();
            this.EndRequest += MvcApplication_EndRequest;
            this.BeginRequest += MvcApplication_BeginRequest;
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var NHSession = SF.OpenSession();
            CurrentSessionContext.Bind(NHSession);
        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var NHSession = CurrentSessionContext.Unbind(SF);
            NHSession.Dispose();
        }
    }
}
