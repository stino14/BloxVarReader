using System;
using System.Collections.Generic;
using System.Text;

namespace BloxVarReader.data
{
	public class BlockVar : Var, IComparable<BlockVar>
	{
		private bool m_bExternal;
		private bool m_fPlots;
		private string m_szPlotname;


		public BlockVar()
		{ }


		public string Plotname
		{
			get { return m_szPlotname; }
			set { m_szPlotname = value; }
		}

		public bool Plots
		{
			get { return m_fPlots; }
			set { m_fPlots = value; }
		}

		public bool External
		{
			get { return m_bExternal; }
			set { m_bExternal = value; }
		}

		public int CompareTo(BlockVar that)
		{
			return Name.CompareTo(that.Name);
		}
	}
}
