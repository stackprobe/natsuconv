using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Charlotte
{
	public class Utils
	{
		public static void _ファイル・フォルダ選択ボタンに引っ付ける(Control ctrl, Button btn)
		{
			ctrl.Width = btn.Left - ctrl.Left;
		}

		public static void ChooseFolder(Form parent, TextBox tb, bool newFolderOk = true)
		{
			string dir = tb.Text;

			if (dir == "" || Directory.Exists(dir) == false)
				dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			//FolderBrowserDialogクラスのインスタンスを作成
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				//上部に表示する説明テキストを指定する
				fbd.Description = "フォルダを指定してください。";
				//ルートフォルダを指定する
				//デフォルトでDesktop
				fbd.RootFolder = Environment.SpecialFolder.Desktop;
				//最初に選択するフォルダを指定する
				//RootFolder以下にあるフォルダである必要がある
				fbd.SelectedPath = dir;
				//ユーザーが新しいフォルダを作成できるようにする
				//デフォルトでTrue
				fbd.ShowNewFolderButton = newFolderOk;

				//ダイアログを表示する
				if (fbd.ShowDialog(parent) == DialogResult.OK)
				{
					//選択されたフォルダを表示する
					//Console.WriteLine(fbd.SelectedPath);

					tb.Text = fbd.SelectedPath;
				}
			}
		}
	}
}
