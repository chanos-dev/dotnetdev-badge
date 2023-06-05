using DotNetDevBadgeWeb.Common;

namespace DotNetDevBadgeWeb.Core
{
    internal interface IBadge
    {
        Task<string> GetSmallBadge(string id, ETheme theme, CancellationToken token);
        Task<string> GetMediumBadge(string id, ETheme theme, CancellationToken token);
    }

    internal interface IBadgeV1 : IBadge
    {

    }
}
