using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyWebAPI.Model;
using HttpHellper;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoubanController : ControllerBase
    {
        #region 全局变量
        //Douban_Movie通用部分
        private readonly string CommonHead_Url = "https://api.douban.com/v2/movie";
        //Top250 example: /top250
        private readonly string Classic_Url = "/top250";
        //明细 example: /subject/1296141
        private readonly string Details_Url = "/subject/{0}";
        //搜索1 example: /search?q=神秘巨星 
        private readonly string SearchName_Url = "/search?q={0}";
        //搜索2 example: /search?tag=喜剧
        private readonly string SearchTag_Url = "/search?tag={0}";
        //即将上映 example: /coming_soon
        private readonly string ComingSoon_Url = "/coming_soon";
        //正在热映 example: /in_theaters?city=深圳
        private readonly string OnShowing_Url = "/in_theaters?city={0}";
        //查询限制 start:从第N条开始，count:取N条
        private readonly string Limit_Url = "start={0}&count={1}";
        #endregion

        #region 方法请求

        /// <summary>
        /// Top250
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet(Name = "MovieList")]
        public string Top250(int start = 0, int count = 20)
        {
            string url = string.Format(CommonHead_Url + Classic_Url + "?" + Limit_Url, start, count);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 获取明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetByID")]
        public string GetDetails(int id)
        {
            string url = string.Format(CommonHead_Url + Details_Url, id);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 根据名字搜索
        /// </summary>
        /// <param name="name"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetByName")]
        public string GetByName(string name, int start = 0, int count = 10)
        {
            string url = string.Format(CommonHead_Url + SearchName_Url, name) + "&" + string.Format(Limit_Url, start, count);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 根据tag搜索
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{tag}", Name = "GetByTag")]
        public string GetBytag(string tag, int start = 0, int count = 10)
        {
            string url = string.Format(CommonHead_Url + SearchTag_Url, tag) + "&" + string.Format(Limit_Url, start, count);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 即将上映
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string CommingSoon(int start = 0, int count = 10)
        {
            string url = string.Format(CommonHead_Url + ComingSoon_Url + "?" + Limit_Url, start, count);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 正在热映
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string OnShowing(string city = "深圳", int start = 0, int count = 10)
        {
            string url = string.Format(CommonHead_Url + OnShowing_Url, city) + "&" + string.Format(Limit_Url, start, count);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        #endregion

    }
}
