using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.GeoExtents;
using System;
using System.Collections.Generic;

namespace GeoHash.NetCore.Interfaces
{
    /// <summary>
    /// GeoHash Decoder Interface
    /// </summary>
    /// <typeparam name="TKey">Key</typeparam>
    public interface IGeoHashDecoder<TKey>
    {
        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHash">GeoHash</param>
        /// <returns>GeoCoordinate</returns>
        GeoCoordinate Decode(string geoHash);

        /// <summary>
        /// Decode to extent
        /// </summary>
        /// <param name="geoHash">GeoHash</param>
        /// <returns>GeoExtent</returns>
        GeoExtent DecodeToExtent(string geoHash);

        /// <summary>
        /// Decode as tuple
        /// </summary>
        /// <param name="geoHash">GeoHash</param>
        /// <returns>Tuple</returns>
        Tuple<double, double> DecodeAsTuple(string geoHash);

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes"></param>
        /// <returns>GeoCoordinate</returns>
        IEnumerable<GeoCoordinate> Decode(IEnumerable<string> geoHashes);

        /// <summary>
        /// Decode to extent
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>GeoExtent[]</returns>
        IEnumerable<GeoExtent> DecodeToExtent(IEnumerable<string> geoHashes);

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>KeyValuePair[]</returns>
        IEnumerable<KeyValuePair<TKey, GeoCoordinate>> Decode(IEnumerable<KeyValuePair<TKey, string>> geoHashes);

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="geoHashes">GeoHash list</param>
        /// <returns>Dictionary</returns>
        IDictionary<TKey, GeoCoordinate> Decode(IDictionary<TKey, GeoCoordinate> geoHashes);
    }
}
