using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace urlshortener.domain.model
{
    public interface IUrlManager
    {
        Task<UrlModel> GetUrlModel(string key);

        Task<List<UrlModel>> GetUrlModels(Guid userGuid);

        Task AddUrl(UrlModel urlModel);

        Task AddCounter(string key);
    }
}
