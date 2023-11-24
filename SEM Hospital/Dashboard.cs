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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            if (LogIn.User == "Receptionist")
            {
                MessageBox.Show("LogIn as Receptionist");
                PrescriptionLbl.Enabled = false;
                DoctorLbl.Enabled = false;
                LabTestLbl.Enabled = false;
                ReceptionistLbl.Enabled = false;
            }
            else if (LogIn.User == "Nurse")
            {
                MessageBox.Show("LogIn as Nurse");
                PatientLbl.Enabled = false;
                DoctorLbl.Enabled = false;
                LabTestLbl.Enabled = false;
                ReceptionistLbl.Enabled = false;
            }

            CountPatient();
            CountDoctor();
            CountLabTest();
            CountCovidPatient();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void CountPatient()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from PatientTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
          private void CountDoctor()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from DoctorTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
           private void CountLabTest()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from TestTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            LabLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }      
        private void CountCovidPatient()
        {
            string Status = "Positive";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from PatientTbl where PatCovid='"+Status+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CovidLvl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Doctor dc = new Doctor();
            dc.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PatientLbl_Click(object sender, EventArgs e)
        {
            Patient pt = new Patient();
            pt.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void PrescriptionLbl_Click(object sender, EventArgs e)
        {
            Prescription pr = new Prescription();
            pr.Show();
            this.Hide();
        }

        private void LabTestLbl_Click(object sender, EventArgs e)
        {
            LabTest lb = new LabTest();
            lb.Show();
            this.Hide();
        }

        private void ReceptionistLbl_Click(object sender, EventArgs e)
        {
            Reseptionist rp = new Reseptionist();
            rp.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
