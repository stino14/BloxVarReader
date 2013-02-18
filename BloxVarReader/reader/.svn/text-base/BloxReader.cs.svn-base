using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using log4net;

using BloxVarReader.data;


namespace BloxVarReader.reader
{
	public static class BloxReader
	{
		private static readonly ILog log = Helper.getLog();


		public static BlockVar CreateVar(XmlNode i_node, UseType useType)
		{
			BlockVar var = new BlockVar();
			Scope scope = Scope.Block;

			var.UseType = useType;
			var.VarType = i_node.Attributes[0].Value;
			
			foreach (XmlNode node in i_node.ChildNodes) {
				switch (node.Name) {
					case "script_name":
						var.Name = node.InnerText;
						break;
					case "variable_scope":
						switch(node.InnerText) {
							case "Block":
								scope = Scope.Block;
								break;
							case "System":
								scope = Scope.System;
								break;
							case "Simulation":
								scope = Scope.Simulation;
								break;
						}
						var.Scope = scope;
						break;
					case "auto_index":
						var.AutoIndex = bool.Parse(node.InnerText);
						break;
					case "series_size":
						var.SeriesSize = int.Parse(node.InnerText);
						break;
					case "default_value":
						var.DefaultValue = node.InnerText;
						break;
					case "external":
						var.External = bool.Parse(node.InnerText);
						break;
					case "plots":
						var.Plots = bool.Parse(node.InnerText);
						break;
					case "plot_area":
						var.Plotname = node.InnerText;
						break;
					default:
						break;
				}
			}
	
			return var;
		}

		public static Indicator CreateIndicator(XmlNode i_node)
		{
			Indicator indi = new Indicator();
			List<string> sourceParameters = new List<string>();

			indi.Type = i_node.Attributes[0].Value;

			foreach (XmlNode node in i_node.ChildNodes) {
				switch (node.Name) {
					case "script_name":
						indi.ScriptName = node.InnerText;
						break;
					case "source_parameter":
						sourceParameters.Add(node.InnerText);
						break;
					case "plots":
						indi.Plot = bool.Parse(node.InnerText);
						break;
					case "fixed_param_one":
						indi.Params[0] = node.InnerText;
						break;
					case "fixed_param_two":
						indi.Params[1] = node.InnerText;
						break;
					case "fixed_param_three":
						indi.Params[2] = node.InnerText;
						break;
					case "variable_scope":
						switch (node.InnerText) {
							case "Block":
								indi.Scope = Scope.Block;
								break;
							case "Simulation":
								indi.Scope = Scope.Simulation;
								break;
							case "System":
								indi.Scope = Scope.System;
								break;
						}
						break;
					default:
						break;
				}
			}
			indi.SourceParameters = sourceParameters.ToArray();
			return indi;
		}


	}
}
