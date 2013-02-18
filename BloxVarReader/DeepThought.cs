using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using log4net;

using BloxVarReader.reader;
using BloxVarReader.data;
using BloxVarReader.writer;

namespace BloxVarReader
{
	public delegate void statusChanged(int percentComplete);
	
	public class DeepThought
	{
		
		private static ILog log = Helper.getLog();

		private static string Resource_Folder = "resources\\";
		private static string Stylesheet = "bloxy.css";
		private static string[] Images = { "tab_rinact.png", "tab_ract.png", "tab_linact.png", "tab_lact.png", "tab_b.png" };

		private string m_szBloxDir;
		private string[] m_szSystems;
		private int m_pThreads;
		private int percent = 0;
		private string m_szOutputDir;

		public event statusChanged statChanged;

		private List<TBSystem> m_Systems;

		public DeepThought(ISettingsReader i_pCmdLineReader)
		{
			m_szBloxDir = i_pCmdLineReader.BloxDir;
			m_szSystems = i_pCmdLineReader.Systems;
			m_pThreads = i_pCmdLineReader.Threads;
			m_szOutputDir = i_pCmdLineReader.OutputDir;
			m_Systems = new List<TBSystem>();
		}

		public void readSystems()
		{
			SystemReader reader = new SystemReader(m_szBloxDir);
			BloxDef bloxdef;

			if (m_szSystems.Length == 0) {
				string[] systems= Directory.GetFiles(m_szBloxDir + "Systems\\","*.tbs");
				m_szSystems = new string[systems.Length];
				for (int i = 0; i < systems.Length; i++) {
					m_szSystems[i] = systems[i].Substring(systems[i].LastIndexOf('\\') + 1, 
											systems[i].Length - systems[i].LastIndexOf('\\') - 1);
				}
			}

			if (log.IsDebugEnabled) log.Debug("Reading properties for systems");
			foreach (string sys in m_szSystems) {
				m_Systems.Add(reader.readSystem(sys));
				percent += 25 / m_szSystems.Length;
				statChanged(percent);
			}
			percent = 25;
			statChanged(percent);

			if (log.IsDebugEnabled) log.Debug("Generating output files");
			foreach (TBSystem system in m_Systems) {
				if (log.IsInfoEnabled) log.Info("Generating output for system: " + system.SystemName);
				bloxdef = new BloxDef(system, m_szOutputDir);
				copyResourceFiles(system.SystemName.Substring(0, system.SystemName.Length - 4), m_szOutputDir);
				bloxdef.createMain();
				bloxdef.createBloxList();
				bloxdef.createVarList();
				bloxdef.generateOutput();
				percent += 75 / m_Systems.Count;
				statChanged(percent);
			}

			percent = 100;
			statChanged(percent);

			Console.WriteLine("");
		}

		private void copyResourceFiles(string system, string _outputDir)
		{
			string folder = _outputDir + system + "\\";

			File.Copy(Resource_Folder + Stylesheet, folder + Stylesheet,true);
			foreach(string im in Images) {
				File.Copy(Resource_Folder + im, folder + im,true);
			}
		}
	}
}
