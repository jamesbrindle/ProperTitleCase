using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Experimental.IO;

namespace System
{
    /// <summary>
    /// Extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Determines whether the specified item is in a collection of items.
        /// </summary>
        /// <typeparam name="T">The type of the elements to be checked.</typeparam>
        /// <param name="item">The item to locate in the collection.</param>
        /// <param name="items">The collection of items in which to locate the item.</param>
        /// <returns>true if the item is found in the collection; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the collection of items is null.</exception>
        internal static bool In<T>(this T item, params T[] items)
        {
            // Check if the 'items' array is null, if so, throw an ArgumentNullException.
            if (items == null)
                throw new ArgumentNullException("items");

            // Use the 'Contains' method of the array to check if 'item' exists within 'items'.
            // Returns true if 'item' is found; otherwise, returns false.
            return items.Contains(item);
        }


        /// <summary>
        /// Reads the content of a file and returns it as a UTF-8 string.
        /// </summary>
        /// <param name="fileName">The path to the file to be read.</param>
        /// <returns>A string containing the file contents in UTF-8 encoding.</returns>
        public static string ReadFileAsUtf8(string fileName)
        {
            // Initialize a variable to hold the detected encoding of the file.
            Encoding encoding = Encoding.Default;
            // Initialize a variable to hold the original content of the file.
            String original = String.Empty;

            // Open a StreamReader to read from the file. It starts with the assumption that the file's encoding is the system's default.
            using (StreamReader sr = new StreamReader(LongPathCommon.NormalizeLongPath(fileName), Encoding.Default))
            {
                // Read the entire file's content into the 'original' variable.
                original = sr.ReadToEnd();
                // Detect and assign the actual encoding of the file to the 'encoding' variable.
                encoding = sr.CurrentEncoding;
                // Explicitly close the StreamReader object.
                sr.Close();
            }

            // Check if the detected encoding is already UTF-8.
            if (encoding == Encoding.UTF8)
                return original; // If it is, return the original content without conversion.

            // If the encoding is not UTF-8, get the bytes of the original content in the detected encoding.
            byte[] encBytes = encoding.GetBytes(original);
            // Convert those bytes from the detected encoding to UTF-8.
            byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encBytes);
            // Return the converted bytes as a UTF-8 string.
            return Encoding.UTF8.GetString(utf8Bytes);
        }
    }
}
