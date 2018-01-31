using System.Windows.Forms;

namespace TFSProjectsWin
{
    class UIControl
    {
        //variable to receive controls from MainForm
        private frmMain mainForm;

        //constructor
        public UIControl(frmMain form1)
        {
            mainForm = form1;
        }

        #region disable all project/role UI elements
        
        public void disableProjectUIControls()
        {
            mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.Text = ""; }));
            mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Text = ""; }));
            mainForm.chkEmail.Invoke(new MethodInvoker(delegate { mainForm.chkEmail.Checked = false; }));   
            mainForm.lblRoles.Invoke(new MethodInvoker(delegate { mainForm.lblRoles.Enabled = false; }));
            mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.Enabled = false; }));
            mainForm.lblProject.Invoke(new MethodInvoker(delegate { mainForm.lblProject.Enabled = false; }));
            mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Enabled = false; }));
            mainForm.btnSave.Invoke(new MethodInvoker(delegate { mainForm.btnSave.Enabled = false; }));
            mainForm.menuStripMain.Invoke(new MethodInvoker(delegate { mainForm.saveToolStripMenuItem.Enabled = false; }));
            mainForm.btnOK.Invoke(new MethodInvoker(delegate { mainForm.btnOK.Enabled = false; }));
            mainForm.chkEmail.Invoke(new MethodInvoker(delegate { mainForm.chkEmail.Enabled = false; }));

        }

        #endregion

        #region enable all project/role UI elements

        public void enableProjectUIControls()
        {
            mainForm.lblRoles.Invoke(new MethodInvoker(delegate { mainForm.lblRoles.Enabled = true; }));
            mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.Enabled = true; }));
            mainForm.lblProject.Invoke(new MethodInvoker(delegate { mainForm.lblProject.Enabled = true; }));
            mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Enabled = true; }));
            mainForm.btnSave.Invoke(new MethodInvoker(delegate { mainForm.btnSave.Enabled = true; }));
            mainForm.menuStripMain.Invoke(new MethodInvoker(delegate { mainForm.saveToolStripMenuItem.Enabled = true; }));
            mainForm.btnOK.Invoke(new MethodInvoker(delegate { mainForm.btnOK.Enabled = true; }));
            mainForm.chkEmail.Invoke(new MethodInvoker(delegate { mainForm.chkEmail.Enabled = true; }));
        }

        #endregion

        #region disable configurable project/role UI elements

        public void hideWhileWorking()
        {
            mainForm.lblRoles.Invoke(new MethodInvoker(delegate { mainForm.lblRoles.Enabled = false; }));
            mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.Enabled = false; }));
            mainForm.lblProject.Invoke(new MethodInvoker(delegate { mainForm.lblProject.Enabled = false; }));
            mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Enabled = false; }));
            mainForm.btnOK.Invoke(new MethodInvoker(delegate { mainForm.btnOK.Enabled = false; }));
            mainForm.chkEmail.Invoke(new MethodInvoker(delegate { mainForm.chkEmail.Enabled = false; }));
        }

        #endregion

        #region enable configurable project/role UI elements

        public void enableWhenFinished()
        {

            mainForm.lblRoles.Invoke(new MethodInvoker(delegate { mainForm.lblRoles.Enabled = true; }));
            mainForm.cboRoles.Invoke(new MethodInvoker(delegate { mainForm.cboRoles.Enabled = true; }));
            mainForm.lblProject.Invoke(new MethodInvoker(delegate { mainForm.lblProject.Enabled = true; }));
            mainForm.cboProject.Invoke(new MethodInvoker(delegate { mainForm.cboProject.Enabled = true; }));
            mainForm.btnOK.Invoke(new MethodInvoker(delegate { mainForm.btnOK.Enabled = true; }));
            mainForm.chkEmail.Invoke(new MethodInvoker(delegate { mainForm.chkEmail.Enabled = true; }));
        }

        #endregion
    }
}
