namespace ContactManager.Service.Configuration;

public class Maps
{
    public string ApiKey { get; set; }
    public int Zoom { get; set; } // 0 - 22 Higher more zoomed in
    public string MapType { get; set; } // roadmap, satellite, terrain, hybrid
}
