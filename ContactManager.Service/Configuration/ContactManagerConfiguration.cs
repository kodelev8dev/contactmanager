namespace ContactManager.Service.Configuration;

public class ContactManagerConfiguration
{
    public Database Database { get; set; } = new();
    public Maps Maps { get; set; } = new();
}
