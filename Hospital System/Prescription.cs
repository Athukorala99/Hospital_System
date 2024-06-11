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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public int id = 0;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DateTime nd = DateTime.Now;
            string ndt = nd.ToString("yyyy , MM , dd");

            string qry = "";

            if (id == 0)//Insert
            {

                qry = "INSERT INTO pres  Values (@cname , @email , @tel , @dname , @pre , @date , @status )";

            }
            else//Update
            {
                qry = "Update pres Set ( cname = @cname, email = @email , tel = @tel , dname = @dname , pre = @pre , date = @date , status = @status where id = @id)";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@cname", lblcname.Text);
            ht.Add("@email", lblemail.Text);
            ht.Add("@tel", lbltel.Text);
            ht.Add("@dname", lbldname.Text);
            ht.Add("@pre", txtpres.Text);
            ht.Add("@date", txtpres.Text);
            ht.Add("@status", "Pending");


            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Prescription Send Successfully...");
                id = 0;
                lblcname.Focus();
            }
            string stat = "Send Pharmacy";
            string qry1 = "UPDATE hchannel set status = '"+ stat + "' where ctel = '"+lbltel.Text+"'";
            Hashtable ht1 = new Hashtable();
            MainClass.SQl(qry1,ht1);
            this.Hide();
        }

        private void Prescription_Load(object sender, EventArgs e)
        {

        }
    }
}
