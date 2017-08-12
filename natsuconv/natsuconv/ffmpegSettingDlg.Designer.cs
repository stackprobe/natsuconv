namespace Charlotte
{
	partial class ffmpegSettingDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ffmpegSettingDlg));
			this.Okボタン = new System.Windows.Forms.Button();
			this.Cancelボタン = new System.Windows.Forms.Button();
			this.ffmpegのパス選択 = new System.Windows.Forms.Button();
			this.ffmpegのパス = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ffmpegのパスの例 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Okボタン
			// 
			this.Okボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Okボタン.Location = new System.Drawing.Point(476, 110);
			this.Okボタン.Name = "Okボタン";
			this.Okボタン.Size = new System.Drawing.Size(109, 45);
			this.Okボタン.TabIndex = 4;
			this.Okボタン.Text = "OK";
			this.Okボタン.UseVisualStyleBackColor = true;
			this.Okボタン.Click += new System.EventHandler(this.Okボタン_Click);
			// 
			// Cancelボタン
			// 
			this.Cancelボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancelボタン.Location = new System.Drawing.Point(591, 110);
			this.Cancelボタン.Name = "Cancelボタン";
			this.Cancelボタン.Size = new System.Drawing.Size(109, 45);
			this.Cancelボタン.TabIndex = 5;
			this.Cancelボタン.Text = "キャンセル";
			this.Cancelボタン.UseVisualStyleBackColor = true;
			this.Cancelボタン.Click += new System.EventHandler(this.Cancelボタン_Click);
			// 
			// ffmpegのパス選択
			// 
			this.ffmpegのパス選択.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ffmpegのパス選択.Location = new System.Drawing.Point(650, 44);
			this.ffmpegのパス選択.Name = "ffmpegのパス選択";
			this.ffmpegのパス選択.Size = new System.Drawing.Size(50, 27);
			this.ffmpegのパス選択.TabIndex = 2;
			this.ffmpegのパス選択.Text = "...";
			this.ffmpegのパス選択.UseVisualStyleBackColor = true;
			this.ffmpegのパス選択.Click += new System.EventHandler(this.ffmpegのパス選択_Click);
			// 
			// ffmpegのパス
			// 
			this.ffmpegのパス.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ffmpegのパス.Location = new System.Drawing.Point(111, 44);
			this.ffmpegのパス.MaxLength = 300;
			this.ffmpegのパス.Name = "ffmpegのパス";
			this.ffmpegのパス.Size = new System.Drawing.Size(533, 27);
			this.ffmpegのパス.TabIndex = 1;
			this.ffmpegのパス.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ffmpegのパス_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "ffmpegのパス";
			// 
			// ffmpegのパスの例
			// 
			this.ffmpegのパスの例.AutoSize = true;
			this.ffmpegのパスの例.Location = new System.Drawing.Point(114, 74);
			this.ffmpegのパスの例.Name = "ffmpegのパスの例";
			this.ffmpegのパスの例.Size = new System.Drawing.Size(265, 20);
			this.ffmpegのパスの例.TabIndex = 3;
			this.ffmpegのパスの例.Text = "例) C:\\app\\ffmpeg-3.2.4-win64-shared";
			// 
			// ffmpegSettingDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(712, 167);
			this.Controls.Add(this.ffmpegのパスの例);
			this.Controls.Add(this.ffmpegのパス選択);
			this.Controls.Add(this.ffmpegのパス);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Cancelボタン);
			this.Controls.Add(this.Okボタン);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ffmpegSettingDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定 / ffmpeg";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ffmpegSettingDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ffmpegSettingDlg_FormClosed);
			this.Load += new System.EventHandler(this.ffmpegSettingDlg_Load);
			this.Shown += new System.EventHandler(this.ffmpegSettingDlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Okボタン;
		private System.Windows.Forms.Button Cancelボタン;
		private System.Windows.Forms.Button ffmpegのパス選択;
		private System.Windows.Forms.TextBox ffmpegのパス;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label ffmpegのパスの例;
	}
}
