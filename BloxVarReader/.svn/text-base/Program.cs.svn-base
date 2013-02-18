using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BloxVarReader.reader;
using BloxVarReader.gui;

namespace BloxVarReader
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main(string[] argv)
		{
			Helper.configure();
			DeepThought pDeepThough = null;
			if (argv.Length == 0) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmMain());
			} else {
				try {
					pDeepThough = new DeepThought(new CmdLineReader(argv));
					pDeepThough.statChanged += new statusChanged(stub);
					pDeepThough.readSystems();
				} catch (ArgumentNullException ane) {
					Environment.Exit(0xff);
				} catch (ArgumentException ae) {
					Environment.Exit(0xfe);
				}
			}

		}

		public static void stub(int percent)
		{

		}


	}
}
