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
        private static string url = "http://localhost:8086";
        private static readonly int PAGE_SIZE = 15;

        // GET: Movie
        public ActionResult Index()
        {
            string apiUrl = url + string.Format("/api/Douban/Top250?start={0}&count={1}", PAGE_SIZE * 0 + 1, PAGE_SIZE);
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

            string apiUrl = url + string.Format("/api/Douban/Top250?start={0}&count={1}", PAGE_SIZE * pageIndex + 1, PAGE_SIZE);
            MovieList movieList = GetMovieList(apiUrl);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = GetPageCount(250);
            ViewBag.PageSize = PAGE_SIZE;
            return View(movieList.subjects);
        }


        public ActionResult Detail()
        {
            return View();
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