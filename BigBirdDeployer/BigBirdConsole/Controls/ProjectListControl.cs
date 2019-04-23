using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BigBird.Models.ProjectModels;
using Azylee.Core.DataUtils.DateTimeUtils;
using BigBirdConsole.Commons;

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
                                    item.Cells[ClmVersion.Name].Value = model.Version;
                                    item.Cells[ClmCPU.Name].Value = model.Cpu;
                                    item.Cells[ClmRam.Name].Value = model.Ram;
                                    item.Cells[ClmStartTime.Name].Value = model.StartTime;
                                    item.Cells[ClmIsRun.Name].Value = model.IsRun;
                                    item.Cells[ClmTxTime.Name].Value = model.CreateTime;
                                    item.Cells[ClmRefreshTime.Name].Value = DateTime.Now;
                                    add = false;
                                }
                            }
                            catch { }
                        }
                    }
                    if (add) DgvProjectList.Rows.Add(
                        model.Name, model.IP, model.Port, model.Version,
                        model.Cpu, model.Ram, model.IsRun, model.StartTime,
                         model.CreateTime, DateTime.Now);
                }));
            }
            catch { }
        }
        public void SetStyle()
        {
            if (!R.MainUI.Visible || DgvProjectList.Rows.Count == 0) return;
            try
            {
                Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow item in DgvProjectList.Rows)
                    {
                        if (DateTime.TryParse(item.Cells[ClmRefreshTime.Name].Value.ToString(), out DateTime dt))
                        {
                            long diff = TimeDiff.Sec(dt);
                            if (diff > -3)
                            {
                                item.DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                            else if (diff > -6)
                            {
                                item.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else if (diff > -9)
                            {
                                item.DefaultCellStyle.BackColor = Color.Pink;
                            }
                            else
                            {
                                item.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
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

        private void TmMain_Tick(object sender, EventArgs e)
        {
            SetStyle();
        }
    }
}
