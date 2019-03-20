namespace BigBirdDeployer.Controls
{
    partial class ColorfulProgressControl
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
            this.PnMain = new System.Windows.Forms.Panel();
            this.PnProgress = new System.Windows.Forms.Panel();
            this.PnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnMain
            // 
            this.PnMain.BackColor = System.Drawing.Color.Silver;
            this.PnMain.Controls.Add(this.PnProgress);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnMain.Location = new System.Drawing.Point(0, 0);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(532, 103);
            this.PnMain.TabIndex = 0;
            // 
            // PnProgress
            // 
            this.PnProgress.BackColor = System.Drawing.Color.DimGray;
            this.PnProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnProgress.Location = new System.Drawing.Point(0, 0);
            this.PnProgress.Name = "PnProgress";
            this.PnProgress.Size = new System.Drawing.Size(0, 103);
            this.PnProgress.TabIndex = 0;
            // 
            // ColorfulProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnMain);
            this.Name = "ColorfulProgressControl";
            this.Size = new System.Drawing.Size(532, 103);
            this.PnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnMain;
        private System.Windows.Forms.Panel PnProgress;
    }
}
