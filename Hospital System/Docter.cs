using System;
using System.Collections;
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
    public partial class Docter : Form
    {
        public Docter()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Docter_Load(object sender, EventArgs e)
        {
            lbldname.Text = MainClass.userName;
            DateTime nd = DateTime.Now;
            lblDate.Text = nd.ToString("yyyy , MM , dd");

            loadProductsFromDatabase();
        }
        private void loadProductsFromDatabase()
        {
            string qry = "Select * from hchannel where status = 'Pending' and cdate = '" + txtdate.Text + "' and docname = '" + lbldname.Text + "' ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AddItems("0", row["id"].ToString(), row["cname"].ToString(), row["ctel"].ToString(), row["cmail"].ToString(), row["docname"].ToString(), row["cdate"].ToString(), row["status"].ToString());
                    //AddItems("0", row["vahicalno"].ToString(), Image.FromStream(new MemoryStream(imageArray)), row["brand"].ToString(), row["name"].ToString(), row["type"].ToString(), row["price"].ToString());
                }
            }
        }
       
        public void AddItems(string iid, string id, string cname, string ctel, string cmail, string docname, string cdate, string status)
        {
            var w = new channel()
            {
                Cname = cname,
                Ctel = ctel,
                Cmail = cmail,
                Docname = docname,
                Cdate = cdate,
                Status = status,
                id = Convert.ToInt32(id),

            };
            flowLayoutPanel1.Controls.Add(w);


            w.onSelect += (ss, ee) =>
            {
                var wdg = (channel)ss;
                //MessageBox.Show("Add");

                Prescription rd = new Prescription();
                rd.lblcname.Text = wdg.Cname;
                rd.lbltel.Text = wdg.Ctel;
                rd.lblemail.Text = wdg.Cmail;
                rd.lbldname.Text = wdg.Docname;
                
                
                MainClass.BlurBackground(rd);


            };
        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            loadProductsFromDatabase();
        }
        
    }
}
