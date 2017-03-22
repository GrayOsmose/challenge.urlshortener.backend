using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urlshortener.web.Data
{
    public class KeyManager : IKeyManager
    {
        public string GenerateKey(Guid userGuid, string url)
        {
            // we don't care about key generation for now
            return Guid.NewGuid().ToString();
        }
    }
}
