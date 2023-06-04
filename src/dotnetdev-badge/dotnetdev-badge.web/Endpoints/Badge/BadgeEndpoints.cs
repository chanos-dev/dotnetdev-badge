using DotNetDevBadgeWeb.Common;
using DotNetDevBadgeWeb.Core;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevBadgeWeb.Endpoints.BadgeEndPoints
{
    internal static class BadgeEndpoints
    {
        internal static WebApplication MapBadgeEndpoints(this WebApplication app)
        {
            app.MapBadgeEndpointsV1();
            return app;
        }

        internal static WebApplication MapBadgeEndpointsV1(this WebApplication app)
        {
            app.MapGet("/api/v1/badge/micro", async ([FromQuery] string id, [FromQuery] ETheme? theme, IBadge badge, CancellationToken token) =>
            {
                string response = await badge.GetMicroBadge(id, theme ?? ETheme.Light, token);
                return Results.Content(response, "image/svg+xml");
            });

            app.MapGet("/api/v1/badge/large", async ([FromQuery] string id, [FromQuery] ETheme? theme, IBadge badge, CancellationToken token) =>
            {
                string response = await badge.GetLargeBadge(id, theme ?? ETheme.Light, token);
                return Results.Content(response, "image/svg+xml");
            });

            return app;
        }
    }
}
