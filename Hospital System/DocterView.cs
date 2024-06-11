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
    public partial class DocterView : Form
    {
        public DocterView()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DocterView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DocterAdd da = new DocterAdd();
            da.Show();
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From docinserts where name like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvspecial);
            lb.Items.Add(dgvtel);
            lb.Items.Add(dgvemail);
            lb.Items.Add(dgvuname);
            lb.Items.Add(dgvpassword);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete From docinserts where id = '" + id1 + "' ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Docter Detete Successfull");
                    GetData();
                }
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Delete
            {

                DocterAdd da = new DocterAdd();

                String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                da.txtSpecial.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvspecial"].Value);
                da.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                da.txtTel.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvtel"].Value);
                da.txtEmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvemail"].Value);
                da.txtUname.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvuname"].Value);
                da.txtPassword.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvpassword"].Value);


                string qry = "Delete From docinserts where id = '" + id1 + "' ";
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);
                MainClass.BlurBackground(da);
                GetData();
            }
        }
    }
}
