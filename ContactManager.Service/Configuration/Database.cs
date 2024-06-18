namespace ContactManager.Service.Configuration;

public record Database
{
    public string Server { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int Port { get; set; }
}
