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
    public partial class channel : UserControl
    {
        public channel()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;
        public int id { get; set; }
        public string Cname 
        {
            get {return lblcname.Text; }
            set {lblcname.Text = value; } 
        }
        public string Ctel 
        {
            get { return lblctel.Text; }
            set { lblctel.Text = value; } 
        }
        public string Cmail 
        { 
            get { return lblcmail.Text; }
            set { lblcmail.Text = value; } 
        }
        public string Docname { get; set; }
        public string Cdate 
        { 
            get { return lblcdate.Text; }
            set { lblcdate.Text = value; } 
        }
        public string Status { get; set; }
        private void lblPName_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);

        }

        private void channel_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);

        }

        private void lblQty_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);

        }

        private void lblctel_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
