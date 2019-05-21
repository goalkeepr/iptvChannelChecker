using System;
using System.Runtime.InteropServices;

namespace iptvChannelChecker.Windows.Forms
{
    public static partial class UI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        ///     Sets the window visibility.  This method can be used to hide a window.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        /// <param name="windowTitle">The window title.</param>
        public static void SetWindowVisibility(bool visible, string windowTitle)
        {
            var hWnd = FindWindow(null, windowTitle);

            if (hWnd != IntPtr.Zero)
            {
                if (!visible)
                    //Hide the window                    
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE                
                else
                    //Show window again                    
                    ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA           
            }
        }
    }
}