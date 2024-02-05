using DotNetDevBadgeWeb.Common;

namespace DotNetDevBadgeWeb.Interfaces
{
    public interface IBadge
    {
        Task<string> GetSmallBadgeAsync(string id, ETheme theme, CancellationToken token);
        Task<string> GetMediumBadgeAsync(string id, ETheme theme, CancellationToken token);
    }

    public interface IBadgeV1 : IBadge
    {

    }
}
