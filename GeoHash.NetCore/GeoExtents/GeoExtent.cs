namespace GeoHash.NetCore.GeoExtents
{
    /// <summary>
    /// Extent
    /// </summary>
    public readonly struct GeoExtent
    {
        /// <summary>
        /// Latitude min
        /// </summary>
        public double LatitudeMin { get; }

        /// <summary>
        /// Longitude min
        /// </summary>
        public double LongitudeMin { get; }

        /// <summary>
        /// Latitude max
        /// </summary>
        public double LatitudeMax { get; }

        /// <summary>
        /// Longitude max
        /// </summary>
        public double LongitudeMax { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="latitudeMin">LatitudeMin</param>
        /// <param name="longitudeMin">LongitudeMin</param>
        /// <param name="latitudeMax">LatitudeMax</param>
        /// <param name="longitudeMax">LongitudeMax</param>
        public GeoExtent(double latitudeMin, double longitudeMin, double latitudeMax, double longitudeMax)
        {
            LatitudeMin = latitudeMin;
            LongitudeMin = longitudeMin;
            LatitudeMax = latitudeMax;
            LongitudeMax = longitudeMax;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geoExtendWithError">Extend with error</param>
        internal GeoExtent(GeoExtentWithError geoExtendWithError) : this(geoExtendWithError.LatitudeMin, geoExtendWithError.LongitudeMin, geoExtendWithError.LatitudeMax, geoExtendWithError.LongitudeMax)
        {
        }

        public override string ToString() => $"{LatitudeMin} {LongitudeMin} {LatitudeMax} {LongitudeMax}".Replace(",", ".").Replace(" ", ",");

        public override bool Equals(object obj) => obj is GeoExtent extent && Equals(extent);

        public override int GetHashCode() => LatitudeMin.GetHashCode() ^ LongitudeMin.GetHashCode() ^ LatitudeMax.GetHashCode() ^ LongitudeMax.GetHashCode();

        private bool Equals(GeoExtent other) => LatitudeMin.Equals(other.LatitudeMin)
                && LongitudeMin.Equals(other.LongitudeMin)
                && LatitudeMax.Equals(other.LatitudeMax)
                && LongitudeMax.Equals(other.LongitudeMax);
    }
}
