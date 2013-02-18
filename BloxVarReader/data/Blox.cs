using System;
using System.Collections.Generic;
using System.Text;

namespace BloxVarReader.data
{
	public class Blox
	{
		private string m_szName;
		private BlockType m_stBlockType;
		private List<Indicator> m_arIndicators;
		private List<BlockVar> m_arBlockVars;


		public Blox(string i_szName, BlockType i_stBlockType)
		{
			m_szName = i_szName;
			m_stBlockType = i_stBlockType;
			m_arBlockVars = new List<BlockVar>();
			m_arIndicators = new List<Indicator>();
		}

		public void addIndicator(Indicator i_indicator)
		{
			m_arIndicators.Add(i_indicator);
		}

		public void addVar(BlockVar i_Var)
		{
			m_arBlockVars.Add(i_Var);
		}

		public List<BlockVar> Vars
		{
			get { return m_arBlockVars; }
		}

		public List<Indicator> Indicators
		{
			get { return m_arIndicators; }
		}

		public string Name
		{
			get { return m_szName; }
		}

		public string BlockType
		{
			get { return m_stBlockType.ToString(); }
		}

	}
}
