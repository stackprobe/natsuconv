using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Charlotte
{
	public class Logger : IDisposable
	{
		private string _file;

		public Logger(string file)
		{
			_file = file;
		}

		private StreamWriter _fs = null;

		public void Writeln(object line)
		{
			if (_fs == null)
				_fs = new StreamWriter(_file, false, Encoding.UTF8);

			_fs.WriteLine("[" + DateTime.Now + "] " + line);
			_fs.Flush();
		}

		public void Close()
		{
			try
			{
				if (_fs != null)
				{
					_fs.Dispose();
					_fs = null;
				}
			}
			catch
			{ }
		}

		public void Dispose()
		{
			this.Close();
		}
	}
}
