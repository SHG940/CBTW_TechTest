using System.ComponentModel.DataAnnotations;

namespace CBTW.API.Gateway.Models.Dtos.Requests;

public class BookIdentifierRequest
{
    [Required]
    [MinLength(10)]
    public string Input { get; set; }
}