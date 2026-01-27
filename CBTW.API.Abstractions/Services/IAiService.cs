using CBTW.API.Abstractions.Dtos.Requests;
using CBTW.API.Abstractions.Dtos.Responses;

namespace CBTW.API.Abstractions.Services;

public interface IAiService
{
    Task<AIServiceResponse> CallAsync(AIServiceRequest request);
}