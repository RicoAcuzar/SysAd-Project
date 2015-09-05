using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Class for additional string manipulation functions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Truncates the string on the desired length.
        /// </summary>
        /// <param name="value">The string to be truncated.</param>
        /// <param name="maxLength">Maximum length of the string.</param>
        /// <returns>Returns the truncated string, or the string itself if its length is less than or equal to the specified length.</returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
