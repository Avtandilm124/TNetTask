namespace TNetTask.SmsProviderSelector.Strategies;

public class RandomProviderStrategy(IReadOnlyList<string> providerKeys) : ISmsProviderStrategy
{
    public string GetProviderKey()
    {
        var randomIndex = Random.Shared.Next(providerKeys.Count);
        return providerKeys[randomIndex];
    }
}