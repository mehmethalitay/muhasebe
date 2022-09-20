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
    public partial class urun_ekle : Form
    {
        public urun_ekle()
        {
            InitializeComponent();

        }

        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();
        int bizimPcGenislik = 1920;//1440 1856 1024
        int bizimPcYukseklik = 1080;//900 1200 600
        private void urun_ekle_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

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
            alantemizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into Urun (Barkod, UrunAdi, UrunGrubu, UrunBirim, Fiyat, Maliyet, Stok )" +
                  "values (@barkod, @urunAdi, @urungrubu, @urunbirim, @fiyat, @maliyet, @stok )", cnstr1.baglan());

                komut.Parameters.AddWithValue("@barkod", richTextBox4.Text);
                komut.Parameters.AddWithValue("@urunadi", richTextBox1.Text);
                komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text);
                komut.Parameters.AddWithValue("@urunbirim", comboBox2.Text); 
                komut.Parameters.AddWithValue("@fiyat", richTextBox3.Text);
                komut.Parameters.AddWithValue("@maliyet", richTextBox2.Text);
                komut.Parameters.AddWithValue("@stok", richTextBox5.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Ürün başarı ile eklendi", "ÜRÜN EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                alantemizle();
            }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }


        }
        void alantemizle()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";
            comboBox1.Text = "";
            comboBox1.Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            alantemizle();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           


        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

