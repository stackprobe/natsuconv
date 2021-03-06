﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Charlotte
{
	public static class Utils
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

			if (SaveLoadDialogs.SelectFolder(ref dir, "フォルダを指定してください。"))
				tb.Text = dir;
		}

		// sync > @ AntiWindowsDefenderSmartScreen

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		// < sync

		public static bool Is初回起動()
		{
			return Gnd.Is初回起動();
		}

		public static void WriteLog(object message)
		{
			Gnd.NormLog.Writeln(message);
		}
	}
}
