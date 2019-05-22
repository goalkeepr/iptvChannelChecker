using NReco.VideoInfo;
using System;

namespace iptvChannelChecker
{
    class ChannelEntry
    {
        public string TvgId { get; set; }
        public string TvgName { get; set; }
        public string TvgLogo { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string GroupTitle { get; set; }
        public string StreamId { get; set; }
        public string StreamUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float FrameRate { get; set; }
        public string ErrorType { get; set; }
        public string Provider { get; set; }

        public int FrameRateInt
        {
            get
            {
                return (int)Math.Round(FrameRate);
            }
        }

        public int QualityLevel
        {
            get
            {
                if (Width <= 10)
                {
                    return 0;
                }
                else if (Width > 1280)
                {
                    return 1;
                }
                else if (Width == 1280)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }

        public string StreamRatingTinyString
        {
            get
            {
                string resolutionLevelSuperScript;
                string frameRateSuperScript;
                if (Width > 1280)
                {
                    resolutionLevelSuperScript = "¹";
                }
                else if (Width == 1280)
                {
                    resolutionLevelSuperScript = "²";
                }
                else
                {
                    resolutionLevelSuperScript = "³";
                }
                switch (FrameRateInt)
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
                        frameRateSuperScript = "";
                        break;
                }

                return string.Format("⁽{0}⁻{1}⁾", resolutionLevelSuperScript, frameRateSuperScript);
            }
        }

        public ChannelEntry(string provider, string inputLine, string nextLine, string epg, string extraEpg)
        {
            Provider = provider;
            TvgId = string.Empty;
            TvgName = string.Empty;
            TvgLogo = string.Empty;
            ChannelId = string.Empty;
            ChannelName = string.Empty;
            GroupTitle = string.Empty;
            StreamId = string.Empty;
            StreamUrl = nextLine;
            ErrorType = "Skipped - No EPG";
            Width = 0;
            Height = 0;
            FrameRate = 0;

            TvgId = ExtractData(inputLine, "tvg-id").Replace(",", "-");
            TvgName = ExtractData(inputLine, "tvg-name").Replace(",", "-");
            TvgLogo = ExtractData(inputLine, "tvg-logo").Replace(",", "-");
            ChannelId = ExtractData(inputLine, "channel-id").Replace(",", "-");
            ChannelName = inputLine.Substring(inputLine.LastIndexOf(",") + 1).Replace(",", "-");
            GroupTitle = ExtractData(inputLine, "group-title").Replace(",", "-");

            if (string.IsNullOrEmpty(GroupTitle))
            {
                GroupTitle = "General";
            }


            //if (!StreamUrl.IsMappedChannel())
            //{
            //    ErrorType = "Channel Not Mapped";
            //}
            //else if (IsChannelToCheck(epg, extraEpg))
            //{
            try
            {
                ErrorType = "Bad Stream";
                var ffProbe = new FFProbe();

                ffProbe.ExecutionTimeout = new TimeSpan(0, 0, 10);
                var videoInfo = ffProbe.GetMediaInfo(string.Concat("\"", nextLine, "\""));
                //var videoInfo = ffProbe.GetMediaInfo(nextLine);
                //var videoInfo = ffProbe.GetMediaInfo(nextLine.Replace("@", "%40"));

                //Console.WriteLine("Media information for: {0}", nextLine);
                //Console.WriteLine("File format: {0}", videoInfo.FormatName);
                //Console.WriteLine("Duration: {0}", videoInfo.Duration);
                //foreach (var tag in videoInfo.FormatTags)
                //{
                //    Console.WriteLine("\t{0}: {1}", tag.Key, tag.Value);
                //}

                //foreach (var stream in videoInfo.Streams)
                //{
                //    Console.WriteLine("Stream {0} ({1})", stream.CodecName, stream.CodecType);
                //    if (stream.CodecType == "video")
                //    {
                //        Console.WriteLine("\tFrame size: {0}x{1}", stream.Width, stream.Height);
                //        Console.WriteLine("\tFrame rate: {0:0.##}", stream.FrameRate);
                //    }
                //    foreach (var tag in stream.Tags)
                //    {
                //        Console.WriteLine("\t{0}: {1}", tag.Key, tag.Value);
                //    }
                //}

                var stream = videoInfo.Streams[0];
                Width = stream.Width;
                Height = stream.Height;
                FrameRate = stream.FrameRate;
                //Console.WriteLine("\tFrame size: {0}x{1}", stream.Width, stream.Height);
                //Console.WriteLine("\tFrame rate: {0:0.##}", stream.FrameRate);
                if (Width > 0)
                {
                    ErrorType = string.Empty;
                }
                //else
                //{                        
                //    videoInfo = ffProbe.GetMediaInfo(nextLine);
                //    foreach(var subsStream in videoInfo.Streams)
                //    {
                //        Width = stream.Width;
                //        Height = stream.Height;
                //        FrameRate = stream.FrameRate;

                //        if (Width > 0)
                //            break;
                //    }
                //    //stream = videoInfo.Streams[0];


                //    if (Width > 0)
                //    {
                //        ErrorType = string.Empty;
                //    }
                //}
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("403 Forbidden"))
                {
                    Width = 1;
                    Height = 1;
                    FrameRate = 1;
                    System.Threading.Thread.Sleep(5000);
                }
                try
                {
                    ErrorType = "Bad Stream";
                    var ffProbe = new FFProbe();

                    ffProbe.ExecutionTimeout = new TimeSpan(0, 0, 10);
                    var videoInfo = ffProbe.GetMediaInfo(nextLine);

                    var stream = videoInfo.Streams[0];
                    Width = stream.Width;
                    Height = stream.Height;
                    FrameRate = stream.FrameRate;
                    if (Width > 0)
                    {
                        ErrorType = string.Empty;
                    }
                }
                catch (Exception ex1)
                {
                    if (ex1.Message.Contains("403 Forbidden"))
                    {
                        Width = 1;
                        Height = 1;
                        FrameRate = 1;
                    }
                }
            }


            //catch (FFProbeException fFProbeException)
            //{
            //    ErrorType = string.Concat("Bad Stream - ", fFProbeException.ErrorCode, " - ", fFProbeException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
            //}
            //Console.WriteLine(TvgId);
            //Console.WriteLine(TvgName);
            //Console.WriteLine(TvgLogo);
            //Console.WriteLine(ChannelId);
            //Console.WriteLine(ChannelName);
            //Console.WriteLine(GroupTitle);
            //Console.WriteLine(StreamUrl);
            //Console.WriteLine(StreamId);
            //Console.WriteLine(Width);
            //Console.WriteLine(Height);
            //Console.WriteLine(string.Format("{0:N2}", FrameRate));
            //Console.ReadKey();
            //}
        }
        public string ExtractData(string inputLine, string thingToGet)
        {
            int thingToGetLength = thingToGet.Length + 2;
            int startIndex = 0;
            int endIndex = 0;
            int stringLength = 0;

            if (inputLine.Contains(thingToGet))
            {
                startIndex = inputLine.IndexOf(thingToGet) + thingToGetLength;
                endIndex = inputLine.IndexOf("\"", startIndex);
                stringLength = endIndex - startIndex;

                return inputLine.Substring(startIndex, stringLength);
            }

            return string.Empty;
        }

    }
}
