using System;
using System.Collections.Generic;
using System.Text;

using log4net;

namespace BloxVarReader.data
{
	public class TBSystem
	{
		private static readonly ILog log = Helper.getLog();
		
		private string m_szName;
		private List<Blox> m_arBlox;
		private List<GlobalVar> m_arVars;

		public TBSystem(string i_szSystemName)
		{
			m_szName = i_szSystemName;
			m_arVars = new List<GlobalVar>();
			m_arBlox = new List<Blox>();
		}


		public void addBlox(Blox i_Blox)
		{
			m_arBlox.Add(i_Blox);
		}

		public void createGlobalVars()
		{
			Dictionary<string, GlobalVar> vars = new Dictionary<string, GlobalVar>();
			GlobalVar currentVar;

			foreach (Blox blox in m_arBlox) {
				blox.Vars.Sort();
				foreach (BlockVar var in blox.Vars) {
					if (!vars.ContainsKey(var.Name.ToLower())) { 
						currentVar = copyVarValues(var);
						vars.Add(currentVar.Name.ToLower(), currentVar);
					} 
					else { currentVar = vars[var.Name.ToLower()]; }

					if (!var.External) currentVar.BloxCreated = blox;
					else currentVar.BloxUsed.Add(blox);

				}
			}



			m_arVars.AddRange(vars.Values);
			m_arVars.Sort();
		}


		private GlobalVar copyVarValues(BlockVar _var)
		{
			GlobalVar newVar = new GlobalVar();
			
			newVar.Name = _var.Name;
			newVar.Scope = _var.Scope;
			newVar.DefaultValue = _var.DefaultValue;
			newVar.AutoIndex = _var.AutoIndex;
			newVar.SeriesSize = _var.SeriesSize;
			newVar.UseType = _var.UseType;
			newVar.VarType = _var.VarType;

			return newVar;
		}

		public string SystemName
		{
			get { return m_szName; }
		}

		public List<GlobalVar> VarList
		{
			get { return m_arVars; }
		}

		public List<Blox> BloxList
		{
			get { return m_arBlox; }
		}


	}
}
