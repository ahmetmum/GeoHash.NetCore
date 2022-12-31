namespace GeoHash.NetCore.GeoCoords
{
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

        public override string ToString() => $"{Latitude} {Longitude}".Replace(",", ".").Replace(" ", ",");

        public override bool Equals(object obj) => obj is GeoCoordinate coordinate && Equals(coordinate);

        public override int GetHashCode() => Latitude.GetHashCode() ^ Longitude.GetHashCode();

        private bool Equals(GeoCoordinate other) => Latitude.Equals(other.Latitude)
                && Longitude.Equals(other.Longitude);
    }
}
