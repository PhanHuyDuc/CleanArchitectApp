using API.Extensions;
using API.Middleware;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opt.Filters.Add(new AuthorizeFilter(policy));
    }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.Use(async (context, next) =>
   {
       context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000");
       await next.Invoke();
   });
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
// app.MapHub<ChatHub>("/chat");
app.MapFallbackToController("Index", "Fallback");


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
