using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using urlshortener.domain.model;

namespace urlshortener.web.Data
{
    public interface IKeyManager
    {
        string GenerateKey(Guid userGuid, string url);
        
        // ToDo: [feature] get user guid and url from generated key
        // UrlModel GetUrl(string Key);
    }
}
