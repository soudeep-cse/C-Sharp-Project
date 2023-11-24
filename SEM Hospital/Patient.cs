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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            DisplayPat();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void DisplayPat()
        {
            Con.Open();
            String Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            PDataDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        

        private void PAddBtn_Click(object sender, EventArgs e)
        {
            if (PIdTb.Text == "" || PNameTb.Text == "" ||PAddTb.Text == "" ||PPhoneTb.Text == ""|| PGenderCb.SelectedIndex == -1 || PCovidCb.SelectedIndex == -1)
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into PatientTbl(PatId,PatName,PatAdd,PatPhone,PatGen,PatCovid,PatDOB) values (@PI,@PN,@PP,@PA,@PG,@PC,@PD)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PI", PIdTb.Text);
                    cmd.Parameters.AddWithValue("@PN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PP", PPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@PA", PAddTb.Text);
                    cmd.Parameters.AddWithValue("@PG", PGenderCb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCovidCb.Text);
                    cmd.Parameters.AddWithValue("@PD", PDob.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient Added SuccessFUlly");
                    Con.Close();
                    DisplayPat();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

       

        private void PDeleteBtn_Click(object sender, EventArgs e)
        {
            if (PIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete PatientTbl where PatId=@PI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PI", PIdTb.Text);
                    cmd.Parameters.AddWithValue("@PN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PP", PPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@PA", PAddTb.Text);
                    cmd.Parameters.AddWithValue("@PG", PGenderCb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCovidCb.Text);
                    cmd.Parameters.AddWithValue("@PD", PDob.Value.Date);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayPat();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

       

        private void PUpdateBtn_Click(object sender, EventArgs e)
        {
            if (PIdTb.Text == "" || PNameTb.Text == "" || PAddTb.Text == "" || PPhoneTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update PatientTbl set PatName=@PN,PatPhone=@PP,PatAdd=@PA,PatGen=@PG,PatCovid=@PC,PatDOB=@PD where PatId=@PI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PI", PIdTb.Text);
                    cmd.Parameters.AddWithValue("@PN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PP", PPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@PA", PAddTb.Text);
                    cmd.Parameters.AddWithValue("@PG", PGenderCb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCovidCb.Text);
                    cmd.Parameters.AddWithValue("@PD", PDob.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update Patient info SuccessFUlly");
                    Con.Close();
                    DisplayPat();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        
        private void PSearchBtn_Click(object sender, EventArgs e)
        {
            if (PIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("select * from PatientTbl where PatId=@PI", Con);
                    cmd.Parameters.AddWithValue("@PI", PIdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    PDataDGV.DataSource = dt;
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PClearBtn_Click(object sender, EventArgs e)
        {
            PIdTb.Text = "";
            PNameTb.Text = "";
            PAddTb.Text = "";
            PPhoneTb.Text = "";
            PGenderCb.SelectedIndex = -1;
            PCovidCb.SelectedIndex = -1;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            /*
            Doctor dr = new Doctor();
            dr.Show();
            this.Close();
            */
        }

        private void label5_Click(object sender, EventArgs e)
        {
            /*
            LabTest lt = new LabTest();
            lt.Show();
            this.Hide();
            */
        }

        private void label4_Click(object sender, EventArgs e)
        {
            /*
            Reseptionist rp = new Reseptionist();
            rp.Show();
            this.Close();
            */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }
    }
}
