using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.GeoExtents;

namespace GeoHash.NetCore.Extensions;

/// <summary>
/// GeoHash Extensions
/// </summary>
public static class GeoHashExtensions
{
    /// <summary>
    /// Generate WKT polygon
    /// </summary>
    /// <param name="geoExtent">Extent</param>
    /// <returns>string</returns>
    public static string ToWktPolygon(this GeoExtent geoExtent) => $"POLYGON (({geoExtent.LongitudeMin} {geoExtent.LatitudeMin}-{geoExtent.LongitudeMax} {geoExtent.LatitudeMin}-{geoExtent.LongitudeMax} {geoExtent.LatitudeMax}-{geoExtent.LongitudeMin} {geoExtent.LatitudeMax}-{geoExtent.LongitudeMin} {geoExtent.LatitudeMin}))".Replace(",", ".").Replace("-", ",");

    /// <summary>
    /// Generate WKT point
    /// </summary>
    /// <param name="geoCoordinate">Coordinate</param>
    /// <returns>string</returns>
    public static string ToWktPoint(this GeoCoordinate geoCoordinate) => $"POINT ({geoCoordinate.Longitude} {geoCoordinate.Latitude})".Replace(",", ".");
}
