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
using System.Runtime.InteropServices;


namespace Muhasebe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Font = SystemFonts.IconTitleFont;


        }

        

        int genislik = 1920,yukseklik=1080;
        cnstr cnstr1 = new cnstr();
        SQLiteConnection baglan = new SQLiteConnection();
        rszfnt rz = new rszfnt();



        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            
           /* this.Scale(rz.bytw(),rz.bytw());
            rz.font(this.Controls);*/


            try
            {
                SQLiteCommand komut = new SQLiteCommand("delete from SatisYap", cnstr1.baglan());
                komut.ExecuteNonQuery();                
            }

            catch (Exception hata)
            {
                cnstr1.mesaj(hata.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }
        cari_ekle cari_ekle = new cari_ekle();
        cari_goruntule cari_goruntule = new cari_goruntule();
        urun_ekle urun_ekle = new urun_ekle();
        urun_goruntule urun_goruntule = new urun_goruntule();
        satis_yap satis_yap = new satis_yap();
        tahsilat_yap tahsilat_yap = new tahsilat_yap();
        iade_gir iade_gir = new iade_gir();
        gider_ekle gider_ekle = new gider_ekle();
        kasa_goruntule kasa_goruntule = new kasa_goruntule();
        stok_grubu stok_grubu = new stok_grubu();
        stok_birim_grubu stok_birim_grubu = new stok_birim_grubu();
        gider_grubu gider_grubu = new gider_grubu();
        cari_grubu cari_grubu = new cari_grubu();
        stok_kontrol stok_kontrol = new stok_kontrol();
        tedarikci tedarikci = new tedarikci();
        cari_rapor cari_rapor = new cari_rapor();
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari_ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cari_goruntule.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urun_ekle.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            urun_goruntule.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            iade_gir.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            satis_yap.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            kasa_goruntule.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tahsilat_yap.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gider_ekle.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            stok_grubu.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            stok_birim_grubu.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            gider_grubu.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cari_grubu.ShowDialog();
        }

        private void cariEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cari_ekle.ShowDialog();
        }

        private void cariGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cari_goruntule.ShowDialog();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urun_ekle.ShowDialog();
        }

        private void ürünGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urun_goruntule.ShowDialog();
        }

        private void satışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satis_yap.ShowDialog();
            
        }

        private void iadeGirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iade_gir.ShowDialog();
        }

        private void kasaGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasa_goruntule.ShowDialog();
        }

        private void tahsilatYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tahsilat_yap.ShowDialog();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gider_ekle.ShowDialog();
        }

        private void stokGrubuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stok_grubu.ShowDialog();
        }

        private void stokBirimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stok_birim_grubu.ShowDialog();
        }

        private void giderGrubuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gider_grubu.ShowDialog();
        }

        private void cariGrubuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cari_grubu.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            cari_rapor.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void stokDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stok_kontrol.ShowDialog();
        }

        private void tedarikçiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tedarikci.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
