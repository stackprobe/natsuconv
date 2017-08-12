using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;
using System.IO;
using System.Diagnostics;

namespace Charlotte
{
	public partial class ResultDlg : Form
	{
		public ResultDlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			this._レポート.ForeColor = new TextBox().ForeColor;
			this._レポート.BackColor = new TextBox().BackColor;

			if (Gnd.Conv.Cancelled) // cancelled
			{
				this._アイコン.Image = Properties.Resources.WarningIcon_100;
				this._メッセージ.Text = "中止しました。";
			}
			else if (Gnd.Conv.Error != null) // error
			{
				this._アイコン.Image = Properties.Resources.ErrorIcon_100;
				this._メッセージ.Text = "エラーにより中断しました。\r\n" + Gnd.Conv.Error.Message;
			}
			else if (1 <= Gnd.Conv.ErrorFileCount || 1 <= Gnd.Conv.FailedCopyFileCount) // warning
			{
				this._アイコン.Image = Properties.Resources.WarningIcon_100;
				this._メッセージ.Text = "いくつかのファイルの処理に失敗しました。";
			}
			else // successful
			{
				this._アイコン.Image = Properties.Resources.InformationIcon_100;
				this._メッセージ.Text = "正常終了";
			}
			this._メッセージ.Top = this._アイコン.Top + (this._アイコン.Height - this._メッセージ.Height) / 2;

			{
				List<string> lines = new List<string>();

				lines.Add("ファイルの総数：" + Gnd.Conv.TotalFileCount);
				lines.Add("----");
				lines.Add("処理に成功したファイル数：" + Gnd.Conv.ProcessedFileCount);
				lines.Add("エラーになったファイル数：" + Gnd.Conv.ErrorFileCount);
				lines.Add("既にノーマライズされていて処理しなかったファイル数：" + Gnd.Conv.NotProcessedFileCount);
				lines.Add("その他のファイル数：" + Gnd.Conv.OtherFileCount);
				lines.Add("----");
				lines.Add("コピーに失敗したファイル数：" + Gnd.Conv.FailedCopyFileCount);
				lines.Add("");

				if (Gnd.Conv.Error != null) // erorr
				{
					lines.Add("" + Gnd.Conv.Error);
					lines.Add("");
				}
				//lines.Add("★処理結果の詳細はログファイルを参照して下さい。");
				//lines.Add("ログファイルの名前は natsuconv_conversion.log です。");
				//lines.Add("");

				this._レポート.Text = string.Join("\r\n", lines);
			}
		}

		private void ResultDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void ResultDlg_Shown(object sender, EventArgs e)
		{
			this._閉じるボタン.Focus();
		}

		private void ResultDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void ResultDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void _閉じるボタン_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void _レポート_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl a
			{
				this._レポート.SelectAll();
				e.Handled = true;
			}
		}

		private void _ログファイルを開くボタン_Click(object sender, EventArgs e)
		{
			try
			{
				Gnd.ConvLog.Close(); // 2bs

				string logFile = StringTools.Combine(BootTools.SelfDir, "natsuconv_conversion.log");
				string tmpFile = StringTools.Combine(BootTools.SelfDir, "natsuconv_conversion_log.txt");

				if (File.Exists(logFile))
				{
					File.Delete(tmpFile);
					File.Move(logFile, tmpFile);
				}
				if (File.Exists(tmpFile) == false)
					throw new Exception(tmpFile + " does not exist.");

				Process.Start(tmpFile);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"" + ex,
					"失敗しました",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
		}
	}
}
