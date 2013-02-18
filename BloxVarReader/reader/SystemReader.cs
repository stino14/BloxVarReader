using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO; 

using log4net;

using BloxVarReader.data;

namespace BloxVarReader.reader
{
	public class SystemReader
	{
		private static readonly ILog log = Helper.getLog();

		private XmlDocument m_xmlDocSystems;
		private XmlDocument m_xmlDocBlox;
		private TBSystem m_System;

		private string m_szDir;

		public SystemReader(string i_szDir)
		{
			m_xmlDocSystems = new XmlDocument();
			m_szDir = i_szDir;
		}


		public TBSystem readSystem(string i_szSystem)
		{
			BlockType type = BlockType.Auxiliary;
			m_System = new TBSystem(i_szSystem);
			#region DocSystemOpen
			if (log.IsDebugEnabled) log.Debug("Trying to open systemfile: " + m_szDir + "Systems\\" + i_szSystem);
			FileStream fs = new FileStream(m_szDir + "Systems\\" + i_szSystem, 
											FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			m_xmlDocSystems.Load(fs);
			fs.Close();
			#endregion
			XmlNodeList nodes = m_xmlDocSystems.ChildNodes[1].ChildNodes;

			foreach (XmlNode node in nodes) {
				if (node.NodeType == XmlNodeType.Comment) continue;
				switch (node.Attributes[0].Value) {
					case "auxiliary":
						type = BlockType.Auxiliary;
						break;
					case "portfolio_manager":
						type = BlockType.PortfolioManager;
						break;
					case "entry_exit":
						type = BlockType.EntryExit;
						break;
					case "money_manager":
						type = BlockType.MoneyManager;
						break;
					case "risk_manager":
						type = BlockType.RiskManager;
						break;
				}
				#region DocBloxOpen
				if (log.IsDebugEnabled) log.Debug("Trying to open bloxfile: " + m_szDir + "Blox\\" + node.InnerText + ".tbx");
				m_xmlDocBlox = new XmlDocument();
				fs = new FileStream(m_szDir + "Blox\\" + node.InnerText + ".tbx",
									FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				m_xmlDocBlox.Load(fs);
				fs.Close();
				#endregion
				m_System.addBlox(readBlock(type, node.InnerText));	
			}
			
			m_System.createGlobalVars();

			return m_System;
		}

		private Blox readBlock(BlockType type, string szName)
		{
			Blox blox = new Blox(szName, type);
			UseType useType;

			foreach (XmlNode node in m_xmlDocBlox.ChildNodes[1].ChildNodes) {
				if (node.Name == "indicator") {
					blox.addIndicator(BloxReader.CreateIndicator(node));
				} else if(node.Name != "script"){ 
					switch(node.Name) {
						case "instrument_global":
							useType = UseType.InstrumentGlobal;
							break;
						case "block_global":
							useType = UseType.BlockGlobal;
							break;
						case "parameter":
							useType = UseType.Parameter;
							break;
						default:
							if (node.Name != "#comment") {
								if (log.IsWarnEnabled) log.Warn("Variable Type not recognized. Skipping! (" + node.Name + ")");
							}
							continue;
					}

					blox.addVar(BloxReader.CreateVar(node, useType));
				}
			}

			return blox;
			
		}
	}
}
