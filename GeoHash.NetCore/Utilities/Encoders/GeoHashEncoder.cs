using GeoHash.NetCore.Enums;
using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.Helpers;
using GeoHash.NetCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GeoHash.NetCore.Utilities.Encoders
{
    /// <summary>
    /// GeoHash Encoder
    /// </summary>
    /// <typeparam name="TKey">Key</typeparam>
    public class GeoHashEncoder<TKey> : BaseEncoder, IGeoHashEncoder<TKey>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GeoHashEncoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetBase32Chars()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bits">Bits</param>
        /// <param name="base32Chars">Base 32 chars</param>
        public GeoHashEncoder(int[] bits, char[] base32Chars) : base(bits, base32Chars) { }

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="geoCoordinate">Coordinate</param>
        /// <param name="precision">Precision</param>
        /// <returns>string</returns>
        public string Encode(GeoCoordinate geoCoordinate, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision) => Encode(geoCoordinate.Latitude, geoCoordinate.Longitude, precision);

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="geoCoordinates">Coordinates</param>
        /// <param name="precision">Precision</param>
        /// <returns>KeyValuePair[]</returns>
        public IEnumerable<KeyValuePair<TKey, string>> Encode(IEnumerable<KeyValuePair<TKey, GeoCoordinate>> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision) => geoCoordinates.AsParallel().Select(c => new KeyValuePair<TKey, string>(c.Key, Encode(c.Value, precision)));

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="geoCoordinates">Coordinates</param>
        /// <param name="precision">Precision</param>
        /// <returns>string[]</returns>
        public IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision) => geoCoordinates.AsParallel().Select(c => Encode(c, precision));

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="geoCoordinates">Coordinates</param>
        /// <param name="precision">Precision</param>
        /// <returns>Dictionary[]</returns>
        public IDictionary<TKey, string> Encode(IDictionary<TKey, GeoCoordinate> geoCoordinates, GeoHashPrecision precision = GeoHashPrecision.LevelMaximumPrecision) => Encode(geoCoordinates.Cast<KeyValuePair<TKey, GeoCoordinate>>(), precision).ToDictionary(x => x.Key, x => x.Value);
    }
}
