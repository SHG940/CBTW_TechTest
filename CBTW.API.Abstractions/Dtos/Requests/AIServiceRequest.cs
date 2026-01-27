namespace CBTW.API.Abstractions.Dtos.Requests;

public class AIServiceRequest
{
    public string Propmt { get; set; }

    public Dictionary<string, string> PropmtValues { get; set; }
}