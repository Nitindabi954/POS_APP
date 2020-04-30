using POS_APP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textUser.Text != "" && textPassword.Text != "")
            {
                DataTable dt = new DataTable();
                dt = DBAccess.FilDataTable("Select * from tbUser where Username='" + textUser.Text.Trim() + "' and Password='" + textPassword.Text.Trim() + "'", dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    MessageBox.Show("Congrat, Login Success", "Nitin POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Username and Password Incorrect", "Nitin POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Enter Username And Password", "Nitin POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}