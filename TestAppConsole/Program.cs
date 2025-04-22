using GeoHash.NetCore.Enums;
using GeoHash.NetCore.Extensions;
using GeoHash.NetCore.GeoCoords;
using GeoHash.NetCore.Utilities.Decoders;
using GeoHash.NetCore.Utilities.Encoders;
using GeoHash.NetCore.Utilities.Matchers;
using System;
using System.Collections.Generic;

#region Lat/Lon to GeoHash
var coordinate = new GeoCoordinate(41.01177049, 28.97609711);
var encoder = new GeoHashEncoder<string>();
var geoHash = encoder.Encode(coordinate, GeoHashPrecision.LevelMaximumPrecision);
Console.WriteLine($"GeoHash: {coordinate} -> {geoHash}");
#endregion

#region GeoHash to Lat/Lon
var hash = "sxk973ysmhx6";
var decoder = new GeoHashDecoder<string>();
var geoCoordinate = decoder.Decode(hash);
Console.WriteLine($"Coordinate: {hash} -> {geoCoordinate}");
Console.WriteLine($"WKT: {hash} -> {geoCoordinate.ToWktPoint()}");
#endregion

#region GeoHash to Extend
hash = "sxk973";
var geoExtent = decoder.DecodeToExtent(hash);
Console.WriteLine($"Extent: {hash} -> {geoExtent}");
Console.WriteLine($"WKT: {hash} -> {geoExtent.ToWktPolygon()}");
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

Console.WriteLine();
Console.WriteLine("> Press Enter to exit.");
Console.ReadLine();
