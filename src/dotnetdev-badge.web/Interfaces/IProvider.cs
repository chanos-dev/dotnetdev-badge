using DotNetDevBadgeWeb.Model;

namespace DotNetDevBadgeWeb.Interfaces
{
    public interface IProvider
    {
        Task<(UserSummary summary, User user)> GetUserInfoAsync(string id, CancellationToken token);
        Task<(byte[] avatar, UserSummary summary, User user)> GetUserInfoWithAvatarAsync(string id, CancellationToken token);
        Task<(int gold, int silver, int bronze)> GetBadgeCountAsync(string id, CancellationToken token);
    }
}
