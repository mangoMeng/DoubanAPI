using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonMethod;
using Newtonsoft.Json;
using MyWebAPI.Model;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoubanController : ControllerBase
    {
        // GET: api/Douban
        [HttpGet(Name = "MovieList")]
        public string Get()
        {
            //http://api.douban.com/v2/movie/top250?start=35&count=25
            string result = HttpHelper.HttpGet("http://api.douban.com/v2/movie/top250");
            MovieList movieList = result.ToObject<MovieList>();
            return result;
        }

        // GET: api/Douban/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            string url = "https://api.douban.com/v2/movie/subject/" + id;
            string result = HttpHelper.HttpGet(url);
            return result;
        }

        // POST: api/Douban
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Douban/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
