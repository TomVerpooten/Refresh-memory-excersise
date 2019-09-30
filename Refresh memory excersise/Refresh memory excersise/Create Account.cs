using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refresh_memory_excersise
{
    public partial class frmCreateAccount : Form
    {
        string strGUserName;
        string strGPassWord;

        public frmCreateAccount(string strLUserName, string strLPassWord)
        {
            this.strGUserName = strLUserName;
            this.strGPassWord = strLPassWord;

            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strUserName, strPassword, strFName, strLName, strBirthDate;

            strFName = txtFirstName.Text.ToLower();
            strLName = txtSecondName.Text.ToLower();
            strBirthDate = txtBirthDate.Text.Substring(8, 2) + txtBirthDate.Text.Substring(3, 2) + txtBirthDate.Text.Substring(0,2);

            strUserName = strFName + "." + strLName;
            strPassword = strLName.Substring(0, 1) + strFName.Substring(0, 1) + strBirthDate + ".";

            DialogResult dialogResult = MessageBox.Show("Je gebruikersnaam is " + strUserName + " en je wachtwoord is " + strPassword, "Inlog gegevens", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Form Login = new frmLogin();
                Login.Show();

                Form C_A = new frmCreateAccount(strGUserName, strGPassWord);
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form Login = new frmLogin();
            Login.Show();

            Form C_A = new frmCreateAccount(strGUserName, strGPassWord);
            this.Close();
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bent u zeker dat u wilt afsluiten?", "Afsluiten", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            Timer Time = new Timer();

            Time.Interval = 1000;
            Time.Tick += new EventHandler(Time_Tick);
            Time.Start();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}