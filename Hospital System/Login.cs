using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlDataAdapter da;
        SqlCommand cmd;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("SELECT * FROM mem_log WHERE uname = '" + txtUname.Text + "' AND password = '" + txtPassword.Text + "'", MainClass.con);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                if (ds.Tables[0].Rows.Count == 1)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[3].ToString() == "Admin")
                    {
                        MainClass.userName = dr[1].ToString();
                        MainClass.con.Close();
                        Admin fmain = new Admin();
                        fmain.Show();
                        this.Hide();
                    }
                    else if (dr[3].ToString() == "Pharmacy")
                    {
                        MainClass.userName = dr[1].ToString();
                        MainClass.con.Close();
                        Pharmacy md = new Pharmacy();
                        md.Show();
                        this.Hide();
                    }
                    else if (dr[3].ToString() == "Docter")
                    {
                        MainClass.userName = dr[1].ToString();
                        MainClass.con.Close();
                        Docter kd = new Docter();
                        kd.Show();
                        this.Hide();
                    }
                }

                else
                {
                    guna2MessageDialog1.Show("Invalid Username or Password");
                    return;

                }
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in ligin process" + ex);
                return;
            }
            finally
            {
                MainClass.con.Close();
            }
        }
    }
}
