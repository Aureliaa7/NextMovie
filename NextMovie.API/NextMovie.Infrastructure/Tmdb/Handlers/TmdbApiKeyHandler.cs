using NextMovie.Models.Options;
using System.Collections.Specialized;
using System.Web;

namespace NextMovie.Infrastructure.Tmdb.Handlers
{
    /// <summary>
    /// Handler used to add the api_key query param to every Http call made to The Movie DB API
    /// </summary>
    public class TmdbApiKeyHandler : DelegatingHandler
    {
        private readonly TmdbSettings settings;

        public TmdbApiKeyHandler(TmdbSettings settings)
        {
            this.settings = settings;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = settings.ApiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;

            return base.SendAsync(request, cancellationToken);
        }
    }
}
