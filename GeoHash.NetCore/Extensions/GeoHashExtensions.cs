using GeoHash.Net.GeoCoords;

namespace GeoHash.NetCore.Extensions
{
    public static class GeoHashExtensions
    {
        public static string ToWKTPolygon(this GeoExtent geoExtend) => $"POLYGON (({geoExtend.LongitudeMin} {geoExtend.LatitudeMin}-{geoExtend.LongitudeMax} {geoExtend.LatitudeMin}-{geoExtend.LongitudeMax} {geoExtend.LatitudeMax}-{geoExtend.LongitudeMin} {geoExtend.LatitudeMax}-{geoExtend.LongitudeMin} {geoExtend.LatitudeMin}))".Replace(",", ".").Replace("-", ",");
        
        public static string ToWKTPoint(this GeoCoordinate geoCoordinate) => $"POINT ({geoCoordinate.Longitude} {geoCoordinate.Latitude})".Replace(",", ".");
    }
}
