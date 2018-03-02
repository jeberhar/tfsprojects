using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TFSProjectsWin
{
    class DisplayText
    {
        #region variables

        private frmMain mainForm; //variable to receive controls from MainForm
        private string printText = ""; //local text holder variable

        #endregion

        //constructor
        public DisplayText(frmMain form1)
        {
            mainForm = form1;
        }

        //#region display initialization text

        public void initText()
        {
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.Clear(); }));

            printText = "\nTFS Project Audit 2.2.1 by Jay Eberhard Copyright 2018\n\n";
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionLength = printText.Length; }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionFont = new Font("Arial",mainForm.rtfAbout.Font.Size, FontStyle.Bold); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText(printText); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionFont = new Font("Arial", mainForm.rtfAbout.Font.Size, FontStyle.Regular); }));
            printText = "";

            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText("Press the Help button at any time for information for the description and usage info.\n\n"); }));

            printText = "Protected by GPL, read COPYING.rtf before making any changes.\n\n";
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionLength = printText.Length; }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionFont = new Font("Arial", mainForm.rtfAbout.Font.Size, FontStyle.Underline); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText(printText); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionFont = new Font("Arial", mainForm.rtfAbout.Font.Size, FontStyle.Regular); }));
            printText = "";

            printText = "The TFS 2010 Forward Compatibility Pack is no longer required for TFS Projects.\n\n";
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionLength = printText.Length; }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionColor = Color.Red; }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText(printText); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.SelectionColor = Color.Black; }));
            printText = "";

            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText("TFS 2005 Users MUST use version 1.0 of TFS Projects, which is available on http://tfsprojects.codeplex.com"); }));
            mainForm.rtfAbout.Invoke(new MethodInvoker(delegate { mainForm.rtfAbout.AppendText("\n\tFor email list generation, TFS 2005 users must use TFS Users, which is available at http://tfsusers.codeplex.com"); }));
        }

        //#endregion

        #region display user guide text

        public void helpText()
        {
            float zoom = mainForm.rtfHelp.ZoomFactor;
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.Clear(); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.ZoomFactor = zoom; }));

            printText = "TFS Projects -- Team Foundation Server Project Audit Tool\n\n";
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionLength = printText.Length; }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Bold); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText(printText); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Regular); }));
            printText = "";

            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("FUNCTION: lists all users for each project for all collections or a specified collection or for only one project within a collection and their roles for a TFS installation. "); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("Individual projects may be selected from the provided combo box once the connection is established.\n\n"); }));

            printText = "USAGE: Supply a valid server name, port number, TFS Version, TFS path and HTTP/S selection and (if applicable) collection name, then click Connect.\nUpon successful connection, select project role or all roles for all projects or individual project and click OK.\n";
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionLength = printText.Length; }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Underline); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText(printText); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Regular); }));
            printText = "";

            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("\nDefault values, which are loaded on startup, can be viewed and set on the Defaults tab.\n\n"); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("Project related user interface items will only become available upon successful connection to the TFS instance provided. A specific project or role on the server may be selected once connected. Results can be saved by clicking the Save Output... button. To generate a list of email addresses rather than verbose project information based on the specified criteria, check the Email Address List check box.\n\n"); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("When specifying a collection for TFS 2010 or later, you only need supply the actual collection name. A server name or any slashes or backslashes should not be included in the collection name.\n\n"); }));

            printText = "To gather data from all collections on TFS 2010 or later specify \"all-collections\" without quotes as the collection name in the Collection field.\n\n";
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionLength = printText.Length; }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionColor = Color.Red; }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText(printText); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionColor = Color.Black; }));
            printText = "";

            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("If no collection names are known use all-collections and a list of collections on the server will be provided then you can simply reconnect to the one you need.\n\n"); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("TFS port is 8080 by default, if this value gives an error contact your TFS admin for your port number."); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("\n\nTFS 2005 Users MUST use version 1.0 of TFS Projects, which is available at http://tfsprojects.codeplex.com"); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText("\n\tFor email list generation, TFS 2005 users must use TFS Users, which is available at http://tfsusers.codeplex.com"); }));
            
            printText = "\n\nTFS Project Audit 2.1 by Jay Eberhard Copyright 2016.\n\n";
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionLength = printText.Length; }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Bold); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.AppendText(printText); }));
            mainForm.rtfHelp.Invoke(new MethodInvoker(delegate { mainForm.rtfHelp.SelectionFont = new Font("Arial", mainForm.rtfHelp.Font.Size, FontStyle.Regular); }));
            printText = "";
        }

        #endregion

        #region display legal licence information

        public void copyingText()
        {
            try
            {
                mainForm.rtfLegal.Invoke(new MethodInvoker(delegate { mainForm.rtfLegal.Clear(); }));

                //load all the legal info from the COPYING.rtf file, in the app dir path
                //using (StreamReader sr = new StreamReader("Resources\\COPYING.rtf"))
                string copyFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TFSProjects\\COPYING.rtf";
                using (StreamReader sr = new StreamReader(copyFile));
                {
                    mainForm.rtfLegal.Invoke(new MethodInvoker
                        //(delegate { mainForm.rtfLegal.LoadFile(Environment.SpecialFolder.LocalApplicationData + "\\TFSProjects\\COPYING.rtf"); })
                        (delegate { mainForm.rtfLegal.LoadFile(copyFile); })
                    );
                }
            }
            catch (Exception e)
            {
                mainForm.rtfLegal.Invoke(new MethodInvoker(delegate { mainForm.rtfLegal.AppendText("ERROR: Copyright information file is not in its expected location!\n\n"); }));
                mainForm.rtfLegal.Invoke(new MethodInvoker(delegate { mainForm.rtfLegal.AppendText("This code is still bound by the license agreement which was installed with the program.\n\n"); }));
                mainForm.rtfLegal.Invoke(new MethodInvoker(delegate { mainForm.rtfLegal.AppendText("Please re-install TFSProjects, the most current version is available at http://tfsprojects.codeplex.com \n\n"); }));
                mainForm.rtfLegal.Invoke(new MethodInvoker(delegate { mainForm.rtfLegal.AppendText("\n\nException message: \n\n" + e.Message); }));
            }
        }

        #endregion
    }
}
