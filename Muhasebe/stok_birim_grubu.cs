using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace Muhasebe
{
    public partial class stok_birim_grubu : Form
    {
        public stok_birim_grubu()
        {
            InitializeComponent();
        }

        SQLiteDataAdapter da;
        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        DataSet ds;
        string id;
        int yenisayi, kayitsayisi;
        private void stok_birim_grubu_Load(object sender, EventArgs e)
        {

            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);
            yenile();
        }
        void alantemizle()
        {
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from StokBirimGrubu", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "StokBirimGrubu");
                dataGridView1.DataSource = ds.Tables["StokBirimGrubu"];
                alantemizle();
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into StokBirimGrubu (StokBirimGrubAdi)" +
                     "values (@stokbirimgurubadi)", cnstr1.baglan());

                komut.Parameters.AddWithValue("@stokbirimgurubadi", richTextBox1.Text);
                komut.ExecuteNonQuery();
                yenile();

            }
            catch (Exception)
            {
                cnstr1.mesaj("Aynı stok birim grubundan vardır !");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili Gider Grubunu silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from StokBirimGrubu where id=@id ", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    yenile();
                    yenisayi = dataGridView1.RowCount;

                    if (kayitsayisi != yenisayi)
                    {
                        MessageBox.Show("Seçili stok birim grubu başarılı bir şekilde silinmiştir !", "STOK BİRİM GRUBU SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Seçili stok birim grubu silinmedi !", "STOK BİRİM GRUBU SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
