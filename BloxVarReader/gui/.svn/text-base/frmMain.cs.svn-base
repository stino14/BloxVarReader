using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BloxVarReader.reader;

namespace BloxVarReader.gui
{
	public partial class frmMain : Form
	{
		private static readonly int CHECKBOX_TOP_START = 5;
		private static readonly int CHECKBOX_LEFT_START = 5;
		private static readonly int CHECKBOX_HORIZONTAL_SPACING = 5;
		private static readonly int CHECKBOX_PER_ROW = 3;
		private static readonly int CHECKBOX_VERTICAL_SPACING = 5;
		private static readonly int CHECKBOX_HEIGHT = 25;
		private static readonly int CHECKBOX_WIDTH = 120;


		private CheckBox[] systemCheckBoxes;

		
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			tbOutputDir.Text = Environment.CurrentDirectory;
		}

		private void bCreate_Click(object sender, EventArgs e)
		{
			if (tbBloxDir.Text == "" || !Directory.Exists(tbBloxDir.Text)) {
				MessageBox.Show("Can't find specified TradingBlox Directory.", 
					"Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!Directory.Exists(tbOutputDir.Text)) {
				MessageBox.Show("Can't find Output Directory. Please enter a valid directory",
					"Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<string> systems = new List<string>();
			GuiSettings settings = new GuiSettings();
			if (tbBloxDir.Text[tbBloxDir.Text.Length - 1] != '\\') settings.BloxDir = tbBloxDir.Text + '\\';
			else settings.BloxDir = tbBloxDir.Text;

			if (tbOutputDir.Text[tbOutputDir.Text.Length - 1] != '\\') settings.OutputDir = tbOutputDir.Text + '\\';
			else settings.OutputDir = tbOutputDir.Text;


			foreach (CheckBox cb in systemCheckBoxes) {
				if (cb.Checked == true) systems.Add(cb.Text + ".tbs");
			}

			if (systems.Count == 0) {
				MessageBox.Show("No System was selected!", "Missing Information",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			settings.Systems = systems.ToArray();

			DeepThought deep = new DeepThought(settings);

			deep.statChanged += new statusChanged(updateProgress);
			pProgress.Visible = true;
			bCreate.Enabled = false;
			deep.readSystems();


		}

		private void updateProgress(int percent)
		{
			pProgress.Value = percent;
			if (percent == 100) bCreate.Enabled = true;
		}

		private void createSystemCheckBoxes()
		{
			int xValue = CHECKBOX_LEFT_START;
			int yValue = CHECKBOX_TOP_START;
			int controlsInRow = 0;
			int controlsPerRow = (pSystems.Size.Width - CHECKBOX_LEFT_START) / (CHECKBOX_WIDTH + CHECKBOX_HORIZONTAL_SPACING);
			string[] systemNames;
			SystemNameReader sysReader = new SystemNameReader(tbBloxDir.Text);
			lblSystems.Text = "Systems:";
			try {
				systemNames = sysReader.getAvailableSystems();
			} catch (DirectoryNotFoundException de) {
				MessageBox.Show("Directory not a valid TradingBlox Directory", "Incorrect Information",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			systemCheckBoxes = new CheckBox[systemNames.Length];

			for (int i = 0; i < systemNames.Length; i++) {
				systemCheckBoxes[i] = new CheckBox();
				systemCheckBoxes[i].Text = systemNames[i];
				systemCheckBoxes[i].Size = new Size(CHECKBOX_WIDTH, CHECKBOX_HEIGHT);
				systemCheckBoxes[i].Checked = true;

				//Position der checkBoxes
				systemCheckBoxes[i].Location = new Point(xValue, yValue);
				xValue += systemCheckBoxes[i].Size.Width + CHECKBOX_HORIZONTAL_SPACING;

				controlsInRow++;
				if (controlsInRow == controlsPerRow) {
					xValue = CHECKBOX_LEFT_START;
					yValue += systemCheckBoxes[i].Size.Height + CHECKBOX_VERTICAL_SPACING;
					controlsInRow = 0;
				}
			}
			pSystems.Controls.Clear();
			pSystems.Controls.AddRange(systemCheckBoxes);
		}

		private void bBloxDir_Click(object sender, EventArgs e)
		{
			if (dirctoryDialog.ShowDialog() == DialogResult.OK) {
				tbBloxDir.Text = dirctoryDialog.SelectedPath;
			}
		}

		private void bOutputDir_Click(object sender, EventArgs e)
		{
			if (dirctoryDialog.ShowDialog() == DialogResult.OK) {
				tbOutputDir.Text = dirctoryDialog.SelectedPath;
			}
		}

		private void tbBloxDir_TextChanged(object sender, EventArgs e)
		{
			if (Directory.Exists(tbBloxDir.Text)) {
				createSystemCheckBoxes();
			} else {
				pSystems.Controls.Clear();
				systemCheckBoxes = new CheckBox[1];
				lblSystems.Text = "No systems found in specified directory";
			}
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			int controlsInRow = 0;
			int controlsPerRow = (pSystems.Size.Width - CHECKBOX_LEFT_START) / (CHECKBOX_WIDTH + CHECKBOX_HORIZONTAL_SPACING);
			int xValue = CHECKBOX_LEFT_START;
			int yValue = CHECKBOX_TOP_START;

			for (int i = 0; i < systemCheckBoxes.Length; i++) {
				systemCheckBoxes[i].Location = new Point(xValue, yValue);

				xValue += systemCheckBoxes[i].Size.Width + CHECKBOX_HORIZONTAL_SPACING;
				controlsInRow++;

				if (controlsInRow == controlsPerRow) {
					xValue = CHECKBOX_LEFT_START;
					yValue += systemCheckBoxes[i].Size.Height + CHECKBOX_VERTICAL_SPACING;
					controlsInRow = 0;
				}
			}
		}
	}
}
