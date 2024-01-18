using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Domain.Geography;

public static class LocationUtils
{
    public static Point CreatePoint(double longitude, double latitude)
    {
        // can't be an instance field because it starts producing invalid values for some reason
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        
        return geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
    }
}