using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.AuthHelper.OverWrite
{
    /// <summary>
    /// JwtTokenAuth，一个中间件，用来过滤每一个http请求，就是每当一个用户发送请求的时候，都先走这一步，然后再去访问http请求的接口
    /// </summary>
    public class JwtTokenAuth
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public JwtTokenAuth(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 检测是否包含'Authorization'请求头
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return _next(httpContext);
            }
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString();



            return null;
        }
    }
}
