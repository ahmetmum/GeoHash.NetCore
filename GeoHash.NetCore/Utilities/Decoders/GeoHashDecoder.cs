using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.GeoExtents;
using GeoHash.NetCore.Helpers;
using GeoHash.NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoHash.NetCore.Utilities.Decoders
{
    /// <summary>
    /// GeoHash Decoder
    /// </summary>
    /// <typeparam name="TKey">Key</typeparam>
    public class GeoHashDecoder<TKey> : BaseDecoder, IGeoHashDecoder<TKey>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GeoHashDecoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetDecodeMap()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bits">Bits</param>
        /// <param name="decodeMap">Decode map</param>
        public GeoHashDecoder(int[] bits, IReadOnlyDictionary<char, int> decodeMap) : base(bits, decodeMap) { }

        /// <summary>
        /// Decode as tuple
        /// </summary>
        /// <param name="geoHash">GeoHash</param>
        /// <returns>Tuple</returns>
        public Tuple<double, double> DecodeAsTuple(string geoHash)
        {
            var decoded = Decode(geoHash);
            return Tuple.Create(decoded.Latitude, decoded.Longitude);
        }

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>GeoCoordinate[]</returns>
        public IEnumerable<GeoCoordinate> Decode(IEnumerable<string> geoHashes) => geoHashes.AsParallel().Select(Decode);

        /// <summary>
        /// Decode to extent
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>GeoExtent[]</returns>
        public IEnumerable<GeoExtent> DecodeToExtent(IEnumerable<string> geoHashes) => geoHashes.AsParallel().Select(DecodeToExtent);

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>KeyValuePair[]</returns>
        public IEnumerable<KeyValuePair<TKey, GeoCoordinate>> Decode(IEnumerable<KeyValuePair<TKey, string>> geoHashes) => geoHashes.AsParallel().Select(geoHash => new KeyValuePair<TKey, GeoCoordinate>(geoHash.Key, Decode(geoHash.Value)));

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>Dictionary</returns>
        public IDictionary<TKey, GeoCoordinate> Decode(IDictionary<TKey, GeoCoordinate> geoHashes) => Decode(geoHashes.Cast<KeyValuePair<TKey, string>>()).ToDictionary(x => x.Key, x => x.Value);
    }
}
