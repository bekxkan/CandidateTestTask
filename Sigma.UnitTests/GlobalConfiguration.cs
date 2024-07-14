using Mapster;
using Xunit;
using UserServiceTests = Sigma.UnitTests.Services.Users.UserServiceTests;

namespace Sigma.UnitTests;

public sealed class TypeAdapterFixture
{
    public TypeAdapterFixture() =>
        TypeAdapterConfig.GlobalSettings.Scan(
            typeof(UserServiceTests).Assembly);
}

[CollectionDefinition("TypeAdapter Configurations")]
public sealed class TypeAdapterCollection: ICollectionFixture<TypeAdapterFixture>;
