using ContactManager.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Context;

public interface IContactManagerContext
{
    DbSet<Contact> Contacts { get;  }
}
