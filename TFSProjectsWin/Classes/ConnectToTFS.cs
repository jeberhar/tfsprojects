using System;
using System.Windows.Forms;
using System.Drawing;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;

namespace TFSProjectsWin
{
    class ConnectToTFS
    {
        #region variables

        private frmMain mainForm; //variable to receive controls from MainForm
        private string printText = ""; //local text holder variable

        #endregion

        //constructor
        public ConnectToTFS(frmMain form1)
        {
            mainForm = form1;
        }

        public void doConnectToTFS()
        {

            #region variable declarations

            UIControl UIControl1 = new UIControl(mainForm);
            UIControl1.disableProjectUIControls();
            mainForm.cancelled = false;
            mainForm.myTeamRoles.Clear();
            mainForm.myTeamProjects.Clear();

            #endregion

            #region print opening connection string

            if (mainForm.rtfMain.InvokeRequired)
            {
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("Opening connection...\n"); }));
            }

            #endregion

            try
            {
                //check for cancellation
                if (mainForm.connectionBackgroundWorker.CancellationPending == true)
                {
                    mainForm.connectionBackgroundWorker.Dispose();
                    return;
                }

                #region form the URI

                Uri tfsUriNew = new Uri(mainForm.serverURI);
                mainForm.tfsConnect = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tfsUriNew);

                #endregion

                #region establish the connection

                if (mainForm.chkTFS2010.Checked == true)
                {
                    try
                    {
                        string serverURInocollection = string.Concat(mainForm.http, mainForm.serverName, mainForm.colon, mainForm.portNumber, mainForm.tfsDir);
                        Uri tfs2010Urinocollection = new Uri(serverURInocollection);
                        mainForm.tfs2010Server = TfsConfigurationServerFactory.GetConfigurationServer(tfs2010Urinocollection); //for TFS 2010 only
                        CatalogNode tfsCatalog = mainForm.tfs2010Server.CatalogNode;

                        // Query the children of the configuration server node for all of the team project collection nodes
                        mainForm.tpcNodes = tfsCatalog.QueryChildren(new Guid[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);
                    }
                    catch
                    {
                        string error = "Cannot connect to specified server, check that it is actually running TFS version 2010!\n";
                        mainForm.doProcessException(error);
                    }
                }

                IBuildServer buildServer = (IBuildServer)mainForm.tfsConnect.GetService(typeof(IBuildServer)); ;

                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\nServer {0} found.", mainForm.serverName)); }));
                }

                mainForm.tfsVersionShort = buildServer.BuildServerVersion.ToString();

                #endregion

                #region put the TFS version into meaningful language

                //put the TFS version into more meaningful verbage //TODO this may need V5...bug on finding V5 is in progress
                if (mainForm.tfsVersionShort == "V5")
                {
                    mainForm.tfsVersionReadable = "Microsoft Team Foundation Server 2013/2015";
                }
                if (mainForm.tfsVersionShort == "V4")
                {
                    mainForm.tfsVersionReadable = "Microsoft Team Foundation Server 2012/2013";
                }
                if (mainForm.tfsVersionShort == "V3")
                {
                    mainForm.tfsVersionReadable = "Microsoft Team Foundation Server 2010";
                }
                if (mainForm.tfsVersionShort == "V2")
                {
                    mainForm.tfsVersionReadable = "Microsoft Team Foundation Server 2008";
                }

                if ((mainForm.tfsVersionShort != "V2") && (mainForm.tfsVersionShort != "V3") && (mainForm.tfsVersionShort != "V4") && (mainForm.tfsVersionShort != "V5"))
                {
                    mainForm.tfsVersionReadable = "ERROR: Could not determine TFS version!";
                }

                #endregion

                #region populate arrayLists with special values for all/none

                //add special entry for all project and all roles in the ArrayList which will later populate the ComboBoxes
                mainForm.myTeamProjects.Add(mainForm.allHolder);
                mainForm.myTeamRoles.Add(mainForm.allHolder);
                mainForm.myTeamRoles.Add(mainForm.noRoleHolder);

                #endregion

                #region project discovery

                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("\n\tWORKING: Discovering and adding TFS projects..."); }));
                }

                //get ICommonStructureService (later to be used to list all team projects)
                mainForm.iss = (ICommonStructureService)mainForm.tfsConnect.GetService(typeof(ICommonStructureService));

                //get IGroupSecurityService (later to be used to retrieve identity information)
                mainForm.gss = (IGroupSecurityService2)mainForm.tfsConnect.GetService(typeof(IGroupSecurityService2));

                mainForm.allTeamProjects = mainForm.iss.ListProjects();

                if (mainForm.cboProject.InvokeRequired)
                {
                    mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Items.Add(mainForm.allHolder); }));
                }

                //iterate through each project to populate the ArrayLists for projects and roles, avoiding duplicate roles
                foreach (ProjectInfo TFSProjectInfo in mainForm.allTeamProjects)
                {
                    //mainForm.teamProjectURI = TFSProjectInfo.Uri;
                    if (mainForm.connectionBackgroundWorker.CancellationPending == true)
                    {
                        return;
                    }
                    mainForm.myTeamProjects.Add(TFSProjectInfo.Name.ToString()); //no filtering on projects, assumed there are no duplicate projects

                }

                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("Done.\n"); }));
                }

                #endregion

                #region roles discovery

                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("\tWORKING: Discovering and adding TFS roles across all projects on the server."); }));
                }

                //iterate through each project to populate the ArrayLists for projects and roles, avoiding duplicate roles
                foreach (ProjectInfo TFSProjectInfo in mainForm.allTeamProjects)
                {
                    if (mainForm.connectionBackgroundWorker.CancellationPending == true)
                    {
                        mainForm.connectionBackgroundWorker.Dispose();
                        return;
                    }

                    mainForm.teamProjectUriConnect = TFSProjectInfo.Uri;

                    //for each Team project identify each security Group
                    mainForm.allProjectGroups = mainForm.gss.ListApplicationGroups(mainForm.teamProjectUriConnect);  //this guy is expensive...why?

                    //filter out duplicate project roles
                    foreach (Identity projectGroup in mainForm.allProjectGroups)
                    {

                        if (mainForm.myTeamRoles.Contains(projectGroup.DisplayName.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            mainForm.myTeamRoles.Add(projectGroup.DisplayName.ToString());
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\t\tFOUND: Role {0}", projectGroup.DisplayName.ToString())); }));
                        }

                    }
                }

                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("\n\tWORKING: Finished TFS roles discovery."); }));
                }

                #endregion

                #region sort projects and roles, then put them in the combo boxes

                //sort the projects and roles arrays - easier to read if they're alphabetical                
                mainForm.myTeamProjects.Sort();
                mainForm.myTeamRoles.Sort();

                //populate the combo boxes with the values from the ArrayLists
                if (mainForm.allCollections == false)
                {
                    if (mainForm.cboProject.InvokeRequired)
                    {
                        mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.DataSource = mainForm.myTeamProjects; }));
                    }
                }
                else
                {
                    if (mainForm.cboProject.InvokeRequired)
                    {
                        mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Text = mainForm.allHolder; mainForm.cboProject.Items.Add(mainForm.allHolder); }));
                    }

                }
                if (mainForm.cboRoles.InvokeRequired)
                {
                    mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.DataSource = mainForm.myTeamRoles; }));
                }

                //don't enable the project/role UI controls until we have a successful connection
                UIControl1.enableProjectUIControls();

                mainForm.tfsConnected = true;

                #endregion

            }
            catch (Exception ex)
            {
                #region handle connection errors

                mainForm.doProcessException(ex.Message.ToString());
                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("\nPlease check the status of your TFS instance and try again.\n"); }));
                }

                #endregion
            }
        }

        #region print connection information which occurs upon a successful connection

        public void connectToTFSComplete()
        {
            #region handle output on non-connection

            if (mainForm.tfsConnected != true)
            {
                //display connection success notification - only reached if no exception was thrown
                printText = "\n\nConnection UNSUCCESSFUL to " + mainForm.serverURInospace + " please check your values and try again.\n\n";
                mainForm.rtfMain.SelectionLength = printText.Length;
                mainForm.rtfMain.SelectionColor = Color.Red;
                mainForm.rtfMain.AppendText(printText);
                mainForm.rtfMain.SelectionColor = Color.Black;
                printText = "";
                mainForm.toolStripBusy.ForeColor = Color.Black;
                mainForm.toolStripBusy.Text = "Idle";
                return;
            }

            #endregion

            #region populate toolStrip information

            mainForm.toolStripPort.Text = mainForm.portNumber;
            mainForm.toolStripServer.Text = mainForm.serverName;

            if (mainForm.tfsVersionShort == "V5")
            {
                if (mainForm.allCollections == true)
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection.ToLower();
                }
                else
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection;
                }
                mainForm.toolStripVersion.Text = "Team Foundation Server 2013/2015";
            }
            if (mainForm.tfsVersionShort == "V4") //TODO implement V5, when that gets resolved
            {
                if (mainForm.allCollections == true)
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection.ToLower();
                }
                else
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection;
                }
                mainForm.toolStripVersion.Text = "Team Foundation Server 2012/2013";
            }
            if (mainForm.tfsVersionShort == "V3")
            {
                if (mainForm.allCollections == true)
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection.ToLower();
                }
                else
                {
                    mainForm.toolStripCollection.Text = mainForm.tfsCollection;
                }
                mainForm.toolStripVersion.Text = "Team Foundation Server 2010";
            }
            if (mainForm.tfsVersionShort == "V2")
            {
                mainForm.toolStripCollection.Text = "Not Applicable";
                mainForm.toolStripVersion.Text = "Team Foundation Server 2008";
            }

            #endregion

            #region print successful connection information

            //display connection success notification - only reached if no exception was thrown
            printText = "\n\nConnection successful to " + mainForm.serverURInospace + " please select the roles and project then click OK.\n\n";
            mainForm.rtfMain.SelectionLength = printText.Length;
            mainForm.rtfMain.SelectionColor = Color.Blue;
            mainForm.rtfMain.AppendText(printText);
            mainForm.rtfMain.SelectionColor = Color.Black;
            printText = "";

            #endregion

            #region print collections information

            //display TFS collection information if we connected to a TFS 2010 box
            if ((mainForm.chkTFS2010.Checked == true) && (mainForm.txtCollection.Text != null) && (mainForm.tfsVersionShort != "V2"))
            {
                mainForm.rtfMain.AppendText(string.Format("\nThe following collections were reported by {0}:\n\n", mainForm.serverName));

                //better 2010 collection data methods
                foreach (CatalogNode tpcNode in mainForm.tpcNodes)
                {
                    // Use tpcNode.Resource to get the details for each team project collection.
                    string defaultCollection = tpcNode.IsDefault.ToString();
                    string displayName = tpcNode.Resource.DisplayName.ToString();
                    string description = tpcNode.Resource.Description.ToString();

                    if (description == "")
                    {
                        description = "Warning: No description specified at collection creation.";
                    }

                    if (mainForm.allCollections == true)
                    {
                        mainForm.myCollections.Add(displayName);
                    }

                    mainForm.rtfMain.AppendText(string.Format("Collection Name: {0}\t\tIs Default Collection: {1}\t\tDescription: {2}\n", displayName, defaultCollection, description));
                }
            }

            mainForm.toolStripBusy.ForeColor = Color.Black;
            mainForm.toolStripBusy.Text = "Idle";

            #endregion

            //add the collection name to myCollections regardless of 2008 or 2010
            //because we must have at least one collection no matter what
            if (mainForm.allCollections == false)
            {
                mainForm.myCollections.Add(mainForm.tfsCollection);
            }

            #region print TFS version confirmation

            //display the TFS version information
            printText = "\nTFS Version Confirmation: " + mainForm.tfsVersionReadable + " on " + mainForm.serverName + ".\n\n";
            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", mainForm.rtfMain.Font.Size, FontStyle.Bold); }));
            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", mainForm.rtfMain.Font.Size, FontStyle.Regular); }));
            printText = "";

            #endregion

            //clean up after the BackgroundWorker
            mainForm.connectionBackgroundWorker.Dispose();
        }

        #endregion
    }
}
