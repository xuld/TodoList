namespace Xuld.TodoList.Controls {
    partial class Form : System.Windows.Forms.Form {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.pbResize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximizeRestore = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.toolTip = new Xuld.TodoList.Controls.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).BeginInit();
            this.SuspendLayout();
            // 
            // pbResize
            // 
            this.pbResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pbResize.Image = global::Xuld.TodoList.Properties.Resources.resize_l;
            this.pbResize.Location = new System.Drawing.Point(214, 276);
            this.pbResize.Name = "pbResize";
            this.pbResize.Size = new System.Drawing.Size(11, 11);
            this.pbResize.TabIndex = 5;
            this.pbResize.TabStop = false;
            this.pbResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbResize_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Xuld.TodoList.Properties.Resources.close_l;
            this.btnClose.Location = new System.Drawing.Point(189, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 28);
            this.btnClose.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnClose, "关闭");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximizeRestore
            // 
            this.btnMaximizeRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeRestore.FlatAppearance.BorderSize = 0;
            this.btnMaximizeRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizeRestore.Image = global::Xuld.TodoList.Properties.Resources.maximize_l;
            this.btnMaximizeRestore.Location = new System.Drawing.Point(153, 1);
            this.btnMaximizeRestore.Name = "btnMaximizeRestore";
            this.btnMaximizeRestore.Size = new System.Drawing.Size(37, 28);
            this.btnMaximizeRestore.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnMaximizeRestore, "最大化/还原");
            this.btnMaximizeRestore.UseVisualStyleBackColor = true;
            this.btnMaximizeRestore.Click += new System.EventHandler(this.btnMaximizeRestore_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Xuld.TodoList.Properties.Resources.minimize_l;
            this.btnMinimize.Location = new System.Drawing.Point(111, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(37, 28);
            this.btnMinimize.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnMinimize, "最小化");
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 2000;
            this.toolTip.BackColor = System.Drawing.Color.Black;
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.InitialDelay = 500;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(227, 289);
            this.Controls.Add(this.pbResize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMaximizeRestore);
            this.Controls.Add(this.btnMinimize);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "ToDoList";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private Controls.ToolTip toolTip;
        private System.Windows.Forms.Button btnMaximizeRestore;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox pbResize;

    }
}

