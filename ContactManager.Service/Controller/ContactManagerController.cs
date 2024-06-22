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

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        if (await _repository.GetAll(cancellationToken) is {} result &&
            result.Any())
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.GetById(id, cancellationToken) is {} result )
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] Contact contact, CancellationToken cancellationToken = default)
    {
        if (await _repository.Add(contact, cancellationToken) is {} result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateContact([FromBody] Contact contact, CancellationToken cancellationToken = default)
    {
        if (await _repository.Update(contact, cancellationToken) is {} result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteContact(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.Delete(id, cancellationToken) is {} result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetContactMap (int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.GetById(id, cancellationToken) is {} result )
        {
            if (!string.IsNullOrWhiteSpace(result.Address))
            {
                return File(await result.FetchMapFromAddress(_config.Value.Maps), "image/png");
            }
        }

        return NotFound();
    }
}
