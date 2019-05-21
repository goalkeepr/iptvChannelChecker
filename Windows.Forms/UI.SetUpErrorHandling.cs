using System;
using System.Windows.Forms;

namespace iptvChannelChecker.Windows.Forms
{
    public static partial class UI
    {
        /// <summary>
        ///     Sets the up error handling for a winforms app, defaulting to not closing on thrown exceptions.
        /// </summary>
        public static void SetUpErrorHandling()
        {
            SetUpErrorHandling(false);
        }

        /// <summary>
        ///     Sets the up error handling for a winforms app.
        /// </summary>
        /// <param name="exitOnError">if set to <c>true</c> [exit the app when an exception is thrown].</param>
        public static void SetUpErrorHandling(bool exitOnError)
        {
            Application.ThreadException += ErrorHandling.HandleThreadException;
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += ErrorHandling.HandleUnhandledExceptions;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ErrorHandling.ExitOnError = exitOnError;
        }
    }
}