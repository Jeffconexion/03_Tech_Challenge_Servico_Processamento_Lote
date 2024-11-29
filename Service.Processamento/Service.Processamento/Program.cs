using Service.Processamento;
using Service.Processamento.Services.Contracts;
using Service.Processamento.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IMessageBusService, MessageBusService>();

var host = builder.Build();
host.Run();
