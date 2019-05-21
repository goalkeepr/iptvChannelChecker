using System;
using System.IO;
using System.Net;

namespace iptvChannelChecker
{
    class M3uDownloader
    {
        public string ProviderUrl = string.Empty;
        public string EpgUrl = string.Empty;
        public string ProviderName;
        private string extraEpg;
        private string epgData;
        public M3uDownloader(string m3uFileUrl)
        {
            ProviderName = m3uFileUrl;
            ProviderUrl = string.Empty;
            EpgUrl = string.Empty;
            GetM3uAndEpgUrls(m3uFileUrl);

            try
            {
                Console.WriteLine(string.Format("Starting {0} M3U/EPG - {1}", m3uFileUrl, DateTime.Now.ToString()));
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                {
                    Console.WriteLine(string.Format("\tGetting {0} M3U - {1}", m3uFileUrl, DateTime.Now.ToString()));
                    client.Encoding = System.Text.Encoding.UTF8;
                    string m3uFile = client.DownloadString(ProviderUrl);
                //    File.WriteAllText(M3uFileName, m3uFile.Replace(",.", ","));
                //    if (!string.IsNullOrEmpty(EpgUrl))
                //    {
                //        //client.DownloadFile(EpgUrl, EpgFileName);
                //        Console.WriteLine(string.Format("\tGetting {0} EPG - {1}", m3uFileUrl, DateTime.Now.ToString()));
                //        epgData = client.DownloadString(EpgUrl);

                //        using (StreamWriter streamWriter = new StreamWriter(EpgFileName, false, System.Text.Encoding.UTF8))
                //        {
                //            streamWriter.Write(EpgData);
                //        }

                //        try
                //        {
                //            if (File.Exists(EpgWwwFileName))
                //            {
                //                File.Delete(EpgWwwFileName);
                //            }

                //            File.Copy(EpgFileName, EpgWwwFileName);
                //        }
                //        catch
                //        { }
                //    }
                }

            }
            catch
            {
                Console.WriteLine(string.Format("\tError in {0} M3U/EPG - {1}", m3uFileUrl, DateTime.Now.ToString()));
            }
            finally
            {
                Console.WriteLine(string.Format("\tFinished {0} M3U/EPG - {1}", m3uFileUrl, DateTime.Now.ToString()));
            }
        }

        private void GetM3uAndEpgUrls(string m3uFileUrl)
        {
            throw new NotImplementedException();
        }
    }
}