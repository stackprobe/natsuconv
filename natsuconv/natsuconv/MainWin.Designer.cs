namespace Charlotte
{
	partial class MainWin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.アプリAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ffmpegFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this._開始ボタン = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._入力フォルダ = new System.Windows.Forms.TextBox();
			this._入力フォルダ選択 = new System.Windows.Forms.Button();
			this._出力フォルダ = new System.Windows.Forms.TextBox();
			this._出力フォルダ選択 = new System.Windows.Forms.Button();
			this._出力フォルダラベル = new System.Windows.Forms.Label();
			this._同じフォルダに出力 = new System.Windows.Forms.CheckBox();
			this._関係ないファイルもコピー = new System.Windows.Forms.CheckBox();
			this._処理に失敗したファイルもコピー = new System.Windows.Forms.CheckBox();
			this._処理しなかったファイルもコピー = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリAToolStripMenuItem,
            this.設定SToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(680, 26);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// アプリAToolStripMenuItem
			// 
			this.アプリAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了XToolStripMenuItem});
			this.アプリAToolStripMenuItem.Name = "アプリAToolStripMenuItem";
			this.アプリAToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
			this.アプリAToolStripMenuItem.Text = "アプリ(&A)";
			// 
			// 終了XToolStripMenuItem
			// 
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
			// 
			// 設定SToolStripMenuItem
			// 
			this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ffmpegFToolStripMenuItem});
			this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
			this.設定SToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
			this.設定SToolStripMenuItem.Text = "設定(&S)";
			// 
			// ffmpegFToolStripMenuItem
			// 
			this.ffmpegFToolStripMenuItem.Name = "ffmpegFToolStripMenuItem";
			this.ffmpegFToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.ffmpegFToolStripMenuItem.Text = "ffmpeg(&F)";
			this.ffmpegFToolStripMenuItem.Click += new System.EventHandler(this.ffmpegFToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 308);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(680, 22);
			this.statusStrip1.TabIndex = 12;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// _開始ボタン
			// 
			this._開始ボタン.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._開始ボタン.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this._開始ボタン.Location = new System.Drawing.Point(524, 239);
			this._開始ボタン.Name = "_開始ボタン";
			this._開始ボタン.Size = new System.Drawing.Size(144, 57);
			this._開始ボタン.TabIndex = 11;
			this._開始ボタン.Text = "開　始";
			this._開始ボタン.UseVisualStyleBackColor = true;
			this._開始ボタン.Click += new System.EventHandler(this._開始ボタン_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "入力フォルダ";
			// 
			// _入力フォルダ
			// 
			this._入力フォルダ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._入力フォルダ.Location = new System.Drawing.Point(105, 46);
			this._入力フォルダ.MaxLength = 300;
			this._入力フォルダ.Name = "_入力フォルダ";
			this._入力フォルダ.Size = new System.Drawing.Size(507, 27);
			this._入力フォルダ.TabIndex = 2;
			this._入力フォルダ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._入力フォルダ_KeyPress);
			// 
			// _入力フォルダ選択
			// 
			this._入力フォルダ選択.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._入力フォルダ選択.Location = new System.Drawing.Point(618, 46);
			this._入力フォルダ選択.Name = "_入力フォルダ選択";
			this._入力フォルダ選択.Size = new System.Drawing.Size(50, 27);
			this._入力フォルダ選択.TabIndex = 3;
			this._入力フォルダ選択.Text = "...";
			this._入力フォルダ選択.UseVisualStyleBackColor = true;
			this._入力フォルダ選択.Click += new System.EventHandler(this._入力フォルダ選択_Click);
			// 
			// _出力フォルダ
			// 
			this._出力フォルダ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._出力フォルダ.Location = new System.Drawing.Point(105, 79);
			this._出力フォルダ.MaxLength = 300;
			this._出力フォルダ.Name = "_出力フォルダ";
			this._出力フォルダ.Size = new System.Drawing.Size(507, 27);
			this._出力フォルダ.TabIndex = 5;
			this._出力フォルダ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._出力フォルダ_KeyPress);
			// 
			// _出力フォルダ選択
			// 
			this._出力フォルダ選択.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._出力フォルダ選択.Location = new System.Drawing.Point(618, 79);
			this._出力フォルダ選択.Name = "_出力フォルダ選択";
			this._出力フォルダ選択.Size = new System.Drawing.Size(50, 27);
			this._出力フォルダ選択.TabIndex = 6;
			this._出力フォルダ選択.Text = "...";
			this._出力フォルダ選択.UseVisualStyleBackColor = true;
			this._出力フォルダ選択.Click += new System.EventHandler(this._出力フォルダ選択_Click);
			// 
			// _出力フォルダラベル
			// 
			this._出力フォルダラベル.AutoSize = true;
			this._出力フォルダラベル.Location = new System.Drawing.Point(12, 82);
			this._出力フォルダラベル.Name = "_出力フォルダラベル";
			this._出力フォルダラベル.Size = new System.Drawing.Size(87, 20);
			this._出力フォルダラベル.TabIndex = 4;
			this._出力フォルダラベル.Text = "出力フォルダ";
			// 
			// _同じフォルダに出力
			// 
			this._同じフォルダに出力.AutoSize = true;
			this._同じフォルダに出力.Location = new System.Drawing.Point(105, 121);
			this._同じフォルダに出力.Name = "_同じフォルダに出力";
			this._同じフォルダに出力.Size = new System.Drawing.Size(417, 24);
			this._同じフォルダに出力.TabIndex = 7;
			this._同じフォルダに出力.Text = "入力フォルダと同じ場所に出力する。(入力ファイルを上書きする)";
			this._同じフォルダに出力.UseVisualStyleBackColor = true;
			this._同じフォルダに出力.CheckedChanged += new System.EventHandler(this._同じフォルダに出力_CheckedChanged);
			// 
			// _関係ないファイルもコピー
			// 
			this._関係ないファイルもコピー.AutoSize = true;
			this._関係ないファイルもコピー.Location = new System.Drawing.Point(105, 211);
			this._関係ないファイルもコピー.Name = "_関係ないファイルもコピー";
			this._関係ないファイルもコピー.Size = new System.Drawing.Size(327, 24);
			this._関係ないファイルもコピー.TabIndex = 10;
			this._関係ないファイルもコピー.Text = "動画・音楽ファイル以外のファイルもコピーする。";
			this._関係ないファイルもコピー.UseVisualStyleBackColor = true;
			// 
			// _処理に失敗したファイルもコピー
			// 
			this._処理に失敗したファイルもコピー.AutoSize = true;
			this._処理に失敗したファイルもコピー.Location = new System.Drawing.Point(105, 151);
			this._処理に失敗したファイルもコピー.Name = "_処理に失敗したファイルもコピー";
			this._処理に失敗したファイルもコピー.Size = new System.Drawing.Size(327, 24);
			this._処理に失敗したファイルもコピー.TabIndex = 8;
			this._処理に失敗したファイルもコピー.Text = "処理に失敗した動画・音楽ファイルもコピーする。";
			this._処理に失敗したファイルもコピー.UseVisualStyleBackColor = true;
			// 
			// _処理しなかったファイルもコピー
			// 
			this._処理しなかったファイルもコピー.AutoSize = true;
			this._処理しなかったファイルもコピー.Location = new System.Drawing.Point(105, 181);
			this._処理しなかったファイルもコピー.Name = "_処理しなかったファイルもコピー";
			this._処理しなかったファイルもコピー.Size = new System.Drawing.Size(516, 24);
			this._処理しなかったファイルもコピー.TabIndex = 9;
			this._処理しなかったファイルもコピー.Text = "既にノーマライズされている (処理しなかった) 動画・音楽ファイルもコピーする。";
			this._処理しなかったファイルもコピー.UseVisualStyleBackColor = true;
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 330);
			this.Controls.Add(this._処理しなかったファイルもコピー);
			this.Controls.Add(this._処理に失敗したファイルもコピー);
			this.Controls.Add(this._関係ないファイルもコピー);
			this.Controls.Add(this._同じフォルダに出力);
			this.Controls.Add(this._出力フォルダラベル);
			this.Controls.Add(this._出力フォルダ選択);
			this.Controls.Add(this._出力フォルダ);
			this.Controls.Add(this._入力フォルダ選択);
			this.Controls.Add(this._入力フォルダ);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._開始ボタン);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "MainWin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "夏Conv";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem アプリAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button _開始ボタン;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _入力フォルダ;
		private System.Windows.Forms.Button _入力フォルダ選択;
		private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ffmpegFToolStripMenuItem;
		private System.Windows.Forms.TextBox _出力フォルダ;
		private System.Windows.Forms.Button _出力フォルダ選択;
		private System.Windows.Forms.Label _出力フォルダラベル;
		private System.Windows.Forms.CheckBox _同じフォルダに出力;
		private System.Windows.Forms.CheckBox _関係ないファイルもコピー;
		private System.Windows.Forms.CheckBox _処理に失敗したファイルもコピー;
		private System.Windows.Forms.CheckBox _処理しなかったファイルもコピー;
	}
}

