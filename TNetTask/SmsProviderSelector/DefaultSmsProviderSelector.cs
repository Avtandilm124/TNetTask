using TNetTask.SmsProviders;
using TNetTask.SmsProviderSelector.Strategies;

namespace TNetTask.SmsProviderSelector;

public class DefaultSmsProviderSelector(IServiceScopeFactory serviceProvider) : ISmsProviderSelector
{
    public ISmsProvider GetProvider(ISmsProviderStrategy strategy)
    {
        var providerKey = strategy.GetProviderKey();
        using var scope = serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredKeyedService<ISmsProvider>(providerKey);
    }
}