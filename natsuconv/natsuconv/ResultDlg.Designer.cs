namespace Charlotte
{
	partial class ResultDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultDlg));
			this._アイコン = new System.Windows.Forms.PictureBox();
			this._メッセージ = new System.Windows.Forms.Label();
			this._レポート = new System.Windows.Forms.TextBox();
			this._閉じるボタン = new System.Windows.Forms.Button();
			this._ログファイルを開くボタン = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._アイコン)).BeginInit();
			this.SuspendLayout();
			// 
			// _アイコン
			// 
			this._アイコン.Location = new System.Drawing.Point(12, 12);
			this._アイコン.Name = "_アイコン";
			this._アイコン.Size = new System.Drawing.Size(100, 100);
			this._アイコン.TabIndex = 0;
			this._アイコン.TabStop = false;
			// 
			// _メッセージ
			// 
			this._メッセージ.AutoSize = true;
			this._メッセージ.Location = new System.Drawing.Point(118, 12);
			this._メッセージ.Name = "_メッセージ";
			this._メッセージ.Size = new System.Drawing.Size(115, 20);
			this._メッセージ.TabIndex = 0;
			this._メッセージ.Text = "準備しています...";
			// 
			// _レポート
			// 
			this._レポート.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._レポート.Location = new System.Drawing.Point(12, 127);
			this._レポート.Multiline = true;
			this._レポート.Name = "_レポート";
			this._レポート.ReadOnly = true;
			this._レポート.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._レポート.Size = new System.Drawing.Size(588, 246);
			this._レポート.TabIndex = 1;
			this._レポート.WordWrap = false;
			this._レポート.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._レポート_KeyPress);
			// 
			// _閉じるボタン
			// 
			this._閉じるボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._閉じるボタン.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this._閉じるボタン.Location = new System.Drawing.Point(491, 390);
			this._閉じるボタン.Name = "_閉じるボタン";
			this._閉じるボタン.Size = new System.Drawing.Size(109, 45);
			this._閉じるボタン.TabIndex = 3;
			this._閉じるボタン.Text = "閉じる";
			this._閉じるボタン.UseVisualStyleBackColor = true;
			this._閉じるボタン.Click += new System.EventHandler(this._閉じるボタン_Click);
			// 
			// _ログファイルを開くボタン
			// 
			this._ログファイルを開くボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._ログファイルを開くボタン.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this._ログファイルを開くボタン.Location = new System.Drawing.Point(12, 390);
			this._ログファイルを開くボタン.Name = "_ログファイルを開くボタン";
			this._ログファイルを開くボタン.Size = new System.Drawing.Size(195, 45);
			this._ログファイルを開くボタン.TabIndex = 2;
			this._ログファイルを開くボタン.Text = "ログファイルを開く";
			this._ログファイルを開くボタン.UseVisualStyleBackColor = true;
			this._ログファイルを開くボタン.Click += new System.EventHandler(this._ログファイルを開くボタン_Click);
			// 
			// ResultDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 447);
			this.Controls.Add(this._ログファイルを開くボタン);
			this.Controls.Add(this._閉じるボタン);
			this.Controls.Add(this._レポート);
			this.Controls.Add(this._メッセージ);
			this.Controls.Add(this._アイコン);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ResultDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "夏Conv / 処理結果";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultDlg_FormClosed);
			this.Load += new System.EventHandler(this.ResultDlg_Load);
			this.Shown += new System.EventHandler(this.ResultDlg_Shown);
			((System.ComponentModel.ISupportInitialize)(this._アイコン)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox _アイコン;
		private System.Windows.Forms.Label _メッセージ;
		private System.Windows.Forms.TextBox _レポート;
		private System.Windows.Forms.Button _閉じるボタン;
		private System.Windows.Forms.Button _ログファイルを開くボタン;
	}
}
