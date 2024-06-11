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
    public partial class DocterAdd : Form
    {
        public DocterAdd()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cl();
        }
        public void cl()
        {
            txtName.Clear();
            txtSpecial.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            txtUname.Clear();
            txtPassword.Clear();

            txtName.PlaceholderText = "Name";
            txtEmail.PlaceholderText = "Email";
            txtPassword.PlaceholderText = "Password";
            txtSpecial.PlaceholderText = "Special";
            txtTel.PlaceholderText = "Tel";
            txtUname.PlaceholderText = "User Name";
        }
        public int id = 0;
        public int id1 = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)//Insert
            {

                qry = "INSERT INTO docinserts  Values (@name , @special , @tel , @email , @uname , @pass)";

            }
            else//Update
            {
                qry = "Update docinserts Set ( name = @name, special = @special , tel = @tel , email = @email , uname = @uname , pass = @pass  where id = @id)";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@name", txtName.Text);
            ht.Add("@special", txtSpecial.Text);
            ht.Add("@tel", txtTel.Text);
            ht.Add("@email", txtEmail.Text);
            ht.Add("@uname", txtUname.Text);
            ht.Add("@pass", txtPassword.Text);

            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Doctor Details Saved Successfully...");
                id = 0;
                txtName.Focus();
            }
            string qry1 = "";

            if (id1 == 0)//Insert
            {

                qry1 = "INSERT INTO mem_log  Values ( @uname , @password , @position)";

            }
            else//Update
            {
                qry1 = "Update mem_log Set ( uname = @uname , password = @password , position = @position where id = @id)";
            }

            Hashtable ht1 = new Hashtable();
            ht1.Add("@id", id1);
            ht1.Add("@uname", txtUname.Text);
            ht1.Add("@password", txtPassword.Text);
            ht1.Add("@position", "Docter");

            if (MainClass.SQl(qry1, ht1) > 0)
            {
                //guna2MessageDialog1.Show("Doctor Details Saved Successfully...");
                id = 0;
                cl();
                txtName.Focus();
            }
        }
    }
}
