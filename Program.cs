using BackendInnovation;
using BackendInnovation.DatabaseSettings;
using BackendInnovation.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<BackendDatabaseSettings>(
    builder.Configuration.GetSection(nameof(BackendDatabaseSettings)));

builder.Services.AddSingleton<IBackendDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<BackendDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("BackendDatabaseSettings:ConnectionStrings")));

builder.Services.AddScoped<IIdeatorService, IdeatorService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
