using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TBForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
            {
                labelErrorText.Text = "用户名不能为空";
                DialogResult = DialogResult.None;
            }
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                labelErrorText.Text = "密码不能为空";
                DialogResult = DialogResult.None;
            }

            //WebUtils webUtils = new WebUtils();
            //IDictionary<string, string> pout = new Dictionary<string, string>();
            //pout.Add("grant_type", "authorization_code");
            //pout.Add("client_id", "test");
            //pout.Add("client_secret", "test");
            //pout.Add("code", "test");
            //pout.Add("redirect_uri", "http://www.test.com");
            //string output = webUtils.DoPost("https://oauth.taobao.com/token", pout);
            //Console.Write(output);
            //Console.ReadLine();
        }
    }
}
