namespace BigBirdConsole.Controls
{
    partial class TxConsoleControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RtbTxLog = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBTextLength = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 22);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RtbTxLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 292);
            this.panel2.TabIndex = 1;
            // 
            // RtbTxLog
            // 
            this.RtbTxLog.BackColor = System.Drawing.Color.Gainsboro;
            this.RtbTxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtbTxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbTxLog.Location = new System.Drawing.Point(0, 0);
            this.RtbTxLog.Name = "RtbTxLog";
            this.RtbTxLog.Size = new System.Drawing.Size(538, 292);
            this.RtbTxLog.TabIndex = 0;
            this.RtbTxLog.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LBTextLength);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 18);
            this.panel3.TabIndex = 1;
            // 
            // LBTextLength
            // 
            this.LBTextLength.AutoSize = true;
            this.LBTextLength.Dock = System.Windows.Forms.DockStyle.Right;
            this.LBTextLength.Location = new System.Drawing.Point(467, 0);
            this.LBTextLength.Name = "LBTextLength";
            this.LBTextLength.Size = new System.Drawing.Size(71, 12);
            this.LBTextLength.TabIndex = 0;
            this.LBTextLength.Text = "1000 / 1000";
            // 
            // TxConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "TxConsoleControl";
            this.Size = new System.Drawing.Size(538, 332);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox RtbTxLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBTextLength;
    }
}
