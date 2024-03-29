﻿using DotNetDevBadgeWeb.Common;
using DotNetDevBadgeWeb.Extensions;
using DotNetDevBadgeWeb.Interfaces;
using DotNetDevBadgeWeb.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevBadgeWeb.Endpoints.BadgeEndPoints
{
    internal static class BadgeEndpoints
    {
        internal static WebApplication MapBadgeEndpoints(this WebApplication app)
        {
            app.UseMiddleware<BadgeIdValidatorMiddleware>();
            app.MapBadgeEndpointsV1();
            return app;
        }

        internal static WebApplication MapBadgeEndpointsV1(this WebApplication app)
        {
            app.MapGet("/api/v1/badge/small", async (HttpContext context, [FromQuery] string id, [FromQuery] ETheme? theme, [FromServices] IBadgeV1 badge, CancellationToken token) =>
            {
                string response = await badge.GetSmallBadgeAsync(id, theme ?? ETheme.Light, token);
                context.Response.SetCacheControl(TimeSpan.FromDays(1).TotalSeconds);
                return Results.Content(response, "image/svg+xml");
            });

            app.MapGet("/api/v1/badge/medium", async (HttpContext context, [FromQuery] string id, [FromQuery] ETheme? theme, [FromServices] IBadgeV1 badge, CancellationToken token) =>
            {
                string response = await badge.GetMediumBadgeAsync(id, theme ?? ETheme.Light, token);
                context.Response.SetCacheControl(TimeSpan.FromDays(1).TotalSeconds);
                return Results.Content(response, "image/svg+xml");
            });

            return app;
        }
    }
}
