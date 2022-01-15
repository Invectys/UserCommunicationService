using Microsoft.AspNetCore.Authentication.JwtBearer;
using UserCommunicationService.Core.Services;
using UserCommunicationService.database.Repositories;
using UserCommunicationService.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.Authority = UsersService.Issuer;
    options.Audience = UsersService.Audience;
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.Write("token validate");
            return Task.CompletedTask;
        },
        OnMessageReceived = context =>
        {
            if(context.HttpContext.Request.Path.StartsWithSegments("/hubs/chat"))
            {
                string accessToken = context.Request.Query["access_token"];
                Console.WriteLine("Access token = " + accessToken);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    context.Token = accessToken;
                }
            }
            
            return Task.CompletedTask;
        }
    };
});


builder.Services.AddSignalR(options => {
    options.EnableDetailedErrors = true;
});
builder.Services.AddCors(options =>
{

    options.AddPolicy("DEFAULT", policy => {
        policy.SetIsOriginAllowed(origin => new Uri(origin).IsLoopback);
        policy.WithOrigins("https://tusa.uno").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        policy.WithOrigins("https://tusanetworkv3.web.app").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });

});




// Add core services
CoreServiceAdder.AddCoreServices(builder.Services);

// Add repositories
RepositoriesAdder.AddRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();




app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseCors("DEFAULT");

app.MapRazorPages();

app.MapControllers();

app.MapHub<ChatHub>("/hubs/chat");

app.Run();


