using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuld.TodoList.Controls {
    public partial class TimeSuggestMenu : UserControl {
        public TimeSuggestMenu() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);


            using (Pen p = new Pen(Color.FromArgb(0, 122, 204), 1f))
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

        }
    }
}
