using System;
using System.Media;
using System.Windows.Forms;

namespace WAV
{
    public partial class frmWAVPlayer : Form
    {
        private SoundPlayer player = new SoundPlayer();

        public frmWAVPlayer()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdWAVFile.Filter = "WAV Files (*.wav)|*.wav";
            ofdWAVFile.FileName = "";

            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdWAVFile.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("請先選擇 WAV 檔案！");
                return;
            }

            try
            {
                player.SoundLocation = txtPath.Text;
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放失敗：" + ex.Message);
            }
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("請先選擇 WAV 檔案！");
                return;
            }

            try
            {
                player.SoundLocation = txtPath.Text;
                player.Load();
                player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("重複播放失敗：" + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmWAVPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "確定要關閉應用程式嗎？",
                "關閉確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}