using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using BloxVarReader.reader;
using System.IO;

namespace BloxVarReader.test
{
	[TestFixture]
	public class SystemNameReaderTest
	{
		private static readonly string[] expectedSystems = { "ContractioField-s", "ContractioField-xs", "ContractioField",
															 "Doubletop", "DoubleToSaw-new", "NAV_Counter", "Pattern", 
															 "Sawwave", "Sawwave_newTest", "Tripletop-new" };

		[Test]
		public void getSystemNamesTest()
		{
			SystemNameReader read = new SystemNameReader(@"C:\Dokumente und Einstellungen\JG\Eigene Dateien\Visual Studio 2008\Projects\BloxVarReader\BloxVarReader\bin\Debug\TestCase");

			string[] systems = read.getAvailableSystems();

			for(int i = 0; i < systems.Length; i++) {
				Assert.AreEqual(expectedSystems[i],systems[i]);
			}

		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void invalidTradingBloxDirectoryTest()
		{
			SystemNameReader read = new SystemNameReader(@"C:\");

			string[] systems = read.getAvailableSystems();

		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void invalidDirectoryTest()
		{
			SystemNameReader read = new SystemNameReader("das ist doch kein Verzeichnis");

			string[] systems = read.getAvailableSystems();
		}
	}
}
