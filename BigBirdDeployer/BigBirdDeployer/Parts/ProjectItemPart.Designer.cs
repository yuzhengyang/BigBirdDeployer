namespace BigBirdDeployer.Parts
{
    partial class ProjectItemPart
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
            this.BTStartOrStop = new System.Windows.Forms.Button();
            this.LBProjectName = new System.Windows.Forms.Label();
            this.LBStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBRam = new System.Windows.Forms.Label();
            this.LBPort = new System.Windows.Forms.Label();
            this.BTAddNew = new System.Windows.Forms.Button();
            this.CBVersion = new System.Windows.Forms.ComboBox();
            this.TTInfo = new System.Windows.Forms.ToolTip(this.components);
            this.CpCpuRate = new BigBirdDeployer.Controls.ColorfulProgressControl();
            this.LBCpu = new System.Windows.Forms.Label();
            this.CmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.输出窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.工程配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.浏览运行目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浏览装载目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.过程日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.CmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTStartOrStop
            // 
            this.BTStartOrStop.BackColor = System.Drawing.Color.White;
            this.BTStartOrStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTStartOrStop.Location = new System.Drawing.Point(266, 8);
            this.BTStartOrStop.Name = "BTStartOrStop";
            this.BTStartOrStop.Size = new System.Drawing.Size(47, 28);
            this.BTStartOrStop.TabIndex = 0;
            this.BTStartOrStop.Text = "启动";
            this.BTStartOrStop.UseVisualStyleBackColor = false;
            this.BTStartOrStop.Click += new System.EventHandler(this.BTStartOrStop_Click);
            // 
            // LBProjectName
            // 
            this.LBProjectName.BackColor = System.Drawing.Color.Gray;
            this.LBProjectName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LBProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBProjectName.ForeColor = System.Drawing.Color.White;
            this.LBProjectName.Location = new System.Drawing.Point(0, 0);
            this.LBProjectName.Name = "LBProjectName";
            this.LBProjectName.Size = new System.Drawing.Size(181, 28);
            this.LBProjectName.TabIndex = 2;
            this.LBProjectName.Text = "点击此处配置工程";
            this.LBProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBProjectName.Click += new System.EventHandler(this.LBProjectName_Click);
            // 
            // LBStatus
            // 
            this.LBStatus.BackColor = System.Drawing.Color.Black;
            this.LBStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.LBStatus.ForeColor = System.Drawing.Color.White;
            this.LBStatus.Location = new System.Drawing.Point(181, 0);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(67, 28);
            this.LBStatus.TabIndex = 3;
            this.LBStatus.Text = "状态显示";
            this.LBStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBProjectName);
            this.panel1.Controls.Add(this.LBStatus);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 28);
            this.panel1.TabIndex = 4;
            // 
            // LBRam
            // 
            this.LBRam.AutoSize = true;
            this.LBRam.ForeColor = System.Drawing.Color.White;
            this.LBRam.Location = new System.Drawing.Point(193, 90);
            this.LBRam.Name = "LBRam";
            this.LBRam.Size = new System.Drawing.Size(71, 12);
            this.LBRam.TabIndex = 9;
            this.LBRam.Text = "内存：99 MB";
            // 
            // LBPort
            // 
            this.LBPort.AutoSize = true;
            this.LBPort.ForeColor = System.Drawing.Color.White;
            this.LBPort.Location = new System.Drawing.Point(12, 90);
            this.LBPort.Name = "LBPort";
            this.LBPort.Size = new System.Drawing.Size(71, 12);
            this.LBPort.TabIndex = 11;
            this.LBPort.Text = "端口：10000";
            // 
            // BTAddNew
            // 
            this.BTAddNew.BackColor = System.Drawing.Color.White;
            this.BTAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTAddNew.Location = new System.Drawing.Point(266, 50);
            this.BTAddNew.Name = "BTAddNew";
            this.BTAddNew.Size = new System.Drawing.Size(47, 23);
            this.BTAddNew.TabIndex = 12;
            this.BTAddNew.Text = "装载";
            this.BTAddNew.UseVisualStyleBackColor = false;
            this.BTAddNew.Click += new System.EventHandler(this.BTAddNew_Click);
            // 
            // CBVersion
            // 
            this.CBVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBVersion.FormattingEnabled = true;
            this.CBVersion.Location = new System.Drawing.Point(12, 51);
            this.CBVersion.Name = "CBVersion";
            this.CBVersion.Size = new System.Drawing.Size(248, 20);
            this.CBVersion.TabIndex = 14;
            this.CBVersion.SelectedIndexChanged += new System.EventHandler(this.CBVersion_SelectedIndexChanged);
            // 
            // CpCpuRate
            // 
            this.CpCpuRate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CpCpuRate.Location = new System.Drawing.Point(0, 120);
            this.CpCpuRate.Name = "CpCpuRate";
            this.CpCpuRate.Size = new System.Drawing.Size(325, 3);
            this.CpCpuRate.TabIndex = 16;
            // 
            // LBCpu
            // 
            this.LBCpu.AutoSize = true;
            this.LBCpu.ForeColor = System.Drawing.Color.White;
            this.LBCpu.Location = new System.Drawing.Point(105, 90);
            this.LBCpu.Name = "LBCpu";
            this.LBCpu.Size = new System.Drawing.Size(59, 12);
            this.LBCpu.TabIndex = 8;
            this.LBCpu.Text = "CPU：10 %";
            // 
            // CmsMain
            // 
            this.CmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输出窗口ToolStripMenuItem,
            this.toolStripSeparator1,
            this.工程配置ToolStripMenuItem,
            this.toolStripSeparator2,
            this.浏览运行目录ToolStripMenuItem,
            this.浏览装载目录ToolStripMenuItem,
            this.toolStripSeparator3,
            this.过程日志ToolStripMenuItem});
            this.CmsMain.Name = "CmsMain";
            this.CmsMain.ShowImageMargin = false;
            this.CmsMain.Size = new System.Drawing.Size(124, 132);
            // 
            // 输出窗口ToolStripMenuItem
            // 
            this.输出窗口ToolStripMenuItem.Name = "输出窗口ToolStripMenuItem";
            this.输出窗口ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.输出窗口ToolStripMenuItem.Text = "输出窗口";
            this.输出窗口ToolStripMenuItem.Click += new System.EventHandler(this.输出窗口ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // 工程配置ToolStripMenuItem
            // 
            this.工程配置ToolStripMenuItem.Name = "工程配置ToolStripMenuItem";
            this.工程配置ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.工程配置ToolStripMenuItem.Text = "工程配置";
            this.工程配置ToolStripMenuItem.Click += new System.EventHandler(this.工程配置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // 浏览运行目录ToolStripMenuItem
            // 
            this.浏览运行目录ToolStripMenuItem.Name = "浏览运行目录ToolStripMenuItem";
            this.浏览运行目录ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.浏览运行目录ToolStripMenuItem.Text = "浏览运行目录";
            this.浏览运行目录ToolStripMenuItem.Click += new System.EventHandler(this.浏览运行目录ToolStripMenuItem_Click);
            // 
            // 浏览装载目录ToolStripMenuItem
            // 
            this.浏览装载目录ToolStripMenuItem.Name = "浏览装载目录ToolStripMenuItem";
            this.浏览装载目录ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.浏览装载目录ToolStripMenuItem.Text = "浏览装载目录";
            this.浏览装载目录ToolStripMenuItem.Click += new System.EventHandler(this.浏览装载目录ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
            // 
            // 过程日志ToolStripMenuItem
            // 
            this.过程日志ToolStripMenuItem.Name = "过程日志ToolStripMenuItem";
            this.过程日志ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.过程日志ToolStripMenuItem.Text = "过程日志";
            this.过程日志ToolStripMenuItem.Click += new System.EventHandler(this.过程日志ToolStripMenuItem_Click);
            // 
            // ProjectItemPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ContextMenuStrip = this.CmsMain;
            this.Controls.Add(this.CpCpuRate);
            this.Controls.Add(this.CBVersion);
            this.Controls.Add(this.BTAddNew);
            this.Controls.Add(this.LBPort);
            this.Controls.Add(this.LBRam);
            this.Controls.Add(this.LBCpu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTStartOrStop);
            this.Name = "ProjectItemPart";
            this.Size = new System.Drawing.Size(325, 123);
            this.Load += new System.EventHandler(this.ProjectItemPart_Load);
            this.panel1.ResumeLayout(false);
            this.CmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStartOrStop;
        private System.Windows.Forms.Label LBProjectName;
        private System.Windows.Forms.Label LBStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBRam;
        private System.Windows.Forms.Label LBPort;
        private System.Windows.Forms.Button BTAddNew;
        private System.Windows.Forms.ComboBox CBVersion;
        private System.Windows.Forms.ToolTip TTInfo;
        private Controls.ColorfulProgressControl CpCpuRate;
        private System.Windows.Forms.Label LBCpu;
        private System.Windows.Forms.ContextMenuStrip CmsMain;
        private System.Windows.Forms.ToolStripMenuItem 输出窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工程配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 过程日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 浏览运行目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 浏览装载目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
