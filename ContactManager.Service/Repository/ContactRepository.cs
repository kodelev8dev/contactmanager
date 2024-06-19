using ContactManager.Service.Context;
using ContactManager.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Repository;

public class ContactRepository : IContactRepository
{
    private readonly ContactManagerContext _db;

    public ContactRepository(ContactManagerContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Contact>> GetAll(CancellationToken cancellationToken = default) =>
        await _db.Contacts.ToListAsync(cancellationToken);

    public async Task<Contact?> GetById(int id, CancellationToken cancellationToken = default) =>
        await _db.Contacts.Where(c => c.Id == (int)id).FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Add(Contact contact, CancellationToken cancellationToken = default)
    {
        await _db.Contacts.AddAsync(contact, cancellationToken);
        return await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> Update(Contact contact, CancellationToken cancellationToken = default)
    {
        if (await _db.Contacts.FirstOrDefaultAsync(c => c.Id == contact.Id, cancellationToken) is { } forUpdate)
        {
            forUpdate.Name = contact.Name;
            forUpdate.Email = contact.Email;
            forUpdate.Phone = contact.Phone;
            forUpdate.Address = contact.Address;
            forUpdate.Notes = contact.Notes;
            forUpdate.LastUpdated = contact.LastUpdated;

            return await _db.SaveChangesAsync(cancellationToken);
        }

        return 0;
    }

    public async Task<int> Delete(int id, CancellationToken cancellationToken = default)
    {
        if (await _db.Contacts.FirstOrDefaultAsync(c => c.Id == id, cancellationToken) is { } forDelete)
        {
            forDelete.IsDeleted = true;
            return await _db.SaveChangesAsync(cancellationToken);
        }

        return 0;
    }
}
