using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TBConsole
{
    static class AppConfig
    {
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                //System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
                return System.Configuration.ConfigurationManager.ConnectionStrings;
            }
            private set { }
        }
    }
}
