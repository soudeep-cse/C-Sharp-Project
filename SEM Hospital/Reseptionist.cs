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
using System.Configuration;

namespace SEM_Hospital
{
    public partial class Reseptionist : Form
    {
        public Reseptionist()
        {
            InitializeComponent();
            DisplayRec();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\88016\OneDrive\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayRec()
        {
            Con.Open();
            String Query = "select * from ReceptionistTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            ReceptionistDGV.DataSource = rt.Tables[0];
            Con.Close();
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (RIdTb.Text == "" || RNameTb.Text == "" || RPasswordTb.Text == "" || RPhoneTb.Text == "" || RAddressTb.Text == "" || GenderCB.SelectedIndex==-1)
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into ReceptionistTbl(RecepId,RecepName,RecepPhone,RecepAdd,RecepPass,RecepGen) values (@RI,@RN,@RP,@RA,@RPA,@RG)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@RI", RIdTb.Text);
                    cmd.Parameters.AddWithValue("@RN", RNameTb.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPasswordTb.Text);
                    cmd.Parameters.AddWithValue("@RG", GenderCB.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Receptionist Added SuccessFUlly");
                    Con.Close();
                    DisplayRec();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (RIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete ReceptionistTbl where RecepId=@RI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@RI", RIdTb.Text);
                    cmd.Parameters.AddWithValue("@RN", RNameTb.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPasswordTb.Text);
                    cmd.Parameters.AddWithValue("@RG", GenderCB.Text);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayRec();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (RIdTb.Text == "" || RNameTb.Text == "" || RPasswordTb.Text == "" || RPhoneTb.Text == "" || RAddressTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update ReceptionistTbl set RecepName=@RN,RecepPhone=@RP,RecepAdd=@RA,RecepPass=@RPA,RecepGen=@RG where RecepId=@RI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@RI", RIdTb.Text);
                    cmd.Parameters.AddWithValue("@RN", RNameTb.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPasswordTb.Text);
                    cmd.Parameters.AddWithValue("@RG", GenderCB.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update receptionist info SuccessFUlly");
                    Con.Close();
                    DisplayRec();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (RIdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide id information");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("select * from ReceptionistTbl where RecepId=@RI", Con);
                    cmd.Parameters.AddWithValue("@RI", RIdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ReceptionistDGV.DataSource = dt;
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ReceptionistDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RClearbtn_Click(object sender, EventArgs e)
        {
            RIdTb.Text = "";
            RPhoneTb.Text = "";
            RNameTb.Text = "";
            RPasswordTb.Text = "";
            RAddressTb.Text = "";
            GenderCB.SelectedIndex = -1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }
    }
}
