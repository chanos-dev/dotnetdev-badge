using DotNetDevBadgeWeb.Core.Badge;
using DotNetDevBadgeWeb.Core.Provider;
using DotNetDevBadgeWeb.Core.MeasureText;
using DotNetDevBadgeWeb.Endpoints.BadgeEndPoints;
using DotNetDevBadgeWeb.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IBadgeV1, BadgeCreatorV1>();
builder.Services.AddSingleton<IMeasureTextV1, MeasureTextV1>();
builder.Services.AddSingleton<IProvider, ForumDataProvider>();
builder.Services.AddResponseCaching();

builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

app.MapBadgeEndpoints();
app.UseResponseCaching();
app.Run();  