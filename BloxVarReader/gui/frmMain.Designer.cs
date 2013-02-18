namespace BloxVarReader.gui
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbBloxDir = new System.Windows.Forms.TextBox();
			this.lblBloxDir = new System.Windows.Forms.Label();
			this.lblOutputDirectory = new System.Windows.Forms.Label();
			this.tbOutputDir = new System.Windows.Forms.TextBox();
			this.bBloxDir = new System.Windows.Forms.Button();
			this.bOutputDir = new System.Windows.Forms.Button();
			this.bCreate = new System.Windows.Forms.Button();
			this.lblSystems = new System.Windows.Forms.Label();
			this.dirctoryDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.pSystems = new System.Windows.Forms.Panel();
			this.pProgress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// tbBloxDir
			// 
			this.tbBloxDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbBloxDir.Location = new System.Drawing.Point(129, 12);
			this.tbBloxDir.Name = "tbBloxDir";
			this.tbBloxDir.Size = new System.Drawing.Size(247, 20);
			this.tbBloxDir.TabIndex = 0;
			this.tbBloxDir.TextChanged += new System.EventHandler(this.tbBloxDir_TextChanged);
			// 
			// lblBloxDir
			// 
			this.lblBloxDir.AutoSize = true;
			this.lblBloxDir.Location = new System.Drawing.Point(12, 15);
			this.lblBloxDir.Name = "lblBloxDir";
			this.lblBloxDir.Size = new System.Drawing.Size(111, 13);
			this.lblBloxDir.TabIndex = 1;
			this.lblBloxDir.Text = "TradingBlox Directory:";
			// 
			// lblOutputDirectory
			// 
			this.lblOutputDirectory.AutoSize = true;
			this.lblOutputDirectory.Location = new System.Drawing.Point(12, 41);
			this.lblOutputDirectory.Name = "lblOutputDirectory";
			this.lblOutputDirectory.Size = new System.Drawing.Size(84, 13);
			this.lblOutputDirectory.TabIndex = 2;
			this.lblOutputDirectory.Text = "OutputDirectory:\r\n";
			// 
			// tbOutputDir
			// 
			this.tbOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputDir.Location = new System.Drawing.Point(129, 38);
			this.tbOutputDir.Name = "tbOutputDir";
			this.tbOutputDir.Size = new System.Drawing.Size(247, 20);
			this.tbOutputDir.TabIndex = 3;
			// 
			// bBloxDir
			// 
			this.bBloxDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bBloxDir.Location = new System.Drawing.Point(382, 12);
			this.bBloxDir.Name = "bBloxDir";
			this.bBloxDir.Size = new System.Drawing.Size(58, 20);
			this.bBloxDir.TabIndex = 4;
			this.bBloxDir.Text = "Open";
			this.bBloxDir.UseVisualStyleBackColor = true;
			this.bBloxDir.Click += new System.EventHandler(this.bBloxDir_Click);
			// 
			// bOutputDir
			// 
			this.bOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bOutputDir.Location = new System.Drawing.Point(382, 38);
			this.bOutputDir.Name = "bOutputDir";
			this.bOutputDir.Size = new System.Drawing.Size(58, 20);
			this.bOutputDir.TabIndex = 5;
			this.bOutputDir.Text = "Open";
			this.bOutputDir.UseVisualStyleBackColor = true;
			this.bOutputDir.Click += new System.EventHandler(this.bOutputDir_Click);
			// 
			// bCreate
			// 
			this.bCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCreate.Location = new System.Drawing.Point(369, 361);
			this.bCreate.Name = "bCreate";
			this.bCreate.Size = new System.Drawing.Size(75, 23);
			this.bCreate.TabIndex = 6;
			this.bCreate.Text = "Create";
			this.bCreate.UseVisualStyleBackColor = true;
			this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
			// 
			// lblSystems
			// 
			this.lblSystems.AutoSize = true;
			this.lblSystems.Location = new System.Drawing.Point(12, 95);
			this.lblSystems.Name = "lblSystems";
			this.lblSystems.Size = new System.Drawing.Size(190, 13);
			this.lblSystems.TabIndex = 7;
			this.lblSystems.Text = "No systems found in specified directory";
			// 
			// pSystems
			// 
			this.pSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pSystems.AutoScroll = true;
			this.pSystems.Location = new System.Drawing.Point(15, 111);
			this.pSystems.Name = "pSystems";
			this.pSystems.Size = new System.Drawing.Size(425, 213);
			this.pSystems.TabIndex = 8;
			// 
			// pProgress
			// 
			this.pProgress.Location = new System.Drawing.Point(15, 330);
			this.pProgress.Name = "pProgress";
			this.pProgress.Size = new System.Drawing.Size(425, 23);
			this.pProgress.TabIndex = 9;
			this.pProgress.Visible = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 396);
			this.Controls.Add(this.pProgress);
			this.Controls.Add(this.pSystems);
			this.Controls.Add(this.lblSystems);
			this.Controls.Add(this.bCreate);
			this.Controls.Add(this.bOutputDir);
			this.Controls.Add(this.bBloxDir);
			this.Controls.Add(this.tbOutputDir);
			this.Controls.Add(this.lblOutputDirectory);
			this.Controls.Add(this.lblBloxDir);
			this.Controls.Add(this.tbBloxDir);
			this.Name = "frmMain";
			this.Text = "Bloxygen";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbBloxDir;
		private System.Windows.Forms.Label lblBloxDir;
		private System.Windows.Forms.Label lblOutputDirectory;
		private System.Windows.Forms.TextBox tbOutputDir;
		private System.Windows.Forms.Button bBloxDir;
		private System.Windows.Forms.Button bOutputDir;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Label lblSystems;
		private System.Windows.Forms.FolderBrowserDialog dirctoryDialog;
		private System.Windows.Forms.Panel pSystems;
		private System.Windows.Forms.ProgressBar pProgress;
	}
}