using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Charlotte.Tools;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace Charlotte
{
	public class Conv
	{
		private string TmpDir;
		private const string WORK_LDIR = "{41d28dd7-e5fd-455f-b82e-6c3d6b9b8bf5}";
		private string WorkDir;
		private string WorkBinDir;
		private string WorkDatDir;
		private string ffmpegDir;
		private string ffmpegFile;
		private string ffmpegBinDir;
		private string RDir;
		private string WDir;

		private List<string> Files_PrepCopy = new List<string>();

		public void Prep()
		{
			Gnd.ConvLog.Close();
			Gnd.ConvLog.Writeln("前処理を開始しました。");

			// ---- work dir ----

			TmpDir = Environment.GetEnvironmentVariable("TMP");
			//TmpDir = @"C:\blank wo fukumu"; // test
			//TmpDir = @"C:\日本語"; // test
			Gnd.ConvLog.Writeln("TmpDir.1: " + TmpDir);

			if (TmpDir == null)
				throw null;

			if (TmpDir == "")
				throw null;

			if (Directory.Exists(TmpDir) == false)
				throw null;

			TmpDir = FileTools.ToFullPath(TmpDir);
			Gnd.ConvLog.Writeln("TmpDir.2: " + TmpDir);

			// TMP に US-ASCII 以外の文字・空白を含む場合、ProgramDataに変更する。
			try
			{
				if (TmpDir.Contains(' '))
					throw new Exception("環境変数 TMP は空白を含んでいます。-> ProgramDataを使用します。");

				byte[] bTmpDir = Encoding.ASCII.GetBytes(TmpDir);
				string sTmpDir = Encoding.ASCII.GetString(bTmpDir);

				if (TmpDir.Equals(sTmpDir) == false)
					throw new Exception("環境変数 TMP は US-ASCII 以外の文字を含んでいます。-> ProgramDataを使用します。");
			}
			catch (Exception e)
			{
				Gnd.ConvLog.Writeln(e);

				string pgDt = Environment.GetEnvironmentVariable("ProgramData");
				Gnd.ConvLog.Writeln("ProgramData: " + pgDt);

				if (pgDt == null)
					throw null;

				if (pgDt == "")
					throw null;

				TmpDir = pgDt;
			}

			Gnd.ConvLog.Writeln("TmpDir.3: " + TmpDir);

			if (Directory.Exists(TmpDir) == false)
				throw null;

			WorkDir = StringTools.Combine(TmpDir, WORK_LDIR);
			Gnd.ConvLog.Writeln("WorkDir: " + WorkDir);
			WorkBinDir = StringTools.Combine(WorkDir, "bin");
			Gnd.ConvLog.Writeln("WorkBinDir: " + WorkBinDir);
			WorkDatDir = StringTools.Combine(WorkDir, "dat");
			Gnd.ConvLog.Writeln("WorkDatDir: " + WorkDatDir);

			DirectoryTools.DeletePath(WorkDir);

			Directory.CreateDirectory(WorkDir);
			Directory.CreateDirectory(WorkBinDir);
			Directory.CreateDirectory(WorkDatDir);

#if false // C:\\の直下は無くなったので、隠す必要は無くなった。
			// +S +H
			{
				// WorkDir は空白を含まないはず！

				ProcessStartInfo psi = new ProcessStartInfo();

				psi.FileName = "ATTRIB.EXE";
				psi.Arguments = "+S +H " + WorkDir;
				psi.CreateNoWindow = true;
				psi.UseShellExecute = false;
				psi.WorkingDirectory = WorkDatDir;

				using (Process p = Process.Start(psi))
				{
					p.WaitForExit();
				}
			}
#endif

			// ---- ffmpeg dir ----

			ffmpegDir = Gnd.ffmpegDir;
			Gnd.ConvLog.Writeln("ffmpegDir.1: " + ffmpegDir);

			const string ffmpegFileErrorTrailer = "\n設定 / ffmpeg / ffmpegのパスを確認して下さい。";

			if (ffmpegDir == "")
				throw new Exception("ffmpegのパスが設定されていません。" + ffmpegFileErrorTrailer);

			if (Directory.Exists(ffmpegDir) == false)
				throw new Exception("ffmpegのパスが存在しません。" + ffmpegFileErrorTrailer);

			ffmpegDir = FileTools.ToFullPath(ffmpegDir);
			Gnd.ConvLog.Writeln("ffmpegDir.2: " + ffmpegDir);

			if (Directory.Exists(ffmpegDir) == false)
				throw new Exception("ffmpegのパスが存在しません。(FullPath)");

			ffmpegFile = Get_ffmpegFile(ffmpegDir);

			if (ffmpegFile == null)
				throw new Exception("ffmpeg.exe が見つかりません。" + ffmpegFileErrorTrailer);

			Gnd.ConvLog.Writeln("ffmpegFile: " + ffmpegFile);
			ffmpegBinDir = Path.GetDirectoryName(ffmpegFile);
			Gnd.ConvLog.Writeln("ffmpegBinDir: " + ffmpegBinDir);

			// ffprobe.exe 存在チェック
			{
				string file = StringTools.Combine(ffmpegBinDir, "ffprobe.exe");

				if (File.Exists(file) == false)
					throw new Exception("ffprobe.exe が見つかりません。" + ffmpegFileErrorTrailer);
			}

			foreach (string file in Directory.GetFiles(ffmpegBinDir))
			{
				string destFile = FileTools.GetCounteredPath(file, ffmpegBinDir, WorkBinDir);

				Gnd.ConvLog.Writeln("< " + file);
				Gnd.ConvLog.Writeln("> " + destFile);

				//File.Copy(file, destFile);
				Files_PrepCopy.Add(file);
				Files_PrepCopy.Add(destFile);
			}

			// ---- Master.exe ----

			{
				string file = "Master.exe";

				if (File.Exists(file) == false)
					file = @"C:\Factory\Program\WavMaster\Master.exe"; // dev env

				string destFile = StringTools.Combine(WorkDir, "Master.exe");

				Gnd.ConvLog.Writeln("Wav-Master");
				Gnd.ConvLog.Writeln("< " + file);
				Gnd.ConvLog.Writeln("> " + destFile);

				//File.Copy(file, destFile);
				Files_PrepCopy.Add(file);
				Files_PrepCopy.Add(destFile);
			}

			// ---- muon.wav ----

			{
				string file = "muon_wav.dat";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\doc\muon_wav.dat"; // dev env

				string destFile = StringTools.Combine(WorkDir, "muon.wav");

				Gnd.ConvLog.Writeln("Muon-Wav");
				Gnd.ConvLog.Writeln("< " + file);
				Gnd.ConvLog.Writeln("> " + destFile);

				//File.Copy(file, destFile);
				Files_PrepCopy.Add(file);
				Files_PrepCopy.Add(destFile);
			}

			// ---- R/WDir ----

			RDir = Gnd.InputDir;

			if (Gnd.SameDir)
				WDir = RDir;
			else
				WDir = Gnd.OutputDir;

			Gnd.ConvLog.Writeln("RDir.1: " + RDir);
			Gnd.ConvLog.Writeln("WDir.1: " + WDir);

			if (RDir == "")
				throw new Exception("入力フォルダが設定されていません。");

			if (WDir == "")
				throw new Exception("出力フォルダが設定されていません。");

			if (Directory.Exists(RDir) == false)
				throw new Exception("入力フォルダが存在しません。");

			if (Directory.Exists(WDir) == false)
				throw new Exception("出力フォルダが存在しません。\n出力フォルダは作成されていなければなりません。");

			RDir = FileTools.ToFullPath(RDir);
			WDir = FileTools.ToFullPath(WDir);
			Gnd.ConvLog.Writeln("RDir.2: " + RDir);
			Gnd.ConvLog.Writeln("WDir.2: " + WDir);

			if (Directory.Exists(RDir) == false)
				throw new Exception("入力フォルダが存在しません。(FullPath)");

			if (Directory.Exists(WDir) == false)
				throw new Exception("出力フォルダが存在しません。(FullPath)");

			// ----

			// 入力・出力フォルダにシステムドライブのルートディレクトリが指定された場合、確認する。
			{
				string sysDrv = Environment.GetEnvironmentVariable("SystemDrive");
				Gnd.ConvLog.Writeln("sysDrv: " + sysDrv);
				string sysRootDir = sysDrv + @"\";
				Gnd.ConvLog.Writeln("sysRootDir: " + sysRootDir);

				if (StringTools.IsSame(sysRootDir, RDir, true))
				{
					if (MessageBox.Show(
						"入力フォルダにシステムドライブのルートフォルダ (" + sysRootDir + ") が指定されています。\n続行しても宜しいですか？",
						"確認",
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Information
						) != DialogResult.OK
						)
						throw new Exception("キャンセルしました。");
				}
				if (StringTools.IsSame(sysRootDir, WDir, true))
				{
					if (MessageBox.Show(
						"出力フォルダにシステムドライブのルートフォルダ (" + sysRootDir + ") が指定されています。\n続行しても宜しいですか？",
						"確認",
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Information
						) != DialogResult.OK
						)
						throw new Exception("キャンセルしました。");
				}
			}

			if (Gnd.SameDir)
			{
				if (MessageBox.Show(
					"オプション「入力フォルダと同じ場所に出力する」が有効になっています。入力フォルダの配下にある動画・音楽ファイルが直接ノーマライズ（上書き）されます。\n続行しても宜しいですか？",
					"確認",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Exception("キャンセルしました。");
			}
			else if (StringTools.IsSame(RDir, WDir, true))
			{
				if (MessageBox.Show(
					"入力フォルダと出力フォルダに同じフォルダが指定されています。\n続行しても宜しいですか？",
					"確認",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Exception("キャンセルしました。");
			}
			else if (FileTools.Is親子関係(RDir, WDir) || FileTools.Is親子関係(WDir, RDir))
			{
				if (MessageBox.Show(
					"入力フォルダと出力フォルダが親子関係にあります。\n続行しても宜しいですか？",
					"確認",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Exception("キャンセルしました。");
			}

			Gnd.ConvLog.Writeln("前処理を終了しました。");
		}

		private string Get_ffmpegFile(string dir)
		{
			foreach (string file in DirectoryTools.GetAllFile(dir))
				if (StringTools.IsSame("ffmpeg.exe", Path.GetFileName(file), true))
					return file;

			return null;
		}

		public bool Cancelled = false; // touched by mlt th
		public bool Errored = false; // touched by mlt th
		public Exception Error = null;

		public int TotalFileCount = 0;
		public int ProcessedFileCount = 0;
		public int ErrorFileCount = 0;
		public int NotProcessedFileCount = 0;
		public int OtherFileCount = 0;
		public int FailedCopyFileCount = 0;

		private bool SameDir;
		private bool ErrorFileCopy;
		private bool NotProcessedFileCopy;
		private bool OtherFileCopy;

		private AudioMovieExts AudioMovieExts = new AudioMovieExts();
		private ExtOptions ExtOptions = new ExtOptions();

		private string LastFailedFile = null;

		private enum ConvFileRet_e
		{
			SUCCESSFUL,
			ERROR,
			NOT_PROCESSED,
			OTHER_FILE,
		};

		/// <summary>
		/// ワーカースレッドから呼ばれる。
		/// </summary>
		public void Main()
		{
			Gnd.ConvLog.Writeln("本処理を開始しました。");

			// 保留してたコピーを実行
			{
				Gnd.ConvLog.Writeln("Files_PrepCopy.1");

				for (int index = 0; index < Files_PrepCopy.Count; index += 2)
				{
					string rFile = Files_PrepCopy[index + 0];
					string wFile = Files_PrepCopy[index + 1];

					Gnd.ConvLog.Writeln("< " + rFile);
					Gnd.ConvLog.Writeln("> " + wFile);

					File.Copy(rFile, wFile);
				}
				Gnd.ConvLog.Writeln("Files_PrepCopy.2");
			}

			ffmpegのテスト();

			SameDir = Gnd.SameDir;

			if (SameDir)
			{
				ErrorFileCopy = false;
				NotProcessedFileCopy = false;
				OtherFileCopy = false;
			}
			else
			{
				ErrorFileCopy = Gnd.ErrorFileCopy;
				NotProcessedFileCopy = Gnd.NotProcessedCopy;
				OtherFileCopy = Gnd.OtherFileCopy;
			}
			Gnd.ConvLog.Writeln("SameDir: " + SameDir);
			Gnd.ConvLog.Writeln("ErrorFileCopy: " + ErrorFileCopy);
			Gnd.ConvLog.Writeln("NotProcessedFileCopy: " + NotProcessedFileCopy);
			Gnd.ConvLog.Writeln("OtherFileCopy: " + OtherFileCopy);

			Gnd.ConvLog.Writeln("audio_movie_extensions: " + string.Join(" ", AudioMovieExts.GetExts()));

			List<string> files = DirectoryTools.GetAllFile(RDir);

			TotalFileCount = files.Count;

			for (int index = 0; index < files.Count; index++)
			{
				GC.Collect();
				//Gnd.BusyDlg.RequestGC = true;
				Gnd.BusyDlg.SetProgress((index + 1) * 1.0 / (files.Count + 1));

				{
					string trailer = "";
					Color statusColor = Color.Black;

					if (this.LastFailedFile != null)
					{
						trailer = "\n最後に失敗したファイル：" + this.LastFailedFile;
					}
					if (1 <= this.ErrorFileCount || 1 <= this.FailedCopyFileCount)
					{
						statusColor = Color.Red;
					}
					Gnd.BusyDlg.SetStatus(
						"総数：" + this.TotalFileCount +
						"\n成功：" + this.ProcessedFileCount +
						" , 失敗：" + this.ErrorFileCount +
						" , 処理不要：" + this.NotProcessedFileCount +
						" , その他：" + this.OtherFileCount +
						"\nコピー失敗：" + this.FailedCopyFileCount +
						trailer,
						statusColor
						);
				}

				string file = files[index];

				Gnd.ConvLog.Writeln("----");
				Gnd.ConvLog.Writeln("[" + index + " / " + files.Count + "]");
				Gnd.ConvLog.Writeln("対象ファイル: " + file);

				switch (ConvFile(file))
				{
					case ConvFileRet_e.SUCCESSFUL:
						Gnd.ConvLog.Writeln("対象ファイルの処理に成功しました。");
						ProcessedFileCount++;
						break;

					case ConvFileRet_e.ERROR:
						Gnd.ConvLog.Writeln("対象ファイルの処理に失敗しました。");
						ErrorFileCount++;
						LastFailedFile = GetLFileUI(file);
						if (ErrorFileCopy)
						{
							CopyFileRDirToWDir(file, "ERROR");
						}
						break;

					case ConvFileRet_e.NOT_PROCESSED:
						Gnd.ConvLog.Writeln("対象ファイルは既にノーマライズされています。(処理不要)");
						NotProcessedFileCount++;
						if (NotProcessedFileCopy)
						{
							CopyFileRDirToWDir(file, "NO-PROC");
						}
						break;

					case ConvFileRet_e.OTHER_FILE:
						Gnd.ConvLog.Writeln("対象ファイルは動画・音楽ファイルではありません。");
						OtherFileCount++;
						if (OtherFileCopy)
						{
							CopyFileRDirToWDir(file, "OTHER");
						}
						break;

					default:
						throw null;
				}
			}
			Gnd.ConvLog.Writeln("----");
			Gnd.ConvLog.Writeln("本処理を終了しました。");

			Gnd.ConvLog.Writeln("====");
			Gnd.ConvLog.Writeln("ファイルの総数: " + TotalFileCount);
			Gnd.ConvLog.Writeln("処理に成功したファイル数: " + ProcessedFileCount);
			Gnd.ConvLog.Writeln("エラーになったファイル数: " + ErrorFileCount);
			Gnd.ConvLog.Writeln("既にノーマライズされていて処理しなかったファイル数: " + NotProcessedFileCount);
			Gnd.ConvLog.Writeln("その他のファイル数: " + OtherFileCount);
			Gnd.ConvLog.Writeln("コピーに失敗したファイル数: " + FailedCopyFileCount);
		}

		private ConvFileRet_e ConvFile(string file)
		{
			if (this.Cancelled) // ★★★ 中止チェック
			{
				throw new Exception("要求により、中止しました。(ConvFile)");
			}

			Gnd.BusyDlg.SetMessage(GetLFileUI(file) + " なう");

			string ext = Path.GetExtension(file);
			Gnd.ConvLog.Writeln("ext: " + ext);

			if (AudioMovieExts.Contains(ext) == false)
			{
				Gnd.ConvLog.Writeln("登録されている動画・音楽ファイルの拡張子ではありません。");
				return ConvFileRet_e.OTHER_FILE;
			}

			DirectoryTools.DeletePath(WorkDatDir);
			Directory.CreateDirectory(WorkDatDir);

			try
			{
				string destFile = StringTools.Combine(WorkDatDir, "0001" + ext);

				Gnd.ConvLog.Writeln("< " + file);
				Gnd.ConvLog.Writeln("> " + destFile);

				File.Copy(file, destFile);

				if (File.Exists(destFile) == false)
					throw new Exception("ファイルのコピーに失敗しました。(対象ファイルにアクセス出来ない？)");
			}
			catch (Exception e)
			{
				Gnd.ConvLog.Writeln(e);
				return ConvFileRet_e.ERROR;
			}

			Run_ffprobe("0001" + ext + " 2> 0002.txt");

			MediaInfo mi = new MediaInfo(StringTools.Combine(WorkDatDir, "0002.txt"));

			foreach (MediaInfo.AudioStream stream in mi.AudioStreams)
				Gnd.ConvLog.Writeln("音声ストリーム.mapIndex=" + stream.MapIndex);

			foreach (MediaInfo.VideoStream stream in mi.VideoStreams)
				Gnd.ConvLog.Writeln("映像ストリーム.mapIndex=" + stream.MapIndex);

			if (mi.AudioStreams.Count == 0 && mi.VideoStreams.Count == 0)
			{
				Gnd.ConvLog.Writeln("映像・音声ストリームが無いため、多分これは動画・音楽ファイルではありません。");
				return ConvFileRet_e.OTHER_FILE;
			}
			if (mi.AudioStreams.Count == 0)
			{
				Gnd.ConvLog.Writeln("音声ストリームが無いため、動画・音楽ファイルと見なしません。");
				return ConvFileRet_e.OTHER_FILE;
			}

			Gnd.ConvLog.Writeln("PROC-AUDIO");

			int audioProcessedCount = 0;

			for (int index = 0; index < mi.AudioStreams.Count; index++)
			{
				string lWavFile = index + ".wav";
				string wavFile = StringTools.Combine(WorkDatDir, lWavFile);

				try
				{
					Gnd.ConvLog.Writeln("音声ストリームを処理します。index=" + index + ", mapIndex=" + mi.AudioStreams[index].MapIndex);

					// ステレオにする。
					Run_ffmpeg("-i 0001" + ext + " -map 0:" + mi.AudioStreams[index].MapIndex + " -ac 2 " + lWavFile);

					if (File.Exists(wavFile) == false)
						throw new Exception("音声ストリームの抽出に失敗しました。"); // -> ConvFileRet_e.ERROR

					File.Delete(StringTools.Combine(WorkDatDir, "0003.wav"));
					File.Delete(StringTools.Combine(WorkDatDir, "0004.report"));
					File.Delete(StringTools.Combine(WorkDatDir, "0004.report-main"));

					Gnd.ConvLog.Writeln("音量をノーマライズします。");

					try
					{
						Run_WavMaster("/E " + Consts.EV_MASTER_CANCEL + " " + lWavFile + " 0003.wav 0004.report-main > 0004.report");

						if (File.Exists(StringTools.Combine(WorkDatDir, "0004.report-main")) == false) // -> ConvFileRet_e.ERROR
						{
							File.Delete(wavFile);
							throw new Exception("0004.report-main does not exist.");
						}
						if (File.Exists(StringTools.Combine(WorkDatDir, "0004.report")) == false) // -> ConvFileRet_e.ERROR
						{
							File.Delete(wavFile);
							throw new Exception("0004.report does not exist.");
						}
					}
					finally
					{
						try
						{
							Gnd.ConvLog.Writeln("WAV-MASTER REPORT BEGIN");

							using (StreamReader rfs = new StreamReader(StringTools.Combine(WorkDatDir, "0004.report"), StringTools.ENCODING_SJIS))
							{
								for (; ; )
								{
									string line = rfs.ReadLine();

									if (line == null)
										break;

									Gnd.ConvLog.Writeln(line);
								}
							}
							Gnd.ConvLog.Writeln("WAV-MASTER REPORT END");
						}
						catch
						{
							Gnd.ConvLog.Writeln("WAV-MASTER REPORT ERROR");
						}
					}

					if (File.Exists(StringTools.Combine(WorkDatDir, "0003.wav")) == false)
						throw new Exception("音量のノーマライズはキャンセルされました。(多分、処理不要)"); // -> 継続

					Gnd.ConvLog.Writeln("音量をノーマライズしました。");

					File.Delete(wavFile);
					File.Move(
						StringTools.Combine(WorkDatDir, "0003.wav"),
						wavFile
						);

					Gnd.ConvLog.Writeln("音声ストリームの処理に成功しました。");

					audioProcessedCount++;
				}
				catch (Exception e)
				{
					Gnd.ConvLog.Writeln(e);
				}
				if (this.Cancelled)
					throw new Exception("要求により、中止しました。(PROC-AUDIO)");

				if (File.Exists(wavFile) == false)
				{
					Gnd.ConvLog.Writeln("Conv_Error: 音声ストリームの処理に問題が発生しました。");
					return ConvFileRet_e.ERROR;
				}
			}

			Gnd.ConvLog.Writeln("audioProcessedCount: " + audioProcessedCount);

			if (audioProcessedCount == 0)
			{
				Gnd.ConvLog.Writeln("ノーマライズを実行した音声ストリームはありません。");
				return ConvFileRet_e.NOT_PROCESSED;
			}

			Gnd.ConvLog.Writeln("PROC-AUDIO OK");
			Gnd.ConvLog.Writeln("MAKE-DEST");

			if (StringTools.IsSame(ext, ".wav", true) && mi.AudioStreams.Count == 1)
			{
				string rFile = Path.Combine(WorkDatDir, "0.wav");
				string wFile = Path.Combine(WorkDatDir, "0005.wav");

				Gnd.ConvLog.Writeln("SIMPLE_COPY");
				Gnd.ConvLog.Writeln("< " + rFile);
				Gnd.ConvLog.Writeln("> " + wFile);

				File.Copy(rFile, wFile);

				Gnd.ConvLog.Writeln("SIMPLE_COPY_DONE");
			}
			else
			{
				List<string> args = new List<string>();
				bool hasVideoStream = 1 <= mi.VideoStreams.Count;

				if (hasVideoStream)
				{
					args.Add("-i");
					args.Add("0001" + ext);
				}
				for (int index = 0; index < mi.AudioStreams.Count; index++) // 音楽
				{
					args.Add("-i");
					args.Add(index + ".wav");
				}
				int fileIndex = 0;

				if (hasVideoStream)
				{
					for (int index = 0; index < mi.VideoStreams.Count; index++) // 動画
					{
						args.Add("-map");
						args.Add(fileIndex + ":" + mi.VideoStreams[index].MapIndex);
					}
					fileIndex++;
				}
				for (int index = 0; index < mi.AudioStreams.Count; index++) // 音楽
				{
					args.Add("-map");
					args.Add(fileIndex + ":0");
					fileIndex++;
				}
				if (hasVideoStream)
				{
					args.Add("-vcodec");
					args.Add("copy");
				}
				args.Add(ExtOptions.GetOption(ext));
				args.Add("0005" + ext);

				Run_ffmpeg(string.Join(" ", args));
			}

			if (File.Exists(StringTools.Combine(WorkDatDir, "0005" + ext)) == false)
			{
				Gnd.ConvLog.Writeln("Conv_Error: 動画・音楽ファイルの再生成に失敗しました。");
				return ConvFileRet_e.ERROR;
			}

			Gnd.ConvLog.Writeln("MAKE-DEST OK");

			try
			{
				string rFile = StringTools.Combine(WorkDatDir, "0005" + ext);
				string destFile = FileTools.GetCounteredPath(file, RDir, WDir);

				Gnd.ConvLog.Writeln("COPY-DEST");
				Gnd.ConvLog.Writeln("< " + rFile);
				Gnd.ConvLog.Writeln("> " + destFile);

				// 出力ファイルのクリア
				{
					DirectoryTools.DeletePath(destFile);
					Directory.CreateDirectory(destFile);
					Directory.Delete(destFile);
				}

				if (File.Exists(destFile))
					throw new Exception("ファイルのコピーに失敗しました。(出力ファイルをクリア出来ません)");

#if true
				File.Copy(rFile, destFile);
				File.Delete(rFile);
#else // 権限とか圧縮状態とか引き継いでしまうので、没..
				File.Move(rFile, destFile);
#endif

				if (File.Exists(destFile) == false)
					throw new Exception("ファイルのコピーに失敗しました。(出力ファイルを生成出来ません)");

				if (File.Exists(rFile))
					throw new Exception("ファイルのコピーに失敗しました。(rFile exists)");
			}
			catch (Exception e)
			{
				Gnd.ConvLog.Writeln(e);
				return ConvFileRet_e.ERROR;
			}

			Gnd.ConvLog.Writeln("COPY-DEST OK");

			return ConvFileRet_e.SUCCESSFUL;
		}

		private void Run_ffmpeg(string arguments)
		{
			Run_Program(@"..\bin\ffmpeg.exe", arguments);
		}

		private void Run_ffprobe(string arguments)
		{
			Run_Program(@"..\bin\ffprobe.exe", arguments);
		}

		private void Run_WavMaster(string arguments)
		{
			Run_Program(@"..\Master.exe", arguments);
		}

		private void Run_Program(string program, string arguments)
		{
			Gnd.ConvLog.Writeln("command-line: " + program + " " + arguments);

			File.WriteAllText(StringTools.Combine(WorkDatDir, "0000.bat"), program + " " + arguments);

			ProcessStartInfo psi = new ProcessStartInfo();

			psi.FileName = "cmd.exe";
			psi.Arguments = "/C 0000.bat";
			psi.CreateNoWindow = true;
			psi.UseShellExecute = false;
			psi.WorkingDirectory = WorkDatDir;

			Gnd.ConvLog.Writeln("command starting");

			using (Process p = Process.Start(psi))
			{
				p.WaitForExit();
			}
			Gnd.ConvLog.Writeln("command ended");

			if (this.Cancelled) // ★★★ 中止チェック
			{
				throw new Exception("要求により、中止しました。");
			}
		}

		private void CopyFileRDirToWDir(string file, string name_option)
		{
			try
			{
				CopyFileRDirToWDir2(file, name_option);
			}
			catch (Exception e)
			{
				Gnd.ConvLog.Writeln(e);
				FailedCopyFileCount++;
				LastFailedFile = GetLFileUI(file);
			}
		}

		private string GetLFileUI(string file)
		{
			string lFile = Path.GetFileName(file);

			if (30 < lFile.Length)
				lFile = lFile.Substring(0, 25) + "...";

			return lFile;
		}

		private void CopyFileRDirToWDir2(string file, string name_option)
		{
			string destFile = FileTools.GetCounteredPath(file, RDir, WDir);
			string midFile = StringTools.Combine(WorkDir, "CopyFileRDirToWDir.mid");

			Gnd.ConvLog.Writeln("COPY-FILE-BY-OPTION_" + name_option);
			Gnd.ConvLog.Writeln("< " + file);
			Gnd.ConvLog.Writeln("$ " + midFile);
			Gnd.ConvLog.Writeln("> " + destFile);

			FileTools.DeleteFileIfExist(midFile);
			File.Copy(file, midFile);

			// 出力ファイルのクリア
			{
				DirectoryTools.DeletePath(destFile);
				Directory.CreateDirectory(destFile);
				Directory.Delete(destFile);
			}

			if (File.Exists(destFile))
				throw new Exception("ファイルのコピーに失敗しました。(出力ファイルをクリア出来ません) OPTION_" + name_option);

#if true
			File.Copy(midFile, destFile);
			File.Delete(midFile);
#else // 権限とか圧縮状態とか引き継いでしまうので、没..
			File.Move(midFile, destFile);
#endif

			if (File.Exists(destFile) == false)
				throw new Exception("ファイルのコピーに失敗しました。(出力ファイルを生成出来ません) OPTION_" + name_option);

			if (File.Exists(midFile))
				throw new Exception("ファイルのコピーに失敗しました。(midFile exist) OPTION_" + name_option);
		}

		public void MainCleanup()
		{
			try
			{
				//#if DEBUG == false
				DirectoryTools.DeletePath(this.WorkDir);
				//#endif
			}
			catch
			{ }
		}

		private void ffmpegのテスト()
		{
			Gnd.ConvLog.Writeln("ffmpegのテスト_Begin");

			DirectoryTools.DeletePath(WorkDatDir);
			Directory.CreateDirectory(WorkDatDir);

			File.Copy(
				StringTools.Combine(WorkDir, "muon.wav"),
				StringTools.Combine(WorkDatDir, "muon.wav")
				);

			Run_ffprobe("muon.wav 2> muon_out.txt");

			MediaInfo mi = new MediaInfo(StringTools.Combine(WorkDatDir, "muon_out.txt"));

			if (mi.VideoStreams.Count != 0)
				throw new Exception("ffmpegを正しく実行出来ません。(vs<>0)");

			if (mi.AudioStreams.Count != 1)
				throw new Exception("ffmpegを正しく実行出来ません。(as<>1)");

			Run_ffmpeg("-i muon.wav -map 0:0 muon_dest.wav");

			if (File.Exists(StringTools.Combine(WorkDatDir, "muon_dest.wav")) == false)
				throw new Exception("ffmpegを正しく実行出来ません。(no_dest)");

			Gnd.ConvLog.Writeln("ffmpegのテスト_End");
		}

		public void Cancelの補助的な何か()
		{
			using (NamedEventData ev = new NamedEventData(Consts.EV_MASTER_CANCEL))
			{
				ev.Set();
			}
		}
	}
}
