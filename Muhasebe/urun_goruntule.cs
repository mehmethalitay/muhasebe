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
    public partial class urun_goruntule : Form
    {
        public urun_goruntule()
        {
            InitializeComponent();
        }

        string id;
        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        SQLiteDataAdapter da;
        DataSet ds;
        string tarih = "5/1/2008 8:30:52 AM";


        private void groupBox2_Enter(object sender, EventArgs e)
        {


        }
        int kayitsayisi;
        int yenisayi;
        private void urun_goruntule_Load(object sender, EventArgs e)
        {

            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

            yenile();
            kayitsayisi = dataGridView1.RowCount;
            yenisayi = kayitsayisi;
            timer1.Start();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            SQLiteCommand komut = new SQLiteCommand("select * from StokGrubu", cnstr1.baglan());
            SQLiteCommand komut1 = new SQLiteCommand("select * from StokBirimGrubu", cnstr1.baglan());
            SQLiteDataReader dr = komut.ExecuteReader();
            SQLiteDataReader dr1 = komut1.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["StokGrubAdi"].ToString());
            }

            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["StokBirimGrubAdi"].ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from Urun", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "Urun");
                dataGridView1.DataSource = ds.Tables["Urun"];
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
            richTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili cariyi silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from Urun where id=@id ", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    yenile();
                    yenisayi = dataGridView1.RowCount;

                    if (kayitsayisi != yenisayi)
                    {
                        MessageBox.Show("Seçili ürün başarılı bir şekilde silinmiştir !", "ÜRÜN SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Seçili ürün silinmedi !", "ÜRÜN SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                kayitsayisi = dataGridView1.RowCount;
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
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili ürünü güncelemek istediğinizden emin misiniz ?", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("update Urun set Barkod = @barkod, UrunAdi = @urunadi, UrunGrubu =@urungrubu, UrunBirim = @urunbirim, Fiyat = @fiyat," +
                    "Maliyet = @maliyet, Stok = @stok where id = @id", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                    komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text);
                    komut.Parameters.AddWithValue("@fiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@maliyet", richTextBox3.Text);
                    komut.Parameters.AddWithValue("@stok", richTextBox5.Text);
                    komut.Parameters.AddWithValue("@id", id);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Seçili ürün başarı ile güncellenmiştir !", "ÜRÜN GÜNCELLEME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());

            }

            yenile();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            richTextBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();



        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                da = new SQLiteDataAdapter("select * from Urun where UrunKodu like '" + richTextBox6.Text + "%'", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "Urun");
                dataGridView1.DataSource = ds.Tables["Urun"];
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            

        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToLongTimeString();


            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void urun_goruntule_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

