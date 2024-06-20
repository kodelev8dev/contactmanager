using ContactManager.Service.Configuration;
using ContactManager.Service.Extensions;
using FluentAssertions;

namespace ContactManager.Service.Test.Extensions;

public class ToConnectionStringTests
{
    [Fact]
    public void ToConnectionString_ReturnsCorrectConnectionString()
    {
        var database = new Database
        {
            Server = "localhost",
            Port = 1433,
            Name = "ContactManager",
            User = "sa",
            Password = "password"
        };

        var result = database.ToConnectionString();

        result.Length.Should().BeGreaterThan(0);
        result.Should().Match("Server=localhost,1433;Database=ContactManager;User Id=sa;Password=password;TrustServerCertificate=true");
    }

    [Fact]
    public void ToConnectionString_ReturnsInvalidConnectionString()
    {
        var database = new Database
        {
            Server = "localhost",
            Port = 1433,
            User = "sa",
            Password = "password"
        };

        var result = database.ToConnectionString();

        result.Length.Should().BeGreaterThan(0);
        result.Should().NotMatch("Server=localhost,1433;Database=ContactManager;User Id=sa;Password=password;TrustServerCertificate=true");
    }
}
