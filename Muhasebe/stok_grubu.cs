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
using System.Data;

namespace Muhasebe
{
    public partial class stok_grubu : Form
    {
        public stok_grubu()
        {
            InitializeComponent();
        }
        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        SQLiteDataAdapter da;
        DataSet ds;
        string id;
        int yenisayi, kayitsayisi;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void stok_grubu_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

            yenile();

        }

        void alantemizle()
        {
            richTextBox1.Text = "";
        }

        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from stokgrubu", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "stokgrubu");
                dataGridView1.DataSource = ds.Tables["stokgrubu"];
                alantemizle();
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into stokgrubu (StokGrubAdi)" +
                     "values (@stokadi)", cnstr1.baglan());

                komut.Parameters.AddWithValue("@stokadi", richTextBox1.Text);
                komut.ExecuteNonQuery();
                yenile();

            }
            catch (Exception hata)
            {
                cnstr1.mesaj("Aynı stok grubundan vardır !");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili stok grubunu silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from StokGrubu where id=@id ", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    yenile();
                    yenisayi = dataGridView1.RowCount;

                    if (kayitsayisi != yenisayi)
                    {
                        MessageBox.Show("Seçili stok grubu başarılı bir şekilde silinmiştir !", "STOK GRUBU SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Seçili stok grubu silinmedi !", "STOK GRUBU SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }
        }
    }
}

        
