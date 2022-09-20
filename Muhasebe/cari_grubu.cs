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
    public partial class cari_grubu : Form
    {
        public cari_grubu()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter da;
        DataSet ds;
        cnstr cnstr1 = new cnstr();

        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from CariGrubu", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "CariGrubu");
                dataGridView1.DataSource = ds.Tables["CariGrubu"];
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
        }
        rszfnt rz = new rszfnt();
        private void cari_grubu_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);
            alantemizle();
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into CariGrubu (CariGrubadi)" +
                     "values (@carigrubu)", cnstr1.baglan());

                komut.Parameters.AddWithValue("@carigrubu", richTextBox1.Text);
                komut.ExecuteNonQuery();
                yenile();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Aynı cari grubundan vardır");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
        int kayitsayisi, yenisayi;
        string id;
        private void button2_Click(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili cari grubunu silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from CariGrubu where id=@id ", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    yenile();
                    yenisayi = dataGridView1.RowCount;

                    if (kayitsayisi != yenisayi)
                    {
                        MessageBox.Show("Seçili cari grubu başarılı bir şekilde silinmiştir !", "CARİ GRUBU SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Seçili cari grubu silinmedi !", "CARİ GRUBU SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                kayitsayisi = dataGridView1.RowCount;
            }

            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }
        }
    }
}
