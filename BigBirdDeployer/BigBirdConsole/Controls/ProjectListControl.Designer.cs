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
            this.DgvProjectList = new System.Windows.Forms.DataGridView();
            this.ClmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIsRun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvProjectList
            // 
            this.DgvProjectList.AllowUserToAddRows = false;
            this.DgvProjectList.AllowUserToDeleteRows = false;
            this.DgvProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProjectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmIP,
            this.ClmPort,
            this.ClmName,
            this.ClmVersion,
            this.ClmCPU,
            this.ClmRam,
            this.ClmStartTime,
            this.ClmIsRun,
            this.ClmTxTime});
            this.DgvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProjectList.Location = new System.Drawing.Point(0, 0);
            this.DgvProjectList.Name = "DgvProjectList";
            this.DgvProjectList.ReadOnly = true;
            this.DgvProjectList.RowHeadersVisible = false;
            this.DgvProjectList.RowTemplate.Height = 23;
            this.DgvProjectList.Size = new System.Drawing.Size(774, 372);
            this.DgvProjectList.TabIndex = 2;
            // 
            // ClmIP
            // 
            this.ClmIP.HeaderText = "IP";
            this.ClmIP.Name = "ClmIP";
            this.ClmIP.ReadOnly = true;
            // 
            // ClmPort
            // 
            this.ClmPort.HeaderText = "Port";
            this.ClmPort.Name = "ClmPort";
            this.ClmPort.ReadOnly = true;
            // 
            // ClmName
            // 
            this.ClmName.HeaderText = "名称";
            this.ClmName.Name = "ClmName";
            this.ClmName.ReadOnly = true;
            // 
            // ClmVersion
            // 
            this.ClmVersion.HeaderText = "版本";
            this.ClmVersion.Name = "ClmVersion";
            this.ClmVersion.ReadOnly = true;
            // 
            // ClmCPU
            // 
            this.ClmCPU.HeaderText = "CPU";
            this.ClmCPU.Name = "ClmCPU";
            this.ClmCPU.ReadOnly = true;
            // 
            // ClmRam
            // 
            this.ClmRam.HeaderText = "内存";
            this.ClmRam.Name = "ClmRam";
            this.ClmRam.ReadOnly = true;
            // 
            // ClmStartTime
            // 
            this.ClmStartTime.HeaderText = "启动时间";
            this.ClmStartTime.Name = "ClmStartTime";
            this.ClmStartTime.ReadOnly = true;
            // 
            // ClmIsRun
            // 
            this.ClmIsRun.HeaderText = "运行状态";
            this.ClmIsRun.Name = "ClmIsRun";
            this.ClmIsRun.ReadOnly = true;
            // 
            // ClmTxTime
            // 
            this.ClmTxTime.HeaderText = "通信时间";
            this.ClmTxTime.Name = "ClmTxTime";
            this.ClmTxTime.ReadOnly = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIsRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTxTime;
    }
}
