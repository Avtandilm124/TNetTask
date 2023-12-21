using System.ComponentModel.DataAnnotations;

namespace TNetTask.Requests;

public class SendPercentMessageRequest
{
    [Range(0,100)]
    public double MagtiSmsProvider { get; set; }
    
    [Range(0,100)]
    public double GeocellSmsProvider { get; set; }
    
    [Range(0,100)]
    public double TwilioSmsProvider { get; set; }
}
