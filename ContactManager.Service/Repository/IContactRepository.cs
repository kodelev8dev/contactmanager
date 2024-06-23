using ContactManager.Service.Model;

namespace ContactManager.Service.Repository;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAll(CancellationToken cancellationToken = default);
    Task<Contact?> GetById(int id, CancellationToken cancellationToken = default);
    Task<int> Add(Contact contact, CancellationToken cancellationToken = default);
    Task<int> Update(Contact contact, CancellationToken cancellationToken = default);
    Task<int> Delete(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Contact>> GetBySearchCriteria(string searchString, CancellationToken cancellationToken = default);
}
