namespace GeoHash.NetCore.GeoCoords;

/// <summary>
/// Coordinate
/// </summary>
public readonly struct GeoCoordinate
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
    /// Constructor
    /// </summary>
    /// <param name="latitude">Latitude</param>
    /// <param name="longitude">Longitude</param>
    public GeoCoordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    /// <summary>
    /// To string
    /// </summary>
    /// <returns>string</returns>
    public override string ToString() => $"{Latitude} {Longitude}".Replace(",", ".").Replace(" ", ",");

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns>bool</returns>
    public override bool Equals(object obj) => obj is GeoCoordinate coordinate && Equals(coordinate);

    /// <summary>
    /// Get hash code
    /// </summary>
    /// <returns>int</returns>
    public override int GetHashCode() => Latitude.GetHashCode() ^ Longitude.GetHashCode();

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other">Other</param>
    /// <returns>bool</returns>
    private bool Equals(GeoCoordinate other) => Latitude.Equals(other.Latitude)
            && Longitude.Equals(other.Longitude);

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="left">Left</param>
    /// <param name="right">Right</param>
    /// <returns>bool</returns>
    public static bool operator ==(GeoCoordinate left, GeoCoordinate right) => left.Equals(right);

    /// <summary>
    /// Not equals
    /// </summary>
    /// <param name="left">Left</param>
    /// <param name="right">Right</param>
    /// <returns>bool</returns>
    public static bool operator !=(GeoCoordinate left, GeoCoordinate right) => !(left == right);
}
