using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Charlotte
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			Utils._ファイル・フォルダ選択ボタンに引っ付ける(this._入力フォルダ, this._入力フォルダ選択);
			Utils._ファイル・フォルダ選択ボタンに引っ付ける(this._出力フォルダ, this._出力フォルダ選択);
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.LoadData();
			this.UIUpdate();
			this._入力フォルダ選択.Focus();

			if (Gnd.ffmpegDir == "") // お節介 1
			{
				if (MessageBox.Show(
					"ffmpegのパスが設定されていません。\n" +
					"設定ダイアログを開きますか？",
					"お節介Dlg",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
					) == DialogResult.Yes
					)
				{
					this.ffmpegFToolStripMenuItem_Click(null, null);
				}
			}
			else if (Directory.Exists(Gnd.ffmpegDir) == false) // お節介.2
			{
				if (MessageBox.Show(
					"ffmpegのパスが、移動または削除されました。\n" +
					"設定ダイアログを開きますか？",
					"お節介Dlg",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
					) == DialogResult.Yes
					)
				{
					this.ffmpegFToolStripMenuItem_Click(null, null);
				}
			}
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.SaveData();
		}

		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void _入力フォルダ_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl a
			{
				this._入力フォルダ.SelectAll();
				e.Handled = true;
			}
		}

		private void _出力フォルダ_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl a
			{
				this._出力フォルダ.SelectAll();
				e.Handled = true;
			}
		}

		private void ffmpegFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SaveData();
			Gnd.SaveData();

			using (ffmpegSettingDlg f = new ffmpegSettingDlg())
			{
				f.ShowDialog();
			}
		}

		private void _開始ボタン_Click(object sender, EventArgs e)
		{
			this.SaveData();
			Gnd.SaveData();

			try
			{
				Gnd.Conv = new Conv();
				Gnd.Conv.Prep();
			}
			catch (Exception ex)
			{
				Gnd.ConvLog.Writeln(ex);

				MessageBox.Show(
					ex.Message,
					"開始できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);

				return;
			}
			this.Visible = false;

			using (BusyDlg f = new BusyDlg())
			{
				f.Th = new Thread((ThreadStart)delegate
				{
					try
					{
						Gnd.Conv.Main();
					}
					catch (Exception ex)
					{
						Gnd.ConvLog.Writeln(ex);

						Gnd.Conv.Errored = true;
						Gnd.Conv.Error = ex;
					}
					finally
					{
						Gnd.Conv.MainCleanup();
					}
				});

				Gnd.BusyDlg = f;
				f.ShowDialog();
				Gnd.BusyDlg = null;
			}
			Gnd.ConvLog.Close();

			using (ResultDlg f = new ResultDlg())
			{
				f.ShowDialog();
			}
			this.Close();
		}

		private void UIUpdate()
		{
			bool flag = this._同じフォルダに出力.Checked == false;

			this._出力フォルダラベル.Enabled = flag;
			this._出力フォルダ.Enabled = flag;
			this._出力フォルダ選択.Enabled = flag;

			this._処理に失敗したファイルもコピー.Enabled = flag;
			this._処理しなかったファイルもコピー.Enabled = flag;
			this._関係ないファイルもコピー.Enabled = flag;
		}

		private void _同じフォルダに出力_CheckedChanged(object sender, EventArgs e)
		{
			this.UIUpdate();
		}

		private void LoadData()
		{
			this._入力フォルダ.Text = Gnd.InputDir;
			this._出力フォルダ.Text = Gnd.OutputDir;
			this._同じフォルダに出力.Checked = Gnd.SameDir;
			this._処理に失敗したファイルもコピー.Checked = Gnd.ErrorFileCopy;
			this._処理しなかったファイルもコピー.Checked = Gnd.NotProcessedCopy;
			this._関係ないファイルもコピー.Checked = Gnd.OtherFileCopy;
		}

		private void SaveData()
		{
			Gnd.InputDir = this._入力フォルダ.Text;
			Gnd.OutputDir = this._出力フォルダ.Text;
			Gnd.SameDir = this._同じフォルダに出力.Checked;
			Gnd.ErrorFileCopy = this._処理に失敗したファイルもコピー.Checked;
			Gnd.NotProcessedCopy = this._処理しなかったファイルもコピー.Checked;
			Gnd.OtherFileCopy = this._関係ないファイルもコピー.Checked;
		}

		private void _入力フォルダ選択_Click(object sender, EventArgs e)
		{
			Utils.ChooseFolder(this, this._入力フォルダ, false);
		}

		private void _出力フォルダ選択_Click(object sender, EventArgs e)
		{
			Utils.ChooseFolder(this, this._出力フォルダ);
		}
	}
}
