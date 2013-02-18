using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using log4net;


namespace BloxVarReader.reader
{
	public class CmdLineReader : ISettingsReader
	{
		private static ILog log = Helper.getLog();
		
		private const string HelpText = "Usage: BloxVarReader.exe [Options] <Trading_Blox_Dir>\n\n" + 
										"\t-s / --system: Gibt an von welchem System die Dokumentation erfolgen soll\n" + 
										"\t-o / --output-dir: Gibt an in welchem Verzeichnis die Ausgabe erfolgen solle. (Standard: momentanes Verzeichnis)\n" + 
										"\t-h / --help: Zeigt diesen Test an";

		private string m_szBloxDir;
		private string[] m_szSystems;
		private int m_dThreads;
		private string m_szOutputDir;

		public CmdLineReader(string[] args)
		{
		
			int i = 0;
			List<string> systems = new List<string>();
			m_szOutputDir = "";

			while(i < args.Length) {

				if (args[i][0] == '-' && args[i][1] != '-') {
					switch (args[i][1]) {
						case 's':
							systems.AddRange(args[i + 1].Split(','));
							i++;
							break;
						case 't':
							m_dThreads = int.Parse(args[i + 1]);
							i++;
							break;
						case 'o':
							m_szOutputDir = args[i + 1];
							i++;
							break;
						case 'h':
							Console.WriteLine(HelpText);
							Environment.Exit(0x00);
							break;
						default:
							Console.WriteLine("Parameter not recognized: " + args[i]);
							break;
					}
				} else if (args[i][0] == '-' && args[i][1] == '-') {
					switch (args[i].Substring(2, args[i].Length - 2)) {
						case "system":
							systems.AddRange(args[i + 1].Split(','));
							i++;
							break;
						case "threads":
							m_dThreads = int.Parse(args[i + 1]);
							i++;
							break;
						case "output-dir":
							m_szOutputDir = args[i + 1];
							i++;
							break;
						case "help":
							Console.WriteLine(HelpText);
							Environment.Exit(0x00);
							break;
						default:
							Console.WriteLine("Parameter not recognized: " + args[i]);
							break;
					}
				} else {
					if (log.IsInfoEnabled) log.Info("Blox directory: " + args[i]);
					if (!Directory.Exists(args[i])) {
						log.Error("Directory does not exist.");
						throw new ArgumentException("TradingBlox directory could not be found.");
					}
					m_szBloxDir = args[i];
					if (m_szBloxDir[m_szBloxDir.Length - 1] != '\\') { m_szBloxDir += "\\"; }
				}
				i++; ;
			}

			if (m_szOutputDir != "" && m_szOutputDir[m_szOutputDir.Length - 1] != '\\') { m_szOutputDir += "\\"; }
			for (int l = 0; l < systems.Count; l++ ) { systems[l] += ".tbs"; }
			m_szSystems = systems.ToArray();

			if (log.IsInfoEnabled) {
				log.Info("Configured Settings: ");
				log.Info("TradingBlox Directory: " + m_szBloxDir);
				log.Info("Output Directory: " + Environment.CurrentDirectory + m_szOutputDir);
				string debugsystems = "";
				if(m_szSystems.Length == 0) debugsystems = "all";
				else foreach (string s in m_szSystems) debugsystems += s + " ";
				log.Info("Specified systems: " + debugsystems);
			}

			if (m_szBloxDir == null) throw new ArgumentNullException("BloxDirectory was not provided");
		
		}


		public string BloxDir
		{
			get { return m_szBloxDir; }
		}

		public string[] Systems
		{
			get { return m_szSystems; }
		}

		public int Threads
		{
			get { return m_dThreads; }
		}

		public string OutputDir
		{
			get { return m_szOutputDir; }
		}

	}
}
