using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iptvChannelChecker
{
    public partial class frmMain : Form
    {
        private readonly SynchronizationContext _synchronizationContext;
        private int _1080x30Count;

        private int _1080x60Count;
        private int _720x30Count;
        private int _720x60Count;
        private int _badChannels;

        private readonly List<ChannelEntry> _channelEntries = new List<ChannelEntry>();
        private string[] _fileLines;
        private int _goodChannels;
        private int _otherSdCount;

        private bool _stopRunning;
        private int _totalChannels;

        private ThreadHandler _threadHandler = new ThreadHandler(2);
        public frmMain()
        {
            InitializeComponent();
            cboAllowedConnections.SelectedIndex = 0;
            dgvChannels.AutoGenerateColumns = false;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "m3u files (*.m3u;*.m3u8)|*.m3u;*.m3u8|All Files (*.*)|*.*",
                Title = "Input - Select m3u/m3u8 File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFile.Text = openFileDialog.FileName;


                _fileLines = File.ReadAllLines(openFileDialog.FileName);
                _totalChannels = _fileLines.Count(p => p.StartsWith("#EXTINF"));
            }
        }

        private void BtnOutputFile_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "csv files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Output - Select csv File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK) txtOutputFile.Text = saveFileDialog.FileName;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            _channelEntries.Clear();
            RebindDataGridView();
            prgProgressBar.Maximum = _totalChannels;
            prgProgressBar.Step = 1;
            prgProgressBar.Value = 0;

            var progress = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                prgProgressBar.Value += v;
                lblProgress.Text = string.Format("{0} / {1} ({2}%)", prgProgressBar.Value, _totalChannels, prgProgressBar.Value * 100 / _totalChannels);
                lblTotalChannelsCount.Text = (_goodChannels + _badChannels).ToString("N0");
                lblGoodChannelsCount.Text = _goodChannels.ToString("N0");
                lblBadChannelsCount.Text = _badChannels.ToString("N0");
                lbl1080x60Count.Text = _1080x60Count.ToString("N0");
                lbl1080x30Count.Text = _1080x30Count.ToString("N0");
                lbl720x60Count.Text = _720x60Count.ToString("N0");
                lbl720x30Count.Text = _720x30Count.ToString("N0");
                lblOtherSdCount.Text = _otherSdCount.ToString("N0");
                RebindDataGridView();
            });

            // Run operation in another thread
            await Task.Run(() => DoWork(progress));

            // TODO: Do something after all calculations
            OutputResultsFile();
        }

        public void DoWork(IProgress<int> progress)
        {
            // This method is executed in the context of
            // another thread (different than the main UI thread),
            // so use only thread-safe code
            var i = 1;

            for (var channels = 0; channels < _fileLines.Length; channels++)
            {
                if (_stopRunning) break;

                if (_fileLines[channels].StartsWith("#EXTINF"))
                {
                    string firstLine = _fileLines[channels];
                    string secondLine = _fileLines[channels + 1];
                    //var channelEntry = new ChannelEntry(string.Empty, _fileLines[channels], _fileLines[channels + 1],
                    ThreadStart threadStart = () => GetChannelInfo(progress, firstLine, secondLine);
                    _threadHandler.Add(threadStart);
                }
            }

            _threadHandler.Run();
            _stopRunning = false;
        }

        private void GetChannelInfo(IProgress<int> progress, string firstLine, string secondLine)
        {
            var channelEntry = new ChannelEntry(string.Empty, firstLine, secondLine,
                string.Empty, string.Empty);
            _channelEntries.Add(channelEntry);
            if (string.IsNullOrEmpty(channelEntry.ErrorType))
            {
                _goodChannels++;
                if (channelEntry.Width > 1280)
                {
                    if (channelEntry.FrameRateInt >= 50)
                        _1080x60Count++;
                    else
                        _1080x30Count++;
                }
                else if (channelEntry.Width == 1280)
                {
                    if (channelEntry.FrameRateInt >= 50)
                        _720x60Count++;
                    else
                        _720x30Count++;
                }
                else
                {
                    _otherSdCount++;
                }
            }
            else
            {
                _badChannels++;
            }

            //progress.Report(i++);
            progress.Report(1);
        }

        private void RebindDataGridView()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _channelEntries;

            dgvChannels.DataSource = bindingSource;
            dgvChannels.Update();
            dgvChannels.Refresh();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _stopRunning = true;
            _threadHandler.KillThreads = true;
            OutputResultsFile();
        }

        private void CboAllowedConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            _threadHandler = new ThreadHandler(cboAllowedConnections.SelectedIndex+1);
        }

        private void OutputResultsFile()
        {
            if(!string.IsNullOrEmpty(txtOutputFile.Text))
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(txtOutputFile.Text))
                    {
                        streamWriter.WriteLine("TVG ID,TVG Name,Group Title,Channel Name,Width,Height,Frame Rate,Quality Level,Error Type");
                        foreach (ChannelEntry channelEntry in _channelEntries)
                        {
                            streamWriter.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", channelEntry.TvgId, channelEntry.TvgName, channelEntry.GroupTitle, channelEntry.ChannelName, channelEntry.Width, channelEntry.Height, channelEntry.FrameRateInt, channelEntry.QualityLevel, channelEntry.ErrorType));
                        }
                    }

                    try
                    {
                        Process.Start("excel.exe", txtOutputFile.Text);
                    }
                    catch (Exception e)
                    {

                        Process.Start("notepad.exe", txtOutputFile.Text);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}