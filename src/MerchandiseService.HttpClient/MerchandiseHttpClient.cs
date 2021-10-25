using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.RestModels;

namespace MerchandiseService.HttpClients
{
    public sealed class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private const string ApiInfoString = "/api/merchandise/info";
        private const string ApiDemandString = "/api/merchandise/demand";

        private readonly HttpClient _HttpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            this._HttpClient = httpClient;
        }

        public Task<MerchandiseInfoResponse> GetInfo(MerchandiseInfoRequest request, CancellationToken token)
            => this.PostAsync<MerchandiseInfoRequest, MerchandiseInfoResponse>(request, ApiInfoString, token);

        public Task<MerchandiseDemandResponse> SendDemand(MerchandiseDemandRequest request, CancellationToken token)
            => this.PostAsync<MerchandiseDemandRequest, MerchandiseDemandResponse>(request, ApiDemandString, token);

        private async Task<T> PostAsync<R, T>(R request, string uri, CancellationToken token)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using var response = await this._HttpClient.PostAsync(uri, httpContent, token).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync(token).ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(body);
        }
    }
}
