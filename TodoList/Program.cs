﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Xuld.TodoList {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            AppManager.Run(args);
        }
    }
}
