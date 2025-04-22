using GeoHash.NetCore.Enums;
using System;
using System.Text;

namespace GeoHash.NetCore.Utilities.Encoders;

/// <summary>
/// Encoder Base
/// </summary>
public abstract class BaseEncoder
{
    private readonly int[] _bits;
    private readonly char[] _base32;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bits">Bits</param>
    /// <param name="base32Chars">Base 32 chars</param>
    protected BaseEncoder(int[] bits, char[] base32Chars)
    {
        _bits = bits;
        _base32 = base32Chars;
    }

    /// <summary>
    /// Encode
    /// </summary>
    /// <param name="latitude">Latitude (min: -90, max: 90)</param>
    /// <param name="longitude">Longitude (min: -180, max: 180)</param>
    /// <param name="precision">Precision (default Level12:~ 3.7cm x 1.8cm)</param>
    /// <returns>string</returns>
    /// <exception cref="ArgumentOutOfRangeException">Argument out of range</exception>
    public string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.Level12)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "Must be between -90 and 90.");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "Must be between -180 and 180.");

        double latMin = -90, latMax = 90;
        double lngMin = -180, lngMax = 180;

        var geoHash = new StringBuilder();
        var isEven = true;
        int bit = 0, ch = 0;

        while (geoHash.Length < (int)precision)
        {
            double midPoint;
            if (isEven)
            {
                midPoint = (lngMin + lngMax) / 2;
                if (longitude > midPoint)
                {
                    ch |= _bits[bit];
                    lngMin = midPoint;
                }
                else
                {
                    lngMax = midPoint;
                }
            }
            else
            {
                midPoint = (latMin + latMax) / 2;
                if (latitude > midPoint)
                {
                    ch |= _bits[bit];
                    latMin = midPoint;
                }
                else
                {
                    latMax = midPoint;
                }
            }

            isEven = !isEven;

            if (bit < 4)
            {
                bit++;
            }
            else
            {
                geoHash.Append(_base32[ch]);
                bit = 0;
                ch = 0;
            }
        }

        return geoHash.ToString();
    }
}
