using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace iptvChannelChecker
{
    static class Utilities
    {
        public static string RemoveIllegalFileNameChars(string input, string replacement = "-")
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(input, replacement);
        }

        public static string ResolutionSuperScript(int width)
        {
            string resolutionLevelSuperScript;
            if (width > 1280)
            {
                resolutionLevelSuperScript = "ᴴ";
            }
            else if (width > 1024)
            {
                resolutionLevelSuperScript = "ʰ";
            }
            else if (width > 640)
            {
                resolutionLevelSuperScript = "ˢ";
            }
            else if (width > 0)
            {
                resolutionLevelSuperScript = "ˣ";
            }
            else
            {
                resolutionLevelSuperScript = "";
            }
            return resolutionLevelSuperScript;
        }

        public static string FrameRateSuperScript(int frameRateInt)
        {
            string frameRateSuperScript;
            switch (frameRateInt)
            {
                case 90:
                    frameRateSuperScript = "⁹⁰";
                    break;
                case 60:
                    frameRateSuperScript = "⁶⁰";
                    break;
                case 50:
                    frameRateSuperScript = "⁵⁰";
                    break;
                case 30:
                    frameRateSuperScript = "³⁰";
                    break;
                case 26:
                    frameRateSuperScript = "²⁶";
                    break;
                case 25:
                    frameRateSuperScript = "²⁵";
                    break;
                case 24:
                    frameRateSuperScript = "²⁴";
                    break;
                default:
                    frameRateSuperScript = "⁰⁰";
                    break;
            }

            return frameRateSuperScript;
        }
    }
}
