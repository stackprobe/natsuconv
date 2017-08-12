using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class BusyDlg : Form
	{
		private bool XBtnPressed = false;

		#region ALT_F4 抑止

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
			{
				this.XBtnPressed = true;
				return;
			}
			base.WndProc(ref m);
		}

		#endregion

		public BusyDlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			_メッセージ.Text = "";
			_ステータス.Text = "";
		}

		public Thread Th;

		private void BusyDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void BusyDlg_Shown(object sender, EventArgs e)
		{
			this.Th.Start();
			this.MT_Enabled = true;
		}

		private void BusyDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void BusyDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
		}

		private void _中止ボタン_Click(object sender, EventArgs e)
		{
			if (this._中止ボタン.Enabled)
			{
				Gnd.Conv.Cancelled = true;
				Gnd.Conv.Cancelの補助的な何か();
				this.ProgBar.Style = ProgressBarStyle.Marquee;
				this._メッセージ.Text = "中止しています。しばらくお待ち下さい。";
				this._中止ボタン.Enabled = false;
			}
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private long FinishedCount;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				if (this.XBtnPressed)
				{
					this.XBtnPressed = false;
					this._中止ボタン_Click(null, null);
					return;
				}

				// ----

				if (Gnd.Conv.Cancelled || Gnd.Conv.Errored)
				{
					if (this.Th.IsAlive == false)
					{
						this.MT_Enabled = false;
						this.Close();
						return;
					}
				}
				else if (1 <= this.FinishedCount)
				{
					if (this.FinishedCount == 10)
					{
						this.MT_Enabled = false;
						this.Close();
						return;
					}

					{
						int prog = IntTools.IMAX;

						if (this.ProgBar.Value != prog)
							this.ProgBar.Value = prog;
					}

					this.FinishedCount++;
				}
				else
				{
					if (this.Th.IsAlive == false)
					{
						this.FinishedCount = 1;
						return;
					}

					{
						double curr = this.CurrProg;
						double dest;

						lock (SYNCROOT)
						{
							dest = this.DestProg;
						}
						curr -= dest;
						curr *= 0.9985;
						curr += dest;

						this.CurrProg = curr;
					}

					{
						int prog = IntTools.ToInt(this.CurrProg * IntTools.IMAX);

						prog = IntTools.ToRange(prog);

						if (this.ProgBar.Value != prog)
							this.ProgBar.Value = prog;
					}

					{
						string message = null;

						lock (SYNCROOT)
						{
							if (this.NextMessage != null)
							{
								message = this.NextMessage;
								this.NextMessage = null;
							}
						}
						if (message != null)
						{
							_メッセージ.Text = message;
						}
					}

					if (this.MT_Count % 20 == 0)
					{
						string status;
						Color statusColor;

						lock (SYNCROOT)
						{
							status = this.NextStatus;
							statusColor = this.NextStatusColor;
						}
						if (status != null)
						{
							if (_ステータス.Text != status)
								_ステータス.Text = status;
						}
						if (statusColor != null)
						{
							if (_ステータス.ForeColor != statusColor)
								_ステータス.ForeColor = statusColor;
						}
					}

					if (this.RequestGC)
					{
						GC.Collect();
						this.RequestGC = false;
					}
				}
			}
			finally
			{
				this.MT_Busy = false;
				this.MT_Count++;
			}
		}

		private object SYNCROOT = new object();
		private double CurrProg = 0.0;
		private double DestProg = 0.1; // touched by mlt th

		/// <summary>
		/// thread safe
		/// </summary>
		/// <param name="rate"></param>
		public void SetProgress(double rate)
		{
			lock (SYNCROOT)
			{
				this.DestProg = 0.1 + 0.9 * rate;
			}
		}

		private string NextMessage = null; // touched by mlt th

		/// <summary>
		/// thread safe
		/// </summary>
		/// <param name="message"></param>
		public void SetMessage(string message)
		{
			lock (SYNCROOT)
			{
				this.NextMessage = message;
			}
		}

		public bool RequestGC = false; // touched by mlt th

		private string NextStatus = null; // touched by mlt th
		private Color NextStatusColor = Color.Black; // touched by mlt th

		/// <summary>
		/// thread safe
		/// </summary>
		/// <param name="status"></param>
		public void SetStatus(string status, Color statusColor)
		{
			lock (SYNCROOT)
			{
				this.NextStatus = status;
				this.NextStatusColor = statusColor;
			}
		}
	}
}
