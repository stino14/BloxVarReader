using System;
using System.Collections.Generic;
using System.Text;

namespace BloxVarReader.data
{
	public class GlobalVar : Var, IComparable<GlobalVar>
	{
		private Blox m_pBloxCreated;
		private List<Blox> m_parBloxUsed;

		public GlobalVar()
		{
			m_parBloxUsed = new List<Blox>();
		}


		public int CompareTo(GlobalVar that)
		{
			return this.Name.CompareTo(that.Name);
		}

		#region Properties
		public Blox BloxCreated
		{
			get { return m_pBloxCreated; }
			set { m_pBloxCreated = value; }
		}

		public List<Blox> BloxUsed
		{
			get { return m_parBloxUsed; }
			set { m_parBloxUsed = value; }
		}
		#endregion
	}
}
