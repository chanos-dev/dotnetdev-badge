using DotNetDevBadgeWeb.Core;
using DotNetDevBadgeWeb.Endpoints.BadgeEndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IBadgeV1, BadgeCreatorV1>();
builder.Services.AddResponseCaching();

var app = builder.Build();

app.MapBadgeEndpoints();
app.UseResponseCaching();
app.Run();  