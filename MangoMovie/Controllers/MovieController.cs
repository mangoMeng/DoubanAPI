using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpHellper;
using CommFunc;
using MangoMovie.Model;

namespace MangoMovie.Controllers
{
    public class MovieController : Controller
    {
        private static string url = "http://120.78.170.214:8086/api/Douban";
        private static int PAGE_SIZE = 15;

        // GET: Movie
        public ActionResult Index()
        {
            string apiUrl = url + string.Format("/Top250?start={0}&count={1}", PAGE_SIZE * 0 + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = GetPageCount(249);
            ViewBag.PageSize = PAGE_SIZE;
            return View(movieList.subjects);
        }

        [HttpPost]
        public ActionResult Index(int pageIndex)
        {
            if (pageIndex < 0)
                pageIndex = 0;

            int pageCount = GetPageCount(249);

            if (pageIndex > 1 && pageIndex >= pageCount)
            {
                pageIndex = pageCount - 1;
            }

            string apiUrl = url + string.Format("/Top250?start={0}&count={1}", PAGE_SIZE * pageIndex + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = GetPageCount(250);
            ViewBag.PageSize = PAGE_SIZE;
            return View(movieList.subjects);
        }

        public ActionResult Detail(int ID)
        {
            string apiUrl = url + string.Format("/GetDetails/{0}", ID);
            string result = HttpHelper.HttpGet(apiUrl);
            Movie movie = result.ToObject<Movie>();
            return View(movie);
        }

        public ActionResult OnShowing(string city = "深圳")
        {
            PAGE_SIZE = 12;
            string apiUrl = url + string.Format("/OnShowing?city={0}&start={1}&count={2}", city, PAGE_SIZE * 0 + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = GetPageCount(249);
            ViewBag.PageSize = PAGE_SIZE;
            ViewBag.ResultTitle = movieList.title;
            return View(movieList.subjects);
        }

        public ActionResult CommingSoon()
        {
            PAGE_SIZE = 12;
            string apiUrl = url + string.Format("/CommingSoon?start={0}&count={1}", PAGE_SIZE * 0 + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = GetPageCount(249);
            ViewBag.PageSize = PAGE_SIZE;
            ViewBag.ResultTitle = movieList.title;
            return View(movieList.subjects);
        }

        /// <summary>
        /// 根据关键字搜索 1：movie；2：tag
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult Search(string keyWord, string type = "movie")
        {
            PAGE_SIZE = 12;
            string apiUrl = url;
            if (type == "movie")
            {
                apiUrl += string.Format("/GetByName/{0}", keyWord);
            }
            else
            {
                apiUrl += string.Format("/GetBytag/{0}", keyWord);
            }
            apiUrl = string.Format(apiUrl + "&start={0}&count={1}", PAGE_SIZE * 0 + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = 0;
            ViewBag.PageCount = GetPageCount(249);
            ViewBag.PageSize = PAGE_SIZE;
            ViewBag.ResultTitle = movieList.title;
            return View(movieList.subjects);
        }


        #region 自定义方法
        private int GetPageCount(int recordCount)
        {
            int pageCount = recordCount / PAGE_SIZE;
            if (recordCount / PAGE_SIZE > 0)
            {
                pageCount++;
            }
            return pageCount;
        }

        private MovieList GetMovieList(string apiUrl)
        {
            string result = HttpHelper.HttpGet(apiUrl);
            MovieList movieList = result.ToObject<MovieList>();
            return movieList;
        }

        #endregion


    }
}