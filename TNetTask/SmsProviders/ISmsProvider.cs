namespace TNetTask.SmsProviders;

public interface ISmsProvider
{
    Task SendAsync(string number, string message);
}