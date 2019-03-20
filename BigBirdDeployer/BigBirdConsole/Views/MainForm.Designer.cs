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
            this.MsMain = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpServerStatus = new System.Windows.Forms.TabPage();
            this.DgvProjectList = new System.Windows.Forms.DataGridView();
            this.TpComputerStatus = new System.Windows.Forms.TabPage();
            this.TpTxLog = new System.Windows.Forms.TabPage();
            this.RtbTxLog = new System.Windows.Forms.RichTextBox();
            this.TmMain = new System.Windows.Forms.Timer(this.components);
            this.DgvSystemList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SsMain.SuspendLayout();
            this.MsMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TpServerStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjectList)).BeginInit();
            this.TpComputerStatus.SuspendLayout();
            this.TpTxLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemList)).BeginInit();
            this.SuspendLayout();
            // 
            // SsMain
            // 
            this.SsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsslConnectCount});
            this.SsMain.Location = new System.Drawing.Point(0, 392);
            this.SsMain.Name = "SsMain";
            this.SsMain.Size = new System.Drawing.Size(726, 22);
            this.SsMain.TabIndex = 0;
            this.SsMain.Text = "statusStrip1";
            // 
            // TsslConnectCount
            // 
            this.TsslConnectCount.Name = "TsslConnectCount";
            this.TsslConnectCount.Size = new System.Drawing.Size(56, 17);
            this.TsslConnectCount.Text = "暂无连接";
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
            this.MsMain.Size = new System.Drawing.Size(726, 25);
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
            this.tabControl1.Controls.Add(this.TpServerStatus);
            this.tabControl1.Controls.Add(this.TpComputerStatus);
            this.tabControl1.Controls.Add(this.TpTxLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(726, 367);
            this.tabControl1.TabIndex = 2;
            // 
            // TpServerStatus
            // 
            this.TpServerStatus.Controls.Add(this.DgvProjectList);
            this.TpServerStatus.Location = new System.Drawing.Point(4, 22);
            this.TpServerStatus.Name = "TpServerStatus";
            this.TpServerStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TpServerStatus.Size = new System.Drawing.Size(718, 341);
            this.TpServerStatus.TabIndex = 0;
            this.TpServerStatus.Text = "tabPage1";
            this.TpServerStatus.UseVisualStyleBackColor = true;
            // 
            // DgvProjectList
            // 
            this.DgvProjectList.AllowUserToDeleteRows = false;
            this.DgvProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProjectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column6});
            this.DgvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProjectList.Location = new System.Drawing.Point(3, 3);
            this.DgvProjectList.Name = "DgvProjectList";
            this.DgvProjectList.ReadOnly = true;
            this.DgvProjectList.RowHeadersVisible = false;
            this.DgvProjectList.RowTemplate.Height = 23;
            this.DgvProjectList.Size = new System.Drawing.Size(712, 335);
            this.DgvProjectList.TabIndex = 1;
            // 
            // TpComputerStatus
            // 
            this.TpComputerStatus.Controls.Add(this.DgvSystemList);
            this.TpComputerStatus.Location = new System.Drawing.Point(4, 22);
            this.TpComputerStatus.Name = "TpComputerStatus";
            this.TpComputerStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TpComputerStatus.Size = new System.Drawing.Size(718, 341);
            this.TpComputerStatus.TabIndex = 1;
            this.TpComputerStatus.Text = "tabPage2";
            this.TpComputerStatus.UseVisualStyleBackColor = true;
            // 
            // TpTxLog
            // 
            this.TpTxLog.Controls.Add(this.RtbTxLog);
            this.TpTxLog.Location = new System.Drawing.Point(4, 22);
            this.TpTxLog.Name = "TpTxLog";
            this.TpTxLog.Padding = new System.Windows.Forms.Padding(3);
            this.TpTxLog.Size = new System.Drawing.Size(718, 341);
            this.TpTxLog.TabIndex = 2;
            this.TpTxLog.Text = "tabPage3";
            this.TpTxLog.UseVisualStyleBackColor = true;
            // 
            // RtbTxLog
            // 
            this.RtbTxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtbTxLog.Location = new System.Drawing.Point(98, 50);
            this.RtbTxLog.Name = "RtbTxLog";
            this.RtbTxLog.Size = new System.Drawing.Size(502, 228);
            this.RtbTxLog.TabIndex = 2;
            this.RtbTxLog.Text = "";
            // 
            // TmMain
            // 
            this.TmMain.Enabled = true;
            this.TmMain.Interval = 2000;
            this.TmMain.Tick += new System.EventHandler(this.TmMain_Tick);
            // 
            // DgvSystemList
            // 
            this.DgvSystemList.AllowUserToDeleteRows = false;
            this.DgvSystemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSystemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column7});
            this.DgvSystemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSystemList.Location = new System.Drawing.Point(3, 3);
            this.DgvSystemList.Name = "DgvSystemList";
            this.DgvSystemList.ReadOnly = true;
            this.DgvSystemList.RowHeadersVisible = false;
            this.DgvSystemList.RowTemplate.Height = 23;
            this.DgvSystemList.Size = new System.Drawing.Size(712, 335);
            this.DgvSystemList.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "IP地址";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CPU";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "RAM";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "空闲RAM";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "APP CPU";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "APP RAM";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "IP";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Port";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "版本";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "CPU";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "内存";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 414);
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
            this.TpServerStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjectList)).EndInit();
            this.TpComputerStatus.ResumeLayout(false);
            this.TpTxLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemList)).EndInit();
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
        private System.Windows.Forms.TabPage TpServerStatus;
        private System.Windows.Forms.DataGridView DgvProjectList;
        private System.Windows.Forms.TabPage TpComputerStatus;
        private System.Windows.Forms.TabPage TpTxLog;
        private System.Windows.Forms.RichTextBox RtbTxLog;
        private System.Windows.Forms.ToolStripStatusLabel TsslConnectCount;
        private System.Windows.Forms.Timer TmMain;
        private System.Windows.Forms.DataGridView DgvSystemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}