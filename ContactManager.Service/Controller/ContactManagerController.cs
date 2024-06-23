using ContactManager.Service.Configuration;
using ContactManager.Service.Extensions;
using ContactManager.Service.Model;
using ContactManager.Service.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ContactManager.Service.Controller;

[ApiController]
[Route("api/[controller]/[action]")]

public class ContactManagerController : ControllerBase
{
    private readonly IContactRepository _repository;
    private readonly IOptions<ContactManagerConfiguration> _config;

    public ContactManagerController(IContactRepository repository, IOptions<ContactManagerConfiguration> config)
    {
        _repository = repository;
        _config = config;
    }

    // Api Endpoint of Contacts that return all contacts
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        if (await _repository.GetAll(cancellationToken) is { } result &&
            result.Any())
        {
            return Ok(result);
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that returns contacts filter by Id
    [HttpGet]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.GetById(id, cancellationToken) is { } result)
        {
            return Ok(result);
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that create new record
    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] Contact contact, CancellationToken cancellationToken = default)
    {
        if (await _repository.Add(contact, cancellationToken) is { } result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that update a record
    [HttpPost]
    public async Task<IActionResult> UpdateContact([FromBody] Contact contact, CancellationToken cancellationToken = default)
    {
        if (await _repository.Update(contact, cancellationToken) is { } result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that update a record
    [HttpPost]
    public async Task<IActionResult> DeleteContact(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.Delete(id, cancellationToken) is { } result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that return the address from google map  as a image
    [HttpGet]
    public async Task<IActionResult> GetContactMap(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.GetById(id, cancellationToken) is { } result)
        {
            if (!string.IsNullOrWhiteSpace(result.Address))
            {
                return File(await result.FetchMapFromAddress(_config.Value.Maps), "image/png");
            }
        }

        return NotFound();
    }

    // Api Endpoint of Contacts that returns contacts filter by Name,EmailAddress,Phone and Address
    [HttpGet]
    public async Task<IActionResult> GetBySearchCriteria(string searchString, CancellationToken cancellationToken = default)
    {
        if (await _repository.GetBySearchCriteria(searchString, cancellationToken) is { } result)
        {
            return Ok(result);
        }

        return NotFound();
    }
}
