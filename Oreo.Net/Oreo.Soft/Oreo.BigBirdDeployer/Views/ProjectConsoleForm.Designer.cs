namespace Oreo.BigBirdDeployer.Views
{
    partial class ProjectConsoleForm
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
            this.BTClean = new System.Windows.Forms.Button();
            this.PNHead = new System.Windows.Forms.Panel();
            this.PNContainer = new System.Windows.Forms.Panel();
            this.RTBConsole = new System.Windows.Forms.RichTextBox();
            this.PNHead.SuspendLayout();
            this.PNContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTClean
            // 
            this.BTClean.Location = new System.Drawing.Point(10, 12);
            this.BTClean.Name = "BTClean";
            this.BTClean.Size = new System.Drawing.Size(75, 23);
            this.BTClean.TabIndex = 1;
            this.BTClean.Text = "清空";
            this.BTClean.UseVisualStyleBackColor = true;
            this.BTClean.Click += new System.EventHandler(this.BTClean_Click);
            // 
            // PNHead
            // 
            this.PNHead.Controls.Add(this.BTClean);
            this.PNHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNHead.Location = new System.Drawing.Point(0, 0);
            this.PNHead.Name = "PNHead";
            this.PNHead.Size = new System.Drawing.Size(556, 45);
            this.PNHead.TabIndex = 2;
            // 
            // PNContainer
            // 
            this.PNContainer.Controls.Add(this.RTBConsole);
            this.PNContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNContainer.Location = new System.Drawing.Point(0, 45);
            this.PNContainer.Name = "PNContainer";
            this.PNContainer.Padding = new System.Windows.Forms.Padding(10);
            this.PNContainer.Size = new System.Drawing.Size(556, 306);
            this.PNContainer.TabIndex = 3;
            // 
            // RTBConsole
            // 
            this.RTBConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTBConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBConsole.Location = new System.Drawing.Point(10, 10);
            this.RTBConsole.Name = "RTBConsole";
            this.RTBConsole.Size = new System.Drawing.Size(536, 286);
            this.RTBConsole.TabIndex = 1;
            this.RTBConsole.Text = "";
            // 
            // ProjectConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 351);
            this.Controls.Add(this.PNContainer);
            this.Controls.Add(this.PNHead);
            this.Name = "ProjectConsoleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectConsoleForm";
            this.PNHead.ResumeLayout(false);
            this.PNContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BTClean;
        private System.Windows.Forms.Panel PNHead;
        private System.Windows.Forms.Panel PNContainer;
        private System.Windows.Forms.RichTextBox RTBConsole;
    }
}