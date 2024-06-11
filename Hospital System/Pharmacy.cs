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
    public partial class Pharmacy : Form
    {
        public Pharmacy()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Pharmacy_Load(object sender, EventArgs e)
        {
            DateTime nd = DateTime.Now;
            lblDate.Text = nd.ToString("yyyy , MM , dd");

            GetOrders();
        }


        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            string qry1 = "Select * from pres where status = 'Pending' ";
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt1);

            FlowLayoutPanel p1;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //string x = Convert.ToString(dt1.Rows.Count);
                //MessageBox.Show(x);
                p1 = new FlowLayoutPanel();
                p1.AutoSize = true;
                p1.Width = 230;
                p1.Height = 350;
                p1.FlowDirection = FlowDirection.TopDown;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Margin = new Padding(10, 10, 10, 10);

                FlowLayoutPanel p2 = new FlowLayoutPanel();
                p2 = new FlowLayoutPanel();
                p2.BackColor = Color.FromArgb(50, 55, 89);
                p2.AutoSize = true;
                p2.Width = 230;
                p2.Height = 125;
                p2.FlowDirection = FlowDirection.TopDown;
                p2.Margin = new Padding(0, 0, 0, 0);

                Label lb1 = new Label();
                lb1.ForeColor = Color.White;
                lb1.Margin = new Padding(10, 10, 3, 0);
                lb1.AutoSize = true;

                Label lb2 = new Label();
                lb2.ForeColor = Color.White;
                lb2.Margin = new Padding(10, 5, 3, 0);
                lb2.AutoSize = true;

                /*Label lb3 = new Label();
                lb3.ForeColor = Color.White;
                lb3.Margin = new Padding(10, 5, 3, 0);
                lb3.AutoSize = true;

                Label lb4 = new Label();
                lb4.ForeColor = Color.White;
                lb4.Margin = new Padding(10, 5, 3, 0);
                lb4.AutoSize = true;*/

                lb1.Text = "Client Name : " + dt1.Rows[i]["cname"].ToString();
                lb2.Text = "Docter : " + dt1.Rows[i]["dname"].ToString();
                //lb3.Text = "Table : " + dt1.Rows[i].ToString();
                //lb4.Text = "Table : " + dt1.Rows[i].ToString();

                p2.Controls.Add(lb1);
                p2.Controls.Add(lb2);
                p1.Controls.Add(p2);

                Label lb5 = new Label();
                lb5.ForeColor = Color.Black;
                lb5.Margin = new Padding(10, 10, 3, 0);
                lb5.AutoSize = true;

                Label lb6 = new Label();
                lb6.ForeColor = Color.Black;
                lb6.Margin = new Padding(10, 10, 3, 0);
                lb6.AutoSize = true;

                Label lb7 = new Label();
                lb7.ForeColor = Color.Black;
                lb7.Margin = new Padding(10,10,3,0);
                lb7.AutoSize = true;

                lb5.Text = "Client Tel : " + dt1.Rows[i]["tel"].ToString();
                lb6.Text = "Client mail : " + dt1.Rows[i]["email"].ToString();
                lb7.Text = "Prescription : " + dt1.Rows[i]["pre"].ToString();

                p1.Controls.Add(lb5);
                p1.Controls.Add(lb6);
                p1.Controls.Add(lb7);

                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.AutoRoundedCorners = true;
                b.Size = new Size(100, 35);
                b.FillColor = Color.FromArgb(241, 85, 126);
                b.Margin = new Padding(30, 5, 3, 10);
                b.Text = "Complete Checking";
                b.Tag = dt1.Rows[i]["tel"].ToString();

                b.Click += new EventHandler(b_click);
                p1.Controls.Add(b);


                flowLayoutPanel1.Controls.Add(p1);

            }
        }
        private void b_click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());
            
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            
            if (guna2MessageDialog1.Show("Are you sure you want to complete order?") == DialogResult.Yes)
            {
                string qry3 = "Update hchannel set status = 'Complete Medicine' where ctel = @ID";
                string qry5 = "Update pres set status = 'Complete' where tel = '"+id+"'";
                Hashtable ht = new Hashtable();
                Hashtable ht1 = new Hashtable();
                ht.Add("@ID", id);
                MainClass.SQl(qry5,ht1);

               
                


                if (MainClass.SQl(qry3, ht) > 0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Complete Check Successfull");
                }
               
                GetOrders();
            }
        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Clear();
            //GetOrders();
        }
    }
}
