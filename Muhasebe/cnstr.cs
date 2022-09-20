using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Windows;
using System.ComponentModel;



namespace Muhasebe
{
    class cnstr
    {
        
        public void mesaj(string c)
        {
            MessageBox.Show(c,"Hata !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
         SQLiteConnection baglanti;
            string baglantiadi = "Data Source=App_Data\\msbdb.sqlite;Version=3;";
        public SQLiteConnection baglan()
        {
            baglanti = new SQLiteConnection(baglantiadi);

                baglanti.Open();
         
            
            return baglanti;
        }

       
    }
    
    
}
