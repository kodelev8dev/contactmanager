using ContactManager.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Context;

public interface IContactManagerContext : IInitializable
{
    DbSet<Contact> Contacts { get; set; }
}
