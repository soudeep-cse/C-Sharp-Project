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
    public partial class LabTest : Form
    {
        public LabTest()
        {
            InitializeComponent();
            DisplayLab();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void LabTest_Load(object sender, EventArgs e)
        {

        }

        private void DisplayLab()
        {
            Con.Open();
            String Query = "select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            LabTestDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void LAddBtn_Click(object sender, EventArgs e)
        {
            if (LTestIdTb.Text == "" || LNameTb.Text == "" || LCostTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into TestTbl(TestNum,TestName,TestCost) values (@TI,@TN,@TC)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@TI", LTestIdTb.Text);
                    cmd.Parameters.AddWithValue("@TN", LNameTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LCostTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Labtest Added SuccessFUlly");
                    Con.Close();
                    DisplayLab();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void LDeleteBtn_Click(object sender, EventArgs e)
        {
            if (LTestIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete TestTbl where TestNum=@TI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@TI", LTestIdTb.Text);
                    cmd.Parameters.AddWithValue("@TN", LNameTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LCostTb.Text);



                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayLab();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void LUpdateBtn_Click(object sender, EventArgs e)
        {
            if (LTestIdTb.Text == "" || LNameTb.Text == "" || LCostTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update TestTbl set TestName=@TN,TestCost=@TC where TestNum=@TI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@TI", LTestIdTb.Text);
                    cmd.Parameters.AddWithValue("@TN", LNameTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LCostTb.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update Labtest info SuccessFUlly");
                    Con.Close();
                    DisplayLab();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void LSearchBtn_Click(object sender, EventArgs e)
        {
            if (LTestIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("select * from TestTbl where TestNum=@TI", Con);
                    cmd.Parameters.AddWithValue("@TI", LTestIdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    LabTestDGV.DataSource = dt;
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void LClearTb_Click(object sender, EventArgs e)
        {
            LTestIdTb.Text = "";
            LNameTb.Text = "";
            LCostTb.Text = "";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Doctor dr = new Doctor();
            dr.Show();
            this.Hide();
        }
    }
}
