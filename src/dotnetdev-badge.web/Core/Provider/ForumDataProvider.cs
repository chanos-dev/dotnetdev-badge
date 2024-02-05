using DotNetDevBadgeWeb.Interfaces;
using DotNetDevBadgeWeb.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetDevBadgeWeb.Core.Provider
{
    internal class ForumDataProvider : IProvider
    {
        private const string UNKOWN_IMG_PATH = "Assets/unknown.png";

        private const string BASE_URL = "https://forum.dotnetdev.kr";
        private const string BADGE_URL = "https://forum.dotnetdev.kr/user-badges/{0}.json?grouped=true";
        private const string SUMMARY_URL = "https://forum.dotnetdev.kr/u/{0}/summary.json";

        private readonly IHttpClientFactory _httpClientFactory;

        public ForumDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private async Task<string> GetResponseStringAsync(Uri uri, CancellationToken token)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            using HttpResponseMessage response = await client.GetAsync(uri, token);

            return await response.Content.ReadAsStringAsync(token);
        }

        private async Task<byte[]> GetResponseBytesAsync(Uri uri, CancellationToken token)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            using HttpResponseMessage response = await client.GetAsync(uri, token);

            return await response.Content.ReadAsByteArrayAsync(token);
        }

        public async Task<(UserSummary summary, User user)> GetUserInfoAsync(string id, CancellationToken token)
        {
            Uri summaryUri = new(string.Format(SUMMARY_URL, id));
            string summaryData = await GetResponseStringAsync(summaryUri, token);
            JObject summaryJson = JObject.Parse(summaryData);

            UserSummary userSummary = JsonConvert.DeserializeObject<UserSummary>(summaryJson["user_summary"]?.ToString() ?? string.Empty) ?? new();
            List<User>? users = JsonConvert.DeserializeObject<List<User>>(summaryJson["users"]?.ToString() ?? string.Empty);

            User user = users?.Where(user => user.Id != -1).FirstOrDefault() ?? new();

            return (userSummary, user);
        }

        public async Task<(byte[] avatar, UserSummary summary, User user)> GetUserInfoWithAvatarAsync(string id, CancellationToken token)
        {
            (UserSummary summary, User user) = await GetUserInfoAsync(id, token);

            if (string.IsNullOrEmpty(user.AvatarEndPoint))
                return (await File.ReadAllBytesAsync(UNKOWN_IMG_PATH, token), summary, user);

            Uri avatarUri = new(string.Concat(BASE_URL, user.AvatarEndPoint));
            return (await GetResponseBytesAsync(avatarUri, token), summary, user);
        }

        public async Task<(int gold, int silver, int bronze)> GetBadgeCountAsync(string id, CancellationToken token)
        {
            Uri badgeUri = new(string.Format(BADGE_URL, id));
            string badgeData = await GetResponseStringAsync(badgeUri, token);
            JObject badgeJson = JObject.Parse(badgeData);

            var badges = badgeJson["badges"]?.GroupBy(badge => badge["badge_type_id"]?.ToString() ?? string.Empty).Select(g => new
            {
                Type = g.Key,
                Count = g.Count(),
            }).ToDictionary(kv => kv.Type, kv => kv.Count);

            int gold = default;
            int silver = default;
            int bronze = default;

            if (badges is not null)
            {
                gold = badges.ContainsKey("1") ? badges["1"] : 0;
                silver = badges.ContainsKey("2") ? badges["2"] : 0;
                bronze = badges.ContainsKey("3") ? badges["3"] : 0;
            }

            return (gold, silver, bronze);
        }
    }
}
