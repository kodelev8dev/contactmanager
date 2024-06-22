using System.ComponentModel.DataAnnotations;

namespace ContactManager.FE.Mvc.Models;

//create a record of contact
public class Contact
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The email address is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The email address is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    public string Phone { get; set; }

    [StringLength(500, ErrorMessage = "Address is too long")]
    public string Address { get; set; }

    [StringLength(1000, ErrorMessage = "Notes is too long")]
    public string Notes { get; set; }
}
