using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;
using GeoHash.Net.Utilities.Matchers;
using System;
using System.Collections.Generic;

namespace TestAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lat/Lon to GeoHash
            var coordinate = new GeoCoordinate(41.01177049, 28.97609711);
            var encoder = new GeoHashEncoder<string>();
            var geoHash = encoder.Encode(
                geoCoord: coordinate,
                precision: GeoHashPrecision.MaximumPrecision
                );
            Console.WriteLine($"{coordinate} -> {geoHash}");
            #endregion

            #region GeoHash to Lat/Lon
            var hash = "sxk973ysmhx6";
            var decoder = new GeoHashDecoder<string>();
            var geoCoordinate = decoder.Decode(hash);
            Console.WriteLine($"{hash} -> {geoCoordinate}");
            #endregion

            #region Is match  
            var matcher = new GeoHashMatcher<string>();
            var isMatch = matcher.IsMatch("r3gx4", "r3gx41tj0g40", GeoHashPrecision.Level5);
            Console.WriteLine($"is match : {isMatch}");
            #endregion

            #region Muliple matches
            var matches = matcher.GetMatches("r3gx4", new List<string>{
                "r3gx41tj0g40",
                "r3gx41tj0g42",
                "r4gx41tj0g42",
            }, GeoHashPrecision.Level5);
            foreach (var matched in matches)
                Console.WriteLine($"is matched : {matched}");
            #endregion

            Console.ReadLine();
        }
    }
}
