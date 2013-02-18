using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using BloxVarReader.reader;

namespace BloxVarReader.test
{
	[TestFixture]
	public class CmdLineReaderTest
	{
		private string[] tradingbloxdir;
		private string[] outputdir;
		private string[] outputdirlong;
		private string[] system;
		private string[] systemlong;
		//private string systemmultiple;
		//private string systemmultiplelong;
		//private string complete;
		//private string completelong;
		
		//[TestFixtureSetUp]
		//public void init()
		//{
		//    //tradingbloxdir = new string[] {"TradingBloxDirectory"};
		//    //outputdir = new string[] {"-o", "output", "TradingBloxDirectory"};
		//    //outputdirlong = new string[] {"--output-dir", "output", "TradingBloxDirectory"};
		//    //system = new string[] {"-s", "Pattern", "TradingBloxDirectory"};
		//    //systemlong = new string[] {"--system", "Pattern", "TradingBloxDirectory"};
		//    //systemmultiple = "-s \"Pattern,Vola\" TradingBloxDiretory";
		//    //systemmultiplelong = "--system \"Pattern,Vola\" TradingBloxDiretory";
		//}

		[Test]
		public void TradingBloxDirTest()
		{
			tradingbloxdir = new string[] { "T:\\Tradingblox Installationen\\Goetz\\TradingBlox" };
			CmdLineReader reader = new CmdLineReader(tradingbloxdir);
			Assert.AreEqual(tradingbloxdir[0] + "\\", reader.BloxDir);
		}

		[Test]
		public void ouputdirectorytest()
		{
			outputdir = new string[] { "-o", "output", "T:\\Tradingblox Installationen\\Goetz\\TradingBlox" };
			CmdLineReader reader = new CmdLineReader(outputdir);
			Assert.AreEqual(outputdir[2] + "\\", reader.BloxDir);
			Assert.AreEqual(outputdir[1] + "\\", reader.OutputDir);
		}

		[Test]
		public void OutputDirectoryLongTest()
		{
			outputdirlong = new string[] { "--output-dir", "output", "T:\\Tradingblox Installationen\\Goetz\\TradingBlox" };
			CmdLineReader reader = new CmdLineReader(outputdirlong);
			Assert.AreEqual(outputdirlong[2] + "\\", reader.BloxDir);
			Assert.AreEqual(outputdirlong[1] + "\\", reader.OutputDir);
		}

		[Test]
		public void SetSystemTest()
		{
			system = new string[] { "-s", "Pattern", "T:\\Tradingblox Installationen\\Goetz\\TradingBlox" };
			CmdLineReader reader = new CmdLineReader(system);
			Assert.AreEqual(system[2] + "\\", reader.BloxDir);
			Assert.AreEqual(system[1] + ".tbs", reader.Systems[0]);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void WrongInputTest()
		{
			string[] wrong = new string[] { "--system", "Pattern" };
			CmdLineReader reader = new CmdLineReader(wrong);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void WrongDirTest()
		{
			string[] wrongdir = new string[] { "TradingBlox" };
			CmdLineReader reader = new CmdLineReader(wrongdir);
		}

	}
}
