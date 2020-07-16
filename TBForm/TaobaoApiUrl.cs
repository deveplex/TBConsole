using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TBForm
{

    public sealed class TaobaoAccessToken
    {
       public string access_token { get; set; }        public string token_type { get; set; }        public Int64? expires_in { get; set; }        public string refresh_token { get; set; }        public Int64? re_expires_in { get; set; }        public Int64? r1_expires_in { get; set; }        public Int64? r2_expires_in { get; set; }        public string taobao_user_id { get; set; }        public string taobao_user_nick { get; set; }
        public Int64? w1_expires_in { get; set; }
        public Int64? w2_expires_in { get; set; }
        public string state { get; set; }
        public string top_sign { get; set; }
    }

    public sealed class TaobaosandboxApi
    {
        public static string authorizeUrl = @"https://oauth.tbsandbox.com/authorize?response_type=token&client_id={0}&state={1}&view=web";
        public static string authorize2Url = @"https://oauth.tbsandbox.com/oauth2";
    }

   public sealed class TaobaoApi
    {
        public static string authorizeUrl = @"https://oauth.taobao.com/authorize?response_type=token&client_id={0}&state={1}&view=web";
        public static string authorize2Url = @"https://oauth.taobao.com/oauth2";
    }
}
