using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BigBird.Models.SystemModels;
using Azylee.Core.DataUtils.DateTimeUtils;
using BigBirdConsole.Commons;

namespace BigBirdConsole.Controls
{
    public partial class SystemListControl : UserControl
    {
        public SystemListControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加或更新记录
        /// </summary>
        public void AddOrUpdate(SystemStatusModel model)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    bool add = true;
                    //名称、IP、CPU、RAM、空闲RAM、APPCPU、APPRAM
                    if (DgvSystemList.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow item in DgvSystemList.Rows)
                        {
                            try
                            {
                                string _ip = item.Cells[ClmIP.Name].Value.ToString();

                                if (_ip == model.IP)
                                {
                                    item.Cells[ClmName.Name].Value = model.Name;
                                    //item.Cells[ClmIP.Name].Value = model.IP;
                                    item.Cells[ClmCPU.Name].Value = model.Cpu;
                                    item.Cells[ClmRam.Name].Value = model.Ram;
                                    item.Cells[ClmFreeRam.Name].Value = model.RamAvail;
                                    item.Cells[ClmAppCpu.Name].Value = model.AppCpu;
                                    item.Cells[ClmAppRam.Name].Value = model.AppRam;
                                    item.Cells[ClmTxTime.Name].Value = model.CreateTime;
                                    item.Cells[ClmRefreshTime.Name].Value = DateTime.Now;
                                    add = false;
                                }
                            }
                            catch { }
                        }
                    }
                    if (add) DgvSystemList.Rows.Add(
                        model.Name, model.IP, model.Cpu, model.Ram,
                        model.RamAvail, model.AppCpu, model.AppRam, model.CreateTime, DateTime.Now);
                }));
            }
            catch { }
        }
        public void SetStyle()
        {
            if (!R.MainUI.Visible || DgvSystemList.Rows.Count == 0) return;
            try
            {
                Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow item in DgvSystemList.Rows)
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
                    DgvSystemList.Rows.Clear();
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
