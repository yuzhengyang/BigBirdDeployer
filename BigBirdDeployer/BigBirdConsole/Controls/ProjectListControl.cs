using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BigBird.Models.ProjectModels;

namespace BigBirdConsole.Controls
{
    public partial class ProjectListControl : UserControl
    {
        public ProjectListControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加或更新记录
        /// </summary>
        public void AddOrUpdate(ProjectStatusModel model)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    bool add = true;
                    //IP、Port、名称、版本、CPU、内存
                    if (DgvProjectList.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow item in DgvProjectList.Rows)
                        {
                            try
                            {
                                string _ip = item.Cells[ClmIP.Name].Value.ToString();
                                int _port = int.Parse(item.Cells[ClmPort.Name].Value.ToString());

                                if (_ip == model.IP && _port == model.Port)
                                {
                                    //item.Cells[ClmIP.Name].Value = model.IP;
                                    //item.Cells[ClmPort.Name].Value = model.Port;
                                    item.Cells[ClmName.Name].Value = model.Name;
                                    item.Cells[ClmVersion.Name].Value = model.CurrentVersion;
                                    item.Cells[ClmCPU.Name].Value = model.Cpu;
                                    item.Cells[ClmRam.Name].Value = model.UseRam;
                                    item.Cells[ClmStartTime.Name].Value = model.StartTime;
                                    item.Cells[ClmIsRun.Name].Value = model.IsRun;
                                    item.Cells[ClmTxTime.Name].Value = model.NowTime;
                                    add = false;
                                }
                            }
                            catch { }
                        }
                    }
                    if (add) DgvProjectList.Rows.Add(
                        model.IP, model.Port, model.Name, model.CurrentVersion,
                        model.Cpu, model.UseRam, model.StartTime, model.IsRun,
                         model.NowTime);
                }));
            }
            catch { }
        }
        public void Clear()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    DgvProjectList.Rows.Clear();
                }));
            }
            catch { }
        }
    }
}
