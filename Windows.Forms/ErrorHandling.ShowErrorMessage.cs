using System;
using System.Windows.Forms;

namespace iptvChannelChecker.Windows.Forms
{
    /// <summary>
    ///     Provides static classes for handling Exceptions in Windows apps.
    /// </summary>
    public partial class ErrorHandling
    {
        /// <summary>
        ///     This value determines whether the application will close after an exception is thrown.
        /// </summary>
        public static bool ExitOnError;

        /// <summary>
        ///     Shows the error message.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="message">The message.</param>
        /// <param name="exit">
        ///     True if application should exit.
        ///     If False then the ExitOnError global will determine if the application should exit.
        /// </param>
        public static void ShowErrorMessage(string caption, string message, bool exit = false)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (ExitOnError || exit) Environment.Exit(-1);
        }

        /// <summary>
        ///     Shows the error message.
        /// </summary>
        /// <param name="ex">The exception thrown.</param>
        public static void ShowErrorMessage(Exception ex)
        {
            ShowErrorMessage(FormatErrorType(ex.GetType().ToString()), ex.Message);
        }
    }
}