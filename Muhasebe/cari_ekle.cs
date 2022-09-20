using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class cari_ekle : Form
    {
        public cari_ekle()
        {
            InitializeComponent();
        }
      

        cnstr cnstr1 = new cnstr();
        rszfnt rz = new rszfnt();

        private void cari_ekle_Load(object sender, EventArgs e)
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
          
          
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
 


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into CariEkle (AdSoyadekle, Firmaekle, Telefonekle, Sabittelefonekle, EMailekle, Adresekle, Ilekle, Ilceekle, Webekle, CariGrubuekle, ToplamSatisekle, ToplamAlinanekle, Bakiyeekle)" +
                  "values (@adsoyad, @firma, @telefon, @sabit, @email, @adres, @ilekle, @ilceekle, @webekle, @carigrubu, @toplamsatis, @toplamalinan, @bakiye )", cnstr1.baglan());

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
                komut.Parameters.AddWithValue("@toplamsatis", "0");
                komut.Parameters.AddWithValue("@toplamalinan", "0");
                komut.Parameters.AddWithValue("@bakiye", "0");

                komut.ExecuteNonQuery();

                MessageBox.Show("Cari başarı ile eklendi", "CARİ EKLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                alantemizle();
              }
            catch (Exception hata)
            {

                cnstr1.mesaj(hata.ToString());
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
        private void button2_Click(object sender, EventArgs e)
        {
            alantemizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

