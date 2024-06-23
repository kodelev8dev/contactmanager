using ContactManager.FE.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ContactManager.FE.Mvc.Controllers;

public class ContactsController : Controller
{
    private readonly HttpClient _client;

    public ContactsController(HttpClient client)
    {
        _client = client;
    }

    // GET
    // Funtionalities of Contac controller

    // Index  returns all records from contacts or the search records from contacts
    public async Task<IActionResult> Index(string? searchString)
    {

        if (!String.IsNullOrEmpty(searchString))
        {
            if (await _client.GetAsync("GetBySearchCriteria?searchString=" + searchString) is { StatusCode: HttpStatusCode.OK } serresponse)
            {
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(await serresponse.Content.ReadAsStringAsync());

                return View(contacts);
            }
        }

        if (await _client.GetAsync("getall") is { StatusCode: HttpStatusCode.OK } response)
        {
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());
            return View(contacts);
        }

        return View();
    }

    // Create -  return to create page
    public IActionResult Create()
    {
        return View();
    }

    // Create allows to create new contact
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

    // Edit -  return to create Edit
    public async Task<IActionResult> Edit(int id)
    {
        if (await _client.GetAsync("GetById?id=" + id) is { StatusCode: HttpStatusCode.OK } response)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(await response.Content.ReadAsStringAsync());
            return View(contact);
        }

        return View();
    }

    // Edit allows to update  contact
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

    // Edit allows to update  contact
    public async Task<IActionResult> Delete(int id)
    {
        await _client.PostAsync($"deletecontact?id={id}", new StringContent(String.Empty));
        return RedirectToAction("Index", "Contacts");
    }

    // Map - get Address location on google maps and return to image
    public async Task<IActionResult> Map(int id)
    {
        if (await _client.GetAsync("GetContactMap?id=" + id) is { StatusCode: HttpStatusCode.OK } response)
        {
            var mapPng = await response.Content.ReadAsStreamAsync();
            return File(mapPng, "image/png");
        }
        return NotFound();
    }
}
