using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TorrentReader.Config;

namespace TorrentReader.Http
{
    public class HttpProvider
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<IReadOnlyList<TEntity>> GetAsync<TEntity>(string relativeUrl) where TEntity : class
        {
            var response = await HttpClient.GetAsync($"{Configuration.BaseUrl}{relativeUrl}").ConfigureAwait(false);
            var jsonBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IReadOnlyList<TEntity>>(jsonBody);
        }
    }
}
