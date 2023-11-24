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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            DisplayDoc();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");


       
        private void Doctor_Load(object sender, EventArgs e)
        {

        }

      
        private void DisplayDoc()
        {
            Con.Open();
            String Query = "select * from DoctorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            DDataDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void DAddBtn_Click(object sender, EventArgs e)
        {
            if (DIdTb.Text == "" || DNameTb.Text == "" || DPassTb.Text == "" || DPhoneTb.Text == "" || DAddressTb.Text == ""||DExperienceTb.Text==""||DGenderCb.SelectedIndex==-1||DSpecialistCb.SelectedIndex==-1)
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into DoctorTbl(DocId,DocName,DOCPHONE,DocAdd,DocPass,DocExp,DocGen,DOCSPEC,DocJoin) values (@DI,@DN,@DP,@DA,@DPA,@DE,@DG,@DS,@DJ)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", DIdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@DA", DAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DPA", DPassTb.Text);
                    cmd.Parameters.AddWithValue("@DE", DExperienceTb.Text);
                    cmd.Parameters.AddWithValue("@DG", DGenderCb.Text);
                    cmd.Parameters.AddWithValue("@DS", DSpecialistCb.Text);
                    cmd.Parameters.AddWithValue("@DJ", DJoinTP.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Doctor Added SuccessFUlly");
                    Con.Close();
                    DisplayDoc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DDeleteBtn_Click(object sender, EventArgs e)
        {
            if (DIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete DoctorTbl where DocId=@DI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", DIdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DPassTb.Text);
                    cmd.Parameters.AddWithValue("@DA", DAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DPA", DPassTb.Text);
                    cmd.Parameters.AddWithValue("@DE", DExperienceTb.Text);
                    cmd.Parameters.AddWithValue("@DG", DGenderCb.Text);
                    cmd.Parameters.AddWithValue("@DS", DSpecialistCb.Text);
                    cmd.Parameters.AddWithValue("@DJ", DJoinTP.Value.Date);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayDoc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DUpdateBtn_Click(object sender, EventArgs e)
        {
            if (DIdTb.Text == "" || DNameTb.Text == "" || DPassTb.Text == "" || DPhoneTb.Text == "" || DAddressTb.Text == "" || DExperienceTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update DoctorTbl set DocName=@DN,DOCPHONE=@DP,DocAdd=@DA,DocPass=@DPA,DocExp=@DE,DocGen=@DG,DOCSPEC=@DS,DocJoin=@DJ where DocId=@DI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", DIdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DPassTb.Text);
                    cmd.Parameters.AddWithValue("@DA", DAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DPA", DPassTb.Text);
                    cmd.Parameters.AddWithValue("@DE", DExperienceTb.Text);
                    cmd.Parameters.AddWithValue("@DG", DGenderCb.Text);
                    cmd.Parameters.AddWithValue("@DS", DSpecialistCb.Text);
                    cmd.Parameters.AddWithValue("@DJ", DJoinTP.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update Doctor info SuccessFUlly");
                    Con.Close();
                    DisplayDoc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DSearchBtn_Click(object sender, EventArgs e)
        {
            if (DIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("select * from DoctorTbl where DocId=@DI", Con);
                    cmd.Parameters.AddWithValue("@DI", DIdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DDataDGV.DataSource = dt;
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void DClearbtn_Click(object sender, EventArgs e)
        {
            DIdTb.Text = "";
            DNameTb.Text = "";
            DExperienceTb.Text = "";
            DAddressTb.Text = "";
            DPhoneTb.Text = "";
            DPassTb.Text = "";
            DGenderCb.SelectedIndex = -1;
            DSpecialistCb.SelectedIndex = -1;
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
    }
}
