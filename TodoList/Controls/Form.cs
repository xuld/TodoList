using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Xuld.TodoList.Controls {
    public partial class Form : System.Windows.Forms.Form {

        #region DllImport

        private const int MOUSE_MOVE = 0xf012;
        private const int WM_SYSCOMMAND = 0x112;

        [DllImport("user32.DLL")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL")]
        private static extern void SendMessage(IntPtr hWnd, uint wMsg, uint wParam, uint lParam);

        #endregion

        public Color DominantColor {
            get;
            set;
        }

        public Form() {
            InitializeComponent();

            DominantColor = Color.FromArgb(0, 122, 204);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            pbResize.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizeRestore_Click(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Maximized;
            } else {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (e.Clicks >= 2) {
                    btnMaximizeRestore.PerformClick();
                } else {
                    Capture = false;
                    SendMessage(Handle, 0x00A1u, 0x0002, 0);
                }
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {

            Graphics g = e.Graphics;

            g.DrawIcon(Icon, 3, 2);

            int left = 36;
            int right = btnMinimize.Left;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(153, 153, 153)))
                g.DrawString(Text, SystemFonts.CaptionFont, brush, new RectangleF(left, 10, right - left, SystemFonts.CaptionFont.Height));

            if (this.WindowState == FormWindowState.Normal) {
                using (Pen p = new Pen(DominantColor, 1f))
                    e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }

            if (WindowState == FormWindowState.Normal) {
                btnMaximizeRestore.Image = Xuld.TodoList.Properties.Resources.maximize_l;
            } else {
                btnMaximizeRestore.Image = Xuld.TodoList.Properties.Resources.restore_l;
            }
        }

        private void pbResize_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {

                int width = Width + e.X;
                int height = Height + e.Y;

                if (width < 140) {
                    width = 140;
                }

                if (height < 40) {
                    height = 40;
                }

                Width = width;
                Height = height;


            }
        }

        protected override void OnTextChanged(EventArgs e) {
            Invalidate();
        }

    }


}
