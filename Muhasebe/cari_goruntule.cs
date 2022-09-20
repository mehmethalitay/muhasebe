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
    public partial class cari_goruntule : Form
    {
        public cari_goruntule()
        {
            InitializeComponent();
        }
        string id;
        cnstr cnstr1 = new cnstr();
        SQLiteDataAdapter da;
        DataSet ds;
        
        private void button1_Click(object sender, EventArgs e)
        {


            if (button1.Text=="Düzenle")
            {
                button1.Text = "Tamamla";
                richTextBox1.ReadOnly = false;
                richTextBox2.ReadOnly = false;
                richTextBox3.ReadOnly = false;
                richTextBox4.ReadOnly = false;
                richTextBox5.ReadOnly = false;
                richTextBox6.ReadOnly = false;
                richTextBox7.ReadOnly = false;
                richTextBox8.ReadOnly = false;
                richTextBox9.ReadOnly = false;
                richTextBox1.BackColor = Color.White;
                richTextBox2.BackColor = Color.White;
                richTextBox3.BackColor = Color.White;
                richTextBox4.BackColor = Color.White;
                richTextBox5.BackColor = Color.White;
                richTextBox6.BackColor = Color.White;
                richTextBox7.BackColor = Color.White;
                richTextBox8.BackColor = Color.White;
                richTextBox9.BackColor = Color.White;
                comboBox1.Enabled = true;


            }
            else
            {
                try

                {
                    DialogResult sonuc = new DialogResult();
                    sonuc = MessageBox.Show("Seçili cariyi güncelemek istediğinizden emin misiniz ?", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.Yes)
                    {
                        SQLiteCommand komut = new SQLiteCommand("update CariEkle set AdSoyadekle = @adsoyad, Firmaekle =@firma, Telefonekle = @telefon, Sabittelefonekle = @sabit," +
                        "EMailekle = @email, Adresekle = @adres, Ilekle = @ilekle, Ilceekle = @ilcEekle, Webekle = @webekle, CariGrubuekle = @carigrubu where id = @id", cnstr1.baglan());

                        komut.Parameters.AddWithValue("@id", id);
                        komut.Parameters.AddWithValue("@adsoyad", richTextBox1.Text);
                        komut.Parameters.AddWithValue("@firma", richTextBox2.Text);
                        komut.Parameters.AddWithValue("@telefon", richTextBox3.Text);
                        komut.Parameters.AddWithValue("@sabit", richTextBox4.Text);
                        komut.Parameters.AddWithValue("@email", richTextBox5.Text);
                        komut.Parameters.AddWithValue("@adres", richTextBox6.Text);
                        komut.Parameters.AddWithValue("@ilekle", richTextBox7.Text);
                        komut.Parameters.AddWithValue("@ilceekle", richTextBox8.Text);
                        komut.Parameters.AddWithValue("@webekle", richTextBox9.Text);
                        komut.Parameters.AddWithValue("@carigrubu", comboBox1.Text);

                        komut.ExecuteNonQuery();

                        MessageBox.Show("Seçili cari başarı ile güncellenmiştir !", "CARİ GÜNCELLEME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Text = "Düzenle";
                        richTextBox1.ReadOnly = true;
                        richTextBox2.ReadOnly = true;
                        richTextBox3.ReadOnly = true;
                        richTextBox4.ReadOnly = true;
                        richTextBox5.ReadOnly = true;
                        richTextBox6.ReadOnly = true;
                        richTextBox7.ReadOnly = true;
                        richTextBox8.ReadOnly = true;
                        richTextBox9.ReadOnly = true;
                        comboBox1.Enabled     = false;
                        richTextBox1.BackColor = Color.FromArgb(240,240,240);
                        richTextBox2.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox3.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox4.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox5.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox6.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox7.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox8.BackColor = Color.FromArgb(240, 240, 240);
                        richTextBox9.BackColor = Color.FromArgb(240, 240, 240);
                    }

                }

                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());

                }
            }


            yenile();


        }
        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from CariEkle", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "CariEkle");
                dataGridView1.DataSource = ds.Tables["CariEkle"];
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }
        int kayitsayisi;
        int yenisayi;
        rszfnt rz = new rszfnt();
        private void cari_goruntule_Load(object sender, EventArgs e)
        {

            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);
            comboBox1.Items.Clear();
            SQLiteCommand komut = new SQLiteCommand("select * from CariGrubu", cnstr1.baglan());
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {


                comboBox1.Items.Add(dr["CariGrubAdi"].ToString());
            }
            alantemizle();

            yenile();
           
            kayitsayisi = dataGridView1.RowCount;
            yenisayi = kayitsayisi;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        void alantemizle()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";
            richTextBox6.Text = "";
            richTextBox7.Text = "";
            richTextBox8.Text = "";
            richTextBox9.Text = "";
        }
        decimal dec1, dec2, sonuc;
        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            richTextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            richTextBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            richTextBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            richTextBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            richTextBox13.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            richTextBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dec1 = Convert.ToDecimal(richTextBox13.Text);
            dec2 = Convert.ToDecimal(richTextBox12.Text);
            sonuc = dec1 - dec2;
            richTextBox11.Text = sonuc.ToString();
        }

        private void richTextBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                da = new SQLiteDataAdapter("select * from CariEkle where AdSoyadekle like '"+richTextBox10.Text+"%'", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "CariEkle");
                dataGridView1.DataSource = ds.Tables["CariEkle"];
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }





        cari_ekle cariekle = new cari_ekle();
        private void button2_Click(object sender, EventArgs e)
        {
            cariekle.ShowDialog();
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili cariyi silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from CariEkle where id=@id AND ToplamSatisekle='0'", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                   yenile();
                    yenisayi = dataGridView1.RowCount;
                    
                    if (kayitsayisi!=yenisayi)
                    {
                        MessageBox.Show("Seçili cari başarılı bir şekilde silinmiştir !", "CARİ SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Seçili cari silinmedi !", "CARİ SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                kayitsayisi = dataGridView1.RowCount;
            }
            
            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    }

