using Microsoft.EntityFrameworkCore;
using Sigma.DAL;
using Sigma.Services.Users;

namespace Sigma.UnitTests.Services.Users;

public partial class UserServiceTests
{
    private readonly SigmaDbContext _dbContextMock;
    private readonly IUserService _userService;
    
    public UserServiceTests()
    {
        _dbContextMock = new SigmaDbContext(new DbContextOptionsBuilder<SigmaDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase($"{nameof(UserService)}-InMemoryDb-{Guid.NewGuid()}")
            .Options);
        _userService = new UserService(_dbContextMock);
    }
}
