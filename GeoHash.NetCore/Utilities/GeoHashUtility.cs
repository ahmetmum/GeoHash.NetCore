using GeoHash.NetCore.Interfaces;
using GeoHash.NetCore.Utilities.Decoders;
using GeoHash.NetCore.Utilities.Encoders;
using GeoHash.NetCore.Utilities.Matchers;

namespace GeoHash.NetCore.Utilities
{
    /// <summary>
    /// GeoHash Utility
    /// </summary>
    /// <typeparam name="TKey">Key</typeparam>
    public class GeoHashUtility<TKey> : IGeoHashUtility<TKey>
    {
        /// <summary>
        /// Encoder
        /// </summary>
        public IGeoHashEncoder<TKey> Encoder { get; }

        /// <summary>
        /// Decoder
        /// </summary>
        public IGeoHashDecoder<TKey> Decoder { get; }

        /// <summary>
        /// Matcher
        /// </summary>
        public IGeoHashMatcher<TKey> Matcher { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GeoHashUtility() : this(new GeoHashEncoder<TKey>(), new GeoHashDecoder<TKey>(), new GeoHashMatcher<TKey>()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encoder">Encoder</param>
        /// <param name="decoder">Decoder</param>
        /// <param name="matcher">Matcher</param>
        public GeoHashUtility(IGeoHashEncoder<TKey> encoder, IGeoHashDecoder<TKey> decoder, IGeoHashMatcher<TKey> matcher)
        {
            Encoder = encoder;
            Decoder = decoder;
            Matcher = matcher;
        }
    }
}
