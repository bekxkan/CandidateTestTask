using Sigma.Services.Users.Models;

namespace Sigma.API.Controllers.Requests;

public record CreateUpdateUserRequest
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public TimeIntervalDto? CallTimeInterval { get; set; }

    public string? LinkedInUrl { get; set; }
    
    public string? GitHubUrl { get; set; }

    public string FreeTextComment { get; set; } = null!;
}
