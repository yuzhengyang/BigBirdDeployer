using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BigBird.Models.SystemModels;

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
                                    item.Cells[ClmFreeRam.Name].Value = model.FreeRam;
                                    item.Cells[ClmAppCpu.Name].Value = model.AppCpu;
                                    item.Cells[ClmAppRam.Name].Value = model.AppUseRam;
                                    item.Cells[ClmTxTime.Name].Value = model.NowTime;
                                    add = false;
                                }
                            }
                            catch { }
                        }
                    }
                    if (add) DgvSystemList.Rows.Add(
                        model.Name, model.IP, model.Cpu, model.Ram,
                        model.FreeRam, model.AppCpu, model.AppUseRam, model.NowTime);
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
    }
}
