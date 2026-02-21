using CRUD.Interfaces;
using CRUD.Services;
using CRUD.Storage;
using CRUD.Commons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var storageType = StorageType.SQLite;
//var storageType = StorageType.InMemory;

var storage = ClientStorageFactory.Create(storageType);
builder.Services.AddSingleton<IClientStorage>(storage);
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler("/error");
app.UseMiddleware<ResponseWrapperMiddleware>();

app.Run();

Logger.GetInstance().Stop();