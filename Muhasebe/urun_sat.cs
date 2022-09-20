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
    public partial class urun_sat : Form
    {
        public urun_sat()
        {
            InitializeComponent();
        }

        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        string id;
        SQLiteDataAdapter da;
        DataSet ds;


        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from Urun", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "Urun");

            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
        }
            private void urun_sat_Load(object sender, EventArgs e)
        {

            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

            da = new SQLiteDataAdapter("select * from Urun", cnstr1.baglan());
            ds = new DataSet();
            da.Fill(ds, "Urun");
            dataGridView1.DataSource = ds.Tables["Urun"];
            yenile();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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
            label4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


            yenile();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (label3.Text == "0")
            {
                try
                {
                    satis_yap st = new satis_yap();

                    SQLiteCommand komut = new SQLiteCommand("insert into SatisYap (Barkod, UrunAdi, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Stok )" +
                      "values (@barkod, @urunadi, @urungrubu, @urunbirim, @urunsayi, @fiyat, @urunKdv, @urunisk, @urunsatisf, @tarih, @stok )", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                    komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text);
                    komut.Parameters.AddWithValue("@urunsayi", 0);
                    komut.Parameters.AddWithValue("@fiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@urunkdv", 18);
                    komut.Parameters.AddWithValue("@urunisk", 0);
                    komut.Parameters.AddWithValue("@urunsatisf", 0);
                    komut.Parameters.AddWithValue("@tarih", st.dateTimePicker1.Value.Date);
                    komut.Parameters.AddWithValue("@stok", label4.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    yenile();

                }
                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());
                }
            }
            else if (label3.Text == "1")
            {
                try
                {
                    satis_yap st = new satis_yap();

                    SQLiteCommand komut = new SQLiteCommand("insert into SatisYap (Barkod, UrunAdi, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Stok )" +
                      "values (@barkod, @urunadi, @urungrubu, @urunbirim, @urunsayi, @fiyat, @urunKdv, @urunisk, @urunsatisf, @tarih, @stok )", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                    komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text);
                    komut.Parameters.AddWithValue("@urunsayi", 0);
                    komut.Parameters.AddWithValue("@fiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@urunkdv", 18);
                    komut.Parameters.AddWithValue("@urunisk", 0);
                    komut.Parameters.AddWithValue("@urunsatisf", 0);
                    komut.Parameters.AddWithValue("@tarih", st.dateTimePicker1.Value.Date);
                    komut.Parameters.AddWithValue("@stok", label4.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    yenile();

                }
                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text=="0")
            {
                try
                {
                    satis_yap st = new satis_yap();

                    SQLiteCommand komut = new SQLiteCommand("insert into SatisYap (Barkod, UrunAdi, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Stok )" +
                      "values (@barkod, @urunadi, @urungrubu, @urunbirim, @urunsayi, @fiyat, @urunKdv, @urunisk, @urunsatisf, @tarih, @stok )", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                    komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text);
                    komut.Parameters.AddWithValue("@urunsayi", 0);
                    komut.Parameters.AddWithValue("@fiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@urunkdv", 18);
                    komut.Parameters.AddWithValue("@urunisk", 0);
                    komut.Parameters.AddWithValue("@urunsatisf", 0);
                    komut.Parameters.AddWithValue("@tarih", st.dateTimePicker1.Value.Date);
                    komut.Parameters.AddWithValue("@stok", label4.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    yenile();

                }
                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());
                }
            }else if (label3.Text=="1")
            {
                try
                {
                    satis_yap st = new satis_yap();

                    SQLiteCommand komut = new SQLiteCommand("insert into SatisYap (Barkod, UrunAdi, UrunGrubu, UrunBirim, UrunSayi, Fiyat, UrunKdv, UrunIsk, UrunSatisF, Tarih, Stok )" +
                      "values (@barkod, @urunadi, @urungrubu, @urunbirim, @urunsayi, @fiyat, @urunKdv, @urunisk, @urunsatisf, @tarih, @stok )", cnstr1.baglan());

                    komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                    komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text);
                    komut.Parameters.AddWithValue("@urunsayi", 0);
                    komut.Parameters.AddWithValue("@fiyat", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@urunkdv", 18);
                    komut.Parameters.AddWithValue("@urunisk", 0);
                    komut.Parameters.AddWithValue("@urunsatisf", 0);
                    komut.Parameters.AddWithValue("@tarih", st.dateTimePicker1.Value.Date);
                    komut.Parameters.AddWithValue("@stok", label4.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    yenile();

                }
                catch (Exception hata)
                {

                    cnstr1.mesaj(hata.ToString());
                }

            }
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
