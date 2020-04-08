using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        NameValueCollection dataToSend = new NameValueCollection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataToSend["user_username"] = textBox1.Text;
            dataToSend["user_password"] = textBox2.Text;
            string GetData = Encoding.UTF8.GetString(wc.UploadValues(@"http://127.0.0.1/index.php", dataToSend));

            if (GetData == "nodata")
            {
                MessageBox.Show("No data found!", "#nodata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetData == "dataerror")
            {
                MessageBox.Show("Something went be wrong!", "#dataerror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetData == "usernotfound")
            {
                MessageBox.Show("Username not found!", "#usernotfound", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetData == "userwrongpassword")
            {
                MessageBox.Show("Username/Password incorrect", "#userwrongpassword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetData == "userbanned")
            {
                MessageBox.Show("Your account has been banned!", "#userbanned", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GetData == "success")
            {
                this.Hide();
                MessageBox.Show("Login Success!", "WELCOME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main f2 = new Main();
                f2.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("New Member?", "Create Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("THIS FUNCTION WILL BE SOON PLEASE DO A LOT OF REACTION TO REVIEW MORE PROJECTS!!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
