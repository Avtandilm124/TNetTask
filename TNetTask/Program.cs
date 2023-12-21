using TNetTask.Middlewares;
using TNetTask.SmsProviders;
using TNetTask.SmsProviderSelector;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

services.AddSwaggerGen();

services.AddKeyedScoped<ISmsProvider, MagtiSmsProvider>(nameof(MagtiSmsProvider));
services.AddKeyedScoped<ISmsProvider, GeocellSmsProvider>(nameof(GeocellSmsProvider));
services.AddKeyedScoped<ISmsProvider, TwilioSmsProvider>(nameof(TwilioSmsProvider));

services.AddSingleton<ISmsProviderSelector, DefaultSmsProviderSelector>();


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
