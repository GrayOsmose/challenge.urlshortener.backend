using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace urlshortener.domain.model
{
    public interface IUrlManager
    {
        Task<UrlModel> GetUrlModel(string key);

        // ToDo: [feature] create user manager in the fufture
        Task<List<UrlModel>> GetUrlModels(Guid userGuid);

        Task AddUrl(UrlModel urlModel);

        Task DeleteUrl(Guid userGuid, string key);

        Task AddCounter(string key);
    }
}
