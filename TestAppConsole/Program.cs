using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;
using System;

namespace TestAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinate = new GeoCoordinate(28.97609711, 41.01177049);
            var encoder = new GeoHashEncoder<string>();
            var geoHash = encoder.Encode(
                geoCoord: coordinate,
                precision: GeoHashPrecision.MaximumPrecision
                );
            Console.WriteLine($"{coordinate} -> {geoHash}");

            var hash = "sxk973ysmhx6";
            var decoder = new GeoHashDecoder<object>();
            var geoCoordinate = decoder.Decode(hash);
            Console.WriteLine($"{hash} -> {geoCoordinate}");

            Console.ReadLine();
        }
    }
}
