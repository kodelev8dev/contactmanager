using System.Net;
using System.Text;
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
        if (await _client.GetAsync("getall") is {StatusCode: HttpStatusCode.OK} response)
        {
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());
            return View(contacts);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (!ModelState.IsValid) return View(contact);

        var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("addcontact", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "Contacts");
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (await _client.GetAsync("GetById?id=" + id) is {StatusCode: HttpStatusCode.OK} response)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(await response.Content.ReadAsStringAsync());
            return View(contact);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Contact contact)
    {
        if (!ModelState.IsValid) return View(contact);

        var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("updatecontact", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "Contacts");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _client.PostAsync($"deletecontact?id={id}", new StringContent(String.Empty));
        return RedirectToAction("Index", "Contacts");
    }

    public async Task<IActionResult> Map(int id)
    {
        if (await _client.GetAsync("GetContactMap?id=" + id) is {StatusCode: HttpStatusCode.OK} response)
        {
            var mapPng = await response.Content.ReadAsStreamAsync();
            return File(mapPng, "image/png");
        }
        return NotFound();
    }
}
