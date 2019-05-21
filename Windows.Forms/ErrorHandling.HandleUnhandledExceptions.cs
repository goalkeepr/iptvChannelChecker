using System;

namespace iptvChannelChecker.Windows.Forms
{
    public partial class ErrorHandling
    {
        /// <summary>
        ///     Handles the unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        public static void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception) e.ExceptionObject;
            ShowErrorMessage(ex);
        }
    }
}