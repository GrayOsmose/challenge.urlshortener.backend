using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urlshortener.web.Data
{
    public static class Storage
    {
        public static Guid GetUserData(ISession session)
        {
            var userData = session.GetString("UserData");

            if (userData == null)
            {
                userData = Guid.NewGuid().ToString();
                session.SetString("UserData", userData);
            }

            return Guid.Parse(userData);
        }
    }
}
