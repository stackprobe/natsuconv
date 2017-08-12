using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class MediaInfo
	{
		public List<AudioStream> AudioStreams = new List<AudioStream>();
		public List<VideoStream> VideoStreams = new List<VideoStream>();

		public MediaInfo(string file)
		{
			string[] lines = File.ReadAllLines(file, Encoding.ASCII);

			foreach (string line in lines)
			{
				if (line.Contains("Stream") == false)
					continue;

				int p = line.IndexOf("#0:");

				if (p == -1)
					continue;

				p += 3;
				int q = p;

				while (StringTools.DIGIT.Contains(line[q]))
					q++;

				if (p == q)
					continue;

				int mapIndex = int.Parse(line.Substring(p, q - p));

				if (line.Contains("Audio:"))
				{
					this.AudioStreams.Add(new AudioStream()
					{
						MapIndex = mapIndex,
					});
				}
				else if (line.Contains("Video:"))
				{
					this.VideoStreams.Add(new VideoStream()
					{
						MapIndex = mapIndex,
					});
				}
			}
		}

		public class AudioStream
		{
			public int MapIndex;
		}

		public class VideoStream
		{
			public int MapIndex;
		}
	}
}
