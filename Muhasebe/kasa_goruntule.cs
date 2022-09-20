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

namespace Muhasebe
{
    public partial class kasa_goruntule : Form
    {
        public kasa_goruntule()
        {
            InitializeComponent();
        }
        string id;
        SQLiteDataAdapter da;
        DataSet ds;
        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        private void kasa_Load(object sender, EventArgs e)
        {

            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

            da = new SQLiteDataAdapter("Select * From Faturalar", cnstr1.baglan());
            ds = new DataSet();
            da.Fill(ds, "Faturalar");
            dataGridView1.DataSource = ds.Tables["Faturalar"];



            dataGridView1.Columns[0].HeaderText = "İD";
            dataGridView1.Columns[1].HeaderText = "MÜŞTERİ İD";
            dataGridView1.Columns[2].HeaderText = "AD SOYAD";
            dataGridView1.Columns[3].HeaderText = "ÜRÜN KODU";
            dataGridView1.Columns[4].HeaderText = "ÜRÜN GRUBU";
            dataGridView1.Columns[5].HeaderText = "ÜRÜN BİRİMİ";
            dataGridView1.Columns[6].HeaderText = "ÜRÜN SAYISI";
            dataGridView1.Columns[7].HeaderText = "FİYAT";
            dataGridView1.Columns[8].HeaderText = "ÜRÜN KDV";
            dataGridView1.Columns[9].HeaderText = "ÜRÜN İSK";
            dataGridView1.Columns[10].HeaderText = "ÜR. SATIŞ F.";
            dataGridView1.Columns[11].HeaderText = "TARİH";
            dataGridView1.Columns[12].HeaderText = "TOPLAM FİYAT";
            dataGridView1.Columns[13].HeaderText = "TOPLAM ALINAN";
            dataGridView1.Columns[11].HeaderText = "BAKİYE";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            da = new SQLiteDataAdapter("SELECT id, musteriId, UrunKodu, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Topfiyat, Alinan, Bakiye FROM Faturalar Where Tarih BETWEEN @tar1 and @tar2", cnstr1.baglan());
            ds = new DataSet();
            da.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            da.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            da.Fill(ds, "Faturalar");
            dataGridView1.DataSource = ds.Tables["Faturalar"];

        }
    }
}
