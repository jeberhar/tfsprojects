
using System.Windows.Forms;
using System.Drawing;

namespace TFSProjectsWin
{
    class ProcessException
    {
        private frmMain mainForm; //variable to receive controls from MainForm

        //constructor
        public ProcessException(frmMain form1)
        {
            mainForm = form1;
        }

        #region exception handler for all exceptions

        //accepts custom string value for human readable error messages
        public void printException(string message)
        {
            mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.Clear(); }));
            string error = "\nERROR: " + message + "\n";
            if (message != "") 
            {
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionLength = error.Length; }));
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Red;}));
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.AppendText(error); })); 
                mainForm.rtfMain.Invoke(new MethodInvoker(delegate { mainForm.rtfMain.SelectionColor = Color.Black; }));
            }
        }

        #endregion

    }
}