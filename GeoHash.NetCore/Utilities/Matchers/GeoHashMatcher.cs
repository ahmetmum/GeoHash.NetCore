using GeoHash.NetCore.Enums;
using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.Interfaces;
using GeoHash.NetCore.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoHash.NetCore.Utilities.Matchers;

/// <summary>
/// GeoHash Matcher
/// </summary>
/// <typeparam name="TKey">Key</typeparam>
public class GeoHashMatcher<TKey> : IGeoHashMatcher<TKey>
{
    private readonly IGeoHashEncoder<TKey> _encoder;

    /// <summary>
    /// Constructor
    /// </summary>
    public GeoHashMatcher() : this(new GeoHashEncoder<TKey>()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="encoder">Encoder</param>
    public GeoHashMatcher(IGeoHashEncoder<TKey> encoder) => _encoder = encoder;

    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source coordinate</param>
    /// <param name="comparer">Comparer</param>
    /// <param name="precision">Precision</param>
    /// <returns>bool</returns>
    public bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision)
    {
        var sourceGeoHash = _encoder.Encode(source);
        var comparerGeoHash = _encoder.Encode(comparer);

        return IsMatch(sourceGeoHash, comparerGeoHash, precision);
    }

    /// <summary>
    /// IsMatch
    /// </summary>
    /// <param name="source">Source (source >= precision)</param>
    /// <param name="comparer">Comparer (comparer >= precision)</param>
    /// <param name="precision">Precision</param>
    /// <returns>Boolean</returns>
    /// <exception cref="ArgumentOutOfRangeException">Argument out of range</exception>
    /// <exception cref="ArgumentNullException">Argument null</exception>
    public bool IsMatch(string source, string comparer, GeoHashPrecision precision)
    {
        if (source.Length < (int)precision)
            throw new ArgumentOutOfRangeException(nameof(source), $"Should be greater than or equal to {nameof(precision)}.");

        if (comparer.Length < (int)precision)
            throw new ArgumentOutOfRangeException(nameof(comparer), $"Should be greater than or equal to {nameof(precision)}.");

        if (string.IsNullOrEmpty(source))
            throw new ArgumentNullException(nameof(source));

        if (string.IsNullOrEmpty(comparer))
            throw new ArgumentNullException(nameof(comparer));

        if (source.Length < (int)GeoHashPrecision.LevelMinimumPrecision || source.Length > (int)GeoHashPrecision.LevelMaximumPrecision)
            throw new ArgumentOutOfRangeException(nameof(source), "Must have a length between 1 and 12.");

        if (comparer.Length < (int)GeoHashPrecision.LevelMinimumPrecision || comparer.Length > (int)GeoHashPrecision.LevelMaximumPrecision)
            throw new ArgumentOutOfRangeException(nameof(comparer), "Must have a length between 1 and 12.");


        /* 
         * If the source length is greater than the precision, we'll truncate it 
         * so that we can do a "StartsWith" to determine if it's a match.
         */
        if (source.Length > (int)precision)
            source = source[..(int)precision];

        return comparer.StartsWith(source, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Get matches
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="comparers">Comparer list</param>
    /// <param name="precision">Precision</param>
    /// <returns>string[]</returns>
    /// <exception cref="ArgumentNullException">Argument null</exception>
    public IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision)
    {
        if (comparers == null)
            throw new ArgumentNullException(nameof(comparers));

        source = source[..(int)precision];
        return comparers.AsParallel().Where(x => IsMatch(source, x, precision));
    }

    /// <summary>
    /// Get Matches
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="comparers">Comparer list</param>
    /// <param name="precision">Precision</param>
    /// <returns>KeyValuePair[]</returns>
    /// <exception cref="ArgumentNullException">Argument null</exception>
    public IEnumerable<KeyValuePair<TKey, string>> GetMatches(string source, IEnumerable<KeyValuePair<TKey, string>> comparers, GeoHashPrecision precision)
    {
        if (comparers == null)
            throw new ArgumentNullException(nameof(comparers));

        source = source[..(int)precision];
        return comparers.AsParallel().Where(x => IsMatch(source, x.Value, precision));
    }
}
