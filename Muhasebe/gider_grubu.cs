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
    public partial class gider_grubu : Form
    {
        public gider_grubu()
        {
            InitializeComponent();
        }

        SQLiteDataAdapter da;
        DataSet ds;
        cnstr cnstr1 = new cnstr();
        string id;
        int yenisayi, kayitsayisi;
        private void yenile()
        {
            try
            {
                da = new SQLiteDataAdapter("select * from GiderGrubu", cnstr1.baglan());
                ds = new DataSet();
                da.Fill(ds, "GiderGrubu");
                dataGridView1.DataSource = ds.Tables["GiderGrubu"];
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("insert into GiderGrubu (GiderBirimGrubadi)" +
                 "values (@giderbirimgrubadi)", cnstr1.baglan());

                komut.Parameters.AddWithValue("@giderbirimgrubadi", richTextBox1.Text);
                komut.ExecuteNonQuery();
                yenile();

            }
            catch (Exception)
            {
                MessageBox.Show("Aynı gider grubundan vardır !");
            }
        }
        rszfnt rz = new rszfnt();
        private void gider_grubu_Load(object sender, EventArgs e)
        {
            this.Scale(rz.bytw(), rz.bytw());
            rz.font(this.Controls);

            yenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Seçili gider grubunu silmek istediğinizden emin misiniz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    SQLiteCommand komut = new SQLiteCommand("delete from GiderGrubu where id=@id ", cnstr1.baglan());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    yenile();
                    yenisayi = dataGridView1.RowCount;

                    if (kayitsayisi != yenisayi)
                    {
                        MessageBox.Show("Seçili gider grubu başarılı bir şekilde silinmiştir !", "GİDER GRUBU SİLME BAŞARILI !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Seçili gider grubu silinmedi !", "GİDER GRUBU SİLME BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
