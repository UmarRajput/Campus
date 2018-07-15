using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg; //For Database Integration
using NHibernate.Context;//For web session

namespace CampusAcademiaApp
{
    public static class NHibernateSFGenerator
    {
        public static ISessionFactory ReturnSessionFactory()
        {
            ISessionFactory SF = null;
            var config = new NHibernate.Cfg.Configuration();
            try
            {
                config.DataBaseIntegration(delegate(NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties cfgbbi)
                {
                    cfgbbi.ConnectionStringName = "ConnectionMysql";
                    cfgbbi.Driver<NHibernate.Driver.MySqlDataDriver>();
                    cfgbbi.Dialect<NHibernate.Dialect.MySQL55Dialect>();
                    cfgbbi.Timeout = 120;
                
                });
                config.CurrentSessionContext<WebSessionContext>();
                
                config.AddAssembly(typeof(TblAdmin).Assembly);
                SF = config.BuildSessionFactory();
            }
            catch(Exception ex)
            { }
            return SF;
        }
    }
}