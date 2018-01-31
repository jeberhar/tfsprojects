/*
 ###############################################################################
#    This program is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.
#
#    This program is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU General Public License for more details.
#
#    You should have received a copy of the GNU General Public License
#    along with this program.  If not, see <http://www.gnu.org/licenses/>.
###############################################################################
*/

/*
 * Created by SharpDevelop.
 * User: jeberhar
 * Date: 2/8/2010
 * Time: 9:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TFSProjectsWin
{
	partial class frmMain
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.required3 = new System.Windows.Forms.Label();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.chkHttps = new System.Windows.Forms.CheckBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.chkTFS2010 = new System.Windows.Forms.CheckBox();
            this.required4 = new System.Windows.Forms.Label();
            this.lblCollection = new System.Windows.Forms.Label();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.required2 = new System.Windows.Forms.Label();
            this.required1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.rtfMain = new System.Windows.Forms.RichTextBox();
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripBusy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripServerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPortLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCollectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCollection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tfsInfoBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCurrentTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTFSProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.tabDefaults = new System.Windows.Forms.TabPage();
            this.grpCurrentValues = new System.Windows.Forms.GroupBox();
            this.lblDefaultVersion = new System.Windows.Forms.Label();
            this.lblDefaultHTTP = new System.Windows.Forms.Label();
            this.currentHttp = new System.Windows.Forms.Label();
            this.lblDefaultCollection = new System.Windows.Forms.Label();
            this.lblDefaultPath = new System.Windows.Forms.Label();
            this.lblDefaultPort = new System.Windows.Forms.Label();
            this.lblDefaultServer = new System.Windows.Forms.Label();
            this.currentServer = new System.Windows.Forms.Label();
            this.currentPath = new System.Windows.Forms.Label();
            this.currentPort = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.currentCollection = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.setServer = new System.Windows.Forms.Label();
            this.btnSetDefaults = new System.Windows.Forms.Button();
            this.txtSetServer = new System.Windows.Forms.TextBox();
            this.chkSetHttps = new System.Windows.Forms.CheckBox();
            this.txtSetPort = new System.Windows.Forms.TextBox();
            this.setPath = new System.Windows.Forms.Label();
            this.setPort = new System.Windows.Forms.Label();
            this.txtSetPath = new System.Windows.Forms.TextBox();
            this.txtSetCollection = new System.Windows.Forms.TextBox();
            this.setVersion = new System.Windows.Forms.Label();
            this.setCollection = new System.Windows.Forms.Label();
            this.chkSetVersion = new System.Windows.Forms.CheckBox();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.rtfHelp = new System.Windows.Forms.RichTextBox();
            this.tabLegal = new System.Windows.Forms.TabPage();
            this.rtfLegal = new System.Windows.Forms.RichTextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.rtfAbout = new System.Windows.Forms.RichTextBox();
            this.grpMain.SuspendLayout();
            this.contextMenuMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabDefaults.SuspendLayout();
            this.grpCurrentValues.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.tabLegal.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpMain.Controls.Add(this.required3);
            this.grpMain.Controls.Add(this.btnLoadDefaults);
            this.grpMain.Controls.Add(this.chkHttps);
            this.grpMain.Controls.Add(this.lblPath);
            this.grpMain.Controls.Add(this.txtPath);
            this.grpMain.Controls.Add(this.lblVersion);
            this.grpMain.Controls.Add(this.chkEmail);
            this.grpMain.Controls.Add(this.btnHelp);
            this.grpMain.Controls.Add(this.chkTFS2010);
            this.grpMain.Controls.Add(this.required4);
            this.grpMain.Controls.Add(this.lblCollection);
            this.grpMain.Controls.Add(this.txtCollection);
            this.grpMain.Controls.Add(this.btnSave);
            this.grpMain.Controls.Add(this.cboProject);
            this.grpMain.Controls.Add(this.btnConnect);
            this.grpMain.Controls.Add(this.cboRoles);
            this.grpMain.Controls.Add(this.lblRoles);
            this.grpMain.Controls.Add(this.required2);
            this.grpMain.Controls.Add(this.required1);
            this.grpMain.Controls.Add(this.btnOK);
            this.grpMain.Controls.Add(this.lblProject);
            this.grpMain.Controls.Add(this.lblPort);
            this.grpMain.Controls.Add(this.lblHost);
            this.grpMain.Controls.Add(this.txtPort);
            this.grpMain.Controls.Add(this.txtHost);
            this.grpMain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(12, 27);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(910, 145);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Team Foundation Server Information";
            // 
            // required3
            // 
            this.required3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.required3.ForeColor = System.Drawing.Color.Red;
            this.required3.Location = new System.Drawing.Point(481, 50);
            this.required3.Name = "required3";
            this.required3.Size = new System.Drawing.Size(144, 12);
            this.required3.TabIndex = 995;
            this.required3.Text = "Directory delimeters not needed";
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDefaults.Location = new System.Drawing.Point(631, 65);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(130, 25);
            this.btnLoadDefaults.TabIndex = 11;
            this.btnLoadDefaults.Text = "Load Default Values";
            this.btnLoadDefaults.UseVisualStyleBackColor = true;
            this.btnLoadDefaults.Click += new System.EventHandler(this.btnLoadDefaults_Click);
            // 
            // chkHttps
            // 
            this.chkHttps.AutoSize = true;
            this.chkHttps.Location = new System.Drawing.Point(648, 28);
            this.chkHttps.Name = "chkHttps";
            this.chkHttps.Size = new System.Drawing.Size(91, 19);
            this.chkHttps.TabIndex = 3;
            this.chkHttps.Text = "Use HTTPS";
            this.chkHttps.UseVisualStyleBackColor = true;
            // 
            // lblPath
            // 
            this.lblPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(442, 28);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(35, 18);
            this.lblPath.TabIndex = 994;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(483, 28);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(140, 21);
            this.txtPath.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(22, 69);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(58, 19);
            this.lblVersion.TabIndex = 996;
            this.lblVersion.Text = "Version:";
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Enabled = false;
            this.chkEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmail.Location = new System.Drawing.Point(445, 110);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(129, 19);
            this.chkEmail.TabIndex = 10;
            this.chkEmail.Text = "Email Address List";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(631, 106);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(130, 25);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // chkTFS2010
            // 
            this.chkTFS2010.AutoSize = true;
            this.chkTFS2010.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTFS2010.Location = new System.Drawing.Point(86, 69);
            this.chkTFS2010.Name = "chkTFS2010";
            this.chkTFS2010.Size = new System.Drawing.Size(120, 19);
            this.chkTFS2010.TabIndex = 5;
            this.chkTFS2010.Text = "TFS 2010 or later";
            this.chkTFS2010.UseVisualStyleBackColor = true;
            // 
            // required4
            // 
            this.required4.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.required4.ForeColor = System.Drawing.Color.Red;
            this.required4.Location = new System.Drawing.Point(442, 73);
            this.required4.Name = "required4";
            this.required4.Size = new System.Drawing.Size(180, 16);
            this.required4.TabIndex = 998;
            this.required4.Text = "Collection required for TFS 2010 or later";
            // 
            // lblCollection
            // 
            this.lblCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollection.Location = new System.Drawing.Point(223, 70);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(72, 19);
            this.lblCollection.TabIndex = 997;
            this.lblCollection.Text = "Collection:";
            // 
            // txtCollection
            // 
            this.txtCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollection.Location = new System.Drawing.Point(296, 68);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.Size = new System.Drawing.Size(140, 21);
            this.txtCollection.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(767, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save Output...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboProject
            // 
            this.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(85, 106);
            this.cboProject.MaxDropDownItems = 20;
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(140, 23);
            this.cboProject.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(767, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(130, 25);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboRoles
            // 
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(296, 106);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(140, 23);
            this.cboRoles.TabIndex = 9;
            // 
            // lblRoles
            // 
            this.lblRoles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoles.Location = new System.Drawing.Point(251, 111);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(45, 18);
            this.lblRoles.TabIndex = 9910;
            this.lblRoles.Text = "Role:";
            // 
            // required2
            // 
            this.required2.Font = new System.Drawing.Font("Arial", 6.75F);
            this.required2.ForeColor = System.Drawing.Color.Red;
            this.required2.Location = new System.Drawing.Point(293, 50);
            this.required2.Name = "required2";
            this.required2.Size = new System.Drawing.Size(100, 15);
            this.required2.TabIndex = 8;
            this.required2.Text = "Required";
            // 
            // required1
            // 
            this.required1.Font = new System.Drawing.Font("Arial", 6.75F);
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(84, 50);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(100, 15);
            this.required1.TabIndex = 7;
            this.required1.Text = "Required";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(767, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 25);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProject
            // 
            this.lblProject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(22, 111);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(50, 18);
            this.lblProject.TabIndex = 999;
            this.lblProject.Text = "Project:";
            // 
            // lblPort
            // 
            this.lblPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(251, 28);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 18);
            this.lblPort.TabIndex = 993;
            this.lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(22, 28);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(62, 18);
            this.lblHost.TabIndex = 992;
            this.lblHost.Text = "Server:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(296, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(140, 21);
            this.txtPort.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(85, 28);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(140, 21);
            this.txtHost.TabIndex = 0;
            // 
            // rtfMain
            // 
            this.rtfMain.BackColor = System.Drawing.SystemColors.Window;
            this.rtfMain.ContextMenuStrip = this.contextMenuMain;
            this.rtfMain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfMain.Location = new System.Drawing.Point(-2, -3);
            this.rtfMain.Name = "rtfMain";
            this.rtfMain.ReadOnly = true;
            this.rtfMain.Size = new System.Drawing.Size(908, 451);
            this.rtfMain.TabIndex = 991;
            this.rtfMain.Text = "";
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyTabToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuStrip1";
            this.contextMenuMain.ShowImageMargin = false;
            this.contextMenuMain.Size = new System.Drawing.Size(143, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyTabToolStripMenuItem
            // 
            this.copyTabToolStripMenuItem.Name = "copyTabToolStripMenuItem";
            this.copyTabToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.copyTabToolStripMenuItem.Text = "Copy Current Tab";
            this.copyTabToolStripMenuItem.Click += new System.EventHandler(this.copyTabToolStripMenuItem_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripBusy,
            this.toolStripServerLabel,
            this.toolStripServer,
            this.toolStripPortLabel,
            this.toolStripPort,
            this.toolStripCollectionLabel,
            this.toolStripCollection,
            this.toolStripVersionLabel,
            this.toolStripVersion});
            this.statusStripMain.Location = new System.Drawing.Point(0, 653);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(934, 22);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 99;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Status:";
            // 
            // toolStripBusy
            // 
            this.toolStripBusy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBusy.ForeColor = System.Drawing.Color.Black;
            this.toolStripBusy.Name = "toolStripBusy";
            this.toolStripBusy.Size = new System.Drawing.Size(27, 17);
            this.toolStripBusy.Text = "Idle";
            // 
            // toolStripServerLabel
            // 
            this.toolStripServerLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripServerLabel.Name = "toolStripServerLabel";
            this.toolStripServerLabel.Size = new System.Drawing.Size(45, 17);
            this.toolStripServerLabel.Text = "Server:";
            // 
            // toolStripServer
            // 
            this.toolStripServer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripServer.Name = "toolStripServer";
            this.toolStripServer.Size = new System.Drawing.Size(90, 17);
            this.toolStripServer.Text = "Not Connected";
            // 
            // toolStripPortLabel
            // 
            this.toolStripPortLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripPortLabel.Name = "toolStripPortLabel";
            this.toolStripPortLabel.Size = new System.Drawing.Size(32, 17);
            this.toolStripPortLabel.Text = "Port:";
            // 
            // toolStripPort
            // 
            this.toolStripPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripPort.Name = "toolStripPort";
            this.toolStripPort.Size = new System.Drawing.Size(90, 17);
            this.toolStripPort.Text = "Not Connected";
            // 
            // toolStripCollectionLabel
            // 
            this.toolStripCollectionLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripCollectionLabel.Name = "toolStripCollectionLabel";
            this.toolStripCollectionLabel.Size = new System.Drawing.Size(65, 17);
            this.toolStripCollectionLabel.Text = "Collection:";
            // 
            // toolStripCollection
            // 
            this.toolStripCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripCollection.Name = "toolStripCollection";
            this.toolStripCollection.Size = new System.Drawing.Size(90, 17);
            this.toolStripCollection.Text = "Not Connected";
            // 
            // toolStripVersionLabel
            // 
            this.toolStripVersionLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripVersionLabel.Name = "toolStripVersionLabel";
            this.toolStripVersionLabel.Size = new System.Drawing.Size(51, 17);
            this.toolStripVersionLabel.Text = "Version:";
            // 
            // toolStripVersion
            // 
            this.toolStripVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripVersion.Name = "toolStripVersion";
            this.toolStripVersion.Size = new System.Drawing.Size(90, 17);
            this.toolStripVersion.Text = "Not Connected";
            // 
            // connectionBackgroundWorker
            // 
            this.connectionBackgroundWorker.WorkerReportsProgress = true;
            this.connectionBackgroundWorker.WorkerSupportsCancellation = true;
            this.connectionBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectionBackgroundWorker_DoWork);
            this.connectionBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.connectionBackgroundWorker_RunWorkerCompleted);
            // 
            // tfsInfoBackgroundWorker
            // 
            this.tfsInfoBackgroundWorker.WorkerReportsProgress = true;
            this.tfsInfoBackgroundWorker.WorkerSupportsCancellation = true;
            this.tfsInfoBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tfsInfoBackgroundWorker_DoWork);
            this.tfsInfoBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tfsInfoBackgroundWorker_RunWorkerCompleted);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(934, 24);
            this.menuStripMain.TabIndex = 100;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.copyCurrentTabToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.toolStripSeparator5,
            this.cancelToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem1.Image")));
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // copyCurrentTabToolStripMenuItem
            // 
            this.copyCurrentTabToolStripMenuItem.Name = "copyCurrentTabToolStripMenuItem";
            this.copyCurrentTabToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copyCurrentTabToolStripMenuItem.Text = "Copy Current Tab";
            this.copyCurrentTabToolStripMenuItem.Click += new System.EventHandler(this.copyCurrentTabToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "Save Output...";
            this.saveToolStripMenuItem.ToolTipText = "Same as Save Output... button";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.cancelToolStripMenuItem.ShowShortcutKeys = false;
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.ToolTipText = "You can also press CTRL + .";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTFSProjectsToolStripMenuItem,
            this.userGuideToolStripMenuItem,
            this.legalToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.ToolTipText = "Initial text from app start";
            // 
            // aboutTFSProjectsToolStripMenuItem
            // 
            this.aboutTFSProjectsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutTFSProjectsToolStripMenuItem.Image")));
            this.aboutTFSProjectsToolStripMenuItem.Name = "aboutTFSProjectsToolStripMenuItem";
            this.aboutTFSProjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.aboutTFSProjectsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.aboutTFSProjectsToolStripMenuItem.Text = "About TFS Projects";
            this.aboutTFSProjectsToolStripMenuItem.Click += new System.EventHandler(this.aboutTFSProjectsToolStripMenuItem_Click);
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.userGuideToolStripMenuItem.Text = "User Guide";
            this.userGuideToolStripMenuItem.ToolTipText = "Same text as Help button";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // legalToolStripMenuItem
            // 
            this.legalToolStripMenuItem.Name = "legalToolStripMenuItem";
            this.legalToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.legalToolStripMenuItem.Text = "Legal";
            this.legalToolStripMenuItem.ToolTipText = "Legal/License info";
            this.legalToolStripMenuItem.Click += new System.EventHandler(this.legalToolStripMenuItem_Click);
            // 
            // tabMain
            // 
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabOutput);
            this.tabMain.Controls.Add(this.tabDefaults);
            this.tabMain.Controls.Add(this.tabHelp);
            this.tabMain.Controls.Add(this.tabLegal);
            this.tabMain.Controls.Add(this.tabAbout);
            this.tabMain.Location = new System.Drawing.Point(12, 178);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(912, 472);
            this.tabMain.TabIndex = 991;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.rtfMain);
            this.tabOutput.Location = new System.Drawing.Point(4, 26);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(904, 442);
            this.tabOutput.TabIndex = 0;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // tabDefaults
            // 
            this.tabDefaults.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDefaults.Controls.Add(this.grpCurrentValues);
            this.tabDefaults.Controls.Add(this.groupBox2);
            this.tabDefaults.Location = new System.Drawing.Point(4, 26);
            this.tabDefaults.Margin = new System.Windows.Forms.Padding(0);
            this.tabDefaults.Name = "tabDefaults";
            this.tabDefaults.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefaults.Size = new System.Drawing.Size(904, 442);
            this.tabDefaults.TabIndex = 1;
            this.tabDefaults.Text = "Defaults";
            // 
            // grpCurrentValues
            // 
            this.grpCurrentValues.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCurrentValues.Controls.Add(this.lblDefaultVersion);
            this.grpCurrentValues.Controls.Add(this.lblDefaultHTTP);
            this.grpCurrentValues.Controls.Add(this.currentHttp);
            this.grpCurrentValues.Controls.Add(this.lblDefaultCollection);
            this.grpCurrentValues.Controls.Add(this.lblDefaultPath);
            this.grpCurrentValues.Controls.Add(this.lblDefaultPort);
            this.grpCurrentValues.Controls.Add(this.lblDefaultServer);
            this.grpCurrentValues.Controls.Add(this.currentServer);
            this.grpCurrentValues.Controls.Add(this.currentPath);
            this.grpCurrentValues.Controls.Add(this.currentPort);
            this.grpCurrentValues.Controls.Add(this.currentVersion);
            this.grpCurrentValues.Controls.Add(this.currentCollection);
            this.grpCurrentValues.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grpCurrentValues.Location = new System.Drawing.Point(8, 27);
            this.grpCurrentValues.Name = "grpCurrentValues";
            this.grpCurrentValues.Size = new System.Drawing.Size(887, 174);
            this.grpCurrentValues.TabIndex = 1017;
            this.grpCurrentValues.TabStop = false;
            this.grpCurrentValues.Text = "Current Default Values";
            // 
            // lblDefaultVersion
            // 
            this.lblDefaultVersion.AutoSize = true;
            this.lblDefaultVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultVersion.Location = new System.Drawing.Point(168, 97);
            this.lblDefaultVersion.Name = "lblDefaultVersion";
            this.lblDefaultVersion.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultVersion.TabIndex = 1022;
            this.lblDefaultVersion.Text = "null";
            // 
            // lblDefaultHTTP
            // 
            this.lblDefaultHTTP.AutoSize = true;
            this.lblDefaultHTTP.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultHTTP.Location = new System.Drawing.Point(643, 55);
            this.lblDefaultHTTP.Name = "lblDefaultHTTP";
            this.lblDefaultHTTP.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultHTTP.TabIndex = 1021;
            this.lblDefaultHTTP.Text = "null";
            // 
            // currentHttp
            // 
            this.currentHttp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHttp.Location = new System.Drawing.Point(558, 55);
            this.currentHttp.Name = "currentHttp";
            this.currentHttp.Size = new System.Drawing.Size(79, 18);
            this.currentHttp.TabIndex = 1020;
            this.currentHttp.Text = "Use HTTPS:";
            // 
            // lblDefaultCollection
            // 
            this.lblDefaultCollection.AutoSize = true;
            this.lblDefaultCollection.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultCollection.Location = new System.Drawing.Point(370, 97);
            this.lblDefaultCollection.Name = "lblDefaultCollection";
            this.lblDefaultCollection.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultCollection.TabIndex = 1019;
            this.lblDefaultCollection.Text = "null";
            // 
            // lblDefaultPath
            // 
            this.lblDefaultPath.AutoSize = true;
            this.lblDefaultPath.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultPath.Location = new System.Drawing.Point(462, 55);
            this.lblDefaultPath.Name = "lblDefaultPath";
            this.lblDefaultPath.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultPath.TabIndex = 1018;
            this.lblDefaultPath.Text = "null";
            // 
            // lblDefaultPort
            // 
            this.lblDefaultPort.AutoSize = true;
            this.lblDefaultPort.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultPort.Location = new System.Drawing.Point(370, 55);
            this.lblDefaultPort.Name = "lblDefaultPort";
            this.lblDefaultPort.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultPort.TabIndex = 1017;
            this.lblDefaultPort.Text = "null";
            // 
            // lblDefaultServer
            // 
            this.lblDefaultServer.AutoSize = true;
            this.lblDefaultServer.BackColor = System.Drawing.Color.LightGray;
            this.lblDefaultServer.Location = new System.Drawing.Point(168, 55);
            this.lblDefaultServer.Name = "lblDefaultServer";
            this.lblDefaultServer.Size = new System.Drawing.Size(23, 14);
            this.lblDefaultServer.TabIndex = 1016;
            this.lblDefaultServer.Text = "null";
            // 
            // currentServer
            // 
            this.currentServer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentServer.Location = new System.Drawing.Point(100, 55);
            this.currentServer.Name = "currentServer";
            this.currentServer.Size = new System.Drawing.Size(62, 18);
            this.currentServer.TabIndex = 1010;
            this.currentServer.Text = "Server:";
            // 
            // currentPath
            // 
            this.currentPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPath.Location = new System.Drawing.Point(424, 55);
            this.currentPath.Name = "currentPath";
            this.currentPath.Size = new System.Drawing.Size(35, 18);
            this.currentPath.TabIndex = 1012;
            this.currentPath.Text = "Path:";
            // 
            // currentPort
            // 
            this.currentPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPort.Location = new System.Drawing.Point(329, 55);
            this.currentPort.Name = "currentPort";
            this.currentPort.Size = new System.Drawing.Size(35, 18);
            this.currentPort.TabIndex = 1011;
            this.currentPort.Text = "Port:";
            // 
            // currentVersion
            // 
            this.currentVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentVersion.Location = new System.Drawing.Point(100, 97);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(58, 19);
            this.currentVersion.TabIndex = 1014;
            this.currentVersion.Text = "Version:";
            // 
            // currentCollection
            // 
            this.currentCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCollection.Location = new System.Drawing.Point(292, 97);
            this.currentCollection.Name = "currentCollection";
            this.currentCollection.Size = new System.Drawing.Size(72, 19);
            this.currentCollection.TabIndex = 1015;
            this.currentCollection.Text = "Collection:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.setServer);
            this.groupBox2.Controls.Add(this.btnSetDefaults);
            this.groupBox2.Controls.Add(this.txtSetServer);
            this.groupBox2.Controls.Add(this.chkSetHttps);
            this.groupBox2.Controls.Add(this.txtSetPort);
            this.groupBox2.Controls.Add(this.setPath);
            this.groupBox2.Controls.Add(this.setPort);
            this.groupBox2.Controls.Add(this.txtSetPath);
            this.groupBox2.Controls.Add(this.txtSetCollection);
            this.groupBox2.Controls.Add(this.setVersion);
            this.groupBox2.Controls.Add(this.setCollection);
            this.groupBox2.Controls.Add(this.chkSetVersion);
            this.groupBox2.Location = new System.Drawing.Point(8, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(887, 174);
            this.groupBox2.TabIndex = 1016;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Default Values";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(532, 100);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(140, 25);
            this.btnImport.TabIndex = 1016;
            this.btnImport.Text = "Import Current Values";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // setServer
            // 
            this.setServer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setServer.Location = new System.Drawing.Point(71, 62);
            this.setServer.Name = "setServer";
            this.setServer.Size = new System.Drawing.Size(62, 18);
            this.setServer.TabIndex = 1010;
            this.setServer.Text = "Server:";
            // 
            // btnSetDefaults
            // 
            this.btnSetDefaults.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSetDefaults.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDefaults.Location = new System.Drawing.Point(697, 100);
            this.btnSetDefaults.Name = "btnSetDefaults";
            this.btnSetDefaults.Size = new System.Drawing.Size(140, 25);
            this.btnSetDefaults.TabIndex = 1009;
            this.btnSetDefaults.Text = "Save Default Values";
            this.btnSetDefaults.UseVisualStyleBackColor = false;
            this.btnSetDefaults.Click += new System.EventHandler(this.btnSetDefaults_Click);
            // 
            // txtSetServer
            // 
            this.txtSetServer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetServer.Location = new System.Drawing.Point(134, 62);
            this.txtSetServer.Name = "txtSetServer";
            this.txtSetServer.Size = new System.Drawing.Size(140, 21);
            this.txtSetServer.TabIndex = 999;
            // 
            // chkSetHttps
            // 
            this.chkSetHttps.AutoSize = true;
            this.chkSetHttps.Location = new System.Drawing.Point(697, 62);
            this.chkSetHttps.Name = "chkSetHttps";
            this.chkSetHttps.Size = new System.Drawing.Size(80, 18);
            this.chkSetHttps.TabIndex = 1002;
            this.chkSetHttps.Text = "Use HTTPS";
            this.chkSetHttps.UseVisualStyleBackColor = true;
            // 
            // txtSetPort
            // 
            this.txtSetPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPort.Location = new System.Drawing.Point(345, 62);
            this.txtSetPort.Name = "txtSetPort";
            this.txtSetPort.Size = new System.Drawing.Size(140, 21);
            this.txtSetPort.TabIndex = 1000;
            // 
            // setPath
            // 
            this.setPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setPath.Location = new System.Drawing.Point(491, 62);
            this.setPath.Name = "setPath";
            this.setPath.Size = new System.Drawing.Size(35, 18);
            this.setPath.TabIndex = 1012;
            this.setPath.Text = "Path:";
            // 
            // setPort
            // 
            this.setPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setPort.Location = new System.Drawing.Point(300, 62);
            this.setPort.Name = "setPort";
            this.setPort.Size = new System.Drawing.Size(35, 18);
            this.setPort.TabIndex = 1011;
            this.setPort.Text = "Port:";
            // 
            // txtSetPath
            // 
            this.txtSetPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPath.Location = new System.Drawing.Point(532, 62);
            this.txtSetPath.Name = "txtSetPath";
            this.txtSetPath.Size = new System.Drawing.Size(140, 21);
            this.txtSetPath.TabIndex = 1001;
            // 
            // txtSetCollection
            // 
            this.txtSetCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetCollection.Location = new System.Drawing.Point(345, 102);
            this.txtSetCollection.Name = "txtSetCollection";
            this.txtSetCollection.Size = new System.Drawing.Size(140, 21);
            this.txtSetCollection.TabIndex = 1005;
            // 
            // setVersion
            // 
            this.setVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setVersion.Location = new System.Drawing.Point(71, 103);
            this.setVersion.Name = "setVersion";
            this.setVersion.Size = new System.Drawing.Size(58, 19);
            this.setVersion.TabIndex = 1014;
            this.setVersion.Text = "Version:";
            // 
            // setCollection
            // 
            this.setCollection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setCollection.Location = new System.Drawing.Point(272, 104);
            this.setCollection.Name = "setCollection";
            this.setCollection.Size = new System.Drawing.Size(72, 19);
            this.setCollection.TabIndex = 1015;
            this.setCollection.Text = "Collection:";
            // 
            // chkSetVersion
            // 
            this.chkSetVersion.AutoSize = true;
            this.chkSetVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetVersion.Location = new System.Drawing.Point(135, 103);
            this.chkSetVersion.Name = "chkSetVersion";
            this.chkSetVersion.Size = new System.Drawing.Size(120, 19);
            this.chkSetVersion.TabIndex = 1004;
            this.chkSetVersion.Text = "TFS 2010 or later";
            this.chkSetVersion.UseVisualStyleBackColor = true;
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.rtfHelp);
            this.tabHelp.Location = new System.Drawing.Point(4, 26);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Size = new System.Drawing.Size(904, 456);
            this.tabHelp.TabIndex = 2;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // rtfHelp
            // 
            this.rtfHelp.BackColor = System.Drawing.SystemColors.Window;
            this.rtfHelp.ContextMenuStrip = this.contextMenuMain;
            this.rtfHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfHelp.Location = new System.Drawing.Point(-2, -2);
            this.rtfHelp.Name = "rtfHelp";
            this.rtfHelp.ReadOnly = true;
            this.rtfHelp.Size = new System.Drawing.Size(908, 451);
            this.rtfHelp.TabIndex = 6;
            this.rtfHelp.Text = "";
            // 
            // tabLegal
            // 
            this.tabLegal.Controls.Add(this.rtfLegal);
            this.tabLegal.Location = new System.Drawing.Point(4, 26);
            this.tabLegal.Name = "tabLegal";
            this.tabLegal.Size = new System.Drawing.Size(904, 456);
            this.tabLegal.TabIndex = 3;
            this.tabLegal.Text = "Legal";
            this.tabLegal.UseVisualStyleBackColor = true;
            // 
            // rtfLegal
            // 
            this.rtfLegal.BackColor = System.Drawing.SystemColors.Window;
            this.rtfLegal.ContextMenuStrip = this.contextMenuMain;
            this.rtfLegal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfLegal.Location = new System.Drawing.Point(-2, -2);
            this.rtfLegal.Name = "rtfLegal";
            this.rtfLegal.ReadOnly = true;
            this.rtfLegal.Size = new System.Drawing.Size(908, 451);
            this.rtfLegal.TabIndex = 6;
            this.rtfLegal.Text = "";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.rtfAbout);
            this.tabAbout.Location = new System.Drawing.Point(4, 26);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(904, 456);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // rtfAbout
            // 
            this.rtfAbout.BackColor = System.Drawing.SystemColors.Window;
            this.rtfAbout.ContextMenuStrip = this.contextMenuMain;
            this.rtfAbout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfAbout.Location = new System.Drawing.Point(-2, -3);
            this.rtfAbout.Name = "rtfAbout";
            this.rtfAbout.ReadOnly = true;
            this.rtfAbout.Size = new System.Drawing.Size(908, 451);
            this.rtfAbout.TabIndex = 992;
            this.rtfAbout.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 675);
            this.ContextMenuStrip = this.contextMenuMain;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.grpMain);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(50, 50);
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TFS Projects";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.contextMenuMain.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabDefaults.ResumeLayout(false);
            this.grpCurrentValues.ResumeLayout(false);
            this.grpCurrentValues.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabHelp.ResumeLayout(false);
            this.tabLegal.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.ToolStripStatusLabel toolStripVersion;
        public System.Windows.Forms.ComboBox cboProject;
        public System.ComponentModel.BackgroundWorker connectionBackgroundWorker;
        public System.ComponentModel.BackgroundWorker tfsInfoBackgroundWorker;
        public System.Windows.Forms.RichTextBox rtfMain;
        public System.Windows.Forms.ComboBox cboRoles;
        public System.Windows.Forms.Label lblRoles;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblProject;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtCollection;
        public System.Windows.Forms.CheckBox chkTFS2010;
        public System.Windows.Forms.CheckBox chkEmail;
        public System.Windows.Forms.ToolStripStatusLabel toolStripServer;
        public System.Windows.Forms.ToolStripStatusLabel toolStripPort;
        public System.Windows.Forms.ToolStripStatusLabel toolStripCollection;
        public System.Windows.Forms.ToolStripStatusLabel toolStripBusy;
        private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Label required1;
		private System.Windows.Forms.Label required2;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label required4;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Button btnHelp;
        public System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripServerLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPortLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCollectionLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripVersionLabel;
        public System.Windows.Forms.MenuStrip menuStripMain;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTFSProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TabPage tabDefaults;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.TabPage tabLegal;
        private System.Windows.Forms.Label required3;
        private System.Windows.Forms.Button btnLoadDefaults;
        public System.Windows.Forms.CheckBox chkHttps;
        private System.Windows.Forms.Label lblPath;
        public System.Windows.Forms.TextBox txtPath;
        public System.Windows.Forms.RichTextBox rtfHelp;
        public System.Windows.Forms.RichTextBox rtfLegal;
        private System.Windows.Forms.Button btnSetDefaults;
        public System.Windows.Forms.CheckBox chkSetHttps;
        private System.Windows.Forms.Label setPath;
        public System.Windows.Forms.TextBox txtSetPath;
        private System.Windows.Forms.Label setVersion;
        public System.Windows.Forms.CheckBox chkSetVersion;
        private System.Windows.Forms.Label setCollection;
        public System.Windows.Forms.TextBox txtSetCollection;
        private System.Windows.Forms.Label setPort;
        private System.Windows.Forms.Label setServer;
        private System.Windows.Forms.GroupBox grpCurrentValues;
        private System.Windows.Forms.Label currentHttp;
        private System.Windows.Forms.Label currentServer;
        private System.Windows.Forms.Label currentPath;
        private System.Windows.Forms.Label currentPort;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label currentCollection;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtSetPort;
        public System.Windows.Forms.TextBox txtSetServer;
        public System.Windows.Forms.Label lblDefaultVersion;
        public System.Windows.Forms.Label lblDefaultHTTP;
        public System.Windows.Forms.Label lblDefaultCollection;
        public System.Windows.Forms.Label lblDefaultPath;
        public System.Windows.Forms.Label lblDefaultPort;
        public System.Windows.Forms.Label lblDefaultServer;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TabPage tabAbout;
        public System.Windows.Forms.RichTextBox rtfAbout;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ToolStripMenuItem copyCurrentTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTabToolStripMenuItem;
    }
}
