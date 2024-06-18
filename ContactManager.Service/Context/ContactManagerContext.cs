using ContactManager.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Context;

public class ContactManagerContext : DbContext, IContactManagerContext
{
    public DbSet<Contact> Contacts { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasQueryFilter(order => !order.IsDeleted);
            entity.HasIndex(e => new
            {
                e.Id, e.Name
            });
        });
    }
}
