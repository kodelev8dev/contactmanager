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

    //Returns all the contacts from the database
    public async Task<IEnumerable<Contact>> GetAll(CancellationToken cancellationToken = default) =>
        await _db.Contacts.ToListAsync(cancellationToken);

    //Returns the search contact by Id from the database
    public async Task<Contact?> GetById(int id, CancellationToken cancellationToken = default) =>
        await _db.Contacts.Where(c => c.Id == (int)id).FirstOrDefaultAsync(cancellationToken);

    //Allows you to create new record from database
    public async Task<int> Add(Contact contact, CancellationToken cancellationToken = default)
    {
        contact.Created = DateTime.Now;
        contact.LastUpdated = DateTime.Now;
        contact.IsDeleted = false;

        await _db.Contacts.AddAsync(contact, cancellationToken);
        return await _db.SaveChangesAsync(cancellationToken);
    }

    //Allows you to update a record from database
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
    //Allows you to delete a record from database
    public async Task<int> Delete(int id, CancellationToken cancellationToken = default)
    {
        if (await _db.Contacts.FirstOrDefaultAsync(c => c.Id == id, cancellationToken) is { } forDelete)
        {
            forDelete.IsDeleted = true;
            return await _db.SaveChangesAsync(cancellationToken);
        }

        return 0;
    }

    //Returns the records of contact that search by multiple fields
    public async Task<IEnumerable<Contact>> GetBySearchCriteria(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _db.Contacts.Where(x => x.Name.Contains(searchTerm) ||
        x.Address.Contains(searchTerm) ||
        x.Email.Contains(searchTerm) ||
        x.Phone.Contains(searchTerm)).ToListAsync();
    }
}