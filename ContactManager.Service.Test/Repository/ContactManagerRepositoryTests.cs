using ContactManager.Service.Context;
using ContactManager.Service.Model;
using ContactManager.Service.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace ContactManager.Service.Test.Repository;

public class ContactManagerRepositoryTests
{
    private readonly IContactRepository _repository;
    private readonly DbContextOptions<ContactManagerContext> _options;

    public ContactManagerRepositoryTests()
    {
        _repository = Substitute.For<IContactRepository>();

        _options = new DbContextOptionsBuilder<ContactManagerContext>()
            .UseInMemoryDatabase(databaseName: "Tbl_GetAllTest")
            .Options;

        using var context = new ContactManagerContext(_options);

        if (!context.Contacts.IgnoreQueryFilters().Any(i => i.Id == 1))
        {
            context.Contacts.Add(new Contact
            {
                Id = 1,
                Name = "John Doe",
                Email = "iUqFP@example.com",
                Phone = "1234567890",
                Address = "123 Main St",
                Notes = "Test contact",
                IsDeleted = false,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            });
        }

        if (!context.Contacts.IgnoreQueryFilters().Any(i => i.Id == 2))
        {
            context.Contacts.Add(new Contact
            {
                Id = 2,
                Name = "Jane Doe",
                Email = "iUqFP@example.com",
                Phone = "1234567890",
                Address = "123 Main St",
                Notes = "Test contact",
                IsDeleted = false,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            });
        }

        if (!context.Contacts.IgnoreQueryFilters().Any(i => i.Id == 3))
        {
            context.Contacts.Add(new Contact
            {
                Id = 3,
                Name = "John Smith",
                Email = "iUqFP@example.com",
                Phone = "1234567890",
                Address = "123 Main St",
                Notes = "Test contact",
                IsDeleted = true,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            });
        }

        context.SaveChanges();
    }

    [Fact]
    public async Task GetAllTests()
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.GetAll();

        result.Should().NotBeNull();
        result.Count().Should().BeGreaterThan(0);
        result.FirstOrDefault(t => t.Id == 1).Should().BeEquivalentTo(new Contact
        {
            Id = 1,
            Name = "John Doe",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        }, e => e.Excluding(p => p.Created).Excluding(p => p.LastUpdated));
        result.FirstOrDefault(t => t.Id == 2).Should().BeEquivalentTo(new Contact
        {
            Id = 2,
            Name = "Jane Doe",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        }, e => e.Excluding(p => p.Created).Excluding(p => p.LastUpdated));
        result.FirstOrDefault(t => t.IsDeleted == true).Should().Be(null);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetByIdTest(int id)
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.GetById(id);

        if (new int[] { 1, 2 }.Contains(id))
        {
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.IsDeleted.Should().Be(false);
        }
        if (id == 3)
        {
            result.Should().BeNull();
        }
    }


    [Theory]
    [InlineData("Jane")]
    [InlineData("John")]
    [InlineData("Pepe")]
    public async Task GetByAnySearchTest(string search)
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.GetBySearchCriteria(search);

        if (new string[] { "Jane", "John" }.Contains(search))
        {
            result.Should().NotBeNull();
            result.Count().Should().BeGreaterThan(0);
        }
        if (search == "Pepe")
        {
            result.Count().Should().Be(0);
        }
    }

    [Fact]
    public async Task AddTest()
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.Add(new Contact
        {
            Id = 4,
            Name = "Jane Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        });

        var contact = context.Contacts.FirstOrDefault(i => i.Id == 4);
        result.Should().BeGreaterThan(0);
        contact.Should().BeEquivalentTo(new Contact
        {
            Id = 4,
            Name = "Jane Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        }, e => e.Excluding(p => p.Created).Excluding(p => p.LastUpdated)); ;
    }

    [Fact]
    public async Task WhenFound_UpdateTest()
    {
        using var context = new ContactManagerContext(_options);

        context.Contacts.Add(new Contact
        {
            Id = 10,
            Name = "Pepe Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        });
        await context.SaveChangesAsync();

        var repository = new ContactRepository(context);
        var result = await repository.Update(new Contact
        {
            Id = 10,
            Name = "Johnoy Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        });

        result.Should().BeGreaterThan(0);
        context.Contacts.FirstOrDefault(i => i.Id == 10).Should().NotBeNull();
        context.Contacts.FirstOrDefault(i => i.Id == 10).IsDeleted.Should().Be(false);
        context.Contacts.FirstOrDefault(i => i.Id == 10).Name.Should().Be("Johnoy Smith");
    }

    [Fact]
    public async Task WhenNotFound_UpdateTest()
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.Update(new Contact
        {
            Id = 20,
            Name = "Johnoy Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        });

        result.Should().Be(0);
        context.Contacts.FirstOrDefault(i => i.Id == 20).Should().BeNull();
    }

    [Fact]
    public async Task WhenFound_DeleteTest()
    {
        using var context = new ContactManagerContext(_options);

        context.Contacts.Add(new Contact
        {
            Id = 20,
            Name = "Pepe Smith",
            Email = "iUqFP@example.com",
            Phone = "1234567890",
            Address = "123 Main St",
            Notes = "Test contact",
            IsDeleted = false,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        });
        await context.SaveChangesAsync();

        var repository = new ContactRepository(context);
        var result = await repository.Delete(20);

        result.Should().BeGreaterThan(0);
        context.Contacts.IgnoreQueryFilters().FirstOrDefault(i => i.Id == 20).Should().NotBeNull();
        context.Contacts.IgnoreQueryFilters().FirstOrDefault(i => i.Id == 20).IsDeleted.Should().Be(true);
    }

    [Fact]
    public async Task WhenNotFound_DeleteTest()
    {
        using var context = new ContactManagerContext(_options);

        var repository = new ContactRepository(context);
        var result = await repository.Delete(30);

        result.Should().Be(0);
        context.Contacts.IgnoreQueryFilters().FirstOrDefault(i => i.Id == 30).Should().BeNull();
    }
}
