namespace GeoHash.Net.GeoCoords
{
    public struct GeoExtent
    {
        public double LatitudeMin { get; }

        public double LongitudeMin { get; }

        public double LatitudeMax { get; }

        public double LongitudeMax { get; }

        public GeoExtent(double latitudeMin, double longitudeMin, double latitudeMax, double longitudeMax)
        {
            LatitudeMin = latitudeMin;
            LongitudeMin = longitudeMin;
            LatitudeMax = latitudeMax;
            LongitudeMax = longitudeMax;
        }

        internal GeoExtent(GeoExtentWithError geoExtendWithError) : this(geoExtendWithError.LatitudeMin, geoExtendWithError.LongitudeMin, geoExtendWithError.LatitudeMax, geoExtendWithError.LongitudeMax)
        {
        }

        public override string ToString() => $"{LatitudeMin} {LongitudeMin} {LatitudeMax} {LongitudeMax}".Replace(",", ".").Replace(" ", ",");

        public override bool Equals(object other) => other is GeoExtent && Equals((GeoExtent)other);

        public override int GetHashCode() => LatitudeMin.GetHashCode() ^ LongitudeMin.GetHashCode() ^ LatitudeMax.GetHashCode() ^ LongitudeMax.GetHashCode();

        private bool Equals(GeoExtent other) => LatitudeMin.Equals(other.LatitudeMin)
                && LongitudeMin.Equals(other.LongitudeMin)
                && LatitudeMax.Equals(other.LatitudeMax)
                && LongitudeMax.Equals(other.LongitudeMax);
    }
}
