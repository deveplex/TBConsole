using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace TBForm
{
    public partial class WebLoginForm : Form
    {
        public TaobaoAccessToken TaobaoAccessToken { get; set; }
        public WebLoginForm()
        {
            InitializeComponent();
        }

        private void WebLoginForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(string.Format(TaobaosandboxApi.authorizeUrl, "1023759279", DateTime.Now.Ticks));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string res_Url = webBrowser1.Url.ToString();
            if (res_Url.Contains(TaobaosandboxApi.authorize2Url))
            {
                string resy_Url = HttpUtility.UrlDecode(res_Url);
                NameValueCollection nc = ParseTaobaoAuthorizeUrl(resy_Url);
                string json = JsonSerializer.Serialize<IDictionary<string,string>>(nc.ToDictionary());
                TaobaoAccessToken = JsonSerializer.Deserialize<TaobaoAccessToken>(json);

                this.DialogResult = DialogResult.OK;
            }
        }


        public NameValueCollection ParseTaobaoAuthorizeUrl(string url)
        {
            NameValueCollection nvc = new NameValueCollection();

            string[] query = url.Split(new char[] { '?', '#' });
            string queryString = query.LastOrDefault();
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return null;
            }

            string[] NameValue = queryString.Split(new char[] { '&' });
            foreach (var nv in NameValue)
            {
                string[] keyValue = nv.Split(new char[] { '=' });
                string key = keyValue[0];
                string value = null;
                if (keyValue.Length >= 2)
                {
                    value = keyValue[1];
                }
                nvc.Add(key, value);
            }

            return nvc;
        }
    }
}
