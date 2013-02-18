using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloxVarReader.reader
{
	public class GuiSettings : ISettingsReader
	{
		public string BloxDir { get; set; }
		public string OutputDir { get; set; }
		public string[] Systems { get; set; }
		public int Threads { get; set; }


	}
}
