using Microsoft.AspNetCore.Mvc;
using TNetTask.Requests;
using TNetTask.SmsProviderSelector;
using TNetTask.SmsProviderSelector.Strategies;

namespace TNetTask.Controllers;

[ApiController]
[Route("api/sms-examples")]
public class SmsController(ISmsProviderSelector smsProviderSelector) : ControllerBase
{
    [HttpPost("send-by-random")]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> SendByRandomStrategy()
    {
        var providersChosen = new List<string>() {"MagtiSmsProvider", "GeocellSmsProvider", "TwilioSmsProvider"};
        var provider = smsProviderSelector.GetProvider(new RandomProviderStrategy(providersChosen));
        await provider.SendAsync("example", "example");

        return Ok($"Send via {provider.GetType().Name}");
    }
    
    
    [HttpPost("send-by-percent")]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> SendByPercentStrategy(SendPercentMessageRequest request)
    {
        var percentMap = new Dictionary<string, double>()
        {
            {"MagtiSmsProvider", request.MagtiSmsProvider},
            {"GeocellSmsProvider", request.GeocellSmsProvider},
            {"TwilioSmsProvider", request.TwilioSmsProvider}
        };
        
        var provider = smsProviderSelector.GetProvider(new PercentProviderStrategy(new PercentProviderStrategyOptions(percentMap)));
        await provider.SendAsync("example", "example");

        return Ok($"Send via {provider.GetType().Name}");
    }
    
}