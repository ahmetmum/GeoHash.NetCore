namespace GeoHash.Net.GeoCoords
{
    internal struct GeoExtentWithError
    {
        public double LatitudeMin { get; }

        public double LongitudeMin { get; }

        public double LatitudeMax { get; }

        public double LongitudeMax { get; }

        public double LatitudeError { get; }

        public double LongitudeError { get; }

        public GeoExtentWithError(double latitudeMin, double longitudeMin, double latitudeMax, double longitudeMax, double latitudeError, double longitudeError)
        {
            LatitudeMin = latitudeMin;
            LongitudeMin = longitudeMin;
            LatitudeMax = latitudeMax;
            LongitudeMax = longitudeMax;
            LongitudeError = latitudeError;
            LatitudeError = longitudeError;
        }

        public override string ToString() => $"{LatitudeMin} {LongitudeMin} {LatitudeMax} {LongitudeMax}".Replace(",", ".").Replace(" ", ",");

        public override bool Equals(object other) => other is GeoExtentWithError && Equals((GeoExtentWithError)other);

        public override int GetHashCode() => LatitudeMin.GetHashCode() ^ LongitudeMin.GetHashCode() ^ LatitudeMax.GetHashCode() ^ LongitudeMax.GetHashCode() ^ LatitudeError.GetHashCode();

        private bool Equals(GeoExtentWithError other) => LatitudeMin.Equals(other.LatitudeMin)
                && LongitudeMin.Equals(other.LongitudeMin)
                && LatitudeMax.Equals(other.LatitudeMax)
                && LongitudeMax.Equals(other.LongitudeMax)
                && LatitudeError.Equals(other.LatitudeError)
                && LongitudeError.Equals(other.LongitudeError);
    }
}
