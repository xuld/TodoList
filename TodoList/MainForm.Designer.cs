namespace Xuld.TodoList {
    partial class MainForm: Xuld.TodoList.Controls.Form {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.tbTask = new System.Windows.Forms.TextBox();
            this.toolBar = new Xuld.TodoList.Controls.ToolBar();
            this.SuspendLayout();
            // 
            // tbTask
            // 
            this.tbTask.AcceptsReturn = true;
            this.tbTask.AcceptsTab = true;
            this.tbTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTask.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.tbTask.ForeColor = System.Drawing.Color.White;
            this.tbTask.HideSelection = false;
            this.tbTask.Location = new System.Drawing.Point(5, 66);
            this.tbTask.Multiline = true;
            this.tbTask.Name = "tbTask";
            this.tbTask.Size = new System.Drawing.Size(218, 219);
            this.tbTask.TabIndex = 0;
            this.tbTask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTask_KeyDown);
            this.tbTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTask_KeyUp);
            this.tbTask.Leave += new System.EventHandler(this.tbTask_Leave);
            // 
            // toolBar
            // 
            this.toolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolBar.Location = new System.Drawing.Point(4, 40);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowCurrent = false;
            this.toolBar.Size = new System.Drawing.Size(221, 21);
            this.toolBar.TabIndex = 6;
            this.toolBar.ActiveControlChanged += new System.EventHandler(this.toolBar_ActiveControlChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(227, 289);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.tbTask);
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Controls.SetChildIndex(this.tbTask, 0);
            this.Controls.SetChildIndex(this.toolBar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTask;
        private Controls.ToolBar toolBar;

    }
}

