using TNetTask.SmsProviders;
using TNetTask.SmsProviderSelector.Strategies;

namespace TNetTask.SmsProviderSelector;

public interface ISmsProviderSelector
{
    ISmsProvider GetProvider(ISmsProviderStrategy strategy);
}