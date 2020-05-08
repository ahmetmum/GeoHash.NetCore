using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoHash.Net.Utilities.Decoders
{
    public class GeoHashDecoder<TKey> : BaseDecoder, IGeoHashDecoder<TKey>
    {
        public GeoHashDecoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetDecodeMap()) { }

        public GeoHashDecoder(int[] bits, IReadOnlyDictionary<char, int> decodeMap) : base(bits, decodeMap) { }

        public Tuple<double, double> DecodeAsTuple(string geoHash)
        {
            var decoded = Decode(geoHash);
            return Tuple.Create(decoded.Latitude, decoded.Longitude);
        }

        public IEnumerable<GeoCoordinate> Decode(IEnumerable<string> geoHashes) => geoHashes.AsParallel().Select(Decode);

        public IEnumerable<GeoExtent> DecodeToExtent(IEnumerable<string> geoHashes) => geoHashes.AsParallel().Select(DecodeToExtent);

        public IEnumerable<KeyValuePair<TKey, GeoCoordinate>> Decode(IEnumerable<KeyValuePair<TKey, string>> geoHashes) => geoHashes.AsParallel().Select(geoHash => new KeyValuePair<TKey, GeoCoordinate>(geoHash.Key, Decode(geoHash.Value)));

        public IDictionary<TKey, GeoCoordinate> Decode(IDictionary<TKey, GeoCoordinate> geoHashes) => Decode(geoHashes.Cast<KeyValuePair<TKey, string>>()).ToDictionary(x => x.Key, x => x.Value);
    }
}
