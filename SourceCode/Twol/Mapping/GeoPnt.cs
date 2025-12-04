namespace Twol.Mapping
{
    public struct GeoPnt
    {
        public static GeoPnt Empty = new GeoPnt();

        /// <summary>
        /// Gets or sets the longitude coordinate of a geographic location.
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the geographic location.
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPnt"/> class with the specified longitude and latitude.
        /// </summary>
        /// <remarks>This constructor creates a geographic point using the specified longitude and
        /// latitude values. Ensure that the provided values are within the valid ranges to represent a valid geographic
        /// location.</remarks>
        /// <param name="longitude">The longitude of the geographic point, in degrees. Valid values range from -180 to 180.</param>
        /// <param name="latitude">The latitude of the geographic point, in degrees. Valid values range from -90 to 90.</param>
        public GeoPnt(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
