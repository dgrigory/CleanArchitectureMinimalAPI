using Application;
using Common.Interfaces;
using FluentValidation;
using MinimalApiExtensions;
using MinimalApiExtensions.Extensions;
using Reader;
using Store;
using Store.Connection;
using Winton.Extensions.Configuration.Consul;
using Winton.Extensions.Configuration.Consul.Parsers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

//Configurations
var path = $"environment/{builder.Environment.EnvironmentName}/services/configs/audit-service/versions/v1/".ToLower();
config.AddConsul(path, options =>
{
    options.ConsulConfigurationOptions = consulConfig =>
    {
        var consulHost = config.GetValue<string>("Consul:Host");
        var consulPort = config.GetValue<int>("Consul:Port");
        consulConfig.Address = new Uri($"http://{consulHost}:{consulPort}");
    };
    options.Parser = new SimpleConfigurationParser();
});

//ConfigureServices

services.Configure<MongoConfigurationOptions>(config.GetSection("default:blockchain:database:mongodb"));

services.AddValidatorsFromAssemblyContaining<Program>();
services.AddApplication();
services.AddStore();
services.AddMinimalApis(typeof(Program));
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSingleton<IRemoteFunctionDiscovery, DummyFunctionDiscovery>();

var app = builder.Build();

//Configure
app.UseMinimalApis<RouteMapper>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
