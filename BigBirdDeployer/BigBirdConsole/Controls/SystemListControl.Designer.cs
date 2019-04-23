namespace BigBirdConsole.Controls
{
    partial class SystemListControl
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
            this.components = new System.ComponentModel.Container();
            this.DgvSystemList = new System.Windows.Forms.DataGridView();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFreeRam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAppCpu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAppRam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRefreshTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TmMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSystemList
            // 
            this.DgvSystemList.AllowUserToAddRows = false;
            this.DgvSystemList.AllowUserToDeleteRows = false;
            this.DgvSystemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSystemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmName,
            this.ClmIP,
            this.ClmCPU,
            this.ClmRam,
            this.ClmFreeRam,
            this.ClmAppCpu,
            this.ClmAppRam,
            this.ClmTxTime,
            this.ClmRefreshTime});
            this.DgvSystemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSystemList.Location = new System.Drawing.Point(0, 0);
            this.DgvSystemList.Name = "DgvSystemList";
            this.DgvSystemList.ReadOnly = true;
            this.DgvSystemList.RowHeadersVisible = false;
            this.DgvSystemList.RowTemplate.Height = 23;
            this.DgvSystemList.Size = new System.Drawing.Size(774, 340);
            this.DgvSystemList.TabIndex = 3;
            // 
            // ClmName
            // 
            this.ClmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmName.HeaderText = "名称";
            this.ClmName.Name = "ClmName";
            this.ClmName.ReadOnly = true;
            // 
            // ClmIP
            // 
            this.ClmIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmIP.HeaderText = "IP地址";
            this.ClmIP.Name = "ClmIP";
            this.ClmIP.ReadOnly = true;
            this.ClmIP.Width = 66;
            // 
            // ClmCPU
            // 
            this.ClmCPU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmCPU.HeaderText = "CPU";
            this.ClmCPU.Name = "ClmCPU";
            this.ClmCPU.ReadOnly = true;
            this.ClmCPU.Width = 48;
            // 
            // ClmRam
            // 
            this.ClmRam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmRam.HeaderText = "RAM";
            this.ClmRam.Name = "ClmRam";
            this.ClmRam.ReadOnly = true;
            this.ClmRam.Width = 48;
            // 
            // ClmFreeRam
            // 
            this.ClmFreeRam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmFreeRam.HeaderText = "空闲RAM";
            this.ClmFreeRam.Name = "ClmFreeRam";
            this.ClmFreeRam.ReadOnly = true;
            this.ClmFreeRam.Width = 72;
            // 
            // ClmAppCpu
            // 
            this.ClmAppCpu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmAppCpu.HeaderText = "APP CPU";
            this.ClmAppCpu.Name = "ClmAppCpu";
            this.ClmAppCpu.ReadOnly = true;
            this.ClmAppCpu.Width = 72;
            // 
            // ClmAppRam
            // 
            this.ClmAppRam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmAppRam.HeaderText = "APP RAM";
            this.ClmAppRam.Name = "ClmAppRam";
            this.ClmAppRam.ReadOnly = true;
            this.ClmAppRam.Width = 72;
            // 
            // ClmTxTime
            // 
            this.ClmTxTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmTxTime.HeaderText = "通信时间";
            this.ClmTxTime.Name = "ClmTxTime";
            this.ClmTxTime.ReadOnly = true;
            // 
            // ClmRefreshTime
            // 
            this.ClmRefreshTime.HeaderText = "刷新时间";
            this.ClmRefreshTime.Name = "ClmRefreshTime";
            this.ClmRefreshTime.ReadOnly = true;
            this.ClmRefreshTime.Visible = false;
            // 
            // TmMain
            // 
            this.TmMain.Enabled = true;
            this.TmMain.Interval = 3000;
            this.TmMain.Tick += new System.EventHandler(this.TmMain_Tick);
            // 
            // SystemListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgvSystemList);
            this.Name = "SystemListControl";
            this.Size = new System.Drawing.Size(774, 340);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvSystemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFreeRam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAppCpu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAppRam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRefreshTime;
        private System.Windows.Forms.Timer TmMain;
    }
}
