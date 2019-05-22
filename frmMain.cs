using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private DateTime _startDateTime;

        private ThreadHandler _threadHandler = new ThreadHandler(2);
        private List<string> _groupsToCheck = new List<string>();
        private Dictionary<string, int> _groupsDictionary = new Dictionary<string, int>();
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

                clbGroups.Items.Clear();

                int channelCount = 0;
                foreach (string fileLine in _fileLines)
                {
                    if (fileLine.StartsWith("#EXTINF"))
                    {
                        string groupName = Utilities.ExtractData(fileLine, "group-title");
                        groupName = string.IsNullOrEmpty(groupName) ? "<No Group>" : groupName;

                        //if (!clbGroups.Items.Contains(groupName))
                        //{
                        //    clbGroups.Items.Add(groupName);
                        //}
                        channelCount++;

                        if (!_groupsDictionary.ContainsKey(groupName))
                        {
                            _groupsDictionary.Add(groupName, 1);
                        }
                        else
                        {
                            _groupsDictionary[groupName]++;
                        }
                    }
                }

                clbGroups.Items.Add(string.Format("{0} ({1})", "All Groups", channelCount));

                foreach (string key in _groupsDictionary.Keys)
                {
                    clbGroups.Items.Add(string.Format("{0} ({1})", key, _groupsDictionary[key]));
                }
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
            _startDateTime = DateTime.Now;
            _channelEntries.Clear();
            RebindDataGridView();
            PopulateGroupsToCheck();
            _totalChannels = 0;

            for (int i = 0; i < _fileLines.Length; i++)
            {
                if (_fileLines[i].StartsWith("#EXTINF") && _groupsToCheck.Contains(Utilities.ExtractData(_fileLines[i], "group-title")))
                {
                    _totalChannels++;
                }
            }
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
                lblEstimatedCompletionDate.Text = DateTime.Now.AddSeconds(((DateTime.Now - _startDateTime).TotalSeconds / ((float) (_goodChannels + _badChannels))) * _totalChannels).ToString("MM/dd/yyyy hh:mm tt");
                RebindDataGridView();
            });

            // Run operation in another thread
            await Task.Run(() => DoWork(progress));

            //SortableBindingList<ChannelEntry> sortableBindingList = new SortableBindingList<ChannelEntry>(_channelEntries);
            //var bindingSource = new BindingSource();
            //bindingSource.DataSource = sortableBindingList;

            //dgvChannels.DataSource = bindingSource;
            //dgvChannels.Update();
            //dgvChannels.Refresh();
            //bindingSource.Sort = "GroupTitle,ChannelName";

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
                    string groupName = Utilities.ExtractData(_fileLines[channels], "group-title");

                    if (_groupsToCheck.Contains(groupName) || (_groupsToCheck.Contains("<No Group>") && string.IsNullOrEmpty(groupName)))
                    {
                        ThreadStart threadStart = () => GetChannelInfo(progress, firstLine, secondLine);
                        _threadHandler.Add(threadStart);
                    }
                    //var channelEntry = new ChannelEntry(string.Empty, _fileLines[channels], _fileLines[channels + 1],
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

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }



        private void ClbGroups_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    ChangeAllCheckBoxValues(true);
                }
                else
                {
                    ChangeAllCheckBoxValues(false);
                }
            }


        }

        private void ChangeAllCheckBoxValues(bool value)
        {
            for (int i = 1; i < clbGroups.Items.Count; i++)
            {
                clbGroups.SetItemChecked(i, value);
            }
        }

        private void PopulateGroupsToCheck()
        {
            _groupsToCheck.Clear();
            foreach (int indexChecked in clbGroups.CheckedIndices)
            {
                string groupToCheck = clbGroups.Items[indexChecked].ToString();
                groupToCheck = groupToCheck.Substring(0, groupToCheck.IndexOf('(')).Trim();
                _groupsToCheck.Add(groupToCheck);
            }
        }

        private void ClbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}