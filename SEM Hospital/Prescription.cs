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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
            DisplayPres();
            GetDocId();
            GetPatId();
            GetTestId();
            GetDocName();
            GetPatName();
            GetTestName();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayPres()
        {
            Con.Open();
            String Query = "select * from PrescriptionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            PrescriptionDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void GetDocName()
        {
            Con.Open();
            string Query="select * from DoctorTbl where DocId= "+DocIdCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(Query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow d in dt.Rows)
            {
                DocNameTb.Text = d["DocName"].ToString();
            }

            Con.Close();
        }

         private void GetPatName()
        {
            Con.Open();
            string Query="select * from PatientTbl where PatId= "+PatIdCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(Query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow d in dt.Rows)
            {
                PatNameTb.Text = d["PatName"].ToString();
            }

            Con.Close();
        }

           private void GetTestName()
        {
            Con.Open();
            string Query="select * from TestTbl where TestNum= "+TestCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(Query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow d in dt.Rows)
            {
                TestNameTb.Text = d["TestName"].ToString();
                CostTb.Text = d["TestCost"].ToString();
            }

            Con.Close();
        }


        private void GetDocId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DocId from DoctorTbl",Con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocId",typeof(int));
            dt.Load(sdr);
            DocIdCb.ValueMember = "DocId";
            DocIdCb.DataSource = dt;
            Con.Close();
        }

          private void GetPatId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatId from PatientTbl",Con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatId",typeof(int));
            dt.Load(sdr);
            PatIdCb.ValueMember = "PatId";
            PatIdCb.DataSource = dt;
            Con.Close();
        }

          private void GetTestId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TestNum from TestTbl",Con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestNum",typeof(int));
            dt.Load(sdr);
           TestCb.ValueMember = "TestNum";
           TestCb.DataSource = dt;
            Con.Close();
        }

        private void DocIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDocName();
        }

        private void PatIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPatName();
        }

        private void TestCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTestName();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PrescriptionTb.Text==""||DocNameTb.Text == "" || PatNameTb.Text == "" || TestNameTb.Text == ""||MedicineTb.Text=="")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into PrescriptionTbl(PrescId,DocId,DocName,PatId,PatName,LabTestId,LabTestName,Medicines,Cost) values (@PRI,@DI,@DN,@PI,@PN,@TI,@TN,@M,@C)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PRI", PrescriptionTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DocIdCb.Text);
                    cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                    cmd.Parameters.AddWithValue("@PI", PatIdCb.Text);
                    cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                    cmd.Parameters.AddWithValue("@TI", TestCb.Text);
                    cmd.Parameters.AddWithValue("@TN", TestNameTb.Text);
                    cmd.Parameters.AddWithValue("@M", MedicineTb.Text);
                    cmd.Parameters.AddWithValue("@C", CostTb.Text);
                    

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Priscription Added SuccessFUlly");
                    Con.Close();
                    DisplayPres();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

       
        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (PrescriptionTb.Text=="")
            {
                MessageBox.Show("Sorry!!Provide id ....");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete PrescriptionTbl where PrescId=@PRI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PRI", PrescriptionTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DocIdCb.Text);
                    cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                    cmd.Parameters.AddWithValue("@PI", PatIdCb.Text);
                    cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                    cmd.Parameters.AddWithValue("@TI", TestCb.Text);
                    cmd.Parameters.AddWithValue("@TN", TestNameTb.Text);
                    cmd.Parameters.AddWithValue("@M", MedicineTb.Text);
                    cmd.Parameters.AddWithValue("@C", CostTb.Text);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayPres();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TestNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void TestCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Prescription_Load(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PrescriptionTb.Text == "" || DocNameTb.Text == "" || PatNameTb.Text == "" || TestNameTb.Text == "" || MedicineTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update PrescriptionTbl set DocId=@DI,DocName=@DN,PatId=@PI,PatName=@PN,LabTestId=@TI,LabTestName=@TN,Medicines=@M,Cost=@C where PrescId=@PRI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@PRI", PrescriptionTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DocIdCb.Text);
                    cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                    cmd.Parameters.AddWithValue("@PI", PatIdCb.Text);
                    cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                    cmd.Parameters.AddWithValue("@TI", TestCb.Text);
                    cmd.Parameters.AddWithValue("@TN", TestNameTb.Text);
                    cmd.Parameters.AddWithValue("@M", MedicineTb.Text);
                    cmd.Parameters.AddWithValue("@C", CostTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update Doctor info SuccessFUlly");
                    Con.Close();
                    DisplayPres();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (PrescriptionTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id.....");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("select * from PrescriptionTbl where PrescId=@PI", Con);
                    cmd.Parameters.AddWithValue("@PI", PrescriptionTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    PrescriptionDGV.DataSource = dt;
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            PrescriptionTb.Text = "";
            DocIdCb.Text = "";
            PatIdCb.Text = "";
            TestCb.Text = "";
            DocNameTb.Text = "";
            PatNameTb.Text = "";
            TestNameTb.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            this.Close();
        }
    }
}
