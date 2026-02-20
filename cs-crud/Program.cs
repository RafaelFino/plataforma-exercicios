using CRUD.Interfaces;
using CRUD.Services;
using CRUD.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//var storageType = StorageType.SQLite;
var storageType = StorageType.InMemory;

var storage = ClientStorageFactory.Create(storageType);
builder.Services.AddSingleton<IClientStorage>(storage);
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

app.MapControllers();

app.Run();