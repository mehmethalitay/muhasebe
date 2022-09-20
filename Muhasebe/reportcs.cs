using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.Reporting.WinForms;

namespace Muhasebe
{
    public partial class reportcs : Form
    {
        public reportcs()
        {
            InitializeComponent();
        }

        cnstr cnstr1 = new cnstr();

        
          
        private void reportcs_Load(object sender, EventArgs e)
        {
            


            this.reportViewer1.RefreshReport();
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.ReportPath =
                (Application.StartupPath + "\\App_Data\\msbdb.sqlite;");

            DataTable tbl = new DataTable();
            SQLiteDataAdapter dt = new SQLiteDataAdapter("SELECT * FROM CariEkle", cnstr1.baglan());
            
            dt.Fill(tbl);
            ReportDataSource rds = new ReportDataSource("DataSet1", tbl);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();


        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0:#,##0.00}", double.Parse(textBox1.Text));

        }
    }
}
