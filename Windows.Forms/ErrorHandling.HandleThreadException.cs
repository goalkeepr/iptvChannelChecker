using System.Threading;

namespace iptvChannelChecker.Windows.Forms
{
    public partial class ErrorHandling
    {
        /// <summary>
        ///     Handles the thread exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs" /> instance containing the event data.</param>
        public static void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowErrorMessage(e.Exception);
        }
    }
}