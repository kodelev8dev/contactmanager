using ContactManager.Service.Model;
using ContactManager.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Service.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
// [Route("/api/contactmanager/")]

public class ContactManagerController : ControllerBase
{
    private readonly IContactRepository _repository;

    public ContactManagerController(IContactRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("all")]
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
    [Route("{id:int}")]
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
        if (await _repository.Add(contact, cancellationToken) is {} result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPost]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteContact(int id, CancellationToken cancellationToken = default)
    {
        if (await _repository.Delete(id, cancellationToken) is {} result && result > 0)
        {
            return Ok();
        }

        return NotFound();
    }
}
