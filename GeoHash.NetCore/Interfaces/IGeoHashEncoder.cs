using GeoHash.NetCore.Enums;
using GeoHash.NetCore.GeoCoords;
using System.Collections.Generic;

namespace GeoHash.NetCore.Interfaces;

/// <summary>
/// GeoHash Encoder Interface
/// </summary>
/// <typeparam name="TKey">Key</typeparam>
public interface IGeoHashEncoder<TKey>
{
    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="latitude">Latitude</param>
    /// <param name="longitude">Longitude</param>
    /// <param name="precision">Precision</param>
    /// <returns>string</returns>
    string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision);

    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="geoCoordinate">Coordinate</param>
    /// <param name="precision">Precision</param>
    /// <returns>string</returns>
    string Encode(GeoCoordinate geoCoordinate, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision);

    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="geoCoordinates">Coordinates</param>
    /// <param name="precision">Precision</param>
    /// <returns>KeyValuePair[]</returns>
    IEnumerable<KeyValuePair<TKey, string>> Encode(IEnumerable<KeyValuePair<TKey, GeoCoordinate>> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision);

    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="geoCoordinates">Coordinates</param>
    /// <param name="precision">Precision</param>
    /// <returns>string[]</returns>
    IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision);

    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="geoCoordinates">Coordinates</param>
    /// <param name="precision">Precision</param>
    /// <returns>Dictionary</returns>
    IDictionary<TKey, string> Encode(IDictionary<TKey, GeoCoordinate> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision);
}
