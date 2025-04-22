using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.GeoExtents;
using GeoHash.NetCore.Helpers;
using System;
using System.Collections.Generic;

namespace GeoHash.NetCore.Utilities.Decoders;

/// <summary>
/// Decoder Base
/// </summary>
public abstract class BaseDecoder
{
    private readonly int[] _bits;

    private readonly IReadOnlyDictionary<char, int> _decodeMap;

    /// <summary>
    /// Constructor
    /// </summary>
    protected BaseDecoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetDecodeMap()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bits">Bits</param>
    /// <param name="decodeMap">Decode map</param>
    protected BaseDecoder(int[] bits, IReadOnlyDictionary<char, int> decodeMap)
    {
        _bits = bits;
        _decodeMap = decodeMap;
    }

    /// <summary>
    /// Decode exactly
    /// </summary>
    /// <param name="geoHash">GeoExtentWithError</param>
    /// <returns>GeoCoordinateWithError</returns>
    private GeoCoordinateWithError DecodeExactly(string geoHash)
    {
        double latMin = -90, latMax = 90;
        double lngMin = -180, lngMax = 180;

        var latErr = 90.0;
        var lngError = 180.0;
        var isEven = true;
        var size = geoHash.Length;
        var bitsSize = _bits.Length;
        for (var i = 0; i < size; i++)
        {
            var cd = _decodeMap[geoHash[i]];

            for (var j = 0; j < bitsSize; j++)
            {
                var mask = _bits[j];
                if (isEven)
                {
                    lngError /= 2;
                    if ((cd & mask) != 0)
                    {
                        lngMin = (lngMin + lngMax) / 2;
                    }
                    else
                    {
                        lngMax = (lngMin + lngMax) / 2;
                    }
                }
                else
                {
                    latErr /= 2;

                    if ((cd & mask) != 0)
                    {
                        latMin = (latMin + latMax) / 2;
                    }
                    else
                    {
                        latMax = (latMin + latMax) / 2;
                    }
                }
                isEven = !isEven;
            }
        }

        var latitude = (latMin + latMax) / 2;
        var longitude = (lngMin + lngMax) / 2;

        return new GeoCoordinateWithError(latitude, longitude, latErr, lngError);
    }

    /// <summary>
    /// Decode
    /// </summary>
    /// <param name="geoHash">GeoHash</param>
    /// <returns>GeoCoordinate</returns>
    public GeoCoordinate Decode(string geoHash)
    {
        var decodedCoords = DecodeExactly(geoHash);

        var latPrecision = Math.Max(1, Math.Round(-Math.Log10(decodedCoords.LatitudeError))) - 1;
        var lngPrecision = Math.Max(1, Math.Round(-Math.Log10(decodedCoords.LongitudeError))) - 1;

        var lat = GetPrecision(decodedCoords.Latitude, latPrecision);
        var lng = GetPrecision(decodedCoords.Longitude, lngPrecision);

        return new GeoCoordinate(lat, lng);
    }

    /// <summary>
    /// Decode exactly to extend
    /// </summary>
    /// <param name="geoHash">GeoHash</param>
    /// <returns>GeoExtentWithError</returns>
    private GeoExtentWithError DecodeExactlyToExtend(string geoHash)
    {
        double latMin = -90, latMax = 90;
        double lngMin = -180, lngMax = 180;

        var latErr = 90.0;
        var lngError = 180.0;
        var isEven = true;
        var size = geoHash.Length;
        var bitsSize = _bits.Length;
        for (var i = 0; i < size; i++)
        {
            var cd = _decodeMap[geoHash[i]];

            for (var j = 0; j < bitsSize; j++)
            {
                var mask = _bits[j];
                if (isEven)
                {
                    lngError /= 2;
                    if ((cd & mask) != 0)
                    {
                        lngMin = (lngMin + lngMax) / 2;
                    }
                    else
                    {
                        lngMax = (lngMin + lngMax) / 2;
                    }
                }
                else
                {
                    latErr /= 2;

                    if ((cd & mask) != 0)
                    {
                        latMin = (latMin + latMax) / 2;
                    }
                    else
                    {
                        latMax = (latMin + latMax) / 2;
                    }
                }
                isEven = !isEven;
            }
        }

        return new GeoExtentWithError(latMin, lngMin, latMax, lngMax, latErr, lngError);
    }

    /// <summary>
    /// Decode to extent
    /// </summary>
    /// <param name="geoHash">GeoHash</param>
    /// <returns>GeoExtent</returns>
    public GeoExtent DecodeToExtent(string geoHash) => new(DecodeExactlyToExtend(geoHash));

    /// <summary>
    /// Get precision
    /// </summary>
    /// <param name="x">X</param>
    /// <param name="precision">Precision</param>
    /// <returns>double</returns>
    private static double GetPrecision(double x, double precision)
    {
        var @base = Math.Pow(10, -precision);
        var diff = x % @base;
        return x - diff;
    }
}
