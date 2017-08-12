namespace Charlotte
{
	partial class BusyDlg
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusyDlg));
			this.ProgBar = new System.Windows.Forms.ProgressBar();
			this._中止ボタン = new System.Windows.Forms.Button();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this._メッセージ = new System.Windows.Forms.ToolStripStatusLabel();
			this._ステータス = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProgBar
			// 
			this.ProgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBar.Location = new System.Drawing.Point(12, 31);
			this.ProgBar.Maximum = 1000000000;
			this.ProgBar.Name = "ProgBar";
			this.ProgBar.Size = new System.Drawing.Size(660, 28);
			this.ProgBar.TabIndex = 0;
			// 
			// _中止ボタン
			// 
			this._中止ボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._中止ボタン.Location = new System.Drawing.Point(580, 103);
			this._中止ボタン.Name = "_中止ボタン";
			this._中止ボタン.Size = new System.Drawing.Size(92, 42);
			this._中止ボタン.TabIndex = 1;
			this._中止ボタン.Text = "中止";
			this._中止ボタン.UseVisualStyleBackColor = true;
			this._中止ボタン.Click += new System.EventHandler(this._中止ボタン_Click);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._メッセージ});
			this.statusStrip1.Location = new System.Drawing.Point(0, 156);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(684, 23);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// _メッセージ
			// 
			this._メッセージ.Name = "_メッセージ";
			this._メッセージ.Size = new System.Drawing.Size(104, 18);
			this._メッセージ.Text = "準備しています...";
			// 
			// _ステータス
			// 
			this._ステータス.AutoSize = true;
			this._ステータス.Location = new System.Drawing.Point(12, 72);
			this._ステータス.Name = "_ステータス";
			this._ステータス.Size = new System.Drawing.Size(555, 80);
			this._ステータス.TabIndex = 3;
			this._ステータス.Text = "総数：999999\r\n成功：999999 / 失敗：999999 / 処理不要：999999 / その他：999999\r\nコピー失敗：999999\r\n最後に失敗し" +
    "たファイル：いいいいいろろろろろはははははにににににほほほほほへへへへへ";
			// 
			// BusyDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 179);
			this.Controls.Add(this._中止ボタン);
			this.Controls.Add(this._ステータス);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.ProgBar);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "BusyDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "夏Conv / 処理中...";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusyDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusyDlg_FormClosed);
			this.Load += new System.EventHandler(this.BusyDlg_Load);
			this.Shown += new System.EventHandler(this.BusyDlg_Shown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgBar;
		private System.Windows.Forms.Button _中止ボタン;
		private System.Windows.Forms.Timer MainTimer;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel _メッセージ;
		private System.Windows.Forms.Label _ステータス;
	}
}
