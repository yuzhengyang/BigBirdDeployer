namespace BigBirdConsole.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SsMain = new System.Windows.Forms.StatusStrip();
            this.TsslConnectCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsslWebCenterConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.MsMain = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpProjectStatus = new System.Windows.Forms.TabPage();
            this.projectListControl1 = new BigBirdConsole.Controls.ProjectListControl();
            this.TpSystemStatus = new System.Windows.Forms.TabPage();
            this.systemListControl1 = new BigBirdConsole.Controls.SystemListControl();
            this.TpTxLog = new System.Windows.Forms.TabPage();
            this.txConsoleControl1 = new BigBirdConsole.Controls.TxConsoleControl();
            this.TmMain = new System.Windows.Forms.Timer(this.components);
            this.SsMain.SuspendLayout();
            this.MsMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TpProjectStatus.SuspendLayout();
            this.TpSystemStatus.SuspendLayout();
            this.TpTxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // SsMain
            // 
            this.SsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsslConnectCount,
            this.toolStripStatusLabel1,
            this.TsslWebCenterConnect});
            this.SsMain.Location = new System.Drawing.Point(0, 411);
            this.SsMain.Name = "SsMain";
            this.SsMain.Size = new System.Drawing.Size(716, 22);
            this.SsMain.TabIndex = 0;
            this.SsMain.Text = "statusStrip1";
            // 
            // TsslConnectCount
            // 
            this.TsslConnectCount.Name = "TsslConnectCount";
            this.TsslConnectCount.Size = new System.Drawing.Size(56, 17);
            this.TsslConnectCount.Text = "暂无连接";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // TsslWebCenterConnect
            // 
            this.TsslWebCenterConnect.Name = "TsslWebCenterConnect";
            this.TsslWebCenterConnect.Size = new System.Drawing.Size(80, 17);
            this.TsslWebCenterConnect.Text = "未连接服务器";
            // 
            // MsMain
            // 
            this.MsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.报告ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.分析ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MsMain.Location = new System.Drawing.Point(0, 0);
            this.MsMain.Name = "MsMain";
            this.MsMain.Size = new System.Drawing.Size(716, 25);
            this.MsMain.TabIndex = 1;
            this.MsMain.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 报告ToolStripMenuItem
            // 
            this.报告ToolStripMenuItem.Name = "报告ToolStripMenuItem";
            this.报告ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.报告ToolStripMenuItem.Text = "报告";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.分析ToolStripMenuItem.Text = "分析";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TpProjectStatus);
            this.tabControl1.Controls.Add(this.TpSystemStatus);
            this.tabControl1.Controls.Add(this.TpTxLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 386);
            this.tabControl1.TabIndex = 2;
            // 
            // TpProjectStatus
            // 
            this.TpProjectStatus.Controls.Add(this.projectListControl1);
            this.TpProjectStatus.Location = new System.Drawing.Point(4, 22);
            this.TpProjectStatus.Name = "TpProjectStatus";
            this.TpProjectStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TpProjectStatus.Size = new System.Drawing.Size(708, 360);
            this.TpProjectStatus.TabIndex = 0;
            this.TpProjectStatus.Text = "项目列表";
            this.TpProjectStatus.UseVisualStyleBackColor = true;
            // 
            // projectListControl1
            // 
            this.projectListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectListControl1.Location = new System.Drawing.Point(3, 3);
            this.projectListControl1.Name = "projectListControl1";
            this.projectListControl1.Size = new System.Drawing.Size(702, 354);
            this.projectListControl1.TabIndex = 0;
            // 
            // TpSystemStatus
            // 
            this.TpSystemStatus.Controls.Add(this.systemListControl1);
            this.TpSystemStatus.Location = new System.Drawing.Point(4, 22);
            this.TpSystemStatus.Name = "TpSystemStatus";
            this.TpSystemStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TpSystemStatus.Size = new System.Drawing.Size(732, 337);
            this.TpSystemStatus.TabIndex = 1;
            this.TpSystemStatus.Text = "主机列表";
            this.TpSystemStatus.UseVisualStyleBackColor = true;
            // 
            // systemListControl1
            // 
            this.systemListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemListControl1.Location = new System.Drawing.Point(3, 3);
            this.systemListControl1.Name = "systemListControl1";
            this.systemListControl1.Size = new System.Drawing.Size(726, 331);
            this.systemListControl1.TabIndex = 0;
            // 
            // TpTxLog
            // 
            this.TpTxLog.Controls.Add(this.txConsoleControl1);
            this.TpTxLog.Location = new System.Drawing.Point(4, 22);
            this.TpTxLog.Name = "TpTxLog";
            this.TpTxLog.Padding = new System.Windows.Forms.Padding(3);
            this.TpTxLog.Size = new System.Drawing.Size(732, 337);
            this.TpTxLog.TabIndex = 2;
            this.TpTxLog.Text = "通信日志";
            this.TpTxLog.UseVisualStyleBackColor = true;
            // 
            // txConsoleControl1
            // 
            this.txConsoleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txConsoleControl1.Location = new System.Drawing.Point(3, 3);
            this.txConsoleControl1.Name = "txConsoleControl1";
            this.txConsoleControl1.Size = new System.Drawing.Size(726, 331);
            this.txConsoleControl1.TabIndex = 0;
            // 
            // TmMain
            // 
            this.TmMain.Enabled = true;
            this.TmMain.Interval = 2000;
            this.TmMain.Tick += new System.EventHandler(this.TmMain_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 433);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SsMain);
            this.Controls.Add(this.MsMain);
            this.MainMenuStrip = this.MsMain;
            this.Name = "MainForm";
            this.Text = "BigBird 控制台";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SsMain.ResumeLayout(false);
            this.SsMain.PerformLayout();
            this.MsMain.ResumeLayout(false);
            this.MsMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TpProjectStatus.ResumeLayout(false);
            this.TpSystemStatus.ResumeLayout(false);
            this.TpTxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SsMain;
        private System.Windows.Forms.MenuStrip MsMain;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpProjectStatus;
        private System.Windows.Forms.TabPage TpSystemStatus;
        private System.Windows.Forms.TabPage TpTxLog;
        private System.Windows.Forms.ToolStripStatusLabel TsslConnectCount;
        private System.Windows.Forms.Timer TmMain;
        public Controls.TxConsoleControl txConsoleControl1;
        public Controls.ProjectListControl projectListControl1;
        public Controls.SystemListControl systemListControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TsslWebCenterConnect;
    }
}