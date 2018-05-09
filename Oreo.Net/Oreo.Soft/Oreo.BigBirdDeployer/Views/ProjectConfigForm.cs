using Oreo.BigBirdDeployer.Models;
using Oreo.BigBirdDeployer.Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class ProjectConfigForm : Form
    {
        public ProjectItemPart ProjectItem { get; set; }
        private ProjectModel Project { get; set; }
        public ProjectConfigForm(ProjectItemPart item, ProjectModel project)
        {
            InitializeComponent();
            Project = project;
            ProjectItem = item;
        }
        private void ProjectConfigForm_Load(object sender, EventArgs e)
        {
            TBName.Text = Project.Name;
            TBFolder.Text = Project.Folder;
            TBJarFile.Text = Project.JarFile;
            TBPort.Text = Project.Port.ToString();
            TBVersionCache.Text = Project.VersionCache.ToString();
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            if (Save()) Close();
        }

        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region 方法函数
        public bool Save()
        {
            try
            {
                string name = TBName.Text;
                string folder = TBFolder.Text;
                string jar = TBJarFile.Text;
                int port = int.Parse(TBPort.Text);
                int cache = int.Parse(TBVersionCache.Text);

                if (!string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(folder) &&
                    !string.IsNullOrWhiteSpace(jar))
                {
                    Project.Name = name;
                    Project.Folder = folder;
                    Project.JarFile = jar;
                    Project.Port = port;
                    Project.VersionCache = cache;
                    Project.LastVersion = Project.LastVersion;
                    Project.CurrentVersion = Project.CurrentVersion;
                    ProjectItem.SetProject(Project);
                    LBDesc.Text = "保存成功并更新到管理面板";
                    return true;
                }
            }
            catch { LBDesc.Text = "配置填写有误，请检查修改"; }
            return false;
        }
        #endregion


    }
}
