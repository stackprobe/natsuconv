using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class ExtOptions
	{
		private List<string[]> _extOptions = new List<string[]>();

		public ExtOptions()
		{
			foreach (string line in File.ReadAllLines(DATA_FILE, StringTools.ENCODING_SJIS))
			{
				int index = line.IndexOf('=');

				if (index == -1)
					throw null;

				string ext = "." + line.Substring(0, index);
				string option = line.Substring(index + 1);

				_extOptions.Add(new string[] { ext, option });
			}
		}

		private static string DATA_FILE
		{
			get
			{
				string file = "extensions_options.dat";

				if (File.Exists(file) == false)
					file = Path.GetFullPath(@"..\..\..\..\doc\extensions_options.dat");

				return file;
			}
		}

		public string GetOption(string ext)
		{
			int index = GetIndex(ext);

			if (index == -1)
			{
				index = GetIndex(".*");

				if (index == -1)
					throw null;
			}
			return _extOptions[index][1];
		}

		private int GetIndex(string ext)
		{
			for (int index = 0; index < _extOptions.Count; index++)
				if (StringTools.IsSame(_extOptions[index][0], ext, true))
					return index;

			return -1; // not found
		}
	}
}
