namespace TNetTask.SmsProviders;

public class TwilioSmsProvider(ILogger<TwilioSmsProvider> logger) : ISmsProvider
{
    public Task SendAsync(string number, string message)
    {
        logger.LogInformation("Send by Twilio");
        return Task.CompletedTask;
    }
}