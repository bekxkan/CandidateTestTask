namespace Sigma.DAL.Entities.User;

public class User
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }
    
    public string Email { get; set; } = null!;
    
    public TimeSpan? CallTimeStart { get; set; }
    
    public TimeSpan? CallTimeEnd { get; set; }
 
    public string? LinkedInUrl { get; set; }
    
    public string? GitHubUrl { get; set; }

    public string FreeTextComment { get; set; } = null!;
}
