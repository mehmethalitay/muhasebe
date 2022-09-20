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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Muhasebe
{
    public partial class cari_rapor : Form
    {
        public cari_rapor()
        {
            InitializeComponent();
        }

        cnstr cnstr1 = new cnstr();

        private void cari_rapor_Load(object sender, EventArgs e)
        {
            cnstr1.baglan();
        }

        public string TurkceKarakter(string text)
        {

            text = text.Replace("İ", "\u0130");

            text = text.Replace("ı", "\u0131");

            text = text.Replace("Ş", "\u015e");

            text = text.Replace("ş", "\u015f");

            text = text.Replace("Ğ", "\u011e");

            text = text.Replace("ğ", "\u011f");

            text = text.Replace("Ö", "\u00d6");

            text = text.Replace("ö", "\u00f6");

            text = text.Replace("ç", "\u00e7");

            text = text.Replace("Ç", "\u00c7");

            text = text.Replace("ü", "\u00fc");

            text = text.Replace("Ü", "\u00dc");

            return text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text;
            iTextSharp.text.Document rapor = new iTextSharp.text.Document();
            PdfWriter.GetInstance(rapor, new FileStream("deneme.pdf", FileMode.Create));
            iTextSharp.text.Font asd = new iTextSharp.text.Font();
            BaseFont arial = BaseFont.CreateFont("C:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Image resim = iTextSharp.text.Image.GetInstance(@"C:\a.jpg");
            iTextSharp.text.Font fonty = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            rapor.AddAuthor("ŞİRKET İSMİ");

            rapor.AddCreationDate();
            rapor.AddCreator("KORTEL YAZILIM");
            rapor.AddSubject("KONU BU");
            rapor.AddKeywords("Kelimeler");
            if (rapor.IsOpen() == false)
            {
                rapor.Open();
            }
            rapor.Add(resim);
            text = TurkceKarakter(richTextBox1.Text);
            rapor.Add(new Paragraph(text, fonty));

            rapor.Close();
        }
    }
}
