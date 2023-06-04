using DotNetDevBadgeWeb.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetDevBadgeWeb.Core
{
    internal class BadgeCreator : IBadge
    {
        private const string BADGE_URL = "https://forum.dotnetdev.kr/user-badges/{0}.json?grouped=true";
        private const string SUMMARY_URL = "https://forum.dotnetdev.kr/u/{0}/summary.json";

        private IHttpClientFactory _httpClientFactory;

        public BadgeCreator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private async Task<string> GetDataAsync(Uri uri, CancellationToken token)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            using HttpResponseMessage response = await client.GetAsync(uri, token);

            return await response.Content.ReadAsStringAsync(token);
        } 

        public async Task<string> GetMicroBadge(string id, ETheme theme, CancellationToken token)
        {
            Uri uri = new(string.Format(SUMMARY_URL, id));
            string data = await GetDataAsync(uri, token);
            JObject json = JObject.Parse(data); 

            string received = json["user_summary"]?["likes_received"]?.ToString() ?? "0";
            string trustLv = json["users"]?.Where(t => t["id"]?.ToString() != "-1").FirstOrDefault()?["trust_level"]?.ToString() ?? string.Empty;

            ColorSet colorSet = Palette.GetColorSet(theme);
            string trustColor =  Palette.GetTrustColor(trustLv);

            string svg = $@"
<svg width=""110"" height=""20"" viewBox=""0 0 110 20"" fill=""none"" xmlns=""http://www.w3.org/2000/svg""
    xmlns:xlink=""http://www.w3.org/1999/xlink"">
    <style>  
        .text {{
            font: 800 12px 'Segoe UI';
            fill: #{colorSet.FontColor};
        }}  
    </style>
    <path
        d=""M10 0.5H100C105.247 0.5 109.5 4.75329 109.5 10C109.5 15.2467 105.247 19.5 100 19.5H10C4.75329 19.5 0.5 15.2467 0.5 10C0.5 4.75329 4.7533 0.5 10 0.5Z""
        fill=""#{colorSet.BackgroundColor}"" stroke=""#4D1877"" />
    <path d=""M10 0.5H27.5V19.5H10C4.7533 19.5 0.5 15.2467 0.5 10C0.5 4.75329 4.7533 0.5 10 0.5Z"" fill=""#6E20A0""
        stroke=""#{trustColor}"" />
    <g>
        <path
            d=""M15 10C17.2094 10 19 8.4332 19 6.5C19 4.5668 17.2094 3 15 3C12.7906 3 11 4.5668 11 6.5C11 8.4332 12.7906 10 15 10ZM17.8 10.875H17.2781C16.5844 11.1539 15.8125 11.3125 15 11.3125C14.1875 11.3125 13.4188 11.1539 12.7219 10.875H12.2C9.88125 10.875 8 12.5211 8 14.55V15.6875C8 16.4121 8.67188 17 9.5 17H20.5C21.3281 17 22 16.4121 22 15.6875V14.55C22 12.5211 20.1188 10.875 17.8 10.875Z""
            fill=""#{trustColor}"" />
    </g>
    <g>
        <path
            d=""M37.0711 4.79317C37.5874 4.7052 38.1168 4.73422 38.6204 4.87808C39.124 5.02195 39.5888 5.27699 39.9807 5.62442L40.0023 5.64367L40.0222 5.62617C40.3962 5.29792 40.8359 5.05321 41.312 4.90836C41.7881 4.76352 42.2896 4.72186 42.7831 4.78617L42.9266 4.80717C43.5486 4.91456 44.13 5.18817 44.6092 5.59902C45.0884 6.00987 45.4476 6.54267 45.6487 7.14099C45.8498 7.73931 45.8853 8.38088 45.7516 8.99776C45.6178 9.61464 45.3198 10.1839 44.8889 10.6452L44.7839 10.7531L44.7559 10.777L40.4101 15.0814C40.3098 15.1807 40.1769 15.2402 40.0361 15.249C39.8953 15.2578 39.756 15.2153 39.6442 15.1292L39.5893 15.0814L35.2184 10.7519C34.7554 10.3014 34.4261 9.73148 34.267 9.10532C34.1079 8.47917 34.1252 7.82119 34.317 7.20427C34.5088 6.58734 34.8676 6.03555 35.3537 5.60999C35.8398 5.18443 36.4342 4.90172 37.0711 4.79317Z""
            fill=""#FA6C8D"" />
    </g> 
    <text class=""text"" x=""49"" y=""14.5"" >{received}</text>  
    <rect x=""88"" y=""1"" width=""18"" height=""18"" fill=""url(#pattern0)"" />
    <defs>
        <pattern id=""pattern0"" patternContentUnits=""objectBoundingBox"" width=""1"" height=""1"">
            <use xlink:href=""#image0_16_373"" transform=""translate(-0.0541796) scale(0.00154799)"" />
        </pattern>
        <image id=""image0_16_373"" width=""716"" height=""646""
            xlink:href=""data:image/png;base64,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"" />
    </defs>
</svg>";

            return svg;
        }

        public async Task<string> GetLargeBadge(string id, ETheme theme, CancellationToken token)
        {
            Uri badgeUri = new(string.Format(BADGE_URL, id));
            string badgeData = await GetDataAsync(badgeUri, token);
            JObject badgeJson = JObject.Parse(badgeData);

            var badges = badgeJson["badges"]?.GroupBy(badge => badge["badge_type_id"]?.ToString() ?? string.Empty).Select(g => new
            {
                Type = g.Key,
                Count = g.Count(),
            });

            Uri summaryUri = new(string.Format(SUMMARY_URL, id));
            string summaryData = await GetDataAsync(summaryUri, token);
            JObject summaryJson = JObject.Parse(summaryData);

            // todo..

            string svg = $@"
";

            return svg;
        } 
    }
}
