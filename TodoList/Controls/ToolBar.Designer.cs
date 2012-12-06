namespace Xuld.TodoList.Controls {
    partial class ToolBar {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.lbToDo = new System.Windows.Forms.Label();
            this.lbDone = new System.Windows.Forms.Label();
            this.lbTimer = new System.Windows.Forms.Label();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbToDo
            // 
            this.lbToDo.AutoSize = true;
            this.lbToDo.ForeColor = System.Drawing.Color.White;
            this.lbToDo.Location = new System.Drawing.Point(3, 0);
            this.lbToDo.Size = new System.Drawing.Size(41, 12);
            this.lbToDo.TabIndex = 0;
            this.lbToDo.Text = Xuld.TodoList.AppManager.Todo;
            // 
            // lbDone
            // 
            this.lbDone.AutoSize = true;
            this.lbDone.ForeColor = System.Drawing.Color.White;
            this.lbDone.Location = new System.Drawing.Point(51, 0);
            this.lbDone.Size = new System.Drawing.Size(41, 12);
            this.lbDone.TabIndex = 0;
            this.lbDone.Text = Xuld.TodoList.AppManager.Done;
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.ForeColor = System.Drawing.Color.White;
            this.lbTimer.Location = new System.Drawing.Point(100, 0);
            this.lbTimer.Size = new System.Drawing.Size(41, 12);
            this.lbTimer.TabIndex = 0;
            this.lbTimer.Text = Xuld.TodoList.AppManager.Plan;
            // 
            // lbCurrent
            // 
            this.lbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.ForeColor = System.Drawing.Color.White;
            this.lbCurrent.Location = new System.Drawing.Point(221, 0);
            this.lbCurrent.Size = new System.Drawing.Size(41, 12);
            this.lbCurrent.TabIndex = 0;
            this.lbCurrent.Text = Xuld.TodoList.AppManager.Now;
            this.lbCurrent.Visible = false;
            // 
            // ToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.lbCurrent);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.lbDone);
            this.Controls.Add(this.lbToDo);
            this.Name = "ToolBar";
            this.Size = new System.Drawing.Size(268, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbToDo;
        private System.Windows.Forms.Label lbDone;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbCurrent;
    }
}
