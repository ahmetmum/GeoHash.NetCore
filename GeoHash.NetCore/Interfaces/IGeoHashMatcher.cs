using GeoHash.NetCore.Enums;
using GeoHash.NetCore.GeoCoords;
using System.Collections.Generic;

namespace GeoHash.NetCore.Interfaces;

/// <summary>
/// GeoHash Matcher Interface
/// </summary>
/// <typeparam name="TKey">Key</typeparam>
public interface IGeoHashMatcher<TKey>
{
    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source coordinate</param>
    /// <param name="comparer">Coordinate comparer</param>
    /// <param name="precision">Precision</param>
    /// <returns>bool</returns>
    bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision);

    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="comparer">Comparer</param>
    /// <param name="precision">Precision</param>
    /// <returns>bool</returns>
    bool IsMatch(string source, string comparer, GeoHashPrecision precision);

    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="comparers">Comparer list</param>
    /// <param name="precision">Precision</param>
    /// <returns>string[]</returns>
    IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision);

    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="comparers">Comparer list</param>
    /// <param name="precision">Precision</param>
    /// <returns>KeyValuePair[]</returns>
    IEnumerable<KeyValuePair<TKey, string>> GetMatches(string source, IEnumerable<KeyValuePair<TKey, string>> comparers, GeoHashPrecision precision);
}
