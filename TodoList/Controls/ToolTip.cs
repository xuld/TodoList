using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Xuld.TodoList.Controls {

    [ToolboxBitmap(typeof(System.Windows.Forms.ToolTip))]
    public class ToolTip : System.Windows.Forms.ToolTip {

        public ToolTip() {
            InitialDelay = 1000;
            BackColor = System.Drawing.Color.Black;
            ForeColor = Color.White;
            UseFading = true;
            UseAnimation = true;
            OwnerDraw = true;
            AutomaticDelay = 500;
            AutoPopDelay = 2000;

            Draw += ToolTip_Draw;
            Popup += ToolTip_Popup;

        }

        void ToolTip_Popup(object sender, System.Windows.Forms.PopupEventArgs e) {
            if (BackColor.GetBrightness() >= 0.5) {
                ForeColor = Color.White;
            }
        }

        void ToolTip_Draw(object sender, System.Windows.Forms.DrawToolTipEventArgs e) {
            e.DrawBackground();
            e.DrawText();
        }

    }
}
