using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Muhasebe
{
    public partial class gider_ekle : Form
    {
        public gider_ekle()
        {
            InitializeComponent();
        }

        rszfnt rz = new rszfnt();

        private void gider_ekle_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);
        }
        void alantemizle()
        {
            richTextBox1.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

