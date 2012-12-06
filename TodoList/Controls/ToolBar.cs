using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuld.TodoList.Controls {
    public partial class ToolBar : UserControl {

        public event EventHandler ActiveControlChanged;

        public ToolBar() {
            InitializeComponent();

            _lastControl = _currentControl = lbToDo;

            foreach (Control item in Controls) {
                item.Font = SystemFonts.MenuFont;
                item.Click += item_Click;
            }

        }

        Control _lastControl;

        Control _currentControl;

        public string LastText {
            get {
                return _lastControl.Text;
            }
        }

        public string CurrentText {
            get {
                return _currentControl.Text;
            }
        }

        void item_Click(object sender, EventArgs e) {
            _lastControl = _currentControl;
            _currentControl = (Control)sender;
            Invalidate();

            if (ActiveControlChanged != null) {
                ActiveControlChanged(this, EventArgs.Empty);
            }

        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(0, 122, 204), 6f), 0, 0, 0, Height);

            
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0, 122, 204), 4f), _currentControl.Left, _currentControl.Bottom, _currentControl.Right, _currentControl.Bottom);
        }

        public bool ShowCurrent {
            get {
                return lbCurrent.Visible;
            }
            set {
                lbCurrent.Visible = value;

                if (value) {
                    item_Click(lbCurrent, EventArgs.Empty);
                }
            }
        }
    }
}
