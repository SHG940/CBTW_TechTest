using CBTW.API.Repositories;
using CBTW.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddOpenApi()
    .RegisterServices()
    .RegisterRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Gemini key was removed due to uploaded to Github Repo
// Implement KeyVault for it