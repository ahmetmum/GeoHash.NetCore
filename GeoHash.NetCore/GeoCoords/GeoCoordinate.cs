namespace GeoHash.Net.GeoCoords
{
    public struct GeoCoordinate
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString() => $"{Latitude} {Longitude}".Replace(",", ".").Replace(" ", ",");

        public override bool Equals(object other) => other is GeoCoordinate && Equals((GeoCoordinate)other);

        public override int GetHashCode() => Latitude.GetHashCode() ^ Longitude.GetHashCode();

        private bool Equals(GeoCoordinate other) => Latitude.Equals(other.Latitude)
                && Longitude.Equals(other.Longitude);
    }
}
