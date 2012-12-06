namespace Xuld.TodoList.Controls {
    partial class ConfirmButtons {
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
            this.btnDelay = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbDelay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnDelay
            // 
            this.btnDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelay.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelay.Location = new System.Drawing.Point(3, 14);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(49, 24);
            this.btnDelay.TabIndex = 14;
            this.btnDelay.Text = "推迟";
            this.btnDelay.UseVisualStyleBackColor = false;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfirm.Location = new System.Drawing.Point(133, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 25);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "不再提醒(&O)";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbDelay
            // 
            this.cbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDelay.ForeColor = System.Drawing.Color.Gainsboro;
            this.cbDelay.FormattingEnabled = true;
            this.cbDelay.ItemHeight = 17;
            this.cbDelay.Items.AddRange(new object[] {
            "5 分钟",
            "10 分钟",
            "15 分钟",
            "30 分钟",
            "1 小时",
            "2 小时"});
            this.cbDelay.Location = new System.Drawing.Point(58, 14);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(69, 25);
            this.cbDelay.TabIndex = 12;
            // 
            // ConfirmButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.btnDelay);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbDelay);
            this.Name = "ConfirmButtons";
            this.Size = new System.Drawing.Size(225, 53);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelay;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cbDelay;
    }
}
