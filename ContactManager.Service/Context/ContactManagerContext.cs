using ContactManager.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Context;

public class ContactManagerContext : DbContext, IContactManagerContext
{

    public ContactManagerContext()
    {
    }

    public ContactManagerContext(DbContextOptions<ContactManagerContext> options) :
        base(options)
    {
    }

    public async Task Initialize() =>  await Database.MigrateAsync();

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contacts");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.LastUpdated).HasDefaultValueSql("getdate()");
            entity.HasQueryFilter(order => !order.IsDeleted);
            entity.HasIndex(e => new
            {
                e.Id, e.Name
            });
            entity.HasData
            (
                new Contact
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
                },
                new Contact
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Email = "b2yJn@example.com",
                    Phone = "0987654321",
                    Address = "456 Oak St",
                    Notes = "Test contact",
                    IsDeleted = false,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                },
                new Contact
                {
                    Id = 3,
                    Name = "John Smith",
                    Email = "iUqFP@example.com",
                    Phone = "1234567890",
                    Address = "123 Main St",
                    Notes = "Test contact",
                    IsDeleted = false,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                },
                new Contact
                {
                    Id = 4,
                    Name = "Jane Smith",
                    Email = "b2yJn@example.com",
                    Phone = "0987654321",
                    Address = "456 Oak St",
                    Notes = "Test contact",
                    IsDeleted = true,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                }
            );
        });
    }
}
