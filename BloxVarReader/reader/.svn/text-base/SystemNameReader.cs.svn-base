using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BloxVarReader.reader
{
	public class SystemNameReader
	{
		private string tradingBloxDir;


		public SystemNameReader(string tBloxDir)
		{
			tradingBloxDir = tBloxDir;
		}

		public string[] getAvailableSystems()
		{
			string[] entries = Directory.GetFiles(tradingBloxDir + "\\Systems", "*.tbs");

			for (int i = 0; i < entries.Length; i++) {
				entries[i] = entries[i].Substring(entries[i].LastIndexOf('\\') + 1,
					entries[i].Length - entries[i].LastIndexOf('\\') - 1 - 4);
			}

			return entries;
		}
	}
}
