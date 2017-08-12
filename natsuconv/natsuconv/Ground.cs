using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class Gnd
	{
		public static string ffmpegDir = "";
		public static string InputDir = "";
		public static string OutputDir = "";
		public static bool SameDir = true;
		public static bool ErrorFileCopy = false;
		public static bool NotProcessedCopy = true;
		public static bool OtherFileCopy = false;

		public static void LoadData()
		{
			try
			{
				string[] lines = File.ReadAllLines(DATA_FILE, Encoding.UTF8);
				int c = 0;

				ffmpegDir = lines[c++];
				InputDir = lines[c++];
				OutputDir = lines[c++];
				SameDir = StringTools.ToFlag(lines[c++]);
				ErrorFileCopy = StringTools.ToFlag(lines[c++]);
				NotProcessedCopy = StringTools.ToFlag(lines[c++]);
				OtherFileCopy = StringTools.ToFlag(lines[c++]);
			}
			catch
			{ }
		}

		public static void SaveData()
		{
			try
			{
				List<string> lines = new List<string>();

				lines.Add(ffmpegDir);
				lines.Add(InputDir);
				lines.Add(OutputDir);
				lines.Add(StringTools.ToString(SameDir));
				lines.Add(StringTools.ToString(ErrorFileCopy));
				lines.Add(StringTools.ToString(NotProcessedCopy));
				lines.Add(StringTools.ToString(OtherFileCopy));

				File.WriteAllLines(DATA_FILE, lines, Encoding.UTF8);
			}
			catch
			{ }
		}

		public static string DATA_FILE
		{
			get
			{
				return StringTools.Combine(BootTools.SelfDir, Path.GetFileNameWithoutExtension(BootTools.SelfFile) + ".dat");
			}
		}

		public static Logger ConvLog;

		public static Conv Conv;
		public static BusyDlg BusyDlg;
	}
}
