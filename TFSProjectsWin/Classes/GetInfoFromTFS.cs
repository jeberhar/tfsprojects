using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using System.Collections.Generic;

namespace TFSProjectsWin
{
    class GetInfoFromTFS
    {

        #region variables

        private frmMain mainForm; //variable to receive controls from MainForm
        private string printText = ""; //local text holder variable

        #endregion

        //constructor
        public GetInfoFromTFS(frmMain form1)
        {
            mainForm = form1;
        }

        public void doGetInfoFromTFS()
        {
            mainForm.cancelled = false; //set the cancelled variable to false

            if (mainForm.rtfMain.InvokeRequired)
            {
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("Please hold while I get your information...\n\n"); }));
            }

            #region reconnect for TFS 2010 or 2012
            //essentially, reconnect if running tfs2010 or 2012.  i do it here so the user doesn't have to reconnect every time they change a setting.
            if ((mainForm.tfsVersionShort == "V3")||(mainForm.tfsVersionShort == "V4")||(mainForm.tfsVersionShort == "V5")) //TODO this may need V5...bug on finding V5 is in progress
            {
                try
                {
                    string serverURInocollection = string.Concat(mainForm.http, mainForm.serverName, mainForm.colon, mainForm.portNumber, mainForm.tfsDir);
                    Uri tfs2010Urinocollection = new Uri(serverURInocollection);
                    mainForm.tfs2010Server = TfsConfigurationServerFactory.GetConfigurationServer(tfs2010Urinocollection); //for TFS 2010 only
                    CatalogNode tfsCatalog = mainForm.tfs2010Server.CatalogNode;

                    //query the children of the configuration server node for all of the team project collection nodes
                    mainForm.tpcNodes = tfsCatalog.QueryChildren(new Guid[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

                    if (mainForm.allCollections == true)
                    {
                        foreach (CatalogNode tpcNode in mainForm.tpcNodes)
                        {
                            if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                            {
                                mainForm.tfsInfoBackgroundWorker.Dispose();
                                return;
                            }

                            mainForm.myCollections.Add(tpcNode.Resource.DisplayName.ToString());
                        }
                    }
                    else
                    {
                        mainForm.myCollections.Add(mainForm.tfsCollection);
                    }
                }
                catch
                {
                    string error = "Cannot connect to specified server, check that it is actually operational and running TFS!\n";
                    mainForm.doProcessException(error);
                }
            }
            #endregion

            #region handling for TFS 2008 connection info
            //also ensure that tfs2008 will not need to reconnect.  again, i do this so the user doesn't have to reconnect.
            
            if (mainForm.tfsVersionShort == "V2")
            {
                mainForm.myCollections.Add(mainForm.tfsCollection);
            }

            #endregion

            try
            {
                #region for each collection (TFS 2008 has only one collection)

                //print the output for each collection in myCollections, which will always be at least one, even
                //for 2008 users - even though 2008 doesn't use collections.  tfs2008 is treated as one inclusive collection
                //so users can connect to 2008 and 2010 servers with minimal configuration.
                foreach (string collectionName in mainForm.myCollections)
                {
                    //check for cancellation
                    if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                    {
                        mainForm.tfsInfoBackgroundWorker.Dispose();
                        return;
                    }

                    #region connect to each collection

                    //increment the number of collections
                    mainForm.numberCollections = mainForm.numberCollections + 1;

                    //hide spaces in collectionName by replacing them with underscores. For display purposes only!
                    mainForm.collectionNamenospace = collectionName;
                    if (collectionName.Contains(" "))
                    {
                        mainForm.collectionNamenospace = collectionName.Replace(" ", "_");
                    }

                    if (mainForm.allCollections == true)
                    {
                        //connect to each collection only if allCollections is true, otherwise re-connection is skipped
                        mainForm.serverURI = string.Concat(mainForm.http, mainForm.serverName, mainForm.colon, mainForm.portNumber, mainForm.tfsDir, collectionName);
                        Uri tfsUriNew = new Uri(mainForm.serverURI);
                        mainForm.tfsConnect = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tfsUriNew);
                        mainForm.iss = (ICommonStructureService)mainForm.tfsConnect.GetService(typeof(ICommonStructureService));
                        mainForm.gss = (IGroupSecurityService2)mainForm.tfsConnect.GetService(typeof(IGroupSecurityService2));
                        mainForm.allTeamProjects = mainForm.iss.ListProjects();
                    }

                    #endregion

                    #region get info for all projects

                    //iterate thru the team project list
                    if (mainForm.projectName == mainForm.allHolder)
                    {

                        #region start foreach project within each collection

                        //for each project in allTeamProjects
                        //foreach (ProjectInfo TFSProjectInfo in mainForm.allTeamProjects)
                        foreach (Microsoft.TeamFoundation.Server.ProjectInfo TFSProjectInfo in mainForm.allTeamProjects)
                        {
                            //check for cancellation
                            if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                            {
                                mainForm.tfsInfoBackgroundWorker.Dispose();
                                return;
                            }

                            #region variable assignments

                            //ProjectInfo gives you the team project's name, status, and URI.
                            mainForm.teamProjectName = TFSProjectInfo.Name;
                            mainForm.teamProjectState = TFSProjectInfo.Status;
                            mainForm.teamProjectUriInfo = TFSProjectInfo.Uri;

                            //for each Team project identify each security Group
                            mainForm.allProjectGroups = mainForm.gss.ListApplicationGroups(mainForm.teamProjectUriInfo);

                            #endregion

                            //skip this team project if it has the specific All selection, which isn't an actual project only a value from the combo box
                            if (mainForm.teamProjectName == mainForm.allHolder)
                            {
                                continue;
                            }

                            #region print team project/collection info

                            //increment projectCount
                            mainForm.projectCount = mainForm.projectCount + 1;

                            //increment the total number of projects for all collections
                            mainForm.totalNumberProjects = mainForm.totalNumberProjects + 1;

                            //print team project info
                            if (mainForm.emailOnly == false)
                            {
                                //handle 2008 which has no collectionName or print it for 2010
                                if ((mainForm.tfsVersionShort == "V3")||(mainForm.tfsVersionShort == "V4")||(mainForm.tfsVersionShort == "V5")) //TODO ...may need V5
                                {
                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        //mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\nCollection: {0}\tProject Name: {1}", collectionName, mainForm.teamProjectName)); }));
                                        printText = "\nCollection: " + collectionName + "\tProject Name: " + mainForm.teamProjectName;
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Blue; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                                        printText = "";
                                    }
                                }
                                if (mainForm.tfsVersionShort == "V2")
                                {
                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        //mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\nProject Name: {0}", mainForm.teamProjectName)); }));
                                        printText = "\nProject Name: " + mainForm.teamProjectName;
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Blue; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                                        printText = "";
                                    }
                                }
                            }

                            #endregion

                            //skip this team project if it is not WellFormed.
                            if (TFSProjectInfo.Status.ToString() != "WellFormed")
                            {
                                continue;
                            }

                            #region for each project group within each project within each collection

                            //iterate thru the project group list and get a list of direct members for each project group
                            foreach (Identity projectGroup in mainForm.allProjectGroups)
                            {
                                //check for cancellation
                                if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                {
                                    mainForm.tfsInfoBackgroundWorker.Dispose();
                                    return;
                                }
                                mainForm.projGroup = projectGroup.DisplayName.ToString();
                                if ((mainForm.projGroup.Contains(mainForm.providedGroup) == true) || mainForm.providedGroup.Equals(mainForm.allHolder))
                                {
                                    //for each Security Group, identify all the users that belong to that group
                                    mainForm.projectGroupIdentity = mainForm.gss.ReadIdentity(SearchFactor.Sid, projectGroup.Sid, QueryMembership.Direct);

                                    #region print project group name

                                    //only print if we're not simply generating a list of associated email addresses
                                    if ((mainForm.emailOnly == false) && (mainForm.providedGroup != mainForm.noRoleHolder))
                                    {
                                        if (mainForm.rtfMain.InvokeRequired)
                                        {
                                            //mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\tProject Group Name: {0}", mainForm.projectGroupIdentity.DisplayName)); }));
                                            printText = "\n\tProject Group Name: " + mainForm.projectGroupIdentity.DisplayName;
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.DarkCyan; }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                            printText = "";
                                        }
                                    }

                                    #endregion

                                    #region print group info for each group member

                                    //print detailed identity info for each group member
                                    foreach (String groupMemberSID in mainForm.projectGroupIdentity.Members)
                                    {
                                        //check for cancellation
                                        if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                        {
                                            mainForm.tfsInfoBackgroundWorker.Dispose();
                                            return;
                                        }

                                        #region print full info

                                        mainForm.idCount = mainForm.idCount + 1;

                                        //fetch the user ID info
                                        mainForm.tfsID = mainForm.gss.ReadIdentity(SearchFactor.Sid, groupMemberSID, QueryMembership.None);

                                        //print the name and email for each ID when we're not just printing email addresses
                                        //NOTE: modify the AppendText line if you want more or less user info printed
                                        if ((mainForm.emailOnly == false) && (mainForm.providedGroup != mainForm.noRoleHolder))
                                        {
                                            if (mainForm.rtfMain.InvokeRequired)
                                            {
                                                if (mainForm.tfsID.MailAddress != "")
                                                {
                                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\t\tName : {0}\t\t\tEmail : {1}", mainForm.tfsID.DisplayName, mainForm.tfsID.MailAddress)); }));
                                                }
                                                else
                                                {
                                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\t\tName : {0}\t\t\t", mainForm.tfsID.DisplayName)); }));
                                                }
                                            }
                                        }

                                        #endregion

                                        #region print email info only

                                        else if ((mainForm.emailOnly == true) && (mainForm.emailListValue == true)) //we're only printing email addresses
                                        {
                                            if (mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false)
                                            {
                                                if (mainForm.tfsID.MailAddress.ToString() != "")
                                                {
                                                    if (mainForm.allCollections == false)
                                                    {
                                                        if ((mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false)&&(mainForm.myUsers.Contains(mainForm.tfsID.DisplayName.ToString()) == false))
                                                        {
                                                            mainForm.myUsers.Add(mainForm.tfsID.MailAddress.ToString()); //print the email address if myUsers doesn't already contain it, if the address isn't empty, and if allCollections is false
                                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} email found! --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((mainForm.myUsersAllCollections.Contains(mainForm.tfsID.MailAddress.ToString()) == false)&&(mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false))
                                                        {
                                                            mainForm.myUsersAllCollections.Add(mainForm.tfsID.MailAddress.ToString()); //add the address to myUsersAllCollections for email addresses from all collections
                                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} email found! --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                        }
                                                    }
                                                    mainForm.totalNumberProjectUsers = mainForm.totalNumberProjectUsers + 1; //after we're done with the project add it to the project counter
                                                }
                                                if (mainForm.tfsID.MailAddress.ToString() == "")
                                                {
                                                    if (mainForm.allCollections == false)
                                                    {
                                                        if ((mainForm.myNonUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.myNonUsers.Contains(mainForm.tfsID.DisplayName.ToString()) == false) && (mainForm.tfsID.SecurityGroup.Equals(false)))
                                                        {
                                                            mainForm.myNonUsers.Add(mainForm.tfsID.DisplayName.ToString()); //print the email address if myUsers doesn't already contain it, if the address isn't empty, and if allCollections is false
                                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("No email found for {0} --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((mainForm.myNonUsersAllCollections.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.tfsID.SecurityGroup.Equals(false)) && (mainForm.myNonUsersAllCollections.Contains(mainForm.tfsID.DisplayName.ToString()) == false))
                                                        {
                                                            mainForm.myNonUsersAllCollections.Add(mainForm.tfsID.DisplayName.ToString()); //add the address to myNonUsersAllCollections for email addresses from all collections
                                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("No email found for {0} --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                        }
                                                    }
                                                    if ((mainForm.myNonUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.myNonUsers.Contains(mainForm.tfsID.DisplayName.ToString()) == false))
                                                    {
                                                        mainForm.totalNumberProjectUsers = mainForm.totalNumberProjectUsers + 1; //after we're done with the project add it to the project counter
                                                    }
                                                    if ((mainForm.myNonUsersAllCollections.Contains(mainForm.tfsID.MailAddress.ToString()) == false) && (mainForm.myNonUsersAllCollections.Contains(mainForm.tfsID.DisplayName.ToString()) == false))
                                                    {
                                                        mainForm.totalNumberUsersAllCollections = mainForm.totalNumberUsersAllCollections + 1;
                                                    }
                                                }
                                            }
                                        }

                                        #endregion

                                        else
                                        {
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("PRINT FAILED FOR A USER!!"); }));
                                        }

                                    }

                                    #endregion

                                    #region print user summary for each group

                                    //only print if we're not simply generating a list of associated email addresses
                                    if ((mainForm.emailOnly == false) && (mainForm.providedGroup != mainForm.noRoleHolder))
                                    {
                                        if (mainForm.rtfMain.InvokeRequired)
                                        {
                                            printText = "\n\t\tThere are " + mainForm.idCount + " users in the " + mainForm.projectGroupIdentity.DisplayName + " group for " + mainForm.teamProjectName + ".";
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                                            printText = "";
                                        }
                                    }

                                    #endregion

                                    //reset idCount with each new project group
                                    mainForm.idCount = 0;
                                }
                            }

                            #endregion

                        } //end foreach in allTeamProjects

                        #endregion

                        #region print sorted email list

                        //sort the muUsers array in email address generation - easier to read if they're alphabetical
                        
                        mainForm.myUsers.Sort();

                        //only print what is in the myUsers array if we actually wanted an email list
                        if (mainForm.emailOnly == true)
                        {
                            printText = "\n\nSorted email list:\n\n";
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Blue; }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                            printText = "";

                            if (mainForm.myUsers.Count == 0)
                            {
                                printText = "No email addresses found! Check with your directory administrator!\n\n";
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Red; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                printText = "";
                            }

                            if (mainForm.allCollections == false)
                            {
                                foreach (string email in mainForm.myUsers)
                                {
                                    //check for cancellation
                                    if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                    {
                                        mainForm.tfsInfoBackgroundWorker.Dispose();
                                        return;
                                    }

                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0};\n", email.ToLower())); }));
                                    }
                                }
                                foreach (string email in mainForm.myNonUsers)
                                {
                                    //check for cancellation
                                    if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                    {
                                        mainForm.tfsInfoBackgroundWorker.Dispose();
                                        return;
                                    }

                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} has no email address associated with it!\n", mainForm.tfsID.DisplayName.ToString())); }));
                                    }
                                }
                            }
                        }

                        #endregion

                        #region print warning about a collection with no projects

                        if ((mainForm.projectCount == 0) && (mainForm.emailOnly == false))
                        {
                            if (mainForm.rtfMain.InvokeRequired)
                            {
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(String.Format("WARNING: {0} has no projects.", mainForm.collectionNamenospace)); }));
                            }
                        }

                        #endregion

                        #region print summary information

                        //print closing string depending on the task, email list or regular project description
                        if (mainForm.emailOnly == false)
                        {
                            if (mainForm.allCollections == false)
                            {
                                if (mainForm.rtfMain.InvokeRequired)
                                {
                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\nThere are {0} projects on {1}\n", mainForm.projectCount, mainForm.serverURInospace)); }));
                                }
                            }
                            else
                            {
                                if (mainForm.rtfMain.InvokeRequired)
                                {
                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\nThere are {0} projects on {1}{2}\n", mainForm.projectCount, mainForm.serverURInospace, mainForm.collectionNamenospace)); }));
                                }
                            }
                        }
                        else //allCollections and emailOnly == true is handled later in program execution, outside the main collections execution loop
                        {
                            if (mainForm.allCollections == false)
                            {
                                if (mainForm.rtfMain.InvokeRequired)
                                {
                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\nThere are {0} users on {1}\n", mainForm.totalNumberProjectUsers, mainForm.serverURInospace)); }));
                                }
                            }
                        }

                        #endregion

                        #region reset collection/project variables

                        //reset variables used in project to null values
                        mainForm.myUsers.Clear();
                        mainForm.teamProjectName = "";
                        mainForm.teamProjectUriInfo = "";
                        mainForm.projGroup = "";
                        mainForm.projectCount = 0;
                        mainForm.idCount = 0;
                        mainForm.totalNumberProjectUsers = 0;
                        mainForm.projectGroupIdentity = null;
                        mainForm.tfsID = null;

                        #endregion

                    } //end if (end all projects)
                    #endregion

                    #region get info for single project
                    else //iterate through the groups and users for only one project
                    {
                        #region single project variables declaration

                        ProjectInfo singleTFSProjectInfo = (mainForm.iss.GetProjectFromName(mainForm.projectName));
                        string singleProject = singleTFSProjectInfo.Name;
                        string singleURI = singleTFSProjectInfo.Uri;
                        string singleProjectnospace = "";
                        int singleIdCount = 0;

                        #endregion

                        #region set display name for project (no spaces)

                        //hide spaces in the project name by replacing them with underscores. For display purposes only!
                        singleProjectnospace = singleProject;
                        if (singleProjectnospace.Contains(" "))
                        {
                            singleProjectnospace = singleProjectnospace.Replace(" ", "_");
                        }

                        #endregion

                        #region print project name data

                        //only print certain output if we're not just generating an email list
                        if (mainForm.emailOnly == false)
                        {
                            if (mainForm.rtfMain.InvokeRequired)
                            {
                                //mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("Project Name : {0}", singleProject)); }));
                                printText = "\nProject Name: " + singleProject;
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Blue; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                                printText = "";
                            }
                        }

                        #endregion

                        #region for each group defined for the project...

                        //get the groups for our singleton project
                        List<Identity> projectGroups = new List<Identity>(mainForm.gss.ListApplicationGroups(singleURI));
                        int tfsGroupCount = projectGroups.Count;
                        for (int i = 0;  i<projectGroups.Count;i++)
                        {
                            Identity projectGroup = projectGroups[i];
                            //check for cancellation
                            if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                            {
                                mainForm.tfsInfoBackgroundWorker.Dispose();
                                return;
                            }

                            #region print each project group name

                            mainForm.projGroup = projectGroup.DisplayName.ToString();

                            if ((mainForm.projGroup.Contains(mainForm.providedGroup) == true) || mainForm.providedGroup.Contains(" All"))
                            {
                                // For each Security Group identify all the users that belong to that group
                                mainForm.projectGroupIdentity = mainForm.gss.ReadIdentity(SearchFactor.Sid, projectGroup.Sid, QueryMembership.Direct);

                                //only print if we're not simply generating a list of associated email addresses
                                if (mainForm.emailOnly == false)
                                {
                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        //mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\tProject Group Name : {0}", mainForm.projectGroupIdentity.DisplayName)); }));
                                        if (i < tfsGroupCount)
                                            printText = "\n\tProject Group Name: " + mainForm.projectGroupIdentity.DisplayName;
                                        else
                                            printText = "\n\tOut-Of-Project Group Name: " + mainForm.projectGroupIdentity.DisplayName;
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = (i < tfsGroupCount)? Color.DarkCyan : Color.Blue; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                        printText = "";
                                    }
                                }

                            #endregion

                                #region print each member of each project group

                                // Print detailed identity info for each group member
                                foreach (String groupMemberSid in mainForm.projectGroupIdentity.Members)
                                {
                                    //check for cancellation
                                    if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                    {
                                        mainForm.tfsInfoBackgroundWorker.Dispose();
                                        return;
                                    }

                                    #region print fill member info - email only is false

                                    singleIdCount = singleIdCount + 1;
                                    mainForm.tfsID = mainForm.gss.ReadIdentity(SearchFactor.Sid, groupMemberSid, QueryMembership.None);
                                    if (mainForm.tfsID.SecurityGroup && !projectGroups.Contains(mainForm.tfsID))
                                        projectGroups.Insert(projectGroups.Count, mainForm.tfsID);
                                    if (mainForm.emailOnly == false)
                                    {
                                        if (mainForm.rtfMain.InvokeRequired)
                                        {
                                            if (mainForm.tfsID.MailAddress != "")
                                            {
                                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\t\tName : {0}\t\t\tEmail : {1}", mainForm.tfsID.DisplayName, mainForm.tfsID.MailAddress)); }));
                                            }
                                            else
                                            {
                                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\t\tName : {0}\t\t\t", mainForm.tfsID.DisplayName)); }));
                                            }
                                        }
                                    }

                                    #endregion

                                    #region print notification of email address discovery - email only is true

                                    else
                                    {
                                        if ((mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false)&&(mainForm.myUsers.Contains(mainForm.tfsID.MailAddress.ToString()) == false))
                                        {
                                            if (mainForm.tfsID.MailAddress.ToString() != "")
                                            {
                                                mainForm.myUsers.Add(mainForm.tfsID.MailAddress.ToString());
                                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} email found! --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                mainForm.totalNumberProjectUsers = mainForm.totalNumberProjectUsers + 1;
                                            }
                                        }
                                        if ((mainForm.myNonUsers.Contains(mainForm.tfsID.DisplayName.ToString()) == false)&&(mainForm.myUsers.Contains(mainForm.tfsID.DisplayName.ToString()) == false)&&(mainForm.tfsID.SecurityGroup.Equals(false)))
                                        {
                                            if (mainForm.tfsID.MailAddress.ToString() == "")
                                            {
                                                mainForm.myNonUsers.Add(mainForm.tfsID.DisplayName.ToString());
                                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("No email found for {0} --Continuing to discover other users...\n", mainForm.tfsID.DisplayName.ToString())); }));
                                                mainForm.totalNumberProjectUsers = mainForm.totalNumberProjectUsers + 1;
                                            }
                                        }
                                    }

                                    #endregion
                                }

                                #endregion

                                #region print group total information

                                //only print if we're not simply generating a list of associated email addresses
                                if (mainForm.emailOnly == false)
                                {
                                    if (mainForm.rtfMain.InvokeRequired)
                                    {
                                        printText = "\n\t\tThere are " + singleIdCount + " users in the " + mainForm.projectGroupIdentity.DisplayName + " group for " + singleProject + ".";
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                        mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                                        printText = "";
                                    }
                                }
                                //reset singleIdCount with each new group
                                singleIdCount = 0;

                                #endregion
                            }
                        }

                        #endregion

                        #region post-discovery email address list generation

                        //sort the muUsers array in email address generation - easier to read if they're alphabetical
                        mainForm.myUsers.Sort();

                        //only print what is in the myUsers array if we actually wanted an email list
                        if (mainForm.emailOnly == true)
                        {
                            printText = "\n\nSorted email list:\n\n";
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Blue; }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Bold); }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionFont = new Font("Arial", 9, FontStyle.Regular); }));
                            printText = "";

                            if (mainForm.myUsers.Count == 0)
                            {
                                printText = "No email addresses found! Check with your directory administrator!\n\n";
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = printText.Length; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Red; }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(printText); }));
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
                                printText = "";
                            }

                            foreach (string email in mainForm.myUsers)
                            {
                                if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                {
                                    mainForm.tfsInfoBackgroundWorker.Dispose();
                                    return;
                                }
                                if (mainForm.rtfMain.InvokeRequired)
                                {
                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0};\n", email.ToLower())); }));
                                }
                            }
                            foreach (string email in mainForm.myNonUsers)
                            {
                                //check for cancellation
                                if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                                {
                                    mainForm.tfsInfoBackgroundWorker.Dispose();
                                    return;
                                }

                                if (mainForm.rtfMain.InvokeRequired)
                                {
                                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} has no email address associated with it!\n", email.ToLower())); }));
                                }
                            }
                        }

                        //print closing string for email address list generation
                        if (mainForm.emailOnly == true)
                        {
                            if (mainForm.rtfMain.InvokeRequired)
                            {
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\n\nThere are {0} users on {1}/{2}", mainForm.totalNumberProjectUsers, mainForm.serverURInospace, singleProjectnospace)); }));
                            }
                        }

                        #endregion

                        #region reset singple project variables

                        //reset variables used in singleton project to null values
                        mainForm.myUsers.Clear();
                        singleProject = "";
                        singleURI = "";
                        mainForm.projGroup = "";
                        singleIdCount = 0;
                        mainForm.totalNumberProjectUsers = 0;
                        mainForm.totalNumberUsersAllCollections = 0;
                        mainForm.projectGroupIdentity = null;
                        mainForm.tfsID = null;

                        #endregion

                    } //end else (end single project)
                }

                #endregion

                #region print email list when all collections is true

                //sort the myUsersAllCollections array in email address generation - easier to read if they're alphabetical
                mainForm.myUsersAllCollections.Sort();

                //only print what is in the myUsersAllCollections array if we actually wanted an email list
                if (mainForm.emailOnly == true)
                {
                    if (mainForm.allCollections == true)
                    {
                        foreach (string email in mainForm.myUsersAllCollections)
                        {
                            //check for cancellation
                            if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                            {
                                mainForm.tfsInfoBackgroundWorker.Dispose();
                                return;
                            }
                            if (mainForm.rtfMain.InvokeRequired)
                            {
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0};\n", email.ToLower())); }));
                            }
                            mainForm.totalNumberUsersAllCollections = mainForm.totalNumberUsersAllCollections + 1;
                        }
                        foreach (string email in mainForm.myNonUsersAllCollections)
                        {
                            //check for cancellation
                            if (mainForm.tfsInfoBackgroundWorker.CancellationPending == true)
                            {
                                mainForm.tfsInfoBackgroundWorker.Dispose();
                                return;
                            }

                            if (mainForm.rtfMain.InvokeRequired)
                            {
                                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("{0} has no email address associated with it! \n", email.ToLower())); }));
                            }
                        }
                    }
                }

                mainForm.tfsID = null;

                #endregion

                #region print summary information

                //print summary data for all collections if allCollections is true
                if ((mainForm.allCollections == true)&&(mainForm.tfsProjectValue ==" All"))
                {
                    if (mainForm.emailOnly == true)
                    {
                        if (mainForm.rtfMain.InvokeRequired)
                        {
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\nThere are {0} total collections, {1} total projects and {2} total users on {3}", mainForm.numberCollections, mainForm.totalNumberProjects, mainForm.totalNumberUsersAllCollections, mainForm.serverURInospace)); }));
                            mainForm.totalNumberUsersAllCollections = 0;
                        }
                    }
                    else
                    {
                        if (mainForm.rtfMain.InvokeRequired)
                        {
                            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(string.Format("\nThere are {0} total collections and {1} total projects on {2}", mainForm.numberCollections, mainForm.totalNumberProjects, mainForm.serverURInospace)); }));
                        }
                    }
                }

                #endregion

                #region clear out collection/project variables

                //clear out the collections array
                mainForm.myCollections.Clear();

                //set allCollections to false 
                mainForm.allCollections = false;

                //zero out the counters
                mainForm.numberCollections = 0;
                mainForm.totalNumberProjects = 0;

                mainForm.emailOnly = false;

                mainForm.myUsersAllCollections.Clear();
                mainForm.myNonUsersAllCollections.Clear();
                mainForm.myUsers.Clear();
                mainForm.myNonUsers.Clear();

                #endregion

                #endregion

            } //end try
            
            //catch all errors, display exception message and direct user to try again
            catch (Exception ex)
            {
                #region process any exceptions (the catch)

                mainForm.doProcessException(ex.Message.ToString());
                if (mainForm.rtfMain.InvokeRequired)
                {
                    mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText("\nPlease check the status of your TFS instance and try again.\n"); }));
                }

                #endregion
            }
            
        }
    }
}
