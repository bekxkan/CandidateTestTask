using Sigma.Services.Users.Models;

namespace Sigma.Services.Users;

public interface IUserService
{
    Task<UserDetailsDto> CreateUpdateUserAsync(CreateUpdateUserDto user);
}
