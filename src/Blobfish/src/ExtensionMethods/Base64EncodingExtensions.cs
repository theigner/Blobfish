namespace Blobfish
{
    using System;
    using System.Collections.Generic;

    internal static class Base64EncodingExtensions
    {
        internal static string ToBase64String(this IList<int> source)
        {
            Guard.AgainstNull(nameof(source), source);
        
            if (source.Count == 0)
            {
                return string.Empty;
            }

            int int32Size = sizeof(int);
            byte[] targetBytes = new byte[source.Count * int32Size];

            for (int i = 0; i < source.Count; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(source[i]), 0, targetBytes, i * int32Size, int32Size);
            }

            return Convert.ToBase64String(targetBytes);
        }

        internal static string ToBase64String(this IList<long> source)
        {
            Guard.AgainstNull(nameof(source), source);

            if (source.Count == 0)
            {
                return string.Empty;
            }

            int int64Size = sizeof(long);
            byte[] targetBytes = new byte[source.Count * int64Size];

            for (int i = 0; i < source.Count; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(source[i]), 0, targetBytes, i * int64Size, int64Size);
            }

            return Convert.ToBase64String(targetBytes);
        }

        internal static string ToBase64String(this IList<float> source)
        {
            Guard.AgainstNull(nameof(source), source);

            if (source.Count == 0)
            {
                return string.Empty;
            }

            int float32Size = sizeof(float);
            byte[] targetBytes = new byte[source.Count * float32Size];

            for (int i = 0; i < source.Count; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(source[i]), 0, targetBytes, i * float32Size, float32Size);
            }

            return Convert.ToBase64String(targetBytes);
        }

        internal static string ToBase64String(this IList<double> source)
        {
            Guard.AgainstNull(nameof(source), source);

            if (source.Count == 0)
            {
                return string.Empty;
            }

            int float64Size = sizeof(double);
            byte[] targetBytes = new byte[source.Count * float64Size];

            for (int i = 0; i < source.Count; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(source[i]), 0, targetBytes, i * float64Size, float64Size);
            }

            return Convert.ToBase64String(targetBytes);
        }

        internal static int[] ToIntArray(this string value)
        {
            Guard.AgainstNull(nameof(value), value);

            if (value == string.Empty)
            {
                return Array.Empty<int>();
            }

            byte[] sourceBytes = Convert.FromBase64String(value);

            int int32Size = sizeof(int);
            if (sourceBytes.Length % int32Size != 0)
            {
                throw new ArgumentException("The byte-length of the source string is not suitable to be converted to values of type int.", nameof(value));
            }

            int resultArrayLength = sourceBytes.Length / int32Size;
            int[] resultArray = new int[resultArrayLength];

            for (int i = 0; i < resultArrayLength; i++)
            {
                resultArray[i] = BitConverter.ToInt32(sourceBytes, i * int32Size);
            }

            return resultArray;
        }

        internal static long[] ToLongArray(this string value)
        {
            Guard.AgainstNull(nameof(value), value);

            if (value == string.Empty)
            {
                return Array.Empty<long>();
            }

            byte[] sourceBytes = Convert.FromBase64String(value);

            int int64Size = sizeof(long);
            if (sourceBytes.Length % int64Size != 0)
            {
                throw new ArgumentException("The byte-length of the source string is not suitable to be converted to values of type long.", nameof(value));
            }

            int resultArrayLength = sourceBytes.Length / int64Size;
            long[] resultArray = new long[resultArrayLength];

            for (int i = 0; i < resultArrayLength; i++)
            {
                resultArray[i] = BitConverter.ToInt64(sourceBytes, i * int64Size);
            }

            return resultArray;
        }

        public static float[] ToFloatArray(this string value)
        {
            Guard.AgainstNull(nameof(value), value);

            if (value == string.Empty)
            {
                return Array.Empty<float>();
            }

            byte[] sourceBytes = Convert.FromBase64String(value);

            int float32Size = sizeof(float);
            if (sourceBytes.Length % float32Size != 0)
            {
                throw new ArgumentException("The byte-length of the source string is not suitable to be converted to values of type float.", nameof(value));
            }

            int resultArrayLength = sourceBytes.Length / float32Size;
            float[] resultArray = new float[resultArrayLength];

            for (int i = 0; i < resultArrayLength; i++)
            {
                resultArray[i] = BitConverter.ToSingle(sourceBytes, i * float32Size);
            }

            return resultArray;
        }

        public static double[] ToDoubleArray(this string value)
        {
            Guard.AgainstNull(nameof(value), value);

            if (value == string.Empty)
            {
                return Array.Empty<double>();
            }

            byte[] sourceBytes = Convert.FromBase64String(value);

            int float64Size = sizeof(double);
            if (sourceBytes.Length % float64Size != 0)
            {
                throw new ArgumentException("The byte-length of the source string is not suitable to be converted to values of type double.", nameof(value));
            }

            int resultArrayLength = sourceBytes.Length / float64Size;
            double[] resultArray = new double[resultArrayLength];

            for (int i = 0; i < resultArrayLength; i++)
            {
                resultArray[i] = BitConverter.ToDouble(sourceBytes, i * float64Size);
            }

            return resultArray;
        }
    }
}
