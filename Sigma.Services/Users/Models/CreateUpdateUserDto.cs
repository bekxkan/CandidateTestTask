using Mapster;
using Sigma.DAL.Entities.User;

namespace Sigma.Services.Users.Models;

public record CreateUpdateUserDto : IRegister
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public TimeIntervalDto? CallTimeInterval { get; set; }

    public string? LinkedInUrl { get; set; }
    
    public string? GitHubUrl { get; set; }

    public string FreeTextComment { get; set; } = null!;
    
    public void Register(TypeAdapterConfig config) => 
        config.NewConfig<CreateUpdateUserDto, User>()
            .Map(dest => dest.CallTimeStart, src => src.CallTimeInterval.GetTimeStart())
            .Map(dest => dest.CallTimeEnd, src => src.CallTimeInterval.GetTimeEnd());
}
