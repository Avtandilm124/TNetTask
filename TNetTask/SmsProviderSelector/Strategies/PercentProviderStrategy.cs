using TNetTask.Exceptions;

namespace TNetTask.SmsProviderSelector.Strategies;

public record PercentProviderStrategyOptions(IReadOnlyDictionary<string, double> PercentByProviders);


public class PercentProviderStrategy(PercentProviderStrategyOptions options) : ISmsProviderStrategy
{
    public string GetProviderKey()
    {
        var sortedByPercent = options.PercentByProviders
            .OrderByDescending(x => x.Value).ToDictionary();


        if (sortedByPercent.Sum(x => x.Value) > 100)
            throw new DomainException("Sum of provider percents can't be greater then 100%.");

        var totalSum = sortedByPercent.Values.Sum();
        var randomValue = Random.Shared.NextDouble() * totalSum;

        var probability = 0d;
        foreach (var kvp in sortedByPercent)
        {
            probability += kvp.Value;

            if (probability >= randomValue)
            {
                return kvp.Key;
            }
        }
        return sortedByPercent.Keys.Last();
    }
}