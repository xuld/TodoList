using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuld.TodoList.Controls {
    public partial class ConfirmButtons : UserControl {
        public ConfirmButtons() {
            InitializeComponent();
            cbDelay.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            AppManager.DoConfirm();
        }

        private void btnDelay_Click(object sender, EventArgs e) {
            int minutes = 1;
            switch (cbDelay.SelectedIndex) {
                case 0:
                    minutes = 5;
                    break;
                case 1:
                    minutes = 10;
                    break;
                case 2:
                    minutes = 15;
                    break;
                case 3:
                    minutes = 30;
                    break;
                case 4:
                    minutes = 60;
                    break;
                case 5:
                    minutes = 120;
                    break;
            }

            AppManager.DelayConform(minutes);
        }

    }
}
