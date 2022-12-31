namespace GeoHash.NetCore.GeoExtents
{
    /// <summary>
    /// Extent With Error
    /// </summary>
    internal readonly struct GeoExtentWithError
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
        /// <param name="latitudeMin">LatitudeMin</param>
        /// <param name="longitudeMin">LongitudeMin</param>
        /// <param name="latitudeMax">LatitudeMax</param>
        /// <param name="longitudeMax">LongitudeMax</param>
        /// <param name="latitudeError">LongitudeError</param>
        /// <param name="longitudeError">LatitudeError</param>
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

        public override bool Equals(object obj) => obj is GeoExtentWithError error && Equals(error);

        public override int GetHashCode() => LatitudeMin.GetHashCode() ^ LongitudeMin.GetHashCode() ^ LatitudeMax.GetHashCode() ^ LongitudeMax.GetHashCode() ^ LatitudeError.GetHashCode();

        private bool Equals(GeoExtentWithError other) => LatitudeMin.Equals(other.LatitudeMin)
                && LongitudeMin.Equals(other.LongitudeMin)
                && LatitudeMax.Equals(other.LatitudeMax)
                && LongitudeMax.Equals(other.LongitudeMax)
                && LatitudeError.Equals(other.LatitudeError)
                && LongitudeError.Equals(other.LongitudeError);
    }
}
