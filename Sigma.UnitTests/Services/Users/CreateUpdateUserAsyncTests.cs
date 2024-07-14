using Bogus;
using FluentAssertions;
using Sigma.DAL.Entities.User;
using Sigma.Services.Users.Models;
using Xunit;

namespace Sigma.UnitTests.Services.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task CreateUpdateUserAsync_WhenCalledWithExistingUser_ShouldUpdateUser()
    {
        // Arrange
        var existingUser = new Faker<User>()
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.FreeTextComment, f => f.Lorem.Sentence(10))
            .Generate();
        var user = CreateUpdateUserDtoFaker
            .RuleFor(x => x.Email, existingUser.Email)
            .Generate();
        
        _dbContextMock.Users.Add(existingUser);
        await _dbContextMock.SaveChangesAsync();
        
        // Act
        var result = await _userService.CreateUpdateUserAsync(user);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(user, options => options.ExcludingMissingMembers());
        result.Email.Should().Be(existingUser.Email);
    }
    
    [Fact]
    public async Task CreateUpdateUserAsync_WhenCalledWithNonExistingUser_ShouldCreateUser()
    {
        // Arrange
        var user = CreateUpdateUserDtoFaker.Generate();
        
        // Act
        var result = await _userService.CreateUpdateUserAsync(user);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(user, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public async Task CreateUpdateUserAsync_EmailIsNull_ExceptionRaised()
    {
        // Arrange
        var user = CreateUpdateUserDtoFaker
            .Ignore(x => x.Email)
            .Generate();
        
        // Act and Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _userService.CreateUpdateUserAsync(user));
    }

    private static Faker<CreateUpdateUserDto> CreateUpdateUserDtoFaker => new Faker<CreateUpdateUserDto>()
        .RuleFor(x => x.Email, f => f.Person.Email)
        .RuleFor(x => x.FirstName, f => f.Person.FirstName)
        .RuleFor(x => x.LastName, f => f.Person.LastName)
        .RuleFor(x => x.FreeTextComment, f => f.Lorem.Sentence(10));
}
