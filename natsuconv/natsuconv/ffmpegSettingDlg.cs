using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charlotte
{
	public partial class ffmpegSettingDlg : Form
	{
		public ffmpegSettingDlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			Utils._ファイル・フォルダ選択ボタンに引っ付ける(this.ffmpegのパス, this.ffmpegのパス選択);

			if (Environment.Is64BitOperatingSystem == false) // ? OS == 32-bit
			{
				this.ffmpegのパスの例.Text = this.ffmpegのパスの例.Text.Replace("64", "32");
			}
		}

		private void ffmpegSettingDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void ffmpegSettingDlg_Shown(object sender, EventArgs e)
		{
			this.ffmpegのパス.Text = Gnd.ffmpegDir;
			this.ffmpegのパス選択.Focus();
		}

		private void ffmpegSettingDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void ffmpegSettingDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void ffmpegのパス_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl a
			{
				this.ffmpegのパス.SelectAll();
				e.Handled = true;
			}
		}

		private void Okボタン_Click(object sender, EventArgs e)
		{
			Gnd.ffmpegDir = this.ffmpegのパス.Text;
			Gnd.SaveData();
			this.Close();
		}

		private void Cancelボタン_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ffmpegのパス選択_Click(object sender, EventArgs e)
		{
			Utils.ChooseFolder(this, this.ffmpegのパス, false);
		}
	}
}
