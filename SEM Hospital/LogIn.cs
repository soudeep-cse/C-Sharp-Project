using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SEM_Hospital
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        public static string User;
        private void button2_Click(object sender, EventArgs e)
        {
            if (CUserCb.SelectedIndex == -1)
            {
                MessageBox.Show("First select the user");
            }
            else if (CUserCb.SelectedIndex == 0)
            {
                if (LPNameTb.Text == "" || LPassTb.Text == "")
                {
                    MessageBox.Show("Enter the name and password both for Admin...");
                }
                else if(LPNameTb.Text=="Admin" && LPassTb.Text=="P@$$w0rd")
                {
                    User = "Admin";
                    Dashboard db = new Dashboard();
                    db.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username and password"); 
                }
            }
            
            else if (CUserCb.SelectedIndex == 1)
            {
                if (LPNameTb.Text == "" || LPassTb.Text == "")
                {
                    MessageBox.Show("Enter the name and password both for Doctor...");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from DoctorTbl where DocName='" + LPNameTb.Text + "' and DocPass='" + LPassTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        User = "Doctor";
                        Prescription pres = new Prescription();
                        pres.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username and password for doctor");
                    }
                    Con.Close();
                }
            }
            else if (CUserCb.SelectedIndex == 2)
            {
                if (LPNameTb.Text == "" || LPassTb.Text == "")
                {
                    MessageBox.Show("Enter the name and password both for Staff...");
                }
                else if (LPNameTb.Text == "Nurse" && LPassTb.Text == "nurse123")
                {
                    User = "Nurse";
                    Dashboard pr = new Dashboard();
                    pr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username and password");
                }
                Con.Close();

            }
            else
            {
                if (LPNameTb.Text == "" || LPassTb.Text == "")
                {
                    MessageBox.Show("Enter the name and password both for Receptionist...");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from ReceptionistTbl where RecepName='" + LPNameTb.Text + "' and RecepPass='" + LPassTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        User = "Receptionist";
                        Dashboard d = new Dashboard();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username and Password for Receptionist");
                    }
                    Con.Close();
                }
            }

        }
        private void LResetBtn_Click(object sender, EventArgs e)
        {
            CUserCb.SelectedIndex = 0;
            LPNameTb.Text = "";
            LPassTb.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
