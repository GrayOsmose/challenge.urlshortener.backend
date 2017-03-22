using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urlshortener.web.Middleware
{
    internal static class CookieIdentityMiddlewareExtensions
    {
        public static IApplicationBuilder CookieIdentityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CookieIdentityMiddleware>();
        }
    }
}
