using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Net;

namespace DoubanAPI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> disc = new Dictionary<string, string>();
            string name = TextBox1.Text.Trim();
            string url = "https://api.douban.com/v2/movie/search?q=" + name;

            WebRequest request = HttpWebRequest.Create(url);
            request.Method = "GET";

            string result = HttpHelper.HttpGet2(url);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
            Repeater2.DataSource = obj.subjects;
            Repeater2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> disc = new Dictionary<string, string>();
            string name = TextBox1.Text.Trim();
            string url = "https://api.douban.com/v2/movie/top250";

            WebRequest request = HttpWebRequest.Create(url);
            request.Method = "GET";

            string result = HttpHelper.HttpGet2(url);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
            Repeater2.DataSource = obj.subjects;
            Repeater2.DataBind();
        }
    }
}