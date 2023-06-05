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
            app.MapGet("/api/v1/badge/small", async ([FromQuery] string id, [FromQuery] ETheme? theme, IBadgeV1 badge, CancellationToken token) =>
            {
                string response = await badge.GetSmallBadge(id, theme ?? ETheme.Light, token);
                return Results.Content(response, "image/svg+xml");
            });

            app.MapGet("/api/v1/badge/medium", async ([FromQuery] string id, [FromQuery] ETheme? theme, IBadgeV1 badge, CancellationToken token) =>
            {
                string response = await badge.GetMediumBadge(id, theme ?? ETheme.Light, token);
                return Results.Content(response, "image/svg+xml");
            });

            return app;
        }
    }
}
