using Microsoft.Extensions.Primitives;

namespace DotNetDevBadgeWeb.Extensions
{
    internal static class HttpResponseExtentions
    {
        internal static HttpResponse SetCacheControl(this HttpResponse response, double seconds)
        {
            response.Headers.CacheControl = new StringValues($"max-age={seconds}");
            return response;
        }
    }
}
