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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static Admin _obj;
        public static Admin Instance
        {
            get { if (_obj == null) { _obj = new Admin(); } return _obj; }
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            DateTime nd = DateTime.Now;
            lblDate.Text = nd.ToString("yyyy , MM , dd");

            MainClass.con.Open();

            string qry1 = "Select Count(*) From docinserts ";
            SqlCommand cmd1 = new SqlCommand(qry1,MainClass.con);
            lblcdoc.Text = (cmd1.ExecuteScalar()).ToString();

            string qry2 = "Select Count(*) From hchannel where status = 'Pending' ";
            SqlCommand cmd2 = new SqlCommand(qry2,MainClass.con);
            lblchanc.Text = (cmd2.ExecuteScalar()).ToString();

            string qry3 = "Select Count(*) From pres where status = 'Pending' ";
            SqlCommand cmd3 = new SqlCommand(qry3,MainClass.con);
            lblphc.Text = (cmd3.ExecuteScalar()).ToString();

            MainClass.con.Close();
        }
        public void rel()
        {
            DateTime nd = DateTime.Now; 
            lblDate.Text = nd.ToString("yyyy , MM , dd"); 
            
            MainClass.con.Open(); 
            string qry1 = "Select Count(*) From docinserts "; 
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            lblcdoc.Text = (cmd1.ExecuteScalar()).ToString();

            string qry2 = "Select Count(*) From hchannel where status = 'Pending' "; 
            SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con); 
            lblchanc.Text = (cmd2.ExecuteScalar()).ToString();

            string qry3 = "Select Count(*) From pres where status = 'Pending' ";           
            SqlCommand cmd3 = new SqlCommand(qry3, MainClass.con); 
            lblphc.Text = (cmd3.ExecuteScalar()).ToString();
            MainClass.con.Close();

        }
        private void guna2Panel1_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new DocterView());
            rel();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new DocterView());
            rel();
        }

        private void guna2PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new DocterView());
            rel();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new DocterView());
            rel();
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new ChannelView());
            rel();
        }

        private void guna2PictureBox2_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new ChannelView());
            rel();
        }

        private void lblchanc_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new ChannelView());
            rel();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new ChannelView());
            rel();
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new PharmacyView());
            rel();
        }

        private void guna2PictureBox3_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new PharmacyView());
            rel();
        }

        private void lblphc_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new PharmacyView());
            rel();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_DoubleClick(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new PharmacyView());
            rel();
        }
    }
}
