using Azylee.Core.DataUtils.StringUtils;
using BigBird.Models.ProjectModels;
using BigBirdDeployer.Parts;
using System;
using System.Windows.Forms;

namespace BigBirdDeployer.Views
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
            TBParameter.Text = Project.Parameter;
            CBAutoStart.Checked = Project.AutoStart;
        }
        private void LBParameter_Click(object sender, EventArgs e)
        {
            if (!Str.Ok(TBParameter.Text))
            {
                TBParameter.Text = LBParameter.Text;
            }
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
                string param = TBParameter.Text.Trim();
                bool auto_start = CBAutoStart.Checked;

                if (!string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(folder) &&
                    !string.IsNullOrWhiteSpace(jar))
                {
                    Project.Name = name;
                    Project.Folder = folder;
                    Project.JarFile = jar;
                    Project.Port = port;
                    Project.VersionCache = cache;
                    Project.AutoStart = auto_start;
                    Project.LastVersion = Project.LastVersion;
                    Project.CurrentVersion = Project.CurrentVersion;
                    Project.Parameter = param;
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
