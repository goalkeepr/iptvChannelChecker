using System.Text.RegularExpressions;

namespace iptvChannelChecker.Windows.Forms
{
    public partial class ErrorHandling
    {
        /// <summary>
        ///     Formats the type of the error.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        /// <returns>Returns string of error type</returns>
        public static string FormatErrorType(string errorType)
        {
            return Regex.Replace(errorType.Replace("System.", string.Empty), "([A-Z])", " $1",
                RegexOptions.Compiled).Trim();
        }
    }
}