using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Muhasebe
{
    class rszfnt
    {
        int ekran = 1920, ekranyuksek = 1080;
        public float bytw()
        {
            Rectangle rc = new Rectangle();
            rc = Screen.GetBounds(rc);
            float oranwith = ((float)rc.Width / (float)ekran);
            return oranwith;
        }
        public float byth()
        {
            Rectangle rc = new Rectangle();
            rc = Screen.GetBounds(rc);
            float oranwith = ((float)rc.Height / (float)ekranyuksek);
            return oranwith;
        }
        public void font(Control.ControlCollection cs)
        {
            foreach (Control ctrl in cs)
            {

                //Button btn=ctrl as Button;
                //GroupBox gr = ctrl as GroupBox;
                //Label lbl = ctrl as Label;
                //TextBox txt = ctrl as TextBox;
                //ComboBox cbx = ctrl as ComboBox;
                //MenuStrip ms = ctrl as MenuStrip;
                //RichTextBox rct = ctrl as RichTextBox;
                //TextBox tbx = ctrl as TextBox;
                //DataGridView dgv = ctrl as DataGridView;
                //DateTimePicker dtp = ctrl as DateTimePicker ;


                ////if (gr != null)
                ////    gr.Font = new Font("arial", 8);
                ////if (btn != null)
                ////    btn.Font = new Font("arial", 8);
                ////if (lbl !=null)
                ////    lbl.Font = new Font("arial", 8);
                ////if (txt != null)
                ////    txt.Font = new Font("arial", 8);
                ////if (cbx != null)
                ////    cbx.Font = new Font("arial", 8);
                ////if (ms != null)
                ////    ms.Font = new Font("arial", 8);
                ////if (rct != null)
                ////    rct.Font = new Font("arial", 8);
                ////if (tbx != null)
                ////    tbx.Font = new Font("arial", 8);
                ////if (dgv != null)
                ////    dgv.Font = new Font("arial", 8);
                ////if (dtp != null)
                ////    dtp.Font = new Font("arial", 8);

                //else
                //    font(ctrl.Controls);
                
            }

        }



    }
}
