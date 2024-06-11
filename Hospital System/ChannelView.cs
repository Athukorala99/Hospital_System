using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_System
{
    public partial class ChannelView : Form
    {
        public ChannelView()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ChannelView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From hchannel where cname like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvtel);
            lb.Items.Add(dgvmail);
            lb.Items.Add(dgvdname);
            lb.Items.Add(dgvdate);
            lb.Items.Add(dgvstatus);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ChannelAdd ca = new ChannelAdd();
            ca.Show();
            GetData();
        }
    }
}
