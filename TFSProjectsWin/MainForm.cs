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

#region using directives
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.Framework.Client;
#endregion


namespace TFSProjectsWin
{
	/// <summary>
	/// The Main Form for TFS Projects
	/// </summary>
	public partial class frmMain : Form
    {

        public frmMain()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //		

            InitializeComponent();
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            
            UIControl UIController = new UIControl(this);
            DisplayText displayInitText = new DisplayText(this);
            DefaultValues defaultValues = new DefaultValues(this);
            
            //UIController.disableProjectUIControls();

            defaultValues.loadDefaults();
            defaultValues.checkCopying();

            displayInitText.initText();
            displayInitText.helpText();
            displayInitText.copyingText();
            rtfMain.AppendText("Awaiting user input...");
            tabMain.SelectTab(4);
            UIController.disableProjectUIControls();
        }

        #region variables

        #region TFS URI string variables

        public string http;
        public string tfsDir;
        public string colon = ":";
        public string serverName = "";
        public string portNumber = "";
        public string serverURI = "";
        public string serverURInospace = ""; //used to display the URI as one continuous string, for display purposes only
        public string teamProjectUriConnect = "";
        public string teamProjectUriInfo = "";

        #endregion

        #region Default values variables

        public string[] valuesFromFile = new string[7];
        public string defaultHost;
        public string defaultPort;
        public string defaultPath;
        public string defaultHttp;
        public string defaultVersion;
        public string defaultCollection;

        #endregion

        #region TFS collection variables

        public bool allCollections = false;
        public string tfsCollection = "";
        public string collectionNamenospace = ""; //used to display the collection name as one continuous string, for display purposes only
        public ArrayList myCollections = new ArrayList();
        public ReadOnlyCollection<CatalogNode> tpcNodes;
        public ArrayList myUsersAllCollections = new ArrayList();
        public ArrayList myNonUsersAllCollections = new ArrayList();

        #endregion

        #region combo box static values
        
        public string allHolder = " All";
        public string noRoleHolder = " None - Project List Only";

        #endregion

        #region project/roles variables

        public ArrayList myTeamProjects = new ArrayList();
        public ArrayList myTeamRoles = new ArrayList();
        public string projectName = "";//string variable for the value in the Project combo box
        public string providedGroup = ""; //string variable for the value in the Project Roles combo box
        public string teamProjectName = "";
        public string projGroup = "";
        public Microsoft.TeamFoundation.Server.ProjectInfo[] allTeamProjects;
        public Identity[] allProjectGroups;
        public ArrayList myUsers = new ArrayList();
        public ArrayList myNonUsers = new ArrayList();
        public ICommonStructureService iss;
        public IGroupSecurityService2 gss;
        public Microsoft.TeamFoundation.Common.ProjectState teamProjectState;
        public Identity projectGroupIdentity;
        public Identity tfsID;
        public TfsTeamProjectCollection tfsConnect;
        public TfsConfigurationServer tfs2010Server;
        public bool emailOnly = false;

        #endregion

        #region counter variables

        public int projectCount = 0;
        public int idCount = 0;
        public int totalNumberProjectUsers = 0;
        public int numberCollections = 0;
        public int totalNumberUsersAllCollections = 0;
        public int totalNumberProjects = 0;

        #endregion

        #region TFS version variables

        public string tfsVersionReadable = "";
        public string tfsVersionShort = "";

        #endregion
        
        #region threading variables

        public bool cancelled = false;

        #endregion

        #region settings preservation variables (preventing thread overwrites)
        
        public string tfsServerValue = "";
        public string tfsPortValue = "";
        public bool tfs2010Value = false;
        public string tfsCollectionValue = "";
        public bool tfsConnected = false;

        public string tfsProjectValue = "";
        public string tfsRoleValue = "";
        public bool emailListValue = false;

        #endregion


        #endregion

        #region displayText events

        void helpText()
        {
            DisplayText displayHelpText = new DisplayText(this);
            displayHelpText.helpText();

        }

        void initText()
        {
            DisplayText displayInitText = new DisplayText(this);
            displayInitText.initText();
        }

        void legalText()
        {
            DisplayText displayCopyingText = new DisplayText(this);
            displayCopyingText.copyingText();
        }

        #endregion

        #region contextual menu events

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                System.Windows.Forms.Clipboard.SetText(rtfMain.SelectedText);
            }

            if (tabMain.SelectedIndex == 2)
            {
                System.Windows.Forms.Clipboard.SetText(rtfHelp.SelectedText);
            }

            if (tabMain.SelectedIndex == 3)
            {
                System.Windows.Forms.Clipboard.SetText(rtfLegal.SelectedText);
            }

            if (tabMain.SelectedIndex == 4)
            {
                System.Windows.Forms.Clipboard.SetText(rtfAbout.SelectedText);
            }
        }

        private void copyTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                rtfMain.SelectAll();
                rtfMain.Copy();
                rtfMain.DeselectAll();
            }

            if (tabMain.SelectedIndex == 1)
            {
                MessageBox.Show("Contents of this tab cannot be copied.", "Cannot Copy Tab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (tabMain.SelectedIndex == 2)
            {
                rtfHelp.SelectAll();
                rtfHelp.Copy();
                rtfHelp.DeselectAll();
            }

            if (tabMain.SelectedIndex == 3)
            {
                rtfLegal.SelectAll();
                rtfLegal.Copy();
                rtfLegal.DeselectAll();
            }

            if (tabMain.SelectedIndex == 4)
            {
                rtfAbout.SelectAll();
                rtfAbout.Copy();
                rtfAbout.DeselectAll();
            }
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if ((connectionBackgroundWorker.IsBusy == true) || (tfsInfoBackgroundWorker.IsBusy == true))
            {
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                doSave();
            }
        }

        #endregion

        #region ButtonClick events

        private void btnHelp_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((connectionBackgroundWorker.IsBusy == true) || (tfsInfoBackgroundWorker.IsBusy == true))
            {
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                doSave();
            }
        }

        void btnConnect_Click(object sender, System.EventArgs e)
        {
            tabMain.SelectTab(0);
            if (connectionBackgroundWorker.IsBusy == true)
            {
                txtHost.Text = tfsServerValue;
                txtPort.Text = tfsPortValue;
                chkTFS2010.Checked = tfs2010Value;
                txtCollection.Text = tfsCollectionValue;
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (tfsInfoBackgroundWorker.IsBusy == true)
            {
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                tfsServerValue = txtHost.Text.ToString();
                tfsPortValue = txtPort.Text.ToString();
                tfs2010Value = chkTFS2010.Checked;
                tfsCollectionValue = txtCollection.Text.ToString();
                toolStripBusy.ForeColor = Color.Red;
                toolStripBusy.Text = "Busy";
            }

            //clear out projects and roles combo boxes
            tfsConnected = false;
            cboRoles.DataSource = null;
            cboProject.DataSource = null;

            toolStripServer.Text = "Not Connected";
            toolStripPort.Text = "Not Connected";
            toolStripCollection.Text = "Not Connected";
            toolStripVersion.Text = "Not Connected";

            if (connectionBackgroundWorker.IsBusy == false)
            {
                rtfMain.Clear();
            }

            //set form level variables from appropriate UI elements
            serverName = txtHost.Text;
            portNumber = txtPort.Text;
            tfsCollection = txtCollection.Text;

            #region URI customization

            if (chkHttps.Checked == true)
            {
                http = "https://";
            }
            if (chkHttps.Checked == false)
            {
                http = "http://";
            }

            if (txtPath.Text == "tfs")
            {
                tfsDir = "/tfs/";
            }
            if ((txtPath.Text != "tfs") && (txtPath.Text != ""))
            {
                tfsDir = "/" + txtPath.Text + "/";
            }

            #endregion

            //handle collection name in the URI, only available in TFS 2010
            if (chkTFS2010.Checked == true)
            {
                if (tfsCollection.ToLower() == "all-collections")
                {
                    serverURI = string.Concat(http, serverName, colon, portNumber, tfsDir);
                    allCollections = true;
                }
                else
                {
                    serverURI = string.Concat(http, serverName, colon, portNumber, tfsDir, tfsCollection);
                }
            }
            else
            {
                serverURI = string.Concat(http, serverName, colon, portNumber);
            }

            //hide spaces in the server URI by replacing them with underscores. For display purposes only!
            serverURInospace = serverURI;
            if (serverURI.Contains(" "))
            {
                serverURInospace = serverURI.Replace(" ", "_");
            }

            try
            {
                //revert to error text if server name has no value
                if (serverName == "")
                {
                    throw new Exception();
                }

                //revert to error text if server port has no value
                if (portNumber == "")
                {
                    throw new Exception();
                }

                if (tfsDir == null)
                {
                    throw new Exception();
                }

                //chkTFS2010 shouldn't be checked if tfsCollection has a value
                if ((chkTFS2010.Checked == true) && (tfsCollection == ""))
                {
                    throw new Exception();
                }

                //chkTFS2010 should be checked if tfsCollection has a value
                if ((chkTFS2010.Checked == false) && (tfsCollection != ""))
                {
                    throw new Exception();
                }

                //Go do all the connection work on another thread
                if (connectionBackgroundWorker.IsBusy == false)
                {
                    connectionBackgroundWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }
            catch (Exception ex)
            {
                //remove persistent connection info
                toolStripServer.Text = "Not Connected";
                toolStripPort.Text = "Not Connected";
                toolStripCollection.Text = "Not Connected";
                toolStripVersion.Text = "Not Connected";

                //ensure that project level UI controls are disabled
                UIControl UIControl1 = new UIControl(this);
                UIControl1.disableProjectUIControls();


                //neither serverName nor portNumber nor path can be null
                if ((serverName == "") || (portNumber == "") || (tfsDir == null))
                {
                    toolStripBusy.ForeColor = Color.Black;
                    toolStripBusy.Text = "Idle";
                    string error = "Server Name, Port Number and TFS Path can't be null!\n";
                    doProcessException(error);
                    rtfMain.AppendText("\nPlease check your server name, port number and TFS Path values and try again.\n");
                }
                //if chkTFS2010 is checked, tfsCollection cannot be null
                else if ((chkTFS2010.Checked == true) && (tfsCollection == ""))
                {
                    toolStripBusy.ForeColor = Color.Black;
                    toolStripBusy.Text = "Idle";
                    string error = "For TFS 2010 a collection name MUST be specified!\n";
                    doProcessException(error);
                    rtfMain.AppendText("\nPlease check your collection name and version input values and try again.\n");
                }
                //if a collection name is specified chkTFS2010 must be checked
                else if ((chkTFS2010.Checked == false) && (tfsCollection.Length > 0))
                {
                    toolStripBusy.ForeColor = Color.Black;
                    toolStripBusy.Text = "Idle";
                    string error = "TFS 2010 collection specified for non-2010 version!\n";
                    doProcessException(error);
                    rtfMain.AppendText("\nPlease check your collection name and/or version input values and try again.\n");
                }
                //catch all other errors - likely connection errors from bad input
                else
                {
                    toolStripBusy.ForeColor = Color.Black;
                    toolStripBusy.Text = "Idle";
                    doProcessException(ex.Message.ToString());
                    rtfMain.AppendText("\nPlease check your input values and try again.\n");
                }

            }
            //reset allCollections, determining its value on each click of Connect
            allCollections = false;

        }

        void btnOK_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(0);
            if (tfsInfoBackgroundWorker.IsBusy == true)
            {
                cboProject.Text = tfsProjectValue;
                cboRoles.Text = tfsRoleValue;
                chkEmail.Checked = emailListValue;
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                tfsProjectValue = cboProject.Text;
                tfsRoleValue = cboRoles.Text;
                emailListValue = chkEmail.Checked;
                toolStripBusy.ForeColor = Color.Red;
                toolStripBusy.Text = "Busy";
            }

            emailOnly = chkEmail.Checked;

            UIControl UIController = new UIControl(this);
            UIController.hideWhileWorking();

            //
            if (tfsInfoBackgroundWorker.IsBusy == false)
            {
                rtfMain.Clear();
            }

            //project level data
            projectName = cboProject.Text.ToString();//string variable for the value in the Project combo box
            providedGroup = cboRoles.Text.ToString(); //string variable for the value in the Project Roles combo box

            //clear myCollections so data doesn't keep getting appended
            myCollections.Clear();

            //set allCollections if necessary, which permits reuse of the OK button without reconnecting
            if (toolStripCollection.Text.ToLower() == "all-collections")
            {
                allCollections = true;
            }

            if (tfsInfoBackgroundWorker.IsBusy == false)
            {
                tfsInfoBackgroundWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region MenuStripItemClick events

        #region File menu
        
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (tabMain.SelectedIndex == 0)
            {
                System.Windows.Forms.Clipboard.SetText(rtfMain.SelectedText);
            }
            
            if (tabMain.SelectedIndex == 2)
            {
                System.Windows.Forms.Clipboard.SetText(rtfHelp.SelectedText);
            }

            if (tabMain.SelectedIndex == 3)
            {
                System.Windows.Forms.Clipboard.SetText(rtfLegal.SelectedText);
            }

            if (tabMain.SelectedIndex == 4)
            {
                System.Windows.Forms.Clipboard.SetText(rtfAbout.SelectedText);
            }

        }

        private void copyCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                rtfMain.SelectAll();
                rtfMain.Copy();
                rtfMain.DeselectAll();
            }

            if (tabMain.SelectedIndex == 1)
            {
                MessageBox.Show("Contents of this tab cannot be copied.", "Cannot Copy Tab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (tabMain.SelectedIndex == 2)
            {
                rtfHelp.SelectAll();
                rtfHelp.Copy();
                rtfHelp.DeselectAll();
            }

            if (tabMain.SelectedIndex == 3)
            {
                rtfLegal.SelectAll();
                rtfLegal.Copy();
                rtfLegal.DeselectAll();
            }

            if (tabMain.SelectedIndex == 4)
            {
                rtfAbout.SelectAll();
                rtfAbout.Copy();
                rtfAbout.DeselectAll();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((connectionBackgroundWorker.IsBusy == true) || (tfsInfoBackgroundWorker.IsBusy == true))
            {
                MessageBox.Show("Please cancel from the File menu or wait for the current process to finish.", "Working...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                doSave();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectionBackgroundWorker.IsBusy == true)
            {
                this.connectionBackgroundWorker.CancelAsync();
                cancelled = true;
                toolStripBusy.ForeColor = Color.Black;
                toolStripBusy.Text = "Idle";
            }

            if (tfsInfoBackgroundWorker.IsBusy == true)
            {
                this.tfsInfoBackgroundWorker.CancelAsync();
                cancelled = true;
                toolStripBusy.ForeColor = Color.Black;
                toolStripBusy.Text = "Idle";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionBackgroundWorker.Dispose();
            tfsInfoBackgroundWorker.Dispose();
            Application.Exit();
        }

        #endregion

        #region Help menu

        private void aboutTFSProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(4);
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(2);
        }

        private void legalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(3);
        }

        #endregion

        #endregion

        #region BackgroundWorker_DoWork events

        private void connectionBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = Connect();
        }

        private void tfsInfoBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getInfo();
        }

        #endregion

        #region BackgroundWorker_RunWorkerCompleted events

        private void connectionBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (cancelled == false)
            {
                ConnectToTFS TFSConnectionComplete = new ConnectToTFS(this);
                TFSConnectionComplete.connectToTFSComplete();
            }
        }

        private void tfsInfoBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripBusy.ForeColor = Color.Black;
            toolStripBusy.Text = "Idle";

            if ((cboProject.Text != allHolder) && (cboRoles.Text == noRoleHolder))
            {
                rtfMain.AppendText("\n\nATTENTION: You have selected to list the project names for only one project!");
                rtfMain.AppendText("\nYou might want to either select all projects or a specific role other than None - \"Project Names Only\" ;-)");
            }

            if (cancelled == false)
            {
                MessageBox.Show("Data retrieval from TFS completed successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);              
            }

            UIControl UIController = new UIControl(this);
            UIController.enableProjectUIControls();
        }

        #endregion

        #region main worker methods

        private int Connect()
        {
            ConnectToTFS TFSConnection = new ConnectToTFS(this);
            TFSConnection.doConnectToTFS();
            if (connectionBackgroundWorker.CancellationPending == true)
            {
                connectionBackgroundWorker.Dispose();
                DisplayText displayInitText = new DisplayText(this);
                displayInitText.initText();
                return 1;
            }
            return 0;  
        }

        private int getInfo()
        {
            GetInfoFromTFS TFSInfoSet = new GetInfoFromTFS(this);
            TFSInfoSet.doGetInfoFromTFS();

            if (tfsInfoBackgroundWorker.CancellationPending == true)
            {
                tfsInfoBackgroundWorker.Dispose();
                DisplayText displayInitText = new DisplayText(this);
                displayInitText.initText();
                return 1;
            }
            return 0;
        }

        #endregion

        #region ProcessException event

        public void doProcessException(string message)
        {
            numberCollections = 0; //zero out number of collections on error
            ProcessException displayException = new ProcessException(this);
            displayException.printException(message);
        }

        #endregion

        #region private local form methods

        private void doSave()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.rtf";
            sfd.Filter = "RTF Files|*.rtf";

            tabMain.SelectTab(0);

            if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && sfd.FileName.Length > 0)
            {
                rtfMain.SaveFile(sfd.FileName);
            }
        }

        #endregion

        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            DefaultValues defaultValues = new DefaultValues(this);
            defaultValues.loadDefaults();
            if (defaultValues.malformedConfig == false)
            {
                MessageBox.Show("Default configuration values loaded into TFS Projects", "Default values loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnSetDefaults_Click(object sender, EventArgs e)
        {
            DefaultValues defaultValues = new DefaultValues(this);
            defaultValues.saveDefaults();
            if (defaultValues.malformedConfig == false)
            {
                MessageBox.Show("Saved default configuration values for use in TFS Projects", "Default values saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DefaultValues defaultValues = new DefaultValues(this);
            defaultValues.importCurrentValues();
        }
    }
}