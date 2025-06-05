using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.Common.Extensions;

public static class LocationExtensions
{
    public static void Update(
        this Location location,
        string name,
        string address,
        double longitude,
        double latitude
    )
    {
        location.Name = name;
        location.Address = address;
        location.Longitude = longitude;
        location.Latitude = latitude;
    }
}
