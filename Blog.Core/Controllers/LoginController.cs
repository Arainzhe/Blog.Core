using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.AuthHelper.OverWrite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// 获取JWT的重写方法，推荐这种，注意在文件夹OverWrite下
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token2")]
        public JsonResult GetJWTStr(long id = 1, string sub = "Admin")
        {
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            TokenModelJWT tokenModel = new TokenModelJWT();
            tokenModel.Uid = id;
            tokenModel.Role = sub;

            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return Json(jwtStr);
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //// GET: api/Login/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
