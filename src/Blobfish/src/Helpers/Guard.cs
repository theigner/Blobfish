namespace Blobfish
{
    using System;

    internal static class Guard
    {
        internal static void AgainstEmpty(string argumentName, string value)
        {
            if (value != null && value.Length == 0)
            {
                throw new ArgumentException($"{argumentName} is empty.", argumentName);
            }
        }

        internal static void AgainstNegativeValue(string argumentName, int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{argumentName} is < 0.", argumentName);
            }
        }

        internal static void AgainstNonNumericSeriesType(string argumentName, SeriesType seriesType)
        {
            if (seriesType != SeriesType.Int32 && seriesType != SeriesType.Int64 && seriesType != SeriesType.Float32 && seriesType != SeriesType.Float64)
            {
                throw new ArgumentException($"Value of {argumentName} is not allowed. Only numeric SeriesType is allowed.", argumentName);
            }
        }

        internal static void AgainstNull(string argumentName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        internal static void AgainstNullOrEmpty(string argumentName, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{argumentName} is null or empty.", argumentName);
            }
        }
    }
}
