using DotNetDevBadgeWeb.Common;

namespace DotNetDevBadgeWeb.Core
{
    internal interface IBadge
    {
        Task<string> GetMicroBadge(string id, ETheme theme, CancellationToken token);
        Task<string> GetLargeBadge(string id, ETheme theme, CancellationToken token);
    }
}
