using Cassandra;
using System.Net;
using UserCommunicationService.Core.Services;
using UserCommunicationService.database;
using UserCommunicationService.database.Repositories;
using UserCommunicationService.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

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

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.MapHub<ChatHub>("/hubs/chat");

app.Run();


