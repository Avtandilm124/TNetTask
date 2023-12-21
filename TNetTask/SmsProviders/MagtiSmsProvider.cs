namespace TNetTask.SmsProviders;

public class MagtiSmsProvider(ILogger<MagtiSmsProvider> logger) : ISmsProvider
{
    public Task SendAsync(string number, string message)
    {
        logger.LogInformation("Send by Magti");
        
        return Task.CompletedTask;
    }
}