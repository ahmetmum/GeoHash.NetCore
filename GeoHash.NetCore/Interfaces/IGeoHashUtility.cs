namespace GeoHash.NetCore.Interfaces;

/// <summary>
/// GeoHash Utility Interface
/// </summary>
/// <typeparam name="TKey">Key</typeparam>
public interface IGeoHashUtility<TKey>
{
    /// <summary>
    /// Encoder
    /// </summary>
    IGeoHashEncoder<TKey> Encoder { get; }

    /// <summary>
    /// Decoder
    /// </summary>
    IGeoHashDecoder<TKey> Decoder { get; }

    /// <summary>
    /// Matcher
    /// </summary>
    IGeoHashMatcher<TKey> Matcher { get; }
}
