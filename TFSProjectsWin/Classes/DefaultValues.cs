using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TFSProjectsWin
{
    class DefaultValues
    {
        private frmMain mainForm; //variable to receive controls from MainForm

        //constructor
        public DefaultValues(frmMain form1)
        {
            mainForm = form1;
        }

        public bool malformedConfig = false;

        string configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TFSProjects\";
        string configFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TFSProjects\\defaults.txt";
        string copyFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TFSProjects\\COPYING.rtf";

        public void importCurrentValues()
        {
            mainForm.txtSetServer.Text = mainForm.defaultHost;
            mainForm.txtSetPort.Text = mainForm.defaultPort;
            mainForm.txtSetPath.Text = mainForm.defaultPath;
            mainForm.txtSetCollection.Text = mainForm.defaultCollection;

            if (mainForm.defaultVersion == "2010 or later")
            {
                mainForm.chkSetVersion.Checked = true;
            }
            else
            {
                mainForm.chkSetVersion.Checked = false;
            }

            if (mainForm.defaultHttp == "true")
            {
                mainForm.chkSetHttps.Checked = true;
            }
            else
            {
                mainForm.chkSetHttps.Checked = false;
            }
        }

        public void checkCopying()
        {
            if (!Directory.Exists(configFilePath))
            {
                Directory.CreateDirectory(configFilePath);
            }

            if (!File.Exists(copyFile))
            {
                string copyFileSource = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Jay Eberhard\\TFS Projects\\Resources\\COPYING.rtf";
                File.Copy(copyFileSource, copyFile);
            }
        }

        public void saveDefaults()
        {
            mainForm.defaultHost = mainForm.txtSetServer.Text;
            mainForm.defaultPort = mainForm.txtSetPort.Text;
            mainForm.defaultPath = mainForm.txtSetPath.Text;
            mainForm.defaultCollection = mainForm.txtSetCollection.Text;

            if (mainForm.chkSetHttps.Checked == true)
            {
                mainForm.defaultHttp = "true";
            }
            else
            {
                mainForm.defaultHttp = "false";
            }

            if (mainForm.chkSetVersion.Checked == true)
            {
                mainForm.defaultVersion = "2010 or later";
            }
            else
            {
                mainForm.defaultVersion = "Not 2010 or later";
            }

            #region error handling and writing of values //TODO pretty up these message boxes

            if (mainForm.txtSetServer.Text == "")
            {
                MessageBox.Show("Server can not be empty", "Empty Server Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                malformedConfig = true;
                return;
            }
            if (mainForm.txtSetPort.Text == "")
            {
                MessageBox.Show("Port can not be empty", "Empty Port Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                malformedConfig = true;
                return;
            }
            if (mainForm.txtSetPath.Text == "")
            {
                MessageBox.Show("Path can not be empty", "Empty Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                malformedConfig = true;
                return;
            }
            if (mainForm.txtSetCollection.Text == "" && mainForm.defaultVersion == "2010 or later")
            {
                MessageBox.Show("Collection can not be empty", "Empty Collection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                malformedConfig = true;
                return;
            }
            if(mainForm.txtSetCollection.Text != "" && mainForm.defaultVersion == "Not 2010 or later")
            {
                MessageBox.Show("Collection can not be specified for TFS 2008", "Bad Collection Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                malformedConfig = true;
                return;
            }

            malformedConfig = false;
            System.IO.StreamWriter configFileWriter = new System.IO.StreamWriter(configFile, false);
            configFileWriter.WriteLine(mainForm.defaultHost);
            configFileWriter.WriteLine(mainForm.defaultPort);
            configFileWriter.WriteLine(mainForm.defaultPath);
            configFileWriter.WriteLine(mainForm.defaultHttp);
            configFileWriter.WriteLine(mainForm.defaultVersion);
            configFileWriter.WriteLine(mainForm.defaultCollection);
            configFileWriter.Close();

            mainForm.lblDefaultServer.Text = mainForm.defaultHost;
            mainForm.lblDefaultPort.Text = mainForm.defaultPort;
            mainForm.lblDefaultPath.Text = mainForm.defaultPath;
            mainForm.lblDefaultHTTP.Text = mainForm.defaultHttp;
            mainForm.lblDefaultVersion.Text = mainForm.defaultVersion;
            if (mainForm.defaultCollection != "")
            {
                mainForm.lblDefaultCollection.Text = mainForm.defaultCollection;
            }
            else
            {
                mainForm.lblDefaultCollection.Text = "Default collection not specified by user";
            }

            mainForm.txtSetServer.Text = "";
            mainForm.txtSetPort.Text = "";
            mainForm.txtSetPath.Text = "";
            mainForm.txtSetCollection.Text = "";
            mainForm.chkSetVersion.Checked = false;
            mainForm.chkSetHttps.Checked = false;

            #endregion
        }

        public void loadDefaults()
        {
            string line;
            int counter = 0;
            
            checkForFile();
            System.IO.StreamReader configFileReader = new System.IO.StreamReader(configFile);

            while ((line = configFileReader.ReadLine()) != null)
            {
                mainForm.valuesFromFile[counter] = line;
                counter++;
            }

            configFileReader.Close();

            mainForm.defaultHost = mainForm.valuesFromFile[0];
            mainForm.defaultPort = mainForm.valuesFromFile[1];
            mainForm.defaultPath = mainForm.valuesFromFile[2];
            mainForm.defaultHttp = mainForm.valuesFromFile[3];
            mainForm.defaultVersion = mainForm.valuesFromFile[4];
            mainForm.defaultCollection = mainForm.valuesFromFile[5];

            mainForm.lblDefaultServer.Text = mainForm.defaultHost;
            mainForm.lblDefaultPort.Text = mainForm.defaultPort;
            mainForm.lblDefaultPath.Text = mainForm.defaultPath;
            mainForm.lblDefaultHTTP.Text = mainForm.defaultHttp;
            mainForm.lblDefaultVersion.Text = mainForm.defaultVersion;
            mainForm.lblDefaultCollection.Text = mainForm.defaultCollection;

            mainForm.txtHost.Text = mainForm.defaultHost;
            mainForm.txtPort.Text = mainForm.defaultPort;
            mainForm.txtPath.Text = mainForm.defaultPath;
            mainForm.txtCollection.Text = mainForm.defaultCollection;

            if (mainForm.defaultCollection != "")
            {
                mainForm.lblDefaultCollection.Text = mainForm.defaultCollection;
            }
            else
            {
                mainForm.lblDefaultCollection.Text = "Default collection not specified by user";
            }

            if (mainForm.defaultHttp == "true")
            {
                mainForm.chkHttps.Checked = true;
            }
            else
            {
                mainForm.chkHttps.Checked = false;
            }

            if (mainForm.defaultVersion == "2010 or later")
            {
                mainForm.chkTFS2010.Checked = true;
            }
            else
            {
                mainForm.chkTFS2010.Checked = false;
            }
        }

        private void checkForFile()
        {
            if (!Directory.Exists(configFilePath))
            {
                Directory.CreateDirectory(configFilePath);
            }

            if (!File.Exists(configFile))
            {                
                createDefaultConfig();
            }
            checkConfig();
            if (malformedConfig == true)
            {
                createDefaultConfig();
            }
        }

        private void createDefaultConfig()
        {
            System.IO.StreamWriter configFileWriter = new System.IO.StreamWriter(configFile, false);
            configFileWriter.WriteLine("localhost");
            configFileWriter.WriteLine("8080");
            configFileWriter.WriteLine("tfs");
            configFileWriter.WriteLine("false");
            configFileWriter.WriteLine("2010 or later");
            configFileWriter.WriteLine("all-collections");
            configFileWriter.Close();
            malformedConfig = false;
        }

        private void checkConfig()
        {
            System.IO.StreamReader configFileReader = new System.IO.StreamReader(configFile);

            string[] lines = File.ReadAllLines(configFile);
            int configFileLines = File.ReadAllLines(configFile).Length;

            if (configFileLines != 6)
            {
                malformedConfig = true;
            }

            if ((lines[0] == null) || (lines[1] == null) || (lines[2] == null) || (lines[3] == null) || (lines[4] == null) || (lines[5] == null))
            {
                malformedConfig = true;
            }

            if ((lines[0] == "") || (lines[1] == "") || (lines[2] == "") || (lines[3] == "") || (lines[4] == ""))
            {
                malformedConfig = true;
            }

            if ((lines[4] == "2010 or later") && (lines[5] == ""))
            {
                malformedConfig = true;
            }

            if ((lines[4] == "Not 2010 or later") && (lines[5] != ""))
            {
                malformedConfig = true;
            }

            configFileReader.Close();
        }
    }
}
