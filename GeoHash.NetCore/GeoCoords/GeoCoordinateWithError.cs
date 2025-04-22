namespace GeoHash.NetCore.GeoCoords;

/// <summary>
/// Coordinate With Error
/// </summary>
internal readonly struct GeoCoordinateWithError
{
    /// <summary>
    /// Latitude
    /// </summary>
    public double Latitude { get; }

    /// <summary>
    /// Longitude
    /// </summary>
    public double Longitude { get; }

    /// <summary>
    /// Latitude error
    /// </summary>
    public double LatitudeError { get; }

    /// <summary>
    /// Longitude error
    /// </summary>
    public double LongitudeError { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="latitude">Latitude</param>
    /// <param name="longitude">Longitude</param>
    /// <param name="latitudeError">Latitude error</param>
    /// <param name="longitudeError">Longitude error</param>
    public GeoCoordinateWithError(double latitude, double longitude, double latitudeError, double longitudeError)
    {
        Latitude = latitude;
        Longitude = longitude;
        LongitudeError = latitudeError;
        LatitudeError = longitudeError;
    }

    public override string ToString() => $"{Latitude} {Longitude}".Replace(",", ".").Replace(" ", ",");

    public override bool Equals(object obj) => obj is GeoCoordinateWithError error && Equals(error);

    public override int GetHashCode() => Latitude.GetHashCode() ^ Longitude.GetHashCode() ^ LatitudeError.GetHashCode() ^ LongitudeError.GetHashCode();

    private bool Equals(GeoCoordinateWithError other) => Latitude.Equals(other.Latitude)
            && Longitude.Equals(other.Longitude)
            && LatitudeError.Equals(other.LatitudeError)
            && LongitudeError.Equals(other.LongitudeError);
}
