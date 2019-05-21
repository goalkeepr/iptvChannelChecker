using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iptvChannelChecker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "m3u files (*.m3u;*.m3u8)|*.m3u;*.m3u8|All Files (*.*)|*.*", Title = "Input - Select m3u/m3u8 File" };

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFile.Text = openFileDialog.FileName;
            }

        }

        private void BtnOutputFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "m3u files (*.m3u;*.m3u8)|*.m3u;*.m3u8|All Files (*.*)|*.*", Title = "Output - Select m3u/m3u8 File" };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFile.Text = saveFileDialog.FileName;
            }
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            prgProgressBar.Maximum = 200;
            prgProgressBar.Step = 1;
            prgProgressBar.Value = 0;

            var progress = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                prgProgressBar.Value = v;
                lblProgress.Text = string.Format("{0} / {1} ({2}%)", v, 200, (v*100/200));
            });

            // Run operation in another thread
            await Task.Run(() => DoWork(progress));

            // TODO: Do something after all calculations
        }

        public void DoWork(IProgress<int> progress)
        {
            // This method is executed in the context of
            // another thread (different than the main UI thread),
            // so use only thread-safe code
            for (int j = 0; j < 200; j++)
            {
                // Use progress to notify UI thread that progress has
                // changed
                if (progress != null)
                    progress.Report(j+1);
                    //progress.Report((j+1) * 100 / 100);

                System.Threading.Thread.Sleep(50);
            }
        }

    }
}
