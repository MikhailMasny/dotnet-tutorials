namespace Masny.DotNet.Crud.Constants
{
    /// <summary>
    /// Sql configuration.
    /// </summary>
    public static class SqlConfiguration
    {
        /// <summary>
        /// Custom date format.
        /// </summary>
        public const string DateFormat = "date";

        /// <summary>
        /// Custom decimal format.
        /// </summary>
        public const string DecimalFormat = "decimal(18,4)";

        /// <summary>
        /// Min lenght for string field.
        /// </summary>
        public const int MaxLengthShort = 63;

        /// <summary>
        /// Standart lenght for string field.
        /// </summary>
        public const int MaxLengthMedium = 127;

        /// <summary>
        /// Max lenght for string field.
        /// </summary>
        public const int MaxLengthLong = 255;
    }
}
