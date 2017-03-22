using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urlshortener.web.Middleware
{
    internal sealed class CookieIdentityMiddleware
    {
        private const string IdentityKey = "Urlshortener.Cookie.Key";

        private readonly RequestDelegate _next;

        public CookieIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Guid userGuid;
            var cookie = context.Request.Cookies[IdentityKey];

            userGuid = cookie != null ? Guid.Parse(cookie)
                                      : CreateIdentityCookie(context);

            context.Items.Add("User", userGuid);

            await _next.Invoke(context);
        }

        private static Guid CreateIdentityCookie(HttpContext context)
        {
            var userGuid = Guid.NewGuid();
            // delicious cookie options
            var options = new CookieOptions
                              {
                                  // you are internal my love
                                  Expires = DateTimeOffset.MaxValue,
                                  // no one steals my precious cookie
                                  HttpOnly = true,
                                  // for now
                                  // ToDo: [refactoring] change it in the future to secure only
                                  Secure = false
                              };

            context.Response.Cookies.Append(IdentityKey, userGuid.ToString(), options);

            return userGuid;
        }
    }
}
