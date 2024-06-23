using ContactManager.Service.Configuration;
using ContactManager.Service.Model;
using Google.Maps;
using Google.Maps.StaticMaps;

namespace ContactManager.Service.Extensions;

// This extensions get the map location in each address
public static class ContactExtentions
{
    public static async Task<Stream> FetchMapFromAddress(this Contact contact, Maps maps)
    {
        GoogleSigned.AssignAllServices(new GoogleSigned(maps.ApiKey));

        var map = new StaticMapRequest();
        map.Center = new Location(contact.Address);
        map.Size = new Google.Maps.MapSize(400, 400);
        map.Zoom = 16;
        map.Format = GMapsImageFormats.PNG;
        map.MapType = Enum.TryParse<MapTypes>(maps.MapType, out var mapType)
            ? mapType : MapTypes.Hybrid;
        var mapService = new StaticMapService();
        return await mapService.GetStreamAsync(map);
    }
}
