using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoubanAPI
{
    public partial class Detailes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["mid"] + ""))
            {
                string url = "https://api.douban.com/v2/movie/subject/" + Request["mid"];
                string result = HttpHelper.HttpGet2(url);
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
                Response.Write(obj);
                lb_title.Text = obj.title;
                Image1.ImageUrl = obj.images.medium;
                lb_desc.Text = obj.summary;
                lb_rating.Text = obj.rating["average"];
                lb_wishCount.Text = obj.wish_count;
                lb_collectCount.Text = obj.collect_count;
                lb_subtype.Text = obj.subtype;
                lb_directors.Text = obj.directors[0]["name"];
                Image2.ImageUrl = obj.directors[0]["avatars"]["small"];
            }
        }

    }
}