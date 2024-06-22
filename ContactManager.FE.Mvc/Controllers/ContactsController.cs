using System.Net;
using ContactManager.FE.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactManager.FE.Mvc.Controllers;

public class ContactsController : Controller
{
    private readonly HttpClient _client;

    public ContactsController(HttpClient client)
    {
        _client = client;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var aa = await _client.GetAsync("getall");
        if (await _client.GetAsync("getall") is {StatusCode: HttpStatusCode.OK} response)
        {
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());
            return View(contacts);
        }

        return View();
    }

    public async Task<IActionResult> Create(int id)
    {
        return View();
    }
}
