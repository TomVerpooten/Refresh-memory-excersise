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
    public partial class frmLogin : Form
    {
        string strGUserName;
        string strGPassWord;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strInputLogin, strInputPassword, strUserLogin, strUserPassWord;

            strInputLogin = txtUserName.Text;
            strInputPassword = txtPassWord.Text;

            strUserLogin = "tom.verpooten";
            strUserPassWord = "vt011009.";

            if (strInputLogin == "tom.verpooten")
            {
                if (strInputPassword == "vt011009.")
                {
                    Form Task = new frmTask();
                    Task.Show();

                    Form Login = new frmLogin();
                    this.Hide();
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("Je gebruikersnaam of wachtwoord zijn incorrect, probeer deze opnieuw.", "Input fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.OK)
                    {
                        txtUserName.Text = string.Empty;
                        txtPassWord.Text = string.Empty;
                    }
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Je gebruikersnaam of wachtwoord zijn incorrect, probeer deze opnieuw.", "Input fout", MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    txtUserName.Text = string.Empty;
                    txtPassWord.Text = string.Empty;
                }
            }
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bent u zeker dat u wilt afsluiten?", "Afsluiten", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Form C_A = new frmCreateAccount(strGUserName, strGPassWord);
            C_A.Show();

            Form Login = new frmLogin();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
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