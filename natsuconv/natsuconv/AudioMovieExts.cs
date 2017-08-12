using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class AudioMovieExts
	{
		/// <summary>
		/// 各行は、"." + 拡張子
		/// 例)
		/// .mp4
		/// .mpeg
		/// .wav
		/// </summary>
		private List<string> _exts = new List<string>();

		public AudioMovieExts()
		{
			foreach (string ext in File.ReadAllLines(DATA_FILE))
				if (ext != "")
					_exts.Add("." + ext);
		}

		public string[] GetExts()
		{
			return _exts.ToArray();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="targetExt">"." + 拡張子</param>
		/// <returns></returns>
		public bool Contains(string targetExt)
		{
			foreach (string ext in _exts)
				if (StringTools.IsSame(ext, targetExt, true))
					return true;

			return false;
		}

		/// <summary>
		/// 各行は、1つの拡張子のみ
		/// 例)
		/// mp4
		/// mpeg
		/// wav
		/// </summary>
		private static string DATA_FILE
		{
			get
			{
				string file = "audio_movie_extensions.dat";

				if (File.Exists(file) == false)
					file = Path.GetFullPath(@"..\..\..\..\doc\audio_movie_extensions.dat");

				return file;
			}
		}
	}
}
