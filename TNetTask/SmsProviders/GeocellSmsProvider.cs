namespace TNetTask.SmsProviders;

public class GeocellSmsProvider(ILogger<GeocellSmsProvider> logger) : ISmsProvider
{
    public Task SendAsync(string number, string message)
    {
        logger.LogInformation("Send by Geocell");
        return Task.CompletedTask;
    }
}