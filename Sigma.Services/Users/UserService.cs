using Mapster;
using Sigma.DAL;
using Sigma.DAL.Entities.User;
using Sigma.Services.Users.Models;

namespace Sigma.Services.Users;

public class UserService : IUserService
{
    private readonly SigmaDbContext _dbContext;

    public UserService(SigmaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDetailsDto> CreateUpdateUserAsync(CreateUpdateUserDto userDto)
    {
        var user = await _dbContext.Users.FindAsync(userDto.Email);
        if (user is null) {
            user = userDto.Adapt<User>();
            _dbContext.Users.Add(user);
        }
        else userDto.Adapt(user);
        await _dbContext.SaveChangesAsync();
        return user.Adapt<UserDetailsDto>();
    }
}
