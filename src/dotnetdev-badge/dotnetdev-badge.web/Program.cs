using DotNetDevBadgeWeb.Core;
using DotNetDevBadgeWeb.Endpoints.BadgeEndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IBadgeV1, BadgeCreatorV1>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapBadgeEndpoints();

app.Run(); 