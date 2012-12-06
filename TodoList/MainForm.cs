using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuld.TodoList {
    public partial class MainForm : Xuld.TodoList.Controls.Form {
        public MainForm() {
            InitializeComponent();

            tbTask.Text = TaskManager.LoadTaskString(toolBar.CurrentText);
            tbTask.SelectionStart = tbTask.TextLength;
            tbTask.SelectionLength = 0;

            
        }

        private void tbTask_KeyPress(object sender, KeyPressEventArgs e) {
           
        }

       // Xuld.TodoList.Controls.TimeSuggestMenu suggestMenu;

        private void InsertSuggest(string content) {
            int start = tbTask.SelectionStart;
            tbTask.SelectedText = content;
            tbTask.SelectionStart = start;
            tbTask.SelectionLength = content.Length;
        }

        private void tbTask_KeyUp(object sender, KeyEventArgs e) {
            if (e.Shift && e.KeyValue == 50) {
                DateTime now = DateTime.Now;

                InsertSuggest(now.Month + "月" + now.Day + "日 " + (now.Hour+1) + ":00");

                //if (suggestMenu != null) {
                //    suggestMenu.Visible = true;
                //} else {
                //    suggestMenu = new Controls.TimeSuggestMenu();
                //    Controls.Add(suggestMenu);
                //}

                //Point p = tbTask.GetPositionFromCharIndex(tbTask.SelectionStart - 1);
                //p.X += tbTask.Left;
                //p.Y += tbTask.Top + tbTask.Font.Height;
                //suggestMenu.Location = p;
                //suggestMenu.BringToFront();
            } else {
                //if (suggestMenu != null) {
                //    suggestMenu.Visible = false;
                //}
            }

        }

        private void tbTask_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control) {
                if (e.KeyCode == Keys.A) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    tbTask.SelectAll();
                } else if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Close();
                }
            }
        }

        private void tbTask_Leave(object sender, EventArgs e) {
            if (toolBar.CurrentText != AppManager.Now) {
                TaskManager.SaveTaskString(toolBar.CurrentText, tbTask.Text);
            }
        }

        private void toolBar_ActiveControlChanged(object sender, EventArgs e) {
            if (toolBar.LastText != AppManager.Now) {
                TaskManager.SaveTaskString(toolBar.LastText, tbTask.Text);
            }

            if (toolBar.CurrentText == AppManager.Now) {
                tbTask.Text = TaskManager.CurrentTaskString;
                tbTask.ReadOnly = true;
            } else {
                tbTask.Text = TaskManager.LoadTaskString(toolBar.CurrentText);
                tbTask.ReadOnly = false;
                tbTask.SelectionStart = tbTask.TextLength;
                tbTask.SelectionLength = 0;
            }
        }

        Controls.ConfirmButtons confirmButtons;

        [System.Runtime.InteropServices.DllImport("User32")]
        static extern int FlashWindow(IntPtr hwnd, bool bInvert);

        /// <summary>
        /// 支持显示与隐藏窗口时能产生特殊的效果。有两种类型的动画效果：滚动动画和滑动动画。
        /// </summary>
        /// <param name="hWnd">指定产生动画的窗口的句柄。</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。</param>
        /// <param name="dwFlags">指定动画类型。</param>
        /// <returns>如果函数调用成功则返回值为给定控制的窗口句柄。如果函数调用失败，则返回值为NULL，表示为一个无效的对话框句柄或一个不存在的控制。若想获得更多错误信息，请调用GetLastError函数。</returns>
        /// <remarks>
        /// 窗口使用了窗口边界；窗口已经可见仍要显示窗口；窗口已经隐藏仍要隐藏窗口。若想获得更多错误信息，请调用GetLastError函数。
        /// 
        /// 可以将AW_HOR_POSITIVE或AW_HOR_NEGTVE与AW_VER_POSITVE或AW_VER_NEGATIVE组合来激活一个窗口。
        /// 
        /// </remarks>
        [System.Runtime.InteropServices.DllImport("User32")]
        static extern int AnimateWindow(IntPtr hWnd, int dwTime = 200, AW dwFlags = AW.Center);

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            AnimateWindow(Handle, 300, AW.Blend);

            Invalidate();
        }

        /// <summary>
        /// 表示 AnimateWindow 的标记。
        /// </summary>
        enum AW {

            /// <summary>
            /// 使用滑动类型。缺省则为滚动动画类型。当使用CENTER标志时，这个标志就被忽略。
            /// </summary>
            Slide = 0x40000,

            /// <summary>
            /// 激活窗口。在使用了HIDE标志后不要使用这个标志。
            /// </summary>
            Active = 0x20000,

            /// <summary>
            /// 使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
            /// </summary>
            Blend = 0x80000,

            /// <summary>
            /// 隐藏窗口，缺省则显示窗口。
            /// </summary>
            Hide = 0x10000,

            /// <summary>
            /// 若使用了HIDE标志，则使窗口向内重叠；若未使用HIDE标志，则使窗口向外扩展。
            /// </summary>
            Center = 0x10,

            /// <summary>
            /// 自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用CENTER标志时，该标志将被忽略。
            /// </summary>
            HorNegative = 0x1,

            /// <summary>
            /// 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用CENTER标志时，该标志将被忽略。
            /// </summary>
            HorPositive = 0x1,

            /// <summary>
            /// 自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用CENTER标志时，该标志将被忽略。
            /// </summary>
            VerPositive = 0x4,

            /// <summary>
            /// 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用CENTER标志时，该标志将被忽略。
            /// </summary>
            VerNegative = 0x8

        }

        public bool DoConfirm {
            get {
                return toolBar.ShowCurrent;
            }
            set {

                if (value) {
                    if (confirmButtons == null) {
                        confirmButtons = new Controls.ConfirmButtons() {
                            Left = 0,
                            Width = Width,
                            Dock = DockStyle.Bottom
                        };

                        Controls.Add(confirmButtons);

                        confirmButtons.BringToFront();
                    }

                    confirmButtons.Visible = value;

                    Rectangle area = Screen.FromHandle(Handle).WorkingArea;

                    Left = area.Right - Width;
                    Top = area.Bottom - Height;

                    FlashWindow(Handle, true);

                } else {
                    if (confirmButtons != null) {
                        confirmButtons.Visible = value;
                    }
                }

                toolBar.ShowCurrent = TopMost = value;
                
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            tbTask_Leave(sender, e);
            TaskManager.RebuildTaskList();
        }

        public void Confirm() {
            DoConfirm = true;
        }
    }
}
