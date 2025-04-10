using Microsoft.AspNetCore.WebUtilities;
using NextMovie.Application;
using NextMovie.Application.Interfaces;
using System.Text.Json;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient(Constants.TmdbHttpClient);
        }

        public async Task<T?> GetAsync<T>(
            string url,
            IDictionary<string, string>? queryParams = null)
        {
            string modifiedUrl = queryParams == null ? url :
                QueryHelpers.AddQueryString(url, queryParams!);

            HttpRequestMessage requestMessage = new(HttpMethod.Get, modifiedUrl);

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            T? apiResponse = JsonSerializer.Deserialize<T>(content);

            return apiResponse;
        }
    }
}
