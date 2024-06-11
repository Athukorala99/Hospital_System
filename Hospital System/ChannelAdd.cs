using System;
using System.Collections;
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
    public partial class ChannelAdd : Form
    {
        public ChannelAdd()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void cl()
        {
            txtcmail.Clear();
            txtcname.Clear();
            txtctel.Clear();
            txtcmail.PlaceholderText = "Client Email";
            txtcname.PlaceholderText = "Client Name";
            txtctel.PlaceholderText = "Client Tel";

            DateTime nd = DateTime.Now;
            txtdate.Text = nd.ToString("yyyy , MM , dd");
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            cl();
        }
        public int id = 0;
        public int did = 0;
        private void ChannelAdd_Load(object sender, EventArgs e)
        {
            string qry = "SELECT name 'name' FROM docinserts";
            MainClass.CBFill(qry , cmbdoc);
            if (did > 0)
            {
                cmbdoc.SelectedValue = did;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sta = "Pending";
            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO hchannel VALUES (@cname , @ctel , @cmail , @docname , @cdate , @status)";
            }
            else
            {
                qry = "UPDATE hchannel SET ( cname = @cname , ctel = @ctel , cmail = @cmail , docname = @docname , cdate = @cdate , status = @status WHERE id = @id)";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@cname",txtcname.Text);
            ht.Add("@ctel",txtctel.Text);
            ht.Add("@cmail",txtcmail.Text);
            ht.Add("@docname",cmbdoc.Text);
            ht.Add("@cdate",txtdate.Text);
            ht.Add("@status",sta);

            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Channel Details Saved Successfully...");
                id = 0;
                txtcname.Focus();
            }
        }
    }
}
