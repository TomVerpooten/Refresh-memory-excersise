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
    public partial class frmTask : Form
    {
        public frmTask()
        {
            InitializeComponent();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ben je zeker dat je wilt afmelden?", "Afmelden", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Form Login = new frmLogin();
                Login.Show();

                Form Home = new frmTask();
                this.Close();
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

        private void frmHome_Load(object sender, EventArgs e)
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

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string strInput;

                strInput = txtInput.Text;

                lbxTasks.Items.Add(strInput);
                txtInput.Text = string.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string strInput;

            strInput = txtInput.Text;

            lbxTasks.Items[lbxTasks.SelectedIndex] = "";
            lbxTasks.Items[lbxTasks.SelectedIndex] = strInput;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbxTasks.Items.Remove(lbxTasks.SelectedItem);
        }
    }
}