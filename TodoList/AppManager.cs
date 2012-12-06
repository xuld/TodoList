using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Xuld.TodoList {

    /// <summary>
    /// 应用程序管理器。
    /// </summary>
    public static class AppManager {

        public static string Todo = "要做的";

        public static string Done = "已做的";

        public static string Plan = "定时的";

        public static string Now = "时间到";

        public static string DataFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Data");

        const int TimerDelay = 3000;

        /// <summary>
        /// 获取当前正在使用的 <see cref="NotifyIcon"/> 对象。
        /// </summary>
        public static NotifyIcon NotifyIcon {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前正在使用的 <see cref="MainForm"/> 对象。
        /// </summary>
        public static MainForm MainForm {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前正在使用的 <see cref="MainForm"/> 对象。
        /// </summary>
        public static System.Threading.Timer Timer {
            get;
            private set;
        }

        public static bool Disabled {
            get;
            set;
        }

        public static bool IsRunningFullScreenApp {
            get;
            private set;
        }

        public static void Run(string[] args) {
            Application.SetCompatibleTextRenderingDefault(false);
         //   Application.AddMessageFilter(new FullScreenMessageFilter());

            NotifyIcon = new System.Windows.Forms.NotifyIcon();
            NotifyIcon.Icon = Properties.Resources.Clock1;
            NotifyIcon.Visible = true;
            NotifyIcon.MouseClick += NotifyIcon_Click;
            NotifyIcon.ContextMenu = new ContextMenu();
            NotifyIcon.ContextMenu.Popup += ContextMenu_Popup;
            NotifyIcon.ContextMenu.MenuItems.Add("显示主窗口(&E)", (sender, e) => { ShowMainForm(false); }).DefaultItem = true;
            NotifyIcon.ContextMenu.MenuItems.Add("启用提醒(&S)", (sender, e) => { Disabled = !Disabled; });
         //   NotifyIcon.ContextMenu.MenuItems.Add("关于(&A)", (sender, e) => { MessageBox.Show("一个轻量的提醒软件 - by xuld", "ToDoList 0.1"); });
            NotifyIcon.ContextMenu.MenuItems.Add("-");
            NotifyIcon.ContextMenu.MenuItems.Add("退出(&X)", (sender, e) => { Application.Exit(); });

            Application.ApplicationExit += Application_ApplicationExit;

            Timer = new System.Threading.Timer(TimerCallback);

            Timer.Change(0, TimerDelay);

            if (args.Length == 0) {
                ShowMainForm(false);
            } else {
                TaskManager.RebuildTaskList();
            }

            Application.Run();
        }

        static void ContextMenu_Popup(object sender, EventArgs e) {
            NotifyIcon.ContextMenu.MenuItems[1].Checked = !Disabled;
        }

        static void TimerCallback(object state) {
            if (Disabled || IsRunningFullScreenApp) {
                return;
            }

            TaskManager.Check();
        }

        public static void ShowMainForm(bool doConfirm) {
            if (MainForm == null) {
                if (doConfirm) {
                    Disabled = true;
                }
                MainForm = new MainForm();
                MainForm.DoConfirm = doConfirm;
                MainForm.ShowDialog();
                MainForm = null;
                if (doConfirm) {
                    Disabled = false;
                }
                GC.Collect();
            } else if (doConfirm) {

                if (MainForm.InvokeRequired) {
                    MainForm.Invoke(new Action(MainForm.Confirm));
                } else {
                    MainForm.Confirm();
                }
            }
        }

        public static void DoConfirm() {
            MainForm.Close();
        }

        public static void DelayConform(int miniutes) {
            TaskManager.DelayCurrentTask(miniutes);
            MainForm.Close();
        }

        static void NotifyIcon_Click(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ShowMainForm(false);
            }
        }

        static void Application_ApplicationExit(object sender, EventArgs e) {
            NotifyIcon.Visible = false;
            NotifyIcon.Dispose();
        }

        class FullScreenMessageFilter : IMessageFilter {

            int uCallBackMsg;

            void RegisterAppBar(bool registered) {
                APPBARDATA abd = new APPBARDATA();
                abd.cbSize = Marshal.SizeOf(abd);
               // abd.hWnd = Application.;
                if (!registered) {
                    //register   
                    uCallBackMsg = RegisterWindowMessage("APPBARMSG_CSDN_HELPER");
                    abd.uCallbackMessage = uCallBackMsg;
                    uint ret = SHAppBarMessage((int)ABMsg.ABM_NEW, ref abd);
                } else {
                    SHAppBarMessage((int)ABMsg.ABM_REMOVE, ref abd);
                }
            }

            [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
            static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

            [DllImport("User32", CharSet = CharSet.Auto)]
            static extern int RegisterWindowMessage(string msg);

            [StructLayout(LayoutKind.Sequential)]
            struct APPBARDATA {
                public int cbSize;
                public IntPtr hWnd;
                public int uCallbackMessage;
                public int uEdge;
                public RECT rc;
                public IntPtr lParam;
            }

            enum ABMsg : int {
                ABM_NEW = 0,
                ABM_REMOVE,
                ABM_QUERYPOS,
                ABM_SETPOS,
                ABM_GETSTATE,
                ABM_GETTASKBARPOS,
                ABM_ACTIVATE,
                ABM_GETAUTOHIDEBAR,
                ABM_SETAUTOHIDEBAR,
                ABM_WINDOWPOSCHANGED,
                ABM_SETSTATE
            }

            enum ABNotify : int {
                ABN_STATECHANGE = 0,
                ABN_POSCHANGED,
                ABN_FULLSCREENAPP,
                ABN_WINDOWARRANGE
            }

            enum ABEdge : int {
                ABE_LEFT = 0,
                ABE_TOP,
                ABE_RIGHT,
                ABE_BOTTOM
            }

            [StructLayout(LayoutKind.Sequential)]
            struct RECT {
                public int left;
                public int top;
                public int right;
                public int bottom;

                public override string ToString() {
                    return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " +
                        "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";
                }
            }

            public FullScreenMessageFilter() {
                RegisterAppBar(true);
            }

            public bool PreFilterMessage(ref Message m) {
             
                if (m.Msg == uCallBackMsg && m.WParam.ToInt32() == (int)ABNotify.ABN_FULLSCREENAPP) {
                    if ((int)m.LParam == 1)
                        AppManager.IsRunningFullScreenApp = true;
                    else
                        AppManager.IsRunningFullScreenApp = false;
                }

                return false;
            }

        }

    }
}
