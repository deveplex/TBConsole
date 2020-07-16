using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TBForm;
using TBForm.Models;

namespace TBConsole
{
   public class AppConfig
    {
        [IgnoreDataMember]
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                //System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
                return System.Configuration.ConfigurationManager.ConnectionStrings;
            }
            private set { }
        }

        [IgnoreDataMember]
        public static NameValueCollection AppSettings
        {
            get
            {
                //System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
                return System.Configuration.ConfigurationManager.AppSettings;
            }
            private set { }
        }


        [IgnoreDataMember]
        public TaobaoAccessToken TaobaoAccessToken { get; set; }


       public LoginModel Login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public bool IsAutoRun { get; set; }
    }
}
