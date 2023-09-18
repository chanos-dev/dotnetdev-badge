namespace DotNetDevBadgeWeb.Middleware
{
    public class BadgeIdValidatorMiddleware
    {
        private readonly RequestDelegate _next;

        public BadgeIdValidatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            if (context.Request.Query.ContainsKey("id"))
            {
                string id = context.Request.Query["id"].ToString();
                if (id.Length > 20)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("ID must be no longer than 20 characters.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
