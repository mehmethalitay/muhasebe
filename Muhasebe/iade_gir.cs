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
    public partial class iade_gir : Form
    {
        public iade_gir()
        {
            InitializeComponent();
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        string id;
        SQLiteDataAdapter da;
        DataSet ds;
        int kayitsayisi;
        int yenisayi;
        int musteriid;
        public bool acik;
        decimal bakiye2, bakiye3;
        decimal sayi1, sayi2;
        decimal satislar, satistutar, borcun, alinan, alinmis, aldik;

        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("Select * From iade", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "iade");
                dataGridView2.DataSource = ds.Tables["iade"];


            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());

            }


        }


        private void alankalan()
        {

            decimal tutar, alinan, bakiye;
            tutar = Convert.ToDecimal(richTextBox2.Text);
            alinan = Convert.ToDecimal(richTextBox3.Text);
            bakiye = tutar - alinan;
            richTextBox4.Text = bakiye.ToString();
        }

        private void topfiyat()
        {

            Decimal toplam1 = 0;
            for (int k = 0; k < dataGridView2.Rows.Count; ++k)
            {
                toplam1 += Convert.ToDecimal(dataGridView2.Rows[k].Cells[9].Value);
            }
            richTextBox2.Text = toplam1.ToString();
            iskkdvhesapla();
        }


        private void iskkdvhesapla()
        {
            try
            {

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    decimal iskoran, iskli, fiyat, kdvoran, kdvli, fiyat1, fiyatson, fiyatisk, adetfiyat, topfiyat, adet;

                    adet = Convert.ToDecimal(dataGridView2.Rows[i].Cells[5].Value);
                    adetfiyat = Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                    topfiyat = adet * adetfiyat;
                    label25.Text = topfiyat.ToString();

                    fiyat = topfiyat;
                    iskoran = Convert.ToDecimal(dataGridView2.Rows[i].Cells[8].Value);
                    iskli = iskoran * fiyat / 100;
                    fiyatisk = fiyat - iskli;


                    fiyat1 = fiyatisk;
                    kdvoran = Convert.ToDecimal(dataGridView2.Rows[i].Cells[7].Value);
                    kdvli = kdvoran * fiyat1 / 100;
                    fiyatson = fiyat1 + kdvli;
                    dataGridView2.Rows[i].Cells[9].Value = fiyatson;


                }

            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }

        private void iade_gir_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);


            SQLiteCommand komut = new SQLiteCommand("select * from iade", cnstr1.baglan());
            SQLiteCommand komut1 = new SQLiteCommand("select * from iade", cnstr1.baglan());
            SQLiteDataReader dr = komut.ExecuteReader();
            SQLiteDataReader dr1 = komut1.ExecuteReader();

            da = new SQLiteDataAdapter("select * from CariEkle", cnstr1.baglan());
            ds = new DataSet();
            da.Fill(ds, "CariEkle");
            dataGridView1.DataSource = ds.Tables["CariEkle"];
            iskkdvhesapla();

            timer1.Start();
            kayitsayisi = dataGridView1.RowCount;
            yenisayi = kayitsayisi;


            dataGridView1.Columns[0].HeaderText = "İD";
            dataGridView1.Columns[1].HeaderText = "AD SOYAD";
            dataGridView1.Columns[2].HeaderText = "FİRMA";
            dataGridView1.Columns[3].HeaderText = "TELEFON";
            dataGridView1.Columns[4].HeaderText = "SABİT TELEFON";
            dataGridView1.Columns[5].HeaderText = "E-MAİL";
            dataGridView1.Columns[6].HeaderText = "ADRES";
            dataGridView1.Columns[7].HeaderText = "İL";
            dataGridView1.Columns[8].HeaderText = "İLÇE";
            dataGridView1.Columns[9].HeaderText = "WEB";
            dataGridView1.Columns[10].HeaderText = "CARİ GRUBU";
            dataGridView1.Columns[11].HeaderText = "TOPLAM SATIŞ";
            dataGridView1.Columns[12].HeaderText = "TOPLAM ALINAN";
            dataGridView1.Columns[13].HeaderText = "BAKİYE";


            acik = true;

            iskkdvhesapla();

            alankalan();

            yenile();



        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox18.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox17.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            richTextBox16.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox15.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox14.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox13.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            richTextBox12.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            richTextBox11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            richTextBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        urun_sat urun_sat = new urun_sat();
        private void button3_Click(object sender, EventArgs e)
        {
            urun_sat.label3.Text = "1";
            iskkdvhesapla();
            topfiyat();
            urun_sat.ShowDialog();
            alankalan();

            yenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Tüm listeyi silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from iade", cnstr1.baglan());
                    komut.ExecuteNonQuery();
                    yenile();

                }
            }

            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteCommand komut = new SQLiteCommand("delete from iade where id=@id", cnstr1.baglan());
            komut.Parameters.AddWithValue("@id", label27.Text);
            komut.ExecuteNonQuery();
            yenile();
            yenisayi = dataGridView1.RowCount;
            kayitsayisi = dataGridView1.RowCount;

        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {

            label22.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox18.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox17.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            richTextBox16.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox15.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox14.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox13.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            richTextBox12.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            richTextBox11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            richTextBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            richTextBox7.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            richTextBox8.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dec1 = Convert.ToDecimal(richTextBox7.Text);
            dec2 = Convert.ToDecimal(richTextBox8.Text);
            sonuc = dec1 - dec2;
            richTextBox9.Text = sonuc.ToString();

        }


        decimal dec1, dec2, sonuc;

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iade_gir_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Satışı iptal etmek istiyormusunuz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from iade", cnstr1.baglan());
                    komut.ExecuteNonQuery();

                    richTextBox2.Text = "0";
                    richTextBox3.Text = "0";
                    richTextBox4.Text = "0";

                    yenile();

                }
                else
                    e.Cancel = true;


            }
            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richTextBox18.Text + " " + "Adlı kişiye iade girmek istiyormusunuz ?");
            satistutar = Convert.ToDecimal(richTextBox2.Text);
            borcun = Convert.ToDecimal(richTextBox7.Text);
            alinan = Convert.ToDecimal(richTextBox3.Text);
            alinmis = Convert.ToDecimal(richTextBox8.Text);
            try
            {
                satislar = satistutar + borcun;
                aldik = alinan + alinmis;
                label25.Text = satislar.ToString();
                label24.Text = aldik.ToString();
                SQLiteCommand komut3 = new SQLiteCommand("update CariEkle set ToplamSatisekle = @toplamsatisekle,  ToplamAlinanekle = @toplamalinanekle where id='" + label22.Text + "' ", cnstr1.baglan());
                komut3.Parameters.AddWithValue("@toplamsatisekle", satislar);
                komut3.Parameters.AddWithValue("@toplamalinanekle", aldik);
                komut3.ExecuteNonQuery();

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {

                    SQLiteCommand komut = new SQLiteCommand("insert into Faturalar (id, musteriId, AdSoyadekle, UrunKodu, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Topfiyat, Alinan, Bakiye )" +
                      "values (@id, @musteriId, @adsoyadekle, @urunkodu, @urungrubu, @urunbirim, @urunsayi, @fiyat, @urunKdv, @urunisk, @urunsatisf, @tarih, @topfiyat, @alinan, @bakiye)", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@id", dataGridView2.Rows[i].Cells[0].Value);
                    komut.Parameters.AddWithValue("@musteriId", label22.Text);
                    komut.Parameters.AddWithValue("@adsoyadekle", richTextBox18.Text);
                    komut.Parameters.AddWithValue("@urunkodu", dataGridView2.Rows[i].Cells[2].Value);
                    komut.Parameters.AddWithValue("@urungrubu", dataGridView2.Rows[i].Cells[3].Value);
                    komut.Parameters.AddWithValue("@urunbirim", dataGridView2.Rows[i].Cells[4].Value);
                    komut.Parameters.AddWithValue("@urunsayi", dataGridView2.Rows[i].Cells[5].Value);
                    komut.Parameters.AddWithValue("@fiyat", dataGridView2.Rows[i].Cells[6].Value);
                    komut.Parameters.AddWithValue("@urunkdv", dataGridView2.Rows[i].Cells[7].Value);
                    komut.Parameters.AddWithValue("@urunisk", dataGridView2.Rows[i].Cells[8].Value);
                    komut.Parameters.AddWithValue("@urunsatisf", dataGridView2.Rows[i].Cells[9].Value);
                    komut.Parameters.AddWithValue("@tarih", dataGridView2.Rows[i].Cells[10].Value);
                    komut.Parameters.AddWithValue("@topfiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@alinan", richTextBox3.Text);
                    komut.Parameters.AddWithValue("@bakiye", richTextBox4.Text);

                    komut.ExecuteNonQuery();

                }


                SQLiteCommand komut1 = new SQLiteCommand("delete from iade", cnstr1.baglan());
                komut1.ExecuteNonQuery();
                yenile();
                MessageBox.Show("Satış işlemi başarı ile gerçekleştirildi", "SATIŞ BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            iskkdvhesapla();
            topfiyat();
            alankalan();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            alankalan();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            label22.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            dec1 = Convert.ToDecimal(richTextBox7.Text);
            dec2 = Convert.ToDecimal(richTextBox8.Text);
            sonuc = dec1 - dec2;
            richTextBox9.Text = sonuc.ToString();

            label27.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            iskkdvhesapla();
            topfiyat();
            alankalan();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            {
                SQLiteCommand komut = new SQLiteCommand("update iade set Tarih = @tarih ", cnstr1.baglan());

                komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date);

                komut.ExecuteNonQuery();
                yenile();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iskkdvhesapla();
            topfiyat();
            alankalan();

            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into iade ( UrunAdi, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Barkod)" +
                  "values ('','', '', '','', '', '', '',''  )", cnstr1.baglan());

                komut.ExecuteNonQuery();

                MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
            yenile();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "" || richTextBox3.Text == " ")
            {
                richTextBox3.Text = "0";

            }
            alankalan();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            iskkdvhesapla();
            topfiyat();
            alankalan();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
                {

                    da = new SQLiteDataAdapter("select * from CariEkle where AdSoyadekle like '" + richTextBox1.Text + "%'", cnstr1.baglan());
                    ds = new DataSet();
                    da.Fill(ds, "CariEkle");
                    dataGridView1.DataSource = ds.Tables["CariEkle"];
                }
                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());
                }
        }


    }
}
