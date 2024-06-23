using System.ComponentModel.DataAnnotations;

namespace ContactManager.FE.Mvc.Models;

//create a record of contact
public class Contact
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Email address is required")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Provide a valid EmailAddress")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The Phone number is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    public string Phone { get; set; }

    [StringLength(500, ErrorMessage = "Address is too long")]
    public string Address { get; set; }

    [StringLength(1000, ErrorMessage = "Notes is too long")]
    public string Notes { get; set; }
}
