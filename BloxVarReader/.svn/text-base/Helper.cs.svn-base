
using System.Diagnostics;
using log4net;
using log4net.Config;

namespace BloxVarReader
{
	public static class Helper
	{
		private static readonly ILog log = Helper.getLog();

		public static void configure()
		{
			XmlConfigurator.Configure();
		}

		/// <summary>
		/// Wrapper for LogFactory
		/// </summary>
		/// <returns>Logger for the calling class</returns>
		public static ILog getLog()
		{
			StackTrace stack = new StackTrace();

			return LogManager.GetLogger(stack.GetFrame(1).GetMethod().DeclaringType);

			
		}
	}

	public enum Scope
	{
		Block, System, Simulation
	}

	public enum UseType
	{
		InstrumentGlobal, BlockGlobal, Parameter
	}

	public enum BlockType
	{
		EntryExit, MoneyManager, Auxiliary, RiskManager, PortfolioManager 
	}
}
