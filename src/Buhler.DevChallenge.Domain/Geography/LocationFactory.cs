using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Domain.Geography;

public class LocationFactory
{
    private readonly GeometryFactory _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

    public Point CreatePoint(double latitude, double longitude)
    {
        return _geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
    }
}