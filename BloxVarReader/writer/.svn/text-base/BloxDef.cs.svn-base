using System;
using System.IO;

using log4net;

using HTMLGenerator.page;
using BloxVarReader.data;
using HTMLGenerator.output;

namespace BloxVarReader.writer
{
	public class BloxDef
	{
		private static readonly ILog log = Helper.getLog();
		
		private static readonly string ID_Current = "id=\"current\"";
		private static readonly string Class_Tabs = "class=\"tabs\"";
		private static readonly string Class_TableHeader = "class=\"headerval\"";
		private static readonly string Class_UsedBlox = "class=\"usedblox\"";
		private static readonly string Class_Params = "class=\"params\"";

		private TBSystem m_System;
		private string m_szOutputDir;

		private PageDef[] pages;
		private PageDef m_pMain;
		private PageDef m_pBloxList;
		private PageDef m_pVarList;
		//private PageDef[] m_Blox;

		public BloxDef(TBSystem _sys, string _szOutputDir)
		{
			string sysDir = _szOutputDir;
			sysDir += _sys.SystemName.Substring(0, _sys.SystemName.Length - 4);
			m_szOutputDir = sysDir;
			m_System = _sys;

			Directory.CreateDirectory(sysDir);
			pages = new PageDef[3];
			string bla = Environment.CurrentDirectory;
			pages[0] = new PageDef("Main", "Main", "main.html", new XHTMLGenerator(sysDir + "\\"));
			pages[1] = new PageDef("BloxList", "List of Blox", "bloxlist.html", new XHTMLGenerator(sysDir + "\\"));
			pages[2] = new PageDef("VarList", "List of all Variables", "varlist.html", new XHTMLGenerator(sysDir + "\\"));
			for (int i = 0; i < 3; i++) Pages.getInstance().addPage(pages[i]);
			m_pMain = pages[0];
			m_pBloxList = pages[1];
			m_pVarList = pages[2];
		}

		public void createMain()
		{
			
			createHeader(m_pMain);

			m_pMain.addPageLayout(new PageLayoutText(null,PageLayoutType.Section,
				m_System.SystemName.Substring(0,m_System.SystemName.Length - 4) + " Documentation"));
		}


		public void createVarList()
		{
			//int i;
			bool used = false;
			createHeader(m_pVarList);
						
			PageLayoutTable table = new PageLayoutTable(null);
			PageLayoutTableData data = null;
			PageLayoutLink createdLink;
			PageLayoutLink usedLink;
			PageLayoutText createdText;
			PageLayoutText usedText;
			PageLayoutText varName;
			PageLayoutList usedList;
			PageLayoutListItem listItem;
			PageLayoutText fillText = new PageLayoutText(null, PageLayoutType.Plain, "");

			m_pVarList.addPageLayout(new PageLayoutText(null,PageLayoutType.Section,
									m_System.SystemName.Substring(0,m_System.SystemName.Length - 4) + "Variable List"));
			m_pVarList.addPageLayout(new PageLayoutText(null, PageLayoutType.Paragraph,
									"Here is brief overview of all variables used in this System."));

			table.addTableData(createVarHeader());

			foreach (GlobalVar var in m_System.VarList) {
				if (var.BloxCreated == null) {
					log.Error("Variable is never created in a block. VarName: " + var.Name);
					continue;
				}
				//i = 0;
				varName = new PageLayoutText(null, PageLayoutType.Plain, var.Name);
				createdText = new PageLayoutText(null, PageLayoutType.Plain, var.BloxCreated.Name);
				createdLink = new PageLayoutLink(null,Pages.getInstance().getPageFileName(var.BloxCreated.Name),createdText);
				usedList = new PageLayoutList(null);
				foreach (Blox blox in var.BloxUsed) {
					usedText = new PageLayoutText(null, PageLayoutType.Plain, blox.Name);
					usedLink = new PageLayoutLink(null, Pages.getInstance().getPageFileName(blox.Name),usedText);
					listItem = new PageLayoutListItem(new string[1] {Class_UsedBlox}, usedLink);
					usedList.addListElem(listItem);
					data = new PageLayoutTableData(null, new PageLayout[3]{ varName, createdLink, usedList});
					used = true;
				}
				if (!used) {
					data = new PageLayoutTableData(null, new PageLayout[3] { varName ,createdLink, fillText });
				}
				table.addTableData(data);
				used = false;
				
			}
			m_pVarList.addPageLayout(table);
		}

		private PageLayoutTableData createVarHeader()
		{
			PageLayoutTableData table;

			PageLayoutText name = new PageLayoutText(null, PageLayoutType.Plain, "Name");
			PageLayoutText created = new PageLayoutText(null, PageLayoutType.Plain, "Created in");
			PageLayoutText used = new PageLayoutText(null, PageLayoutType.Plain, "Used in");

			table = new PageLayoutTableData(new string[1] { Class_TableHeader },
						new PageLayout[3] { name, created, used });

			return table;
		}

		public void createBloxList()
		{
			createHeader(m_pBloxList);
			
			m_pBloxList.addPageLayout(new PageLayoutText(null, PageLayoutType.Section, 
							m_System.SystemName.Substring(0,m_System.SystemName.Length - 4) + " Blox List"));
			m_pBloxList.addPageLayout(new PageLayoutText(null, PageLayoutType.Paragraph,
								"Here is a list of all Blox used"));
			
			PageLayoutTable table = new PageLayoutTable(null);
			PageLayoutTableData tableRow;
			PageLayoutText bloxName;
			PageLayoutText type;
			PageLayoutLink link;
			foreach (Blox blox in m_System.BloxList) {
				bloxName = new PageLayoutText(null, PageLayoutType.Plain, blox.Name);
				link = new PageLayoutLink(null, blox.Name + ".html", bloxName);
				type = new PageLayoutText(null, PageLayoutType.Plain, blox.BlockType);
				createBlox(blox);
				tableRow = new PageLayoutTableData(null, new PageLayout[2] { link, type });
				table.addTableData(tableRow);
			}

			m_pBloxList.addPageLayout(table);
			
		}

		private void createBlox(Blox _blox)
		{
			PageDef page = new PageDef(_blox.Name, _blox.Name, _blox.Name + ".html", new XHTMLGenerator(m_szOutputDir + "\\"));

			createHeader(page);
			
			page.addPageLayout(new PageLayoutText(null, PageLayoutType.Section, _blox.Name + " Description"));
			page.addPageLayout(new PageLayoutText(null, PageLayoutType.Paragraph, 
								"Here is a brief overview of all variables used in this block"));
			
			PageLayoutTable table = new PageLayoutTable(null);
			PageLayoutTableData tableRow;
			PageLayoutText name;
			PageLayoutText varType;
			PageLayoutText useType;
			PageLayoutText scope;
			PageLayoutText defaultValue;
			PageLayoutText external;
			PageLayoutText autoIndex;
			PageLayoutText SeriesSize;
			PageLayoutText plotName;

			
			
			table.addTableData(createBloxTableHeader());


			//TODO: plot Eigenschaften der Variablen in die Tabelle schreiben
			foreach (BlockVar var in _blox.Vars) {
				name = new PageLayoutText(null, PageLayoutType.Plain, var.Name);
				varType = new PageLayoutText(null, PageLayoutType.Plain, var.VarType);
				useType = new PageLayoutText(null, PageLayoutType.Plain, var.UseType.ToString());
				scope = new PageLayoutText(null, PageLayoutType.Plain, var.Scope.ToString());
				defaultValue = new PageLayoutText(null, PageLayoutType.Plain, var.DefaultValue);
				external = new PageLayoutText(null,PageLayoutType.Plain,var.External.ToString());
				if (var.VarType == "Series") {
					autoIndex = new PageLayoutText(null, PageLayoutType.Plain, var.AutoIndex.ToString());
					SeriesSize = new PageLayoutText(null, PageLayoutType.Plain, var.SeriesSize.ToString());
				} else {
					autoIndex = new PageLayoutText(null, PageLayoutType.Plain, "-");
					SeriesSize = new PageLayoutText(null, PageLayoutType.Plain, "-");
				}
				if (var.Plots == true) {
					plotName = new PageLayoutText(null, PageLayoutType.Plain, var.Plotname);
				} else {
					plotName = new PageLayoutText(null, PageLayoutType.Plain, "-");
				}
				
				tableRow = new PageLayoutTableData(null, new PageLayout[] { name, varType, useType, scope, 
													defaultValue, external, autoIndex, SeriesSize,plotName});
				table.addTableData(tableRow);
			}

			page.addPageLayout(table);

			//Auskommentieren um auch Indikatoren auszugeben
			//Neue Tabelle mit Indikatoren erstellen, falls vorhanden in dem Block
			//if (_blox.Indicators.Count > 0) {
			//    page.addPageLayout(createIndicatorTable(_blox));
			//}


			Pages.getInstance().addPage(page);

		}

		private PageLayoutTableData createBloxIndicatorTableHeader()
		{
			PageLayoutTableData tableRow;
			PageLayoutText name = new PageLayoutText(null, PageLayoutType.Plain, "Name");
			PageLayoutText type = new PageLayoutText(null, PageLayoutType.Plain, "Type");
			PageLayoutText scope = new PageLayoutText(null, PageLayoutType.Plain, "Scope");
			PageLayoutText parameter = new PageLayoutText(null, PageLayoutType.Plain, "Parameters");
			PageLayoutText sourceparams = new PageLayoutText(null, PageLayoutType.Plain, "Source Param.");
			PageLayoutText plot = new PageLayoutText(null, PageLayoutType.Plain, "Plots");
			tableRow = new PageLayoutTableData(new string[1] { Class_TableHeader }, new PageLayout[] {name,type,scope,
												parameter,sourceparams,plot});
			return tableRow;
		}

		private PageLayoutTable createIndicatorTable(Blox _blox)
		{
			PageLayoutTable table = new PageLayoutTable(null);

			table.addTableData(createBloxIndicatorTableHeader());

			PageLayoutTableData tableRow;
			PageLayoutText name;
			PageLayoutText type;
			PageLayoutText scope;
			PageLayoutText parameter;
			PageLayoutList paramlist;
			PageLayoutListItem param;
			PageLayoutText sourceparams;
			PageLayoutList sourcelist;
			PageLayoutListItem source;
			PageLayoutText plots;

			foreach (Indicator indi in _blox.Indicators) {
				name = new PageLayoutText(null, PageLayoutType.Plain, indi.ScriptName);
				type = new PageLayoutText(null, PageLayoutType.Plain, indi.Type);
				scope = new PageLayoutText(null, PageLayoutType.Plain, indi.Scope.ToString());
				paramlist = new PageLayoutList(new string[] {Class_Params});
				foreach(string str in indi.Params) {
					parameter = new PageLayoutText(null, PageLayoutType.Plain, str);
					param = new PageLayoutListItem(null, parameter);
					paramlist.addListElem(param);
				}
				sourcelist = new PageLayoutList(new string[] {Class_Params});
				foreach (string str in indi.SourceParameters) {
					if (str != "Enter Value") sourceparams = new PageLayoutText(null, PageLayoutType.Plain, str);
					else sourceparams = new PageLayoutText(null, PageLayoutType.Plain, "-");
					source = new PageLayoutListItem(null, sourceparams);
					sourcelist.addListElem(source);
				}
				plots = new PageLayoutText(null, PageLayoutType.Plain, indi.Plot.ToString());
				tableRow = new PageLayoutTableData(null, new PageLayout[] {name, type, scope, paramlist, 
													sourcelist,plots});
				table.addTableData(tableRow);
			}

			return table;

		}

		private PageLayoutTableData createBloxTableHeader()
		{
			PageLayoutTableData tableData;
			PageLayoutText name = new PageLayoutText(null, PageLayoutType.Plain, "Name");
			PageLayoutText varType = new PageLayoutText(null, PageLayoutType.Plain, "Variable Type");
			PageLayoutText useType = new PageLayoutText(null, PageLayoutType.Plain, "Type");
			PageLayoutText scope = new PageLayoutText(null, PageLayoutType.Plain, "Scope");
			PageLayoutText defaultValue = new PageLayoutText(null, PageLayoutType.Plain, "Default Value");
			PageLayoutText external = new PageLayoutText(null, PageLayoutType.Plain, "External");
			PageLayoutText autoIndex = new PageLayoutText(null, PageLayoutType.Plain, "Auto Index");
			PageLayoutText Seriessize = new PageLayoutText(null, PageLayoutType.Plain, "Series Size");
			PageLayoutText plotName = new PageLayoutText(null, PageLayoutType.Plain, "Plot Area");
			tableData = new PageLayoutTableData(new string[1] {Class_TableHeader}, new PageLayout[] {name, varType, useType, scope, defaultValue,
												external, autoIndex, Seriessize, plotName});

			return tableData;
		}

		public void generateOutput()
		{
			Pages.getInstance().generateOutput();
		}

		private void createHeader(PageDef _page)
		{
			//Create Link List
			PageLayoutList linkList = new PageLayoutList(null);
			PageLayoutListItem item;
			PageLayoutLink link;
			PageLayoutText span;
			for (int i = 0; i < 3; i++) {
				span = new PageLayoutText(null,PageLayoutType.Span,pages[i].Title);
				link = new PageLayoutLink(null, pages[i].FileName, span);
				if(_page == pages[i])
					item = new PageLayoutListItem(new string[]{ID_Current}, link);
				else
					item = new PageLayoutListItem(null, link);
				linkList.addListElem(item);
			}
			PageLayoutDiv div = new PageLayoutDiv(new string[]{Class_Tabs}, new PageLayout[] {linkList});

			_page.addPageLayout(div);

		}
	}
}
