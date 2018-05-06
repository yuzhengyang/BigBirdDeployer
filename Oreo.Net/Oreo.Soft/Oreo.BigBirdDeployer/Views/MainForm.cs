using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.WinformSkin.FormUI.CustomTitle;
using Azylee.WinformSkin.FormUI.Toast;
using Oreo.BigBirdDeployer.Commons;
using Oreo.BigBirdDeployer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class MainForm : BigIconForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TBPublishStorage.Text = R.Paths.PublishStorage == R.Paths.DefaultPublishStorage ? "" : R.Paths.PublishStorage;
            TBNewStorage.Text = R.Paths.NewStorage == R.Paths.DefaultNewStorage ? "" : R.Paths.NewStorage;
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #region 方法
        private bool SaveSettings()
        {
            bool flag = false;
            if (!string.IsNullOrWhiteSpace(TBPublishStorage.Text))
            {
                if (Directory.Exists(TBPublishStorage.Text))
                {
                    R.Paths.PublishStorage = TBPublishStorage.Text;
                    IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "发布资料库目录不存在";
                }
            }
            else
            {
                R.Paths.PublishStorage = R.Paths.DefaultPublishStorage;
                IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                flag = true;
            }

            if (!string.IsNullOrWhiteSpace(TBNewStorage.Text))
            {
                if (Directory.Exists(TBNewStorage.Text))
                {
                    R.Paths.NewStorage = TBNewStorage.Text;
                    IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "新增资料库目录不存在";
                }
            }
            else
            {
                R.Paths.NewStorage = R.Paths.DefaultNewStorage;
                IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                flag = true;
            }
            return flag;
        }
        #endregion

        private void BTOpenNewStorage_Click(object sender, EventArgs e)
        {
            ExplorerAPI.Open(R.Paths.NewStorage);
            ToastForm.Display("正在打开", $"正在打开添加新工程的仓库文件夹，请稍候...", 'i', 5000);
        }
    }
}
