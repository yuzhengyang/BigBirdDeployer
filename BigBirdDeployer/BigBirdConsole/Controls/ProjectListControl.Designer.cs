namespace BigBirdConsole.Controls
{
    partial class ProjectListControl
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
            this.DgvProjectList = new System.Windows.Forms.DataGridView();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIsRun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRefreshTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TmMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvProjectList
            // 
            this.DgvProjectList.AllowUserToAddRows = false;
            this.DgvProjectList.AllowUserToDeleteRows = false;
            this.DgvProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProjectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmName,
            this.ClmIP,
            this.ClmPort,
            this.ClmVersion,
            this.ClmCPU,
            this.ClmRam,
            this.ClmIsRun,
            this.ClmStartTime,
            this.ClmTxTime,
            this.ClmRefreshTime});
            this.DgvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProjectList.Location = new System.Drawing.Point(0, 0);
            this.DgvProjectList.Name = "DgvProjectList";
            this.DgvProjectList.ReadOnly = true;
            this.DgvProjectList.RowHeadersVisible = false;
            this.DgvProjectList.RowTemplate.Height = 23;
            this.DgvProjectList.Size = new System.Drawing.Size(774, 372);
            this.DgvProjectList.TabIndex = 2;
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
            this.ClmIP.HeaderText = "IP";
            this.ClmIP.Name = "ClmIP";
            this.ClmIP.ReadOnly = true;
            this.ClmIP.Width = 42;
            // 
            // ClmPort
            // 
            this.ClmPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmPort.HeaderText = "Port";
            this.ClmPort.Name = "ClmPort";
            this.ClmPort.ReadOnly = true;
            this.ClmPort.Width = 54;
            // 
            // ClmVersion
            // 
            this.ClmVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmVersion.HeaderText = "版本";
            this.ClmVersion.Name = "ClmVersion";
            this.ClmVersion.ReadOnly = true;
            this.ClmVersion.Width = 54;
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
            this.ClmRam.HeaderText = "内存";
            this.ClmRam.Name = "ClmRam";
            this.ClmRam.ReadOnly = true;
            this.ClmRam.Width = 54;
            // 
            // ClmIsRun
            // 
            this.ClmIsRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmIsRun.HeaderText = "运行";
            this.ClmIsRun.Name = "ClmIsRun";
            this.ClmIsRun.ReadOnly = true;
            this.ClmIsRun.Width = 54;
            // 
            // ClmStartTime
            // 
            this.ClmStartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmStartTime.HeaderText = "启动时间";
            this.ClmStartTime.Name = "ClmStartTime";
            this.ClmStartTime.ReadOnly = true;
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
            // ProjectListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgvProjectList);
            this.Name = "ProjectListControl";
            this.Size = new System.Drawing.Size(774, 372);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjectList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvProjectList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIsRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRefreshTime;
        private System.Windows.Forms.Timer TmMain;
    }
}
